using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;
using Momo.PlayerInformation;
using Momo.MonsterManagerScene.Panel;
using System;
using Momo.Delegates;

namespace Momo.MonsterManagerScene
{
    public class BabyFeet : MonoBehaviour
    {
        #region Singleton
        public static BabyFeet Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event StringEvent LoadSelectedBabyMonster;
        public event FruitAmountEvent CreateInventoryItemFruit;
        public event NameAmountEvent UpdateInventoryItemFruit;
        public event IntEvent SelectFruitSpot;
        public event IntEvent DeselectFruitSpot;
        public event Action MakeFruitSpotsSelectable;
        public event FruitSpotEvent ChangeFruitInFruitSpotTo;
        public event StringEvent NewCalculatedElement;

        private string babyMonsterName;
        private BabyMonster babyMonster;
        private int selectedFruitSpot;
        private Fruit[] fruitsInFruitSpots;
        private Element resultingElement;

        public void OpenOverlay(string babyMonsterName)
        {
            this.babyMonsterName = babyMonsterName;
            babyMonster = AllScriptableObjects.GetAllBabyMonster().Find(babyMonster => babyMonster.Name == babyMonsterName);
            
            selectedFruitSpot = -1;
            fruitsInFruitSpots = new Fruit[3] { null, null, null };

            GetComponent<UIDocument>().enabled = true;
            GetComponent<BabyFeetPanel>().enabled = true;
        }
        public void LoadContent()
        {
            LoadSelectedBabyMonster?.Invoke(babyMonsterName);
            MakeFruitSpotsSelectable?.Invoke();

            CreateInventoryItemsFruits();
        }
        private void CreateInventoryItemsFruits()
        {
            Dictionary<Fruit, int> fruitsInInventory = Player.Instance.Inventory.getFruitsInPosession();

            foreach (KeyValuePair<Fruit, int> fruit in fruitsInInventory)
                if (fruit.Value > 0) CreateInventoryItemFruit?.Invoke(fruit.Key, fruit.Value);
        }
        public void OnFruitSpotClicked(int fruitSpotArrayIndex)
        {
            if (IsAFruitSpotSelected()) ChangeSelectedFruitSpotToIndex(fruitSpotArrayIndex);
            else SelectFruitSpotWithIndex(fruitSpotArrayIndex);
        }
        private bool IsAFruitSpotSelected()
        {
            if (selectedFruitSpot == -1) return false;
            return true;
        }
        private void ChangeSelectedFruitSpotToIndex(int fruitSpotArrayIndex)
        {
            DeselectFruitSpot?.Invoke(selectedFruitSpot);
            if (selectedFruitSpot != fruitSpotArrayIndex) SelectFruitSpotWithIndex(fruitSpotArrayIndex);
            else selectedFruitSpot = -1;
        }
        private void SelectFruitSpotWithIndex(int fruitSpotArrayIndex)
        {
            SelectFruitSpot?.Invoke(fruitSpotArrayIndex);
            selectedFruitSpot = fruitSpotArrayIndex;
        }
        public void OnFruitInventoryItemClicked(string fruitName)
        {
            Fruit fruit = AllScriptableObjects.GetAllFruits().Find(fruit => fruit.Name == fruitName);

            if (CalculateRemainingAmounfOfFruitInInventory(fruit) < 1) return;

            if (IsAFruitSpotSelected()) PutFruitInFruitSpot(selectedFruitSpot, fruit);
            else AddFruitToFirstEmptyFruitSpot(fruit);
        }
        private void PutFruitInFruitSpot(int fruitSpotArrayIndex, Fruit fruit)
        {
            Fruit oldFruitInSpot = fruitsInFruitSpots[fruitSpotArrayIndex];
            fruitsInFruitSpots[fruitSpotArrayIndex] = fruit;

            string[] elements = new string[3];
            for(int index = 0; index < 3; index++)
                if (Player.Instance.Discovered[fruit.Elements[index]]) elements[index] = fruit.Elements[index].Name;
                else elements[index] = "???";

            ChangeFruitInFruitSpotTo?.Invoke(fruitSpotArrayIndex, fruit, elements);

            UpdateAmountOfFruitInventoryItem(fruit);
            if(oldFruitInSpot != null) UpdateAmountOfFruitInventoryItem(oldFruitInSpot);

            CalculateResultingElement();
        }
        private void AddFruitToFirstEmptyFruitSpot(Fruit fruit)
        {
            for (int index = 0; index < 3; index++)
                if (fruitsInFruitSpots[index] == null)
                {
                    PutFruitInFruitSpot(index, fruit);
                    return;
                }
        }
        private void UpdateAmountOfFruitInventoryItem(Fruit fruit)
        {
            UpdateInventoryItemFruit?.Invoke(fruit.Name, CalculateRemainingAmounfOfFruitInInventory(fruit));
        }
        private int CalculateRemainingAmounfOfFruitInInventory(Fruit fruit)
        {
            int remainingFruitAmountinInventory = Player.Instance.Inventory.getFruitsInPosession()[fruit];

            for (int index = 0; index < 3; index++)
                if (fruitsInFruitSpots[index] == fruit) remainingFruitAmountinInventory--;

            return remainingFruitAmountinInventory;
        }
        private void CalculateResultingElement()
        {
            int primeIDMultiplication = 1;
            for (int index = 0; index < 3; index++)
            {
                if (fruitsInFruitSpots[index] == null) return;
                primeIDMultiplication *= fruitsInFruitSpots[index].PrimeID;
            }

            List<Element> allElements = AllScriptableObjects.GetAllElements();
            foreach (Element element in allElements)
            {
                if (element.PrimeID == primeIDMultiplication)
                {
                    resultingElement = element;
                    break;
                }
                else
                    resultingElement = null;
            }
            if (Player.Instance.Discovered[primeIDMultiplication] == false) NewCalculatedElement?.Invoke("???");
            else if (resultingElement == null)
                NewCalculatedElement?.Invoke("None");
            else NewCalculatedElement?.Invoke(resultingElement.name);
        }
        public void OnFeedClicked()
        {
            Player.Instance.Inventory.RemoveItemFromInventory(babyMonster);
            Player.Instance.Inventory.AddItemToInventory(babyMonster.GetEvolutionBasedOnElement(resultingElement));
            for (int index = 0; index < 3; index++)
                Player.Instance.Inventory.RemoveItemFromInventory(fruitsInFruitSpots[index]);
            MonsterManager.Instance.ReloadInventory();

            Player.Instance.Discovered.Found(babyMonster.GetEvolutionBasedOnElement(resultingElement));
            if(resultingElement != null)
                Player.Instance.Discovered.Found(resultingElement);

            int primeIDMultiplication = 1;
            for (int index = 0; index < 3; index++)
                primeIDMultiplication *= fruitsInFruitSpots[index].PrimeID;
            Player.Instance.Discovered.Found(primeIDMultiplication);

            OnCloseOverlayClicked();
        }
        public void OnCloseOverlayClicked()
        {
            GetComponent<UIDocument>().enabled = false;
            GetComponent<BabyFeetPanel>().enabled = false;
        }
    }
}
