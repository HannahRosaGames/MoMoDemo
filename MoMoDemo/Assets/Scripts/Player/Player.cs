using UnityEngine;
using Momo.ScriptableObjects;

namespace Momo.Player
{
    public class CentralPlayer : MonoBehaviour
    {
        #region Singleton
        public static CentralPlayer Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public Inventory inventory;
        public Dicovered discovered;
        private GrownMonster activeMonster;

        public CentralPlayer()
        {
            inventory = new Inventory();
            discovered = new Dicovered();
        }

        #region active monster control
        public GrownMonster GetActiveMonster()
        {
            return activeMonster;
        }
        public void SetActiveMonster(GrownMonster newActiveMonster)
        {
            activeMonster = newActiveMonster;
        }
        public void UseUpActiveMonster()
        {
            inventory.RemoveItemFromInventory(activeMonster);
            activeMonster = null;
        }
        #endregion
    }
}
