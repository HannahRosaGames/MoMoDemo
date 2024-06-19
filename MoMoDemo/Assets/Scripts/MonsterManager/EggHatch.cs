using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;
using Momo.PlayerInformation;
using Momo.MonsterManagerScene.Panel;
using Momo.Delegates;

namespace Momo.MonsterManagerScene
{
    public class EggHatch : MonoBehaviour
    {
        #region Singleton
        public static EggHatch Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event NameAmountEvent LoadSelectedEgg;

        private string eggName;
        private int eggAmount;
        private Egg egg;

        public void OpenOverlay(string eggName, int eggAmount)
        {
            this.eggName = eggName;
            this.eggAmount = eggAmount;
            egg = AllScriptableObjects.GetAllEggs().Find(egg => egg.Name == eggName);

            GetComponent<UIDocument>().enabled = true;
            GetComponent<EggHatchPanel>().enabled = true;
        }
        public void LoadContent()
        {
            LoadSelectedEgg?.Invoke(eggName, eggAmount);
        }
        public void OnCloseOverlayClicked()
        {
            GetComponent<UIDocument>().enabled = false;
            GetComponent<EggHatchPanel>().enabled = false;
        }
        public void OnHatchClicked()
        {
            Player.Instance.Inventory.RemoveItemFromInventory(egg);
            Player.Instance.Inventory.AddItemToInventory(egg.Into);
            MonsterManager.Instance.ReloadInventory();

            GetComponent<UIDocument>().enabled = false;
            GetComponent<EggHatchPanel>().enabled = false;
        }
        public void OnHatchAllClicked()
        {
            Player.Instance.Inventory.RemoveItemFromInventory(egg, eggAmount);
            Player.Instance.Inventory.AddItemToInventory(egg.Into, eggAmount);
            MonsterManager.Instance.ReloadInventory();

            GetComponent<UIDocument>().enabled = false;
            GetComponent<EggHatchPanel>().enabled = false;
        }
    }
}
