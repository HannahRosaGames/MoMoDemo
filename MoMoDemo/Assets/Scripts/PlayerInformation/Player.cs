using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.Types;

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

        public Inventory inventory;
        public Dicovered discovered;
        private GrownMonsterType activeMonster;

        public Player()
        {
            inventory = new Inventory();
            discovered = new Dicovered();
        }

        #region active monster control
        public GrownMonsterType GetActiveMonster()
        {
            return activeMonster;
        }
        public void SetActiveMonster(GrownMonsterType newActiveMonster)
        {
            activeMonster = newActiveMonster;
        }
        public void UseUpActiveMonster()
        {
            inventory.RemoveItemFromInventory(activeMonster);
            activeMonster = GrownMonsterType.None;
        }
        #endregion
    }
}
