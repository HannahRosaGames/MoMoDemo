using UnityEngine;
using System.Collections.Generic;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BabyMonster")]
    public class BabyMonster : ScriptableObject
    {
        public string babyMonsterName;
        public Evolution[] evolutions;
    }

    [System.Serializable]
    public struct Evolution
    {
        public Attribute attribute;
        public GrownMonster grownMonster;
    }
}
