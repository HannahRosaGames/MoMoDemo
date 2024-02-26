using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;

public static class demoCombine
{
    public static Attribute CombineFruits(Fruit firstFruit, Fruit secondFruit, Fruit thirdFruit)
    {
        int result = firstFruit.fruitPrimeID * secondFruit.fruitPrimeID * thirdFruit.fruitPrimeID;

        List<Attribute> allAttributes = AllScriptableObjects.GetAllAttributes();
        foreach (Attribute attribute in allAttributes)
        {
            if (attribute.attributePrimeID == result)
                return attribute;
        }
        return null;
        /*switch (result)
        {
            case 6:
                return AttributeType.Emo;
            case 14:
                return AttributeType.Lowpoly;
            case 15:
                return AttributeType.Flower;
            case 357:
                return AttributeType.Ghost;
            case 494:
                return AttributeType.Primordial;
            case 715:
                return AttributeType.Camouflage;
            case 935:
                return AttributeType.Neon;
            case 2261:
                return AttributeType.Winged;
            case 2717:
                return AttributeType.Alloyed;
            default:
                return AttributeType.None;
    }*/
    }
}
