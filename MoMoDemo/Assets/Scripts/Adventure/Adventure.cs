using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;
using Momo.Delegates;
using Momo.PlayerInformation;
using UnityEngine.SceneManagement;
using System;

namespace Momo.AdventureScene
{
    public class Adventure : MonoBehaviour
    {
        #region Singleton
        public static Adventure Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event AreaEvent LoadNewArea;
        public event Action HideGoFurtherButton;

        private Area currentArea;
        private Dictionary<Fruit, int> foundFruits;
        private Dictionary<Egg, int> foundEggs;

        public void LoadContent() {
            currentArea = AllScriptableObjects.GetAllAreas()[0];
            foundFruits = new Dictionary<Fruit, int>();
            foundEggs = new Dictionary<Egg, int>();

            LoadNewArea?.Invoke(currentArea);
        }

        public void OnGoFurtherClicked()
        {
            Area nextArea = currentArea.FollowingArea;
            if (IsValidToGoOn(nextArea))
            {
                currentArea = nextArea;
                GoOntoNextArea();
            }
            else
                SummarizeAdventure();
        }

        private bool IsValidToGoOn(Area area)
        {
            if (area == null) return false;
            if (area.RangeNeeded > Player.Instance.GetRange()) return false;
            return true;
        }

        private void GoOntoNextArea()
        { 
            LoadNewArea?.Invoke(currentArea);
        }

        private void SummarizeAdventure()
        {
            AddEndLootToFoundFruitsAndEggs();
            AddFoundFruitsAndEggsToInventory();

            LootDisplay.Instance.OpenOverlay(foundFruits, foundEggs, currentArea);
            HideGoFurtherButton?.Invoke();
        }

        private void AddEndLootToFoundFruitsAndEggs()
        {
            List<Loot> endLoot = currentArea.GetEndLoot();
            foreach(Loot loot in endLoot)
            {
                if (loot.GetType() == typeof(Fruit))
                    AddFruitToFroundFruits(loot as Fruit);
                else if (loot.GetType() == typeof(Egg))
                    AddEggToFoundEggs(loot as Egg);
            }
        }

        private void AddFoundFruitsAndEggsToInventory()
        {
            foreach(KeyValuePair<Fruit,int> fruit in foundFruits)
                Player.Instance.Inventory.AddItemToInventory(fruit.Key, fruit.Value);
            foreach (KeyValuePair<Egg, int> egg in foundEggs)
                Player.Instance.Inventory.AddItemToInventory(egg.Key, egg.Value);
        }

        public void EndAdventure()
        {
            Player.Instance.UseUpActiveMonsterIfExistent();
            SceneManager.LoadScene("Main");
        }

        public void OnFruitClicked(Fruit fruit)
        {
            AddFruitToFroundFruits(fruit);
        }
        public void OnEggClicked(Egg egg)
        {
            AddEggToFoundEggs(egg);
        }
        private void AddFruitToFroundFruits(Fruit fruit)
        {
            if (foundFruits.ContainsKey(fruit))
                foundFruits[fruit] += 1;
            else
                foundFruits.Add(fruit, 1);
        }

        private void AddEggToFoundEggs(Egg egg)
        {
            if (foundEggs.ContainsKey(egg))
                foundEggs[egg] += 1;
            else
                foundEggs.Add(egg, 1);
        }
    }
}
