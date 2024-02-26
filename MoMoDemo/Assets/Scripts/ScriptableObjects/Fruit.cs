using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Fruit")]
    public class Fruit : ScriptableObject
    {
        public string fruitName;
        public Attribute[] attributes;
        public Color fruitColor;
        public int fruitPrimeID;
        }
}
