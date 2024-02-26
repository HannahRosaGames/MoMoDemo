using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.Player;
using System;
using Momo.ScriptableObjects;

namespace Momo.MonsterManagerScene
{
    public class BabyFeetOverlayPanelManager : MonoBehaviour
    {
        private MonsterManager monsterManager;
        #region Monster Manager Initialization
        [SerializeField] private GameObject monsterManagerGameObject;
        public void OnEnable()
        {
            monsterManager = monsterManagerGameObject.GetComponent<MonsterManager>();
        }
        public void OnDisable()
        {
            monsterManagerGameObject = null;
        }
        #endregion
        /*
        private BabyMonster selectedMonster;
        private ScriptableObjects.Attribute calcutlatedAttribute;
        private bool allFruitSpotsFilled;

        private FruitSpot selectedFruitSpot;
        private Fruit firstSpotFruitType;
        private Fruit secondSpotFruitType;
        private Fruit thirdSpotFruitType;

        private Button closeOverlay;
        private Button feed;
        private Label monsterName;
        private VisualElement inventoryDisplay;

        private VisualElement firstFruit;
        private VisualElement secondFruit;
        private VisualElement thirdFruit;
        private VisualElement firstFruitPicture;
        private VisualElement secondFruitPicture;
        private VisualElement thirdFruitPicture;
        private Label firstFruitName;
        private Label secondFruitName;
        private Label thirdFruitName;
        private Label firstFruitAmountLabel;
        private Label secondFruitAmountLabel;
        private Label thirdFruitAmountLabel;

        private Label firstFruitFirstAttribute;
        private Label firstFruitSecondAttribute;
        private Label firstFruitThirdAttribute;
        private Label secondFruitFirstAttribute;
        private Label secondFruitSecondAttribute;
        private Label secondFruitThirdAttribute;
        private Label thirdFruitFirstAttribute;
        private Label thirdFruitSecondAttribute;
        private Label thirdFruitThirdAttribute;

        private Label resuiltingAttribute;

        #region Open / Close Overlay
        public void OverlayOpen(BaseMonsterType monster, int monsterAmount)
        {
            selectedMonster = monster;
            calcutlatedAttribute = null;
            allFruitSpotsFilled = false;
            selectedFruitSpot = FruitSpot.None;
            firstSpotFruitType = 
            secondSpotFruitType = null;
            thirdSpotFruitType = null;

            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            feed = uiDocument.rootVisualElement.Q("Feed") as Button;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;
            inventoryDisplay = uiDocument.rootVisualElement.Q("InventoryDisplay") as VisualElement;

            firstFruit = uiDocument.rootVisualElement.Q("FirstFruit") as VisualElement;
            secondFruit = uiDocument.rootVisualElement.Q("SecondFruit") as VisualElement;
            thirdFruit = uiDocument.rootVisualElement.Q("ThirdFruit") as VisualElement;
            firstFruitPicture = uiDocument.rootVisualElement.Q("FirstFruitPicuture") as VisualElement;
            secondFruitPicture = uiDocument.rootVisualElement.Q("SecondFruitPicuture") as VisualElement;
            thirdFruitPicture = uiDocument.rootVisualElement.Q("ThirdFruitPicuture") as VisualElement;
            firstFruitName = uiDocument.rootVisualElement.Q("FirstFruitName") as Label;
            secondFruitName = uiDocument.rootVisualElement.Q("SecondFruitName") as Label;
            thirdFruitName = uiDocument.rootVisualElement.Q("ThirdFruitName") as Label;

            firstFruitFirstAttribute = uiDocument.rootVisualElement.Q("FirstFruitFirstAttribute") as Label;
            firstFruitSecondAttribute = uiDocument.rootVisualElement.Q("FirstFruitSecondAttribute") as Label;
            firstFruitThirdAttribute = uiDocument.rootVisualElement.Q("FirstFruitThirdAttribute") as Label;
            secondFruitFirstAttribute = uiDocument.rootVisualElement.Q("SecondFruitFirstAttribute") as Label;
            secondFruitSecondAttribute = uiDocument.rootVisualElement.Q("SecondFruitSecondAttribute") as Label;
            secondFruitThirdAttribute = uiDocument.rootVisualElement.Q("SecondFruitThirdAttribute") as Label;
            thirdFruitFirstAttribute = uiDocument.rootVisualElement.Q("ThirdFruitFirstAttribute") as Label;
            thirdFruitSecondAttribute = uiDocument.rootVisualElement.Q("ThirdFruitSecondAttribute") as Label;
            thirdFruitThirdAttribute = uiDocument.rootVisualElement.Q("ThirdFruitThirdAttribute") as Label;

            resuiltingAttribute = uiDocument.rootVisualElement.Q("ResuiltingAttribute") as Label;

            monsterName.text = monster.ToString() + " - " + monsterAmount;

            closeOverlay.RegisterCallback<ClickEvent>(CloseOverlay);
            feed.RegisterCallback<ClickEvent>(Feed);

            MakeFruitSpotsSelectable();
            DisplayFruitsFromInventory();
        }
        private void OverlayClosed()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(CloseOverlay);
            feed.UnregisterCallback<ClickEvent>(CloseOverlay);
        }

        private void CloseOverlay(ClickEvent evt)
        {
            GetComponent<UIDocument>().enabled = false;
            OverlayClosed();
        }
        #endregion

        #region Feed
        private void Feed(ClickEvent evt)
        {
            if (!allFruitSpotsFilled)
                return;

            if (calcutlatedAttribute != null)
                Player.Instance.discovered.Found(calcutlatedAttribute);

            Player.Instance.discovered.Found(firstSpotFruitType, secondSpotFruitType, thirdSpotFruitType);

            GrownMonsterType calcutlatedMonster = BaseMonster.specificBaseMonster[selectedMonster].evolutionBasedOnAttribute[calcutlatedAttribute]; // TODO

            Player.Instance.discovered.Found(calcutlatedMonster);

            Player.Instance.inventory.RemoveItemFromInventory(selectedMonster, true);
            Player.Instance.inventory.RemoveItemFromInventory(firstSpotFruitType);
            Player.Instance.inventory.RemoveItemFromInventory(secondSpotFruitType);
            Player.Instance.inventory.RemoveItemFromInventory(thirdSpotFruitType);
            Player.Instance.inventory.AddItemToInventory(calcutlatedMonster);

            CloseOverlay(evt);
            GameObject.Find("MonsterSelectSceneUI").GetComponent<MonsterSelectScenePM>().ReloadInventory();

            GameObject.Find("NewObtainedOverlayUI").GetComponent<UIDocument>().enabled = true;
            GameObject.Find("NewObtainedOverlayUI").GetComponent<NewObtainedOverlayPM>().OverlayOpen("a grown Monster", calcutlatedMonster.ToString());
        }
        #endregion

        #region FruitSpot Selection
        private enum FruitSpot
        {
            None,
            FirstSpot,
            SecondSpot,
            ThirdSpot
        }
        private void MakeFruitSpotsSelectable()
        {
            firstFruit.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedFruitSpot(FruitSpot.FirstSpot);
            }));
            secondFruit.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedFruitSpot(FruitSpot.SecondSpot);
            }));
            thirdFruit.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedFruitSpot(FruitSpot.ThirdSpot);
            }));
        }
        private void ChangeSelectedFruitSpot(FruitSpot newSelectedFruitSpot)
        {
            if (selectedFruitSpot == FruitSpot.None)
            {
                SelectFruitSpot(newSelectedFruitSpot);
                selectedFruitSpot = newSelectedFruitSpot;
            }
            else if (newSelectedFruitSpot == selectedFruitSpot)
            {
                DeselectFruitSpot(selectedFruitSpot);
                selectedFruitSpot = FruitSpot.None;
            }
            else
            {
                DeselectFruitSpot(selectedFruitSpot);
                SelectFruitSpot(newSelectedFruitSpot);
                selectedFruitSpot = newSelectedFruitSpot;
            }
        }
        private void SelectFruitSpot(FruitSpot newSelectedFruitSpot)
        {
            switch (newSelectedFruitSpot)
            {
                case FruitSpot.FirstSpot:
                    firstFruit.AddToClassList("selectedItem");
                    break;
                case FruitSpot.SecondSpot:
                    secondFruit.AddToClassList("selectedItem");
                    break;
                case FruitSpot.ThirdSpot:
                    thirdFruit.AddToClassList("selectedItem");
                    break;
            }
        }
        private void DeselectFruitSpot(FruitSpot oldSelectedFruitSpot)
        {
            switch (oldSelectedFruitSpot)
            {
                case FruitSpot.FirstSpot:
                    firstFruit.RemoveFromClassList("selectedItem");
                    break;
                case FruitSpot.SecondSpot:
                    secondFruit.RemoveFromClassList("selectedItem");
                    break;
                case FruitSpot.ThirdSpot:
                    thirdFruit.RemoveFromClassList("selectedItem");
                    break;
            }
        }
        #endregion

        #region Fruit Inventory Display
        private void DisplayFruitsFromInventory()
        {
            Dictionary<Fruit, int> fruitsInPosession = Player.Instance.inventory.getFruitsInPosession();
            foreach (KeyValuePair<Fruit, int> fruit in fruitsInPosession)
                CreateInventoryItem(fruit.Key, fruit.Value);
        }

        private void CreateInventoryItem(Fruit fruit, int fruitAmount)
        {
            if (fruitAmount <= 0)
                return;

            string fruitName = fruit.fruitName;

            string invetoryItemName = "item" + fruitName;
            string invetoryPictureName = "picture" + fruitName;
            string invetoryLabelName = "label" + fruitName;

            VisualElement newItem = new VisualElement { name = invetoryItemName };
            VisualElement newPicture = new VisualElement { name = invetoryPictureName };
            Label newLabel = new Label { name = invetoryLabelName };

            newLabel.text = "x" + fruitAmount;

            newItem.AddToClassList("fruitInventoryItem");
            newPicture.AddToClassList("fruitInventoryPicture");
            newLabel.AddToClassList("fruitInventoryLabel");

            newPicture.style.backgroundColor = fruit.fruitColor;

            inventoryDisplay.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedFruitType(fruit, fruitName, newLabel);
            }));
        }
        #endregion

        #region Fruit Selection
        private void ChangeSelectedFruitType(Fruit fruit, string fruitName, Label FruitAmountLabel)
        {
            if(GetFruitAmountFromLabel(FruitAmountLabel) <= 0)
                return;

            FruitSpot fruitSpotToUpdate;

            if (selectedFruitSpot == FruitSpot.None)
            {
                if (firstSpotFruitType == null)
                    fruitSpotToUpdate = FruitSpot.FirstSpot;
                else if (secondSpotFruitType == null)
                    fruitSpotToUpdate = FruitSpot.SecondSpot;
                else if (thirdSpotFruitType == null)
                    fruitSpotToUpdate = FruitSpot.ThirdSpot;
                else
                    return;
            }
            else
                fruitSpotToUpdate = selectedFruitSpot;

            UpdateFruitSpot(fruitSpotToUpdate, fruit, fruitName, FruitAmountLabel);
        }
        private void UpdateFruitSpot(FruitSpot fruitSpotToUpdate, Fruit fruit, string fruitName, Label FruitAmountLabel)
        {
            switch (fruitSpotToUpdate)
            {
                case FruitSpot.FirstSpot:
                    firstSpotFruitType = fruit;

                    firstFruitPicture.style.backgroundColor = fruit.fruitColor;
                    firstFruitName.text = fruitName;

                    ChangeDisplayedFruitAmount(FruitAmountLabel, -1);
                    ChangeDisplayedFruitAmount(firstFruitAmountLabel, +1);
                    firstFruitAmountLabel = FruitAmountLabel;
                    break;
                case FruitSpot.SecondSpot:
                    secondSpotFruitType = fruit;

                    secondFruitPicture.style.backgroundColor = fruit.fruitColor;
                    secondFruitName.text = fruitName;

                    ChangeDisplayedFruitAmount(FruitAmountLabel, -1);
                    ChangeDisplayedFruitAmount(secondFruitAmountLabel, +1);
                    secondFruitAmountLabel = FruitAmountLabel;
                    break;
                case FruitSpot.ThirdSpot:
                    thirdSpotFruitType = fruit;

                    thirdFruitPicture.style.backgroundColor = fruit.fruitColor;
                    thirdFruitName.text = fruitName;

                    ChangeDisplayedFruitAmount(FruitAmountLabel, -1);
                    ChangeDisplayedFruitAmount(thirdFruitAmountLabel, +1);
                    thirdFruitAmountLabel = FruitAmountLabel;
                    break;
            }

            DisplayKnownAttributes(fruitSpotToUpdate, fruit);
            UpdateAttribute();
        }
        private void ChangeDisplayedFruitAmount(Label FruitAmountLabel, int change)
        {
            if (FruitAmountLabel == null)
                return;

            int currentAmount = GetFruitAmountFromLabel(FruitAmountLabel);

            if (currentAmount == -1)
                return;

            int newAmount = currentAmount + change;
            if (newAmount < 0)
                newAmount = 0;

            string newLabelText = "x" + newAmount;
            FruitAmountLabel.text = newLabelText;
        }

        private int GetFruitAmountFromLabel(Label FruitAmountLabel)
        {
            try
            {
                return Int32.Parse(FruitAmountLabel.text.Substring(1));
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Attribute Control
        private void UpdateAttribute()
        {
            if (firstSpotFruitType == null || secondSpotFruitType == null || thirdSpotFruitType == null)
            {
                resuiltingAttribute.text = "";
                calcutlatedAttribute = null;
                allFruitSpotsFilled = false;
                return;
            }

            allFruitSpotsFilled = true;

            if (firstSpotFruitType == secondSpotFruitType || firstSpotFruitType == thirdSpotFruitType || secondSpotFruitType == thirdSpotFruitType)
            {
                resuiltingAttribute.text = "None";
                calcutlatedAttribute = null;
                return;
            }

            ScriptableObjects.Attribute resultingAttribute = demoCombine.CombineFruits(firstSpotFruitType, secondSpotFruitType, thirdSpotFruitType);
            bool fruitCombinationDiscovered = Player.Instance.discovered[firstSpotFruitType, secondSpotFruitType, thirdSpotFruitType];

            if (fruitCombinationDiscovered)
                resuiltingAttribute.text = resultingAttribute.attributeName;
            else
                resuiltingAttribute.text = "???";

            calcutlatedAttribute = resultingAttribute;
        }
        private void DisplayKnownAttributes(FruitSpot fruitSpotToUpdate, Fruit fruit)
        {
            ScriptableObjects.Attribute firstAttribute = fruit.attributes[0];
            ScriptableObjects.Attribute secondAttribute = fruit.attributes[1];
            ScriptableObjects.Attribute thirdAttribute = fruit.attributes[2];
            string firstAttributeText = "???";
            string secondAttributeText = "???";
            string thirdAttributeText = "???";

            if (Player.Instance.discovered[firstAttribute])
                firstAttributeText = firstAttribute.ToString();
            if (Player.Instance.discovered[secondAttribute])
                secondAttributeText = secondAttribute.ToString();
            if (Player.Instance.discovered[thirdAttribute])
                thirdAttributeText = thirdAttribute.ToString();

            switch (fruitSpotToUpdate)
            {
                case FruitSpot.FirstSpot:
                    firstFruitFirstAttribute.text = firstAttributeText;
                    firstFruitSecondAttribute.text = secondAttributeText;
                    firstFruitThirdAttribute.text = thirdAttributeText;
                    break;
                case FruitSpot.SecondSpot:
                    secondFruitFirstAttribute.text = firstAttributeText;
                    secondFruitSecondAttribute.text = secondAttributeText;
                    secondFruitThirdAttribute.text = thirdAttributeText;
                    break;
                case FruitSpot.ThirdSpot:
                    thirdFruitFirstAttribute.text = firstAttributeText;
                    thirdFruitSecondAttribute.text = secondAttributeText;
                    thirdFruitThirdAttribute.text = thirdAttributeText;
                    break;
            }
        }
        #endregion
        */
    }
}
