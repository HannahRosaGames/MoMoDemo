using UnityEngine;
using Momo.ScriptableObjects;

namespace Momo.PlayerInformation
{
    public class Player : MonoBehaviour
    {
        #region Singleton
        public static Player Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public Inventory Inventory;
        public Dicovered Discovered;
        private GrownMonster ActiveMonster;

        public void Start()
        {
            Inventory = new Inventory();
            Discovered = new Dicovered();
        }

        #region active monster control
        public GrownMonster GetActiveMonster()
        {
            return ActiveMonster;
        }
        public void SetActiveMonster(GrownMonster newActiveMonster)
        {
            ActiveMonster = newActiveMonster;
        }
        public void UseUpActiveMonsterIfExistent()
        {
            if (ActiveMonster == null)
                return;

            Inventory.RemoveItemFromInventory(ActiveMonster);
            ActiveMonster = null;
        }
        public int GetRange()
        {
            if (ActiveMonster == null) return 0;
            return ActiveMonster.Range;
        }
        #endregion
    }
}
