using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Momo.Types
{
    public static class TypeInformation
    {
        public static readonly Dictionary<FruitType, FruitInformation> fruitInformation;
        public static readonly Dictionary<BaseMonsterType, EvolutionInformation> evolutionInformation;
        private static readonly Dictionary<int, AttributeType> fruitCombinationInformation;

        static TypeInformation()
        {
            fruitInformation = createFruitInformation();
            evolutionInformation = createEvolutionInformation();
            fruitCombinationInformation  = createFruitCombinationInformation();
        }

        #region createInformation
        private static Dictionary<FruitType, FruitInformation> createFruitInformation()
        {
            Dictionary<FruitType, FruitInformation> fruitInformation = new Dictionary<FruitType, FruitInformation>();

            fruitInformation.Add(FruitType.Pear, new FruitInformation(AttributeType.Emo, AttributeType.Lowpoly, AttributeType.Flower));
            fruitInformation.Add(FruitType.Banana, new FruitInformation(AttributeType.Emo, AttributeType.Lowpoly, AttributeType.Primordial));
            fruitInformation.Add(FruitType.Strawberry, new FruitInformation(AttributeType.Flower, AttributeType.Emo, AttributeType.Ghost));
            fruitInformation.Add(FruitType.Watermelon, new FruitInformation(AttributeType.Camouflage, AttributeType.Flower, AttributeType.Neon));
            fruitInformation.Add(FruitType.Lemon, new FruitInformation(AttributeType.Ghost, AttributeType.Lowpoly, AttributeType.Winged));
            fruitInformation.Add(FruitType.Orange, new FruitInformation(AttributeType.Neon, AttributeType.Camouflage, AttributeType.Alloyed));
            fruitInformation.Add(FruitType.Apple, new FruitInformation(AttributeType.Alloyed, AttributeType.Camouflage, AttributeType.Primordial));
            fruitInformation.Add(FruitType.Avocado, new FruitInformation(AttributeType.Winged, AttributeType.Ghost, AttributeType.Neon));
            fruitInformation.Add(FruitType.Cherry, new FruitInformation(AttributeType.Primordial, AttributeType.Winged, AttributeType.Alloyed));

            return fruitInformation;
        }
        private static Dictionary<BaseMonsterType, EvolutionInformation> createEvolutionInformation()
        {
            Dictionary<BaseMonsterType, EvolutionInformation> evolutionInformation = new Dictionary<BaseMonsterType, EvolutionInformation>();

            foreach (int i in Enum.GetValues(typeof(BaseMonsterType)))
                evolutionInformation.Add((BaseMonsterType)i, new EvolutionInformation((BaseMonsterType)i));

            return evolutionInformation;
        }
        private static Dictionary<int, AttributeType> createFruitCombinationInformation()
        {
            Dictionary<int, AttributeType> fruitCombinationInformation = new Dictionary<int, AttributeType>();

            fruitCombinationInformation.Add(6, AttributeType.Emo);
            fruitCombinationInformation.Add(14, AttributeType.Lowpoly);
            fruitCombinationInformation.Add(15, AttributeType.Flower);
            fruitCombinationInformation.Add(357, AttributeType.Ghost);
            fruitCombinationInformation.Add(494, AttributeType.Primordial);
            fruitCombinationInformation.Add(715, AttributeType.Camouflage);
            fruitCombinationInformation.Add(935, AttributeType.Neon);
            fruitCombinationInformation.Add(2261, AttributeType.Winged);
            fruitCombinationInformation.Add(2717, AttributeType.Alloyed);

            return fruitCombinationInformation;
        }
        #endregion
        #region public functions
        public static AttributeType CombineFruits(FruitType firstFruit, FruitType secondFruit, FruitType thirdFruit)
        {
            int result = ((int)firstFruit) * ((int)secondFruit) * ((int)thirdFruit);
            if (fruitCombinationInformation.ContainsKey(result))
                return fruitCombinationInformation[result];
            else return AttributeType.None;
        }

        public static GrownMonsterType CombineAttributeAndMonster(AttributeType attribute, BaseMonsterType monster)
        {
            return evolutionInformation[monster].evolutionDictionary[attribute];
        }
        #endregion
    }

    public class FruitInformation
    {
        public readonly AttributeType firstAttribute;
        public readonly AttributeType secondAttribute;
        public readonly AttributeType thirdAttribute;

        public FruitInformation(AttributeType firstAttribute, AttributeType secondAttribute, AttributeType thirdAttribute)
        {
            this.firstAttribute = firstAttribute;
            this.secondAttribute = secondAttribute;
            this.thirdAttribute = thirdAttribute;
        }
    }

    public class GrownMonsterInformation
    {
    }

    public class EvolutionInformation
    {
        public readonly Dictionary<AttributeType, GrownMonsterType> evolutionDictionary;

        public EvolutionInformation(BaseMonsterType baseMonster)
        {
            evolutionDictionary = new Dictionary<AttributeType, GrownMonsterType>();
            switch (baseMonster)
            {
                case BaseMonsterType.Goat:
                    FillGoatEvolutions();
                    break;
                case BaseMonsterType.Duck:
                    FillDuckEvolutions();
                    break;
                case BaseMonsterType.Bear:
                    FillBearEvolutions();
                    break;
            }
        }

        private void FillGoatEvolutions()
        {
            evolutionDictionary.Add(AttributeType.None, GrownMonsterType.NormGoat);
            evolutionDictionary.Add(AttributeType.Primordial, GrownMonsterType.PrimGoat);
            evolutionDictionary.Add(AttributeType.Neon, GrownMonsterType.NeonGoat);
            evolutionDictionary.Add(AttributeType.Camouflage, GrownMonsterType.CamoGoat);
            evolutionDictionary.Add(AttributeType.Winged, GrownMonsterType.WingGoat);
            evolutionDictionary.Add(AttributeType.Lowpoly, GrownMonsterType.PolyGoat);
            evolutionDictionary.Add(AttributeType.Flower, GrownMonsterType.FlowGoat);
            evolutionDictionary.Add(AttributeType.Ghost, GrownMonsterType.GhostGoat);
            evolutionDictionary.Add(AttributeType.Alloyed, GrownMonsterType.AlloGoat);
            evolutionDictionary.Add(AttributeType.Emo, GrownMonsterType.EmoGoat);
        }
        private void FillDuckEvolutions()
        {
            evolutionDictionary.Add(AttributeType.None, GrownMonsterType.NormDuck);
            evolutionDictionary.Add(AttributeType.Primordial, GrownMonsterType.PrimDuck);
            evolutionDictionary.Add(AttributeType.Neon, GrownMonsterType.NeonDuck);
            evolutionDictionary.Add(AttributeType.Camouflage, GrownMonsterType.CamoDuck);
            evolutionDictionary.Add(AttributeType.Winged, GrownMonsterType.WingDuck);
            evolutionDictionary.Add(AttributeType.Lowpoly, GrownMonsterType.PolyDuck);
            evolutionDictionary.Add(AttributeType.Flower, GrownMonsterType.FlowDuck);
            evolutionDictionary.Add(AttributeType.Ghost, GrownMonsterType.GhostGoat);
            evolutionDictionary.Add(AttributeType.Alloyed, GrownMonsterType.AlloDuck);
            evolutionDictionary.Add(AttributeType.Emo, GrownMonsterType.EmoDuck);
        }
        private void FillBearEvolutions()
        {
            evolutionDictionary.Add(AttributeType.None, GrownMonsterType.NormBear);
            evolutionDictionary.Add(AttributeType.Primordial, GrownMonsterType.PrimBear);
            evolutionDictionary.Add(AttributeType.Neon, GrownMonsterType.NeonBear);
            evolutionDictionary.Add(AttributeType.Camouflage, GrownMonsterType.CamoBear);
            evolutionDictionary.Add(AttributeType.Winged, GrownMonsterType.WingBear);
            evolutionDictionary.Add(AttributeType.Lowpoly, GrownMonsterType.PolyBear);
            evolutionDictionary.Add(AttributeType.Flower, GrownMonsterType.FlowBear);
            evolutionDictionary.Add(AttributeType.Ghost, GrownMonsterType.GhostBear);
            evolutionDictionary.Add(AttributeType.Alloyed, GrownMonsterType.AlloBear);
            evolutionDictionary.Add(AttributeType.Emo, GrownMonsterType.EmoBear);
        }
    }



    /*
     * Emo: Pear, Banana, Strawberry 1*2*3
     * LowPoly: Pear, Banana, Lemon 1*2*7
     * Flower: Pear, Strawberry, Watermelon 1*3*5
     * Primordial: Banana, Apple, Cherry 2*13*19
     * Ghost: Strawberry, Lemon, Avocado 3*7*17
     * Camouflage: Watermelon, Orange, Apple 5*11*13
     * Neon: Watermelon, Orange, Avocado 5*11*17
     * Winged: Lemon, Avocado, Cherry 7*17*19
     * Alloyed: Orange, Apple, Cherry 11*13*19
    */
}