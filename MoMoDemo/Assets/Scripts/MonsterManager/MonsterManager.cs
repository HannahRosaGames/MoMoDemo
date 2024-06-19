using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;
using Momo.PlayerInformation;
using Momo.Delegates;

namespace Momo.MonsterManagerScene
{
    public class MonsterManager : MonoBehaviour
    {
        #region Singleton
        public static MonsterManager Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event Action ChangeDisplayToGrownMonster;
        public event Action ChangeDisplayToEggsBabys;
        public event Action ClearInventory;
        public event NameAmountEvent CreateInventoryItemEgg;
        public event NameAmountEvent CreateInventoryItemBabyMonster;
        public event GrownMonsterEvent NewActiveMonster;
        public event Action NoActiveMonster;

        public void LoadContent()
        {
            LoadActiveMonster();
            LoadInventory();
        }

        public void OnExitButtonClicked()
        {
            SceneManager.LoadScene("Main");
        }
        public void OnGrownMonsterOnClicked()
        {
            ChangeDisplayToGrownMonster?.Invoke();
        }
        public void OnEggsBabysOnClicked()
        {
            ChangeDisplayToEggsBabys?.Invoke();
        }
        public void OnMonsterActionClicked()
        {
            MonsterSelect.Instance.OpenOverlay();
        }
        public void OnEggInventoryItemClicked(string eggName, int eggAmount)
        {
            EggHatch.Instance.OpenOverlay(eggName, eggAmount);
        }
        public void OnBabyMonsterInventoryItemClicked(string babyMonsterName)
        {
            BabyFeet.Instance.OpenOverlay(babyMonsterName);
        }
        public void ReloadInventory()
        {
            ClearInventory?.Invoke();
            LoadInventory();
        }

        public void ReloadActiveMonster()
        {
            LoadActiveMonster();
        }

        private void LoadActiveMonster()
        {
            GrownMonster activeMonster = Player.Instance.GetActiveMonster();
            if (activeMonster == null) NoActiveMonster?.Invoke();
            else NewActiveMonster?.Invoke(activeMonster);
        }
        private void LoadInventory()
        {
            Dictionary<Egg, int> eggsInInventory = Player.Instance.Inventory.getEggsInPosession();
            Dictionary<BabyMonster, int> babyMonsterInInventory = Player.Instance.Inventory.getBabyMonsterInPosession();

            foreach (KeyValuePair<Egg, int> egg in eggsInInventory)
                if(egg.Value > 0) CreateInventoryItemEgg?.Invoke(egg.Key.Name, egg.Value);

            foreach (KeyValuePair<BabyMonster, int> babyMonster in babyMonsterInInventory)
                if (babyMonster.Value > 0) CreateInventoryItemBabyMonster?.Invoke(babyMonster.Key.Name, babyMonster.Value);
        }
    }
}
