using System.Collections.Generic;
using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Area")]
    public class Area : ScriptableObject
    {
        public int RangeNeeded;
        public string Name;
        public SpawnSpot[] SpawnSpots;
        public Area FollowingArea;
        public SpecialWay SpecialWay;
        public Sprite Background;

        public bool IsSpecialWayAvailable()
        {
            return SpecialWay.available;
        }
    }

    [System.Serializable]
    public struct SpecialWay
    {
        public bool available;
        public Area area;
        public Coordinates Coordinates;
    }

    [System.Serializable]
    public struct Coordinates
    {
        public int x;
        public int y;
    }
}
