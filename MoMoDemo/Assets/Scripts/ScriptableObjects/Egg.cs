using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Egg")]
    public class Egg : ScriptableObject, Loot
    {
        public string Name;
        public BabyMonster Into;
        public Color Color;
    }
}