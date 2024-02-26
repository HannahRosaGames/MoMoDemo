using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momo.OutOfSystem
{
    /*
    public static class Fruits
    {
        public static readonly Dictionary<FruitType, SingleFruit> specificFruit;
        private static Dictionary<int, AttributeType> fruitCombinations;

        static Fruits()
        {
            specificFruit = createFruit();
            fruitCombinations = createFruitCombinations();
        }

        #region Create
        private static Dictionary<FruitType, SingleFruit> createFruit()
        {
            Dictionary<FruitType, SingleFruit> fruit = new Dictionary<FruitType, SingleFruit>();

            foreach (int i in Enum.GetValues(typeof(FruitType)))
                fruit.Add((FruitType)i, new SingleFruit((FruitType)i));

            return fruit;
        }
        private static Dictionary<int, AttributeType> createFruitCombinations()
        {
            Dictionary<int, AttributeType> fruitCombinations = new Dictionary<int, AttributeType>();

            fruitCombinations.Add(6, AttributeType.Emo);
            fruitCombinations.Add(14, AttributeType.Lowpoly);
            fruitCombinations.Add(15, AttributeType.Flower);
            fruitCombinations.Add(357, AttributeType.Ghost);
            fruitCombinations.Add(494, AttributeType.Primordial);
            fruitCombinations.Add(715, AttributeType.Camouflage);
            fruitCombinations.Add(935, AttributeType.Neon);
            fruitCombinations.Add(2261, AttributeType.Winged);
            fruitCombinations.Add(2717, AttributeType.Alloyed);

            return fruitCombinations;
        }
        #endregion

        #region Public Functions
        public static AttributeType CombineFruits(FruitType firstFruit, FruitType secondFruit, FruitType thirdFruit)
        {
            int result = ((int)firstFruit) * ((int)secondFruit) * ((int)thirdFruit);
            if (fruitCombinations.ContainsKey(result))
                return fruitCombinations[result];
            else return AttributeType.None;
        }
        #endregion
    }

    public class SingleFruit
    {
        public readonly AttributeType[] attributes;
        public readonly Color color;

        public SingleFruit(FruitType fruit)
        {
            attributes = CreateAttributes(fruit);
            color = CreateColor(fruit);
        }
        #region Create
        private AttributeType[] CreateAttributes(FruitType fruit)
        {
            AttributeType[] attribute = new AttributeType[2];

            switch (fruit)
            {
                case FruitType.Pear:
                    attribute[0] = AttributeType.Emo;
                    attribute[1] = AttributeType.Lowpoly;
                    attribute[2] = AttributeType.Flower;
                    break;
                case FruitType.Banana:
                    attribute[0] = AttributeType.Emo;
                    attribute[1] = AttributeType.Lowpoly;
                    attribute[2] = AttributeType.Primordial;
                    break;
                case FruitType.Strawberry:
                    attribute[0] = AttributeType.Flower;
                    attribute[1] = AttributeType.Emo;
                    attribute[2] = AttributeType.Ghost;
                    break;
                case FruitType.Watermelon:
                    attribute[0] = AttributeType.Camouflage;
                    attribute[1] = AttributeType.Flower;
                    attribute[2] = AttributeType.Neon;
                    break;
                case FruitType.Lemon:
                    attribute[0] = AttributeType.Ghost;
                    attribute[1] = AttributeType.Lowpoly;
                    attribute[2] = AttributeType.Winged;
                    break;
                case FruitType.Orange:
                    attribute[0] = AttributeType.Neon;
                    attribute[1] = AttributeType.Camouflage;
                    attribute[2] = AttributeType.Alloyed;
                    break;
                case FruitType.Apple:
                    attribute[0] = AttributeType.Alloyed;
                    attribute[1] = AttributeType.Camouflage;
                    attribute[2] = AttributeType.Primordial;
                    break;
                case FruitType.Avocado:
                    attribute[0] = AttributeType.Winged;
                    attribute[1] = AttributeType.Ghost;
                    attribute[2] = AttributeType.Neon;
                    break;
                case FruitType.Cherry:
                    attribute[0] = AttributeType.Primordial;
                    attribute[1] = AttributeType.Winged;
                    attribute[2] = AttributeType.Alloyed;
                    break;
            }
            return attribute;
        }
        private Color CreateColor(FruitType fruit)
        {
            Color color = Color.gray;

            switch (fruit)
            {
                case FruitType.Pear:
                    color = new Color(0.43f, 0.66f, 0.16f, 1f); //6EA829
                    break;
                case FruitType.Banana:
                    color = new Color(0.63f, 0.51f, 0.08f, 1f); //A18214
                    break;
                case FruitType.Strawberry:
                    color = new Color(0.56f, 0f, 0.22f, 1f); //8F0038
                    break;
                case FruitType.Watermelon:
                    color = new Color(0.21f, 0.61f, 0.34f, 1f); //369C38
                    break;
                case FruitType.Lemon:
                    color = new Color(0.7f, 0.8f, 0f, 1f); //B2CC00
                    break;
                case FruitType.Orange:
                    color = new Color(0.8f, 0.43f, 0f, 1f); //CC6E00
                    break;
                case FruitType.Apple:
                    color = new Color(0.69f, 0.07f, 0.11f, 1f); //B0121C
                    break;
                case FruitType.Avocado:
                    color = new Color(0.1f, 0.39f, 0f, 1f); //1A6300
                    break;
                case FruitType.Cherry:
                    color = new Color(0.27f, 0f, 0.05f, 1f); //45000D
                    break;
            }
            return color;
        }
        #endregion
    }
        */
}