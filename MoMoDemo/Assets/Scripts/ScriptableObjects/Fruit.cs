using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Fruit")]
    public class Fruit : ScriptableObject, Loot
    {
        public string Name;
        public Element[] Elements;
        public Color Color;
        public int PrimeID;
        }
}

/*
 * Pear - 6EA829 - 1 - Emo Lowpoly Flower
 * Banana - A18214 - 2 - Emo Lowpoly Primordial
 * Strawberry - 8F0038 - 3 - Flower Emo Ghost
 * Watermelon - 369C38 - 5 - Camouflage Flower Neon
 * Lemon - B2CC00 - 7 - Ghost Lowpoly Winged
 * Orange - CC6E00 - 11 - Neon Camouflage Alloyed
 * Apple - B0121C - 13 - Alloyed Camouflage Primordial
 * Avocado - 1A6300 - 17 - Winged Ghost Neon
 * Cherry - 45000D - 19 - Primordial Winged Alloyed
 */