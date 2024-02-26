using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/People")]
    public class People : ScriptableObject
    {
        public string peopleName;
        public string peopleDescription;
        public string peopleHint;
        public Color peopleColor;
        //places
        //public  Perk perk;
        //public string boni;
        //public FruitTrade[] fruitTrade;
        //public EggTrade eggTrade;
    }
}
