using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GrownMonster")]
    public class GrownMonster : ScriptableObject
    {
        public string Name;
        public int Range;
    }
}
