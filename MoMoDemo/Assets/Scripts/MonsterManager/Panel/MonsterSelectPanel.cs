using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.MonsterManagerScene.Panel
{
    public class MonsterSelectPanel : MonoBehaviour
    {
        // The logic for this panel can be accessed with MonsterSelect.Instance

        private Button closeOverlay;
        private VisualElement inventoryDisplay;
        private VisualElement noMonster;
        private List<VisualElement> inventoryItems;
        private VisualElement selectedItem;

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
            inventoryDisplay = uiDocument.rootVisualElement.Q("InventoryDisplay") as VisualElement;
            noMonster = uiDocument.rootVisualElement.Q("ItemNoMonster") as VisualElement;

            inventoryItems = new List<VisualElement> { noMonster };

            noMonster.AddManipulator(new Clickable(evt =>
            {
                OnGrownMonsterInventoryItemClicked("NoMonster");
            }));
        }
        private void SubscribeToButtonEvents()
        {
            closeOverlay.RegisterCallback<ClickEvent>(OnCloseOverlayClicked);
        }
        private void SubscribeToLogicEvents()
        {
            MonsterSelect.Instance.CreateInventoryItemGrownMonster += OnCreateInventoryItemGrownMonster;
            MonsterSelect.Instance.SelectInventoryItem += OnSelectInventoryItem;
        }
        private void LoadContent()
        {
            MonsterSelect.Instance.LoadContent();
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
        }
        private void UnsubscribeToLogicEvents()
        {
            MonsterSelect.Instance.CreateInventoryItemGrownMonster -= OnCreateInventoryItemGrownMonster;
            MonsterSelect.Instance.SelectInventoryItem -= OnSelectInventoryItem;
        }
        #endregion

        #region On MonsterSelect Event Handling
        private void OnCreateInventoryItemGrownMonster(string grownMonsterName, int grownMonsterAmount)
        {
            VisualElement newItem = new VisualElement { name = "Item" + grownMonsterName};
            VisualElement newPicture = new VisualElement { name = "Picture" + grownMonsterName };
            Label newLabel = new Label { name = "Label" + grownMonsterName };

            inventoryItems.Add(newItem);
            selectedItem = null;

            newLabel.text = grownMonsterName + " - " + grownMonsterAmount;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            inventoryDisplay.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                OnGrownMonsterInventoryItemClicked(grownMonsterName);
            }));
        }
        
        private void OnSelectInventoryItem(string inventoryItemName)
        {
            if (selectedItem != null) selectedItem.RemoveFromClassList("selectedItem");
            VisualElement inventoryItem = inventoryItems.Find(item => item.name == inventoryItemName);
            selectedItem = inventoryItem;
            selectedItem.AddToClassList("selectedItem");
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnCloseOverlayClicked(ClickEvent evt)
        {
            MonsterSelect.Instance.OnCloseOverlayClicked();
        }
        private void OnGrownMonsterInventoryItemClicked(string grownMonsterName)
        {
            MonsterSelect.Instance.OnGrownMonsterInventoryItemClicked(grownMonsterName);
        }
        #endregion
    }
}
