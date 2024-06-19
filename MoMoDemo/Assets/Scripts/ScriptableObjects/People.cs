using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/People")]
    public class People : ScriptableObject
    {
        public string Name;
        public string Description;
        public string Hint;
        public Color Color;
        //places
        //public  Perk perk;
        //public string boni;
        //public FruitTrade[] fruitTrade;
        //public EggTrade eggTrade;
    }
}

/*
 * Hilbert - "A little man." - "no clue" - yellow - 3 Duck Egg for 1 Goat Egg
 * Susi - "That's Susi. Obvious." - "no clue" - white - 5 Goat Egg for 1 Bear Egg
 * HanHan - "A little woman." - "no clue" - magenta - 10 Pear for 2 Watermelon
 * Don - "That's not Susi. For sure." - "no clue" - blue - 10 Watermelon for 1 Apple
 * Little Goblin - "Also a little man." - "no clue" - green - a gigher chance for loot at all
 * YouDon'tSeeMe - "The Don't is just a title." - "no clue" - black - higher chance of better loot
 */