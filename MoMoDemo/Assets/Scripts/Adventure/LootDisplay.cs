using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;
using Momo.Delegates;
using UnityEngine.UIElements;
using Momo.AdventureScene.Panel;

namespace Momo.AdventureScene
{
    public class LootDisplay : MonoBehaviour
    {
        #region Singleton
        public static LootDisplay Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion


        public event FruitAmountEvent CreateLootItemFruit;
        public event EggAmountEvent CreateLootItemEgg;

        private Dictionary<Fruit, int> foundFruits;
        private Dictionary<Egg, int> foundEggs;

        public void OpenOverlay(Dictionary<Fruit, int> foundFruits, Dictionary<Egg, int> foundEggs, Area activeArea)
        {
            this.foundFruits = foundFruits;
            this.foundEggs = foundEggs;
            

            GetComponent<UIDocument>().enabled = true;
            GetComponent<LootPanel>().enabled = true;
        }

        public void LoadContent()
        {
            foreach (KeyValuePair<Fruit, int> fruit in foundFruits)
                if (fruit.Value > 0) CreateLootItemFruit?.Invoke(fruit.Key, fruit.Value);

            foreach (KeyValuePair<Egg, int> egg in foundEggs)
                if (egg.Value > 0) CreateLootItemEgg?.Invoke(egg.Key, egg.Value);
        }

        public void OnGoHomeClicked()
        {
            CloseOverlay();
            Adventure.Instance.EndAdventure();
        }

        private void CloseOverlay()
        {
            GetComponent<UIDocument>().enabled = false;
            GetComponent<LootDisplay>().enabled = false;
        }
    }
}
