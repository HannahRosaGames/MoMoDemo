using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;
using Momo.Delegates;
using Momo.PlayerInformation;
using UnityEngine.SceneManagement;
using System;

namespace Momo.AdventureScene
{
    public class Adventure : MonoBehaviour
    {
        #region Singleton
        public static Adventure Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event AreaEvent LoadNewArea;
        public event Action HideGoFurtherButton;

        private Area currentArea;
        private Dictionary<Fruit, int> foundFruits;
        private Dictionary<Egg, int> foundEggs;

        public void LoadContent() {
            currentArea = AllScriptableObjects.GetAllAreas()[0];
            foundFruits = new Dictionary<Fruit, int>();
            foundEggs = new Dictionary<Egg, int>();

            LoadNewArea?.Invoke(currentArea);
        }

        public void OnGoFurtherClicked()
        {
            Area nextArea = currentArea.FollowingArea;
            currentArea = nextArea;
            if (IsValidToGoOn())
                GoOntoNextArea();
            else
                SummarizeAdventure();
        }

        private bool IsValidToGoOn()
        {
            if (currentArea == null) return false;
            if (currentArea.RangeNeeded > Player.Instance.GetRange()) return false;
            return true;
        }

        private void GoOntoNextArea()
        { 
            LoadNewArea?.Invoke(currentArea);
        }

        private void SummarizeAdventure()
        {
            LootDisplay.Instance.OpenOverlay(foundFruits, foundEggs);
            HideGoFurtherButton?.Invoke();
        }

        public void EndAdventure()
        {
            Player.Instance.UseUpActiveMonsterIfExistent();
            SceneManager.LoadScene("Main");
        }

        public void OnFruitClicked(Fruit fruit)
        {
            Player.Instance.Inventory.AddItemToInventory(fruit);

            if (foundFruits.ContainsKey(fruit))
                foundFruits[fruit] += 1;
            else
                foundFruits.Add(fruit, 1);
        }
        public void OnEggClicked( Egg egg)
        {
            Player.Instance.Inventory.AddItemToInventory(egg);

            if (foundEggs.ContainsKey(egg))
                foundEggs[egg] += 1;
            else
                foundEggs.Add(egg, 1);
        }
    }
}
