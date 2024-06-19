using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;

namespace Momo.PlayerInformation
{
    public class Inventory
    {
        private Dictionary<Fruit, int> fruitsInPosession;
        private Dictionary<Egg, int> eggsInPosession;
        private Dictionary<BabyMonster, int> babyMonsterInPosession;
        private Dictionary<GrownMonster, int> grownMonsterInPosession;

        public Inventory()
        {
            fruitsInPosession = new Dictionary<Fruit, int>();
            eggsInPosession = new Dictionary<Egg, int>();
            babyMonsterInPosession = new Dictionary<BabyMonster, int>();
            grownMonsterInPosession = new Dictionary<GrownMonster, int>();
        }

        #region add / remove items to / from inventory
        public void AddItemToInventory(Fruit fruit, int amount = 1)
        {
            if (fruit == null) return;
            if (amount < 1) return;

            if (fruitsInPosession.ContainsKey(fruit))
                fruitsInPosession[fruit] += amount;
            else
                fruitsInPosession.Add(fruit, amount);
        }
        public void RemoveItemFromInventory(Fruit fruit, int positiveAmount = 1)
        {
            if (fruit == null) return;
            if (positiveAmount < 1) return;

            if (fruitsInPosession.ContainsKey(fruit))
                fruitsInPosession[fruit] -= positiveAmount;
            if (fruitsInPosession[fruit] < 0)
                fruitsInPosession[fruit] = 0;
        }
        public void AddItemToInventory(Egg egg, int amount = 1)
        {
            if (egg == null) return;
            if (amount < 1) return;

            if (eggsInPosession.ContainsKey(egg))
                eggsInPosession[egg] += amount;
            else
                eggsInPosession.Add(egg, amount);
        }
        public void RemoveItemFromInventory(Egg egg, int positiveAmount = 1)
        {
            if (egg == null) return;
            if (positiveAmount < 1) return;

            if (eggsInPosession.ContainsKey(egg))
                eggsInPosession[egg] -= positiveAmount;
            if (eggsInPosession[egg] < 0)
                eggsInPosession[egg] = 0;
        }
        public void AddItemToInventory(BabyMonster babyMonster, int amount = 1)
        {
            if (babyMonster == null) return;
            if (amount < 1) return;

            if (babyMonsterInPosession.ContainsKey(babyMonster))
                babyMonsterInPosession[babyMonster] += amount;
            else
                babyMonsterInPosession.Add(babyMonster, amount);
        }
        public void RemoveItemFromInventory(BabyMonster babyMonster, int positiveAmount = 1)
        {
            if (babyMonster == null) return;
            if (positiveAmount < 1) return;

            if (babyMonsterInPosession.ContainsKey(babyMonster))
                babyMonsterInPosession[babyMonster] -= positiveAmount;
            if (babyMonsterInPosession[babyMonster] < 0)
                babyMonsterInPosession[babyMonster] = 0;
        }
        public void AddItemToInventory(GrownMonster grownMonster, int amount = 1)
        {
            if (grownMonster == null) return;
            if (amount < 1) return;

            if (grownMonsterInPosession.ContainsKey(grownMonster))
                grownMonsterInPosession[grownMonster] += amount;
            else
                grownMonsterInPosession.Add(grownMonster, amount);
        }
        public void RemoveItemFromInventory(GrownMonster grownMonster, int positiveAmount = 1)
        {
            if (grownMonster == null) return;
            if (positiveAmount < 1) return;

            if (grownMonsterInPosession.ContainsKey(grownMonster))
                grownMonsterInPosession[grownMonster] -= positiveAmount;
            if (grownMonsterInPosession[grownMonster] < 0)
                grownMonsterInPosession[grownMonster] = 0;
        }
        #endregion

        #region get possession
        public Dictionary<Fruit, int> getFruitsInPosession()
        {
            return fruitsInPosession;
        }
        public Dictionary<Egg, int> getEggsInPosession()
        {
            return eggsInPosession;
        }
        public Dictionary<BabyMonster, int> getBabyMonsterInPosession()
        {
            return babyMonsterInPosession;
        }
        public Dictionary<GrownMonster, int> getGrownMonsterInPosession()
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

            foreach (KeyValuePair<Fruit, int> item in fruitsInPosession)
                debugFruits += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<Egg, int> item in eggsInPosession)
                debugEggs += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<BabyMonster, int> item in babyMonsterInPosession)
                debugBabyMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<GrownMonster, int> item in grownMonsterInPosession)
                debugGrownMonster += item.Value + " " + item.Key.ToString() + "; ";

            Debug.Log(debugFruits);
            Debug.Log(debugEggs);
            Debug.Log(debugBabyMonster);
            Debug.Log(debugGrownMonster);
        }
        #endregion
    }
}
