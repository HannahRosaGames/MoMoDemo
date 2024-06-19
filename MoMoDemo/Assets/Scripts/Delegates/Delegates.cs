using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;


namespace Momo.Delegates
{
    public delegate void NameAmountEvent(string name, int amount);
    public delegate void StringEvent(string text);
    public delegate void IntEvent(int number);
    public delegate void GrownMonsterEvent(GrownMonster grownMonster);
    public delegate void FruitAmountEvent(Fruit fruit, int fruitAmount);
    public delegate void FruitSpotEvent(int fruitSpotArrayIndex, Fruit fruit, string[] elements);
    public delegate void AreaEvent(Area area);
    public delegate void EggAmountEvent(Egg egg, int amount);
}
