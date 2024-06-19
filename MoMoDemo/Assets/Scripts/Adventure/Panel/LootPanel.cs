using Momo.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.AdventureScene.Panel
{
    public class LootPanel : MonoBehaviour
    {
        // The logic for this panel can be accessed with Loot.Instance

        private VisualElement lootDisplayFruit;
        private VisualElement lootDisplayEgg;
        private Button goHome;

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
            lootDisplayFruit = uiDocument.rootVisualElement.Q("LootDisplayFruit") as VisualElement;
            lootDisplayEgg = uiDocument.rootVisualElement.Q("LootDisplayEgg") as VisualElement;
            goHome = uiDocument.rootVisualElement.Q("GoHome") as Button;
        }
        private void SubscribeToButtonEvents()
        {
            goHome.RegisterCallback<ClickEvent>(OnGoHomeClicked);
        }
        private void SubscribeToLogicEvents()
        {
            LootDisplay.Instance.CreateLootItemFruit += OnCreateLootItemFruit;
            LootDisplay.Instance.CreateLootItemEgg += OnCreateLootItemEgg;
        }
        private void LoadContent()
        {
            LootDisplay.Instance.LoadContent();
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
            goHome.UnregisterCallback<ClickEvent>(OnGoHomeClicked);
        }
        private void UnsubscribeToLogicEvents()
        {
            LootDisplay.Instance.CreateLootItemFruit += OnCreateLootItemFruit;
            LootDisplay.Instance.CreateLootItemEgg += OnCreateLootItemEgg;
        }
        #endregion

        #region On Loot Event Handling
        private void OnCreateLootItemFruit(Fruit fruit, int fruitAmount)
        {
            VisualElement newItem = new VisualElement { name = "Item" + fruit.Name };
            VisualElement newPicture = new VisualElement { name = "Picture" + fruit.Name };
            Label newLabel = new Label { name = "Label" + fruit.Name };

            newLabel.text = fruit.Name + " - " + fruitAmount;
            newPicture.style.backgroundColor = fruit.Color;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            lootDisplayFruit.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);
        }
        private void OnCreateLootItemEgg(Egg egg, int eggAmount)
        {
            VisualElement newItem = new VisualElement { name = "Item" + egg.Name };
            VisualElement newPicture = new VisualElement { name = "Picture" + egg.Name };
            Label newLabel = new Label { name = "Label" + egg.Name };

            newLabel.text = egg.Name + " - " + eggAmount;
            newPicture.style.backgroundColor = egg.Color;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            lootDisplayEgg.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnGoHomeClicked(ClickEvent evt)
        {
            Debug.Log("click");
            LootDisplay.Instance.OnGoHomeClicked();
        }
        #endregion
    }
}
