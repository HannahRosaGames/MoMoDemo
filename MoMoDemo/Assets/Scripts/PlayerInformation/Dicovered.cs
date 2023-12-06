using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.Types;
using System;

namespace Momo.PlayerInformation
{
    public class Dicovered
    {
        private Dictionary<FruitType, bool> fruitsDiscovered;
        private Dictionary<BaseMonsterType, bool> baseMonsterDiscovered;
        private Dictionary<GrownMonsterType, bool> grownMonsterDiscovered;
        private Dictionary<AttributeType, bool> attributesDiscovered;
        private Dictionary<int, bool> fruitCombinationsDiscovered;


        public Dicovered()
        {
            fruitsDiscovered = new Dictionary<FruitType, bool>();
            baseMonsterDiscovered = new Dictionary<BaseMonsterType, bool>();
            grownMonsterDiscovered = new Dictionary<GrownMonsterType, bool>();
            attributesDiscovered = new Dictionary<AttributeType, bool>();
            fruitCombinationsDiscovered = new Dictionary<int, bool>();

            FillDictonaries();
        }

        private void FillDictonaries()
        {
            foreach (int i in Enum.GetValues(typeof(FruitType)))
                fruitsDiscovered.Add((FruitType)i, false);
            foreach (int i in Enum.GetValues(typeof(BaseMonsterType)))
                baseMonsterDiscovered.Add((BaseMonsterType)i, false);
            foreach (int i in Enum.GetValues(typeof(GrownMonsterType)))
                grownMonsterDiscovered.Add((GrownMonsterType)i, false);
            foreach (int i in Enum.GetValues(typeof(AttributeType)))
                attributesDiscovered.Add((AttributeType)i, false);
            foreach (int i in Enum.GetValues(typeof(FruitType)))
                foreach (int j in Enum.GetValues(typeof(FruitType)))
                    foreach (int k in Enum.GetValues(typeof(FruitType)))
                    {
                        int newKey = i * j * k;
                        if (newKey != 0 && i < j && j < k)
                            fruitCombinationsDiscovered.Add(i * j * k, false);
                    }
        }

        #region [] modificator
        public bool this[FruitType fruitType]
        {
            get { return fruitsDiscovered[fruitType]; }
        }
        public bool this[BaseMonsterType baseMonsterType]
        {
            get { return baseMonsterDiscovered[baseMonsterType]; }
        }
        public bool this[GrownMonsterType grownMonsterType]
        {
            get { return grownMonsterDiscovered[grownMonsterType]; }
        }
        public bool this[AttributeType attributeType]
        {
            get { return attributesDiscovered[attributeType]; }
        }
        public bool this[int fruitCombination]
        {
            get { return fruitCombinationsDiscovered[fruitCombination]; }
        }
        public bool this[FruitType firstFruit, FruitType secondFruit, FruitType thirdFruit]
        {
            get { return fruitCombinationsDiscovered[((int)firstFruit) * ((int)secondFruit) * ((int)thirdFruit)]; }
        }
        #endregion

        #region Found
        public void Found(FruitType fruitType)
        {
            fruitsDiscovered[fruitType] = true;
        }
        public void Found(BaseMonsterType baseMonsterType)
        {
            baseMonsterDiscovered[baseMonsterType] = true;
        }
        public void Found(GrownMonsterType grownMonsterType)
        {
            grownMonsterDiscovered[grownMonsterType] = true;
        }
        public void Found(AttributeType attributeType)
        {
            attributesDiscovered[attributeType] = true;
        }
        public void Found(int fruitCombination)
        {
            fruitCombinationsDiscovered[fruitCombination] = true;
        }
        public void Found(FruitType firstFruit, FruitType secondFruit, FruitType thirdFruit)
        {
            fruitCombinationsDiscovered[((int)firstFruit) * ((int)secondFruit) * ((int)thirdFruit)] = true;
        }
        #endregion

        #region Debug
        public void DebugDiscovered()
        {
            string debugFruits = "Fruits discovered: ";
            string debugBaseMonster = "BaseMonster discovered: ";
            string debugGrownMonster = "GrownMonster discovered: ";
            string debugAttributeType = "Attributes discovered: ";

            foreach (KeyValuePair<FruitType, bool> item in fruitsDiscovered)
                debugFruits += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<BaseMonsterType, bool> item in baseMonsterDiscovered)
                debugBaseMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<GrownMonsterType, bool> item in grownMonsterDiscovered)
                debugGrownMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<AttributeType, bool> item in attributesDiscovered)
                debugAttributeType += item.Value + " " + item.Key.ToString() + "; ";

            Debug.Log(debugFruits);
            Debug.Log(debugBaseMonster);
            Debug.Log(debugGrownMonster);
            Debug.Log(debugAttributeType);
        }
        #endregion
    }
}
