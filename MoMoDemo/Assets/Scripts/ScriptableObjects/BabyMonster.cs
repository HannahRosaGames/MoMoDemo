using UnityEngine;
using System;
using System.Collections.Generic;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BabyMonster")]
    public class BabyMonster : ScriptableObject
    {
        public string Name;
        public Evolution[] Evolutions;
        public GrownMonster GetEvolutionBasedOnElement(Element element)
        {
            foreach (Evolution evolution in Evolutions)
                if (evolution.Element == element) return evolution.GrownMonster;

            return null;
        }
    }

    [System.Serializable]
    public struct Evolution
    {
        public Element Element;
        public GrownMonster GrownMonster;
    }
}
