using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.Types;

namespace Momo.PlayerInformation
{
    public class Inventory
    {
        private Dictionary<FruitType, int> fruitsInPosession;
        private Dictionary<BaseMonsterType, int> eggsInPosession;
        private Dictionary<BaseMonsterType, int> babyMonsterInPosession;
        private Dictionary<GrownMonsterType, int> grownMonsterInPosession;

        public Inventory()
        {
            fruitsInPosession = new Dictionary<FruitType, int>();
            eggsInPosession = new Dictionary<BaseMonsterType, int>();
            babyMonsterInPosession = new Dictionary<BaseMonsterType, int>();
            grownMonsterInPosession = new Dictionary<GrownMonsterType, int>();
        }

        #region add / remove items to / from inventory
        public void AddItemToInventory(FruitType fruit, int amount = 1)
        {
            if (fruitsInPosession.ContainsKey(fruit))
                fruitsInPosession[fruit] += amount;
            else
                fruitsInPosession.Add(fruit, amount);
        }
        public void RemoveItemFromInventory(FruitType fruit, int amount = 1)
        {
            if (fruitsInPosession.ContainsKey(fruit))
                fruitsInPosession[fruit] -= amount;
            if (fruitsInPosession[fruit] < 0)
                fruitsInPosession[fruit] = 0;
        }
        public void AddItemToInventory(BaseMonsterType baseMonster, bool hatched, int amount = 1)
        {
            if (hatched)
            {
                if (babyMonsterInPosession.ContainsKey(baseMonster))
                    babyMonsterInPosession[baseMonster] += amount;
                else
                    babyMonsterInPosession.Add(baseMonster, amount);
            }
            else
            {
                if (eggsInPosession.ContainsKey(baseMonster))
                    eggsInPosession[baseMonster] += amount;
                else
                    eggsInPosession.Add(baseMonster, amount);
            }
        }
        public void RemoveItemFromInventory(BaseMonsterType baseMonster, bool hatched, int amount = 1)
        {
            if (hatched)
            {
                if (babyMonsterInPosession.ContainsKey(baseMonster))
                    babyMonsterInPosession[baseMonster] -= amount;
                if (babyMonsterInPosession[baseMonster] < 0)
                    babyMonsterInPosession[baseMonster] = 0;
            }
            else
            {
                if (eggsInPosession.ContainsKey(baseMonster))
                    eggsInPosession[baseMonster] -= amount;
                if (eggsInPosession[baseMonster] < 0)
                    eggsInPosession[baseMonster] = 0;
            }
        }
        public void AddItemToInventory(GrownMonsterType grownMonster, int amount = 1)
        {
            if (grownMonster == GrownMonsterType.None) return;

            if (grownMonsterInPosession.ContainsKey(grownMonster))
                grownMonsterInPosession[grownMonster] += amount;
            else
                grownMonsterInPosession.Add(grownMonster, amount);
        }
        public void RemoveItemFromInventory(GrownMonsterType grownMonster, int amount = 1)
        {
            if (grownMonster == GrownMonsterType.None) return;

            if (grownMonsterInPosession.ContainsKey(grownMonster))
                grownMonsterInPosession[grownMonster] -= amount;
            if (grownMonsterInPosession[grownMonster] < 0)
                grownMonsterInPosession[grownMonster] = 0;
        }
        #endregion

        #region get possession
        public Dictionary<FruitType, int> getFruitsInPosession()
        {
            return fruitsInPosession;
        }
        public Dictionary<BaseMonsterType, int> getEggsInPosession()
        {
            return eggsInPosession;
        }
        public Dictionary<BaseMonsterType, int> getBabyMonsterInPosession()
        {
            return babyMonsterInPosession;
        }
        public Dictionary<GrownMonsterType, int> getGrownMonsterInPosession()
        {
            return grownMonsterInPosession;
        }
        #endregion

        #region Debug
        public void DebugInventory()
        {
            string debugFruits = "Fruits: ";
            string debugEggs = "Eggs: ";
            string debugBabyMonster = "BabyMonster: ";
            string debugGrownMonster = "GrownMonster: ";

            foreach (KeyValuePair<FruitType, int> item in fruitsInPosession)
                debugFruits += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<BaseMonsterType, int> item in eggsInPosession)
                debugEggs += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<BaseMonsterType, int> item in babyMonsterInPosession)
                debugBabyMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<GrownMonsterType, int> item in grownMonsterInPosession)
                debugGrownMonster += item.Value + " " + item.Key.ToString() + "; ";

            Debug.Log(debugFruits);
            Debug.Log(debugEggs);
            Debug.Log(debugBabyMonster);
            Debug.Log(debugGrownMonster);
        }
        #endregion
    }
}
