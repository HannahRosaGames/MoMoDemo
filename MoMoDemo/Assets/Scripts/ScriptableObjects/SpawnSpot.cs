using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;

namespace Momo.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SpawnSpot")]
    public class SpawnSpot : ScriptableObject
    {
        public Coordinates Position;
        public int LootChancesPercentage;
        public Fruit[] FruitsDistributionChances;
        public Egg[] EggDistributionChances;

        public Loot GenerateLootUncertain()
        {
            if (!IsLootGenerated())
                return null;

            return GenerateLootCertain();
        }

        public Loot GenerateLootCertain()
        {
            List<Loot> loot = new List<Loot>();
            loot = EggDistributionChances.ToList<Loot>();
            loot.AddRange(FruitsDistributionChances.ToList<Loot>());

            int numberRange = loot.Count;
            int randomNumber = Random.Range(0, numberRange);

            return loot[randomNumber];
        }

        private bool IsLootGenerated()
        {
            if (LootChancesPercentage < Random.Range(1, 101))
                return false;
            else
                return true;
        }
    }
}