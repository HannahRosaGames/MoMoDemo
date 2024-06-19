using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;

namespace Momo.MonsterManagerScene.Panel
{
    public class BabyFeetPanel : MonoBehaviour
    {
        private Button closeOverlay;
        private Button feed;
        private Label monsterName;
        private VisualElement inventoryDisplay;

        private VisualElement[] fruitSpots;
        private VisualElement[] fruitpotsPictures;
        private Label[] fruitSpotsNames;
        private Label[,] fruitSpotsElements;
        //private Label[] fruitAmountLabels;

        private Dictionary<string, Label> fruitInventoryItemsLabel;

        private Label resultingElement;

        public void OnEnable()
        {
            RegisterUIElements();
            SubscribeToButtonEvents();
            SubscribeToLogicEvents();
            LoadContent();
        }

        #region OnEnable
        private void RegisterUIElements()
        {
            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            feed = uiDocument.rootVisualElement.Q("Feed") as Button;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;
            inventoryDisplay = uiDocument.rootVisualElement.Q("InventoryDisplay") as VisualElement;

            VisualElement firstFruit = uiDocument.rootVisualElement.Q("FirstFruit") as VisualElement;
            VisualElement secondFruit = uiDocument.rootVisualElement.Q("SecondFruit") as VisualElement;
            VisualElement thirdFruit = uiDocument.rootVisualElement.Q("ThirdFruit") as VisualElement;
            fruitSpots = new VisualElement[] { firstFruit, secondFruit, thirdFruit };

            VisualElement firstFruitPicture = uiDocument.rootVisualElement.Q("FirstFruitPicuture") as VisualElement;
            VisualElement secondFruitPicture = uiDocument.rootVisualElement.Q("SecondFruitPicuture") as VisualElement;
            VisualElement thirdFruitPicture = uiDocument.rootVisualElement.Q("ThirdFruitPicuture") as VisualElement;
            fruitpotsPictures = new VisualElement[] { firstFruitPicture, secondFruitPicture, thirdFruitPicture };

            Label firstFruitName = uiDocument.rootVisualElement.Q("FirstFruitName") as Label;
            Label secondFruitName = uiDocument.rootVisualElement.Q("SecondFruitName") as Label;
            Label thirdFruitName = uiDocument.rootVisualElement.Q("ThirdFruitName") as Label;
            fruitSpotsNames = new Label[] { firstFruitName, secondFruitName, thirdFruitName };

            Label firstFruitFirsElement = uiDocument.rootVisualElement.Q("FirstFruitFirstElement") as Label;
            Label firstFruitSecondElement = uiDocument.rootVisualElement.Q("FirstFruitSecondElement") as Label;
            Label firstFruitThirdElement = uiDocument.rootVisualElement.Q("FirstFruitThirdElement") as Label;
            Label secondFruitFirstElement = uiDocument.rootVisualElement.Q("SecondFruitFirstElement") as Label;
            Label secondFruitSecondElement = uiDocument.rootVisualElement.Q("SecondFruitSecondElement") as Label;
            Label secondFruitThirdElement = uiDocument.rootVisualElement.Q("SecondFruitThirdElement") as Label;
            Label thirdFruitFirstElement = uiDocument.rootVisualElement.Q("ThirdFruitFirstElement") as Label;
            Label thirdFruitSecondElement = uiDocument.rootVisualElement.Q("ThirdFruitSecondElement") as Label;
            Label thirdFruitThirdElement = uiDocument.rootVisualElement.Q("ThirdFruitThirdElement") as Label;
            // examples: firstFruitSecondElement = fruitElements[0][1] and thirdFruitFirstElement = fruitElements[2][0]
            fruitSpotsElements = new Label[3, 3] { { firstFruitFirsElement, firstFruitSecondElement, firstFruitThirdElement }, { secondFruitFirstElement, secondFruitSecondElement, secondFruitThirdElement }, { thirdFruitFirstElement, thirdFruitSecondElement, thirdFruitThirdElement } };

            fruitInventoryItemsLabel = new Dictionary<string, Label>();

            resultingElement = uiDocument.rootVisualElement.Q("ResultingElement") as Label;
        }
        private void SubscribeToButtonEvents()
        {
            closeOverlay.RegisterCallback<ClickEvent>(OnCloseOverlayClicked);
            feed.RegisterCallback<ClickEvent>(OnFeedClicked);
        }
        private void SubscribeToLogicEvents()
        {
            BabyFeet.Instance.LoadSelectedBabyMonster += OnLoadSelectedBabyMonster;
            BabyFeet.Instance.MakeFruitSpotsSelectable += OnMakeFruitSpotsSelectable;
            BabyFeet.Instance.CreateInventoryItemFruit += OnCreateInventoryItemFruit;
            BabyFeet.Instance.UpdateInventoryItemFruit += OnUpdateInventoryItemFruit;
            BabyFeet.Instance.SelectFruitSpot += OnSelectFruitSpot;
            BabyFeet.Instance.DeselectFruitSpot += OnDeselectFruitSpot;
            BabyFeet.Instance.ChangeFruitInFruitSpotTo += OnChangeFruitInFruitSpotTo;
            BabyFeet.Instance.NewCalculatedElement += OnNewCalculatedElement;
        }
        private void LoadContent()
        {
            BabyFeet.Instance.LoadContent();
        }
        #endregion

        public void OnDisable()
        {
            UnsubscribeToButtonEvents();
            UnsubscribeToLogicEvents();
        }

        #region OnDisable
        private void UnsubscribeToButtonEvents()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(OnCloseOverlayClicked);
            feed.UnregisterCallback<ClickEvent>(OnFeedClicked);
        }
        private void UnsubscribeToLogicEvents()
        {
            BabyFeet.Instance.LoadSelectedBabyMonster -= OnLoadSelectedBabyMonster;
            BabyFeet.Instance.MakeFruitSpotsSelectable -= OnMakeFruitSpotsSelectable;
            BabyFeet.Instance.CreateInventoryItemFruit -= OnCreateInventoryItemFruit;
            BabyFeet.Instance.UpdateInventoryItemFruit -= OnUpdateInventoryItemFruit;
            BabyFeet.Instance.SelectFruitSpot -= OnSelectFruitSpot;
            BabyFeet.Instance.DeselectFruitSpot -= OnDeselectFruitSpot;
            BabyFeet.Instance.ChangeFruitInFruitSpotTo -= OnChangeFruitInFruitSpotTo;
            BabyFeet.Instance.NewCalculatedElement -= OnNewCalculatedElement;
        }
        #endregion

        #region On EggHatch Event Handling
        private void OnLoadSelectedBabyMonster(string babyMonsterName)
        {
            monsterName.text = babyMonsterName;
        }
        private void OnMakeFruitSpotsSelectable()
        {
            for (int index = 0; index < 3; index++)
                AddSelectableToFruitSpot(index);
        }
        private void AddSelectableToFruitSpot(int fruitSpotArrayIndex)
        {
            fruitSpots[fruitSpotArrayIndex].AddManipulator(new Clickable(evt =>
            {
                OnFruitSpotClicked(fruitSpotArrayIndex);
            }));
        }
        private void OnCreateInventoryItemFruit(Fruit fruit, int fruitAmount)
        {
            string fruitName = fruit.Name;
            Color fruitColor = fruit.Color;

            VisualElement newItem = new VisualElement { name = "Item" + fruitName };
            VisualElement newPicture = new VisualElement { name = "Picture" + fruitName };
            Label newLabel = new Label { name = "Label" + fruitName };

            newLabel.text = "x" + fruitAmount;

            newItem.AddToClassList("fruitInventoryItem");
            newPicture.AddToClassList("fruitInventoryPicture");
            newLabel.AddToClassList("fruitInventoryLabel");

            newPicture.style.backgroundColor = fruitColor;

            inventoryDisplay.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            fruitInventoryItemsLabel.Add(fruitName, newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                OnFruitInventoryItemClicked(fruitName);
            }));
        }
        private void OnUpdateInventoryItemFruit(string fruitName, int fruitAmount)
        {
            fruitInventoryItemsLabel[fruitName].text = "x" + fruitAmount;
        }
        private void OnSelectFruitSpot(int fruitSpotArrayIndex)
        {
            fruitSpots[fruitSpotArrayIndex].AddToClassList("selectedItem");
        }
        private void OnDeselectFruitSpot(int fruitSpotArrayIndex)
        {
            fruitSpots[fruitSpotArrayIndex].RemoveFromClassList("selectedItem");
        }
        private void OnChangeFruitInFruitSpotTo(int fruitSpotArrayIndex, Fruit fruit, string[] elements)
        {
            fruitpotsPictures[fruitSpotArrayIndex].style.backgroundColor = fruit.Color;
            fruitSpotsNames[fruitSpotArrayIndex].text = fruit.Name;
            for (int index = 0; index < 3; index++)
                fruitSpotsElements[fruitSpotArrayIndex, index].text = elements[index];
        }
        private void OnNewCalculatedElement(string element)
        {
            resultingElement.text = element;
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnCloseOverlayClicked(ClickEvent evt)
        {
            BabyFeet.Instance.OnCloseOverlayClicked();
        }
        private void OnFruitSpotClicked(int fruitSpotArrayIndex)
        {
            BabyFeet.Instance.OnFruitSpotClicked(fruitSpotArrayIndex);
        }
        private void OnFruitInventoryItemClicked(string fruitName)
        {
            BabyFeet.Instance.OnFruitInventoryItemClicked(fruitName);
        }
        private void OnFeedClicked(ClickEvent evt)
        {
            BabyFeet.Instance.OnFeedClicked();
        }
        #endregion
    }
}
