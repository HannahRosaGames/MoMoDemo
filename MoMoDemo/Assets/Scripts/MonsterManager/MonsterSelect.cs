using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;
using Momo.PlayerInformation;
using Momo.MonsterManagerScene.Panel;
using Momo.Delegates;

namespace Momo.MonsterManagerScene
{
    public class MonsterSelect : MonoBehaviour
    {
        #region Singleton
        public static MonsterSelect Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event NameAmountEvent CreateInventoryItemGrownMonster;
        public event StringEvent SelectInventoryItem;

        public void OpenOverlay()
        {
            GetComponent<UIDocument>().enabled = true;
            GetComponent<MonsterSelectPanel>().enabled = true;
        }

        public void LoadContent()
        {
            Dictionary<GrownMonster, int> grownMonsterInInventory = Player.Instance.Inventory.getGrownMonsterInPosession();

            foreach (KeyValuePair<GrownMonster, int> grownMonster in grownMonsterInInventory)
                if (grownMonster.Value > 0) CreateInventoryItemGrownMonster?.Invoke(grownMonster.Key.Name, grownMonster.Value);

            SelectInventoryItemBasedOnGrownMonster(Player.Instance.GetActiveMonster());
        }

        public void OnCloseOverlayClicked()
        {
            GetComponent<UIDocument>().enabled = false;
            GetComponent<MonsterSelectPanel>().enabled = false;

            MonsterManager.Instance.ReloadActiveMonster();
        }
        public void OnGrownMonsterInventoryItemClicked(string grownMonsterName)
        {
            GrownMonster activeMonster = AllScriptableObjects.GetAllGrownMonster().Find(grownMonster => grownMonster.Name == grownMonsterName);

            Player.Instance.SetActiveMonster(activeMonster);

            SelectInventoryItemBasedOnGrownMonster(activeMonster);
        }

        private void SelectInventoryItemBasedOnGrownMonster(GrownMonster activeMonster)
        {
            string inventoryItemName = "Item";
            if (activeMonster == null) inventoryItemName += "NoMonster";
            else inventoryItemName += activeMonster.Name;

            SelectInventoryItem?.Invoke(inventoryItemName);
        }
    }
}
