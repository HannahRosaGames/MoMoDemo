using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.Types;
using Momo.PlayerInformation;

namespace Momo.PanelManager.MonsterSelectUI
{
    public class MonsterSelectOverlayPM : MonoBehaviour
    {
        private Button closeOverlay;
        private VisualElement inventoryDisplay;
        private VisualElement noMonster;

        private VisualElement selectedItem;
        private GrownMonsterType selectedMonster = GrownMonsterType.None;

        #region Open / Close Overlay
        public void OverlayOpen()
        {
            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            inventoryDisplay = uiDocument.rootVisualElement.Q("InventoryDisplay") as VisualElement;
            noMonster = uiDocument.rootVisualElement.Q("NoMonster") as VisualElement;

            closeOverlay.RegisterCallback<ClickEvent>(CloseOverlay);

            DisplayGrownMonsterFromInventory();
        }
        private void OverlayClosed()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(CloseOverlay);
        }
        private void CloseOverlay(ClickEvent evt)
        {
            GetComponent<UIDocument>().enabled = false;
            OverlayClosed();
            GameObject.Find("MonsterSelectSceneUI").GetComponent<MonsterSelectScenePM>().UpdateActiveMonster();
        }
        #endregion

        #region Inventory control
        private void DisplayGrownMonsterFromInventory()
        {
            noMonster.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedItem(noMonster, GrownMonsterType.None);
            }));
            if (selectedMonster == GrownMonsterType.None)
            {
                noMonster.AddToClassList("selectedItem");
                selectedItem = noMonster;
            }

            Dictionary<GrownMonsterType, int> monsterInPosession = Player.Instance.inventory.getGrownMonsterInPosession();
            foreach (KeyValuePair<GrownMonsterType, int> monster in monsterInPosession)
                CreateInventoryItem(monster.Key, monster.Value);
        }
        private void CreateInventoryItem(GrownMonsterType monster, int monsterAmount)
        {
            if (monsterAmount <= 0)
                return;

            string monsterName = monster.ToString();

            string invetoryItemName = "item" + monsterName;
            string invetoryPictureName = "picture" + monsterName;
            string invetoryLabelName = "label" + monsterName;

            VisualElement newItem = new VisualElement { name = invetoryItemName};
            VisualElement newPicture = new VisualElement { name = invetoryPictureName };
            Label newLabel = new Label { name = invetoryLabelName };

            newLabel.text = monsterName + " - " + monsterAmount;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            inventoryDisplay.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                ChangeSelectedItem(newItem, monster);
            }));

            if (selectedMonster == monster)
            {
                newItem.AddToClassList("selectedItem");
                selectedItem = newItem;
            }
        }
        private void ChangeSelectedItem(VisualElement newSelectedItem, GrownMonsterType newSelectedMonster)
        {
            if (newSelectedItem == selectedItem)
                return;

            selectedMonster = newSelectedMonster;

            selectedItem.RemoveFromClassList("selectedItem");
            newSelectedItem.AddToClassList("selectedItem");
            selectedItem = newSelectedItem;
            Player.Instance.SetActiveMonster(selectedMonster);
        }
        #endregion
    }
}
