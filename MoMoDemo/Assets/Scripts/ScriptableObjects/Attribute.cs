using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Attribute")]
    public class Attribute : ScriptableObject
    {
        public string attributeName;
        public int attributePrimeID;
    }
}
