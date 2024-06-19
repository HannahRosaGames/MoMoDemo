using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;

namespace Momo.PlayerInformation
{
    public class Dicovered
    {
        [SerializeField] private Dictionary<Fruit, bool> fruitsDiscovered;
        private Dictionary<Egg, bool> eggsDiscovered;
        private Dictionary<BabyMonster, bool> babyMonsterDiscovered;
        private Dictionary<GrownMonster, bool> grownMonsterDiscovered;
        private Dictionary<Element, bool> elementsDiscovered;
        private Dictionary<int, bool> fruitCombinationsDiscovered;
        private Dictionary<People, bool> peopleDiscovered;

        public Dicovered()
        {
            fruitsDiscovered = new Dictionary<Fruit, bool>();
            eggsDiscovered = new Dictionary<Egg, bool>();
            babyMonsterDiscovered = new Dictionary<BabyMonster, bool>();
            grownMonsterDiscovered = new Dictionary<GrownMonster, bool>();
            elementsDiscovered = new Dictionary<Element, bool>();
            fruitCombinationsDiscovered = new Dictionary<int, bool>();
            peopleDiscovered = new Dictionary<People, bool>();

            FillDictonaries();
        }

        #region Fill Dictonaries
        private void FillDictonaries()
        {
            List<Fruit> allFruits = AllScriptableObjects.GetAllFruits();
            List<Egg> allEggs = AllScriptableObjects.GetAllEggs();
            List<BabyMonster> allBabyMonster = AllScriptableObjects.GetAllBabyMonster();
            List<GrownMonster> allGrownMonster = AllScriptableObjects.GetAllGrownMonster();
            List<Element> allElements = AllScriptableObjects.GetAllElements();
            List<People> allPeople = AllScriptableObjects.GetAllPeople();

            FillFruitDictonary(allFruits);
            FillFruitCombinationDictonary(allFruits);
            FillEggsDictonary(allEggs);
            FillBabyMonsterDictonary(allBabyMonster);
            FillGrownMonsterDictonary(allGrownMonster);
            FillElementsDictonary(allElements);
            FillPeopleDictonary(allPeople);
        }
        private void FillFruitDictonary(List<Fruit> allFruits)
        {
            foreach (Fruit fruit in allFruits)
                fruitsDiscovered.Add(fruit, false);
        }
        private void FillFruitCombinationDictonary(List<Fruit> allFruits)
        {
            int count = allFruits.Count;
            for (int firstFruitIndex = 0; firstFruitIndex < count; firstFruitIndex++)
                for (int secondFruitIndex = firstFruitIndex; secondFruitIndex < count; secondFruitIndex++)
                    for (int thirdFruitIndex = secondFruitIndex; thirdFruitIndex < count; thirdFruitIndex++)
                        fruitCombinationsDiscovered.Add(allFruits[firstFruitIndex].PrimeID * allFruits[secondFruitIndex].PrimeID * allFruits[thirdFruitIndex].PrimeID, false);
        }
        private void FillEggsDictonary(List<Egg> allEggs)
        {
            foreach (Egg egg in allEggs)
                eggsDiscovered.Add(egg, false);
        }
        private void FillBabyMonsterDictonary(List<BabyMonster> allBabyMonster)
        {
            foreach (BabyMonster babyMonster in allBabyMonster)
                babyMonsterDiscovered.Add(babyMonster, false);
        }
        private void FillGrownMonsterDictonary(List<GrownMonster> allGrownMonster)
        {
            foreach (GrownMonster grownMonster in allGrownMonster)
                grownMonsterDiscovered.Add(grownMonster, false);
        }
        private void FillElementsDictonary(List<Element> allElements)
        {
            foreach (Element element in allElements)
                elementsDiscovered.Add(element, false);
        }
        private void FillPeopleDictonary(List<People> allPeople)
        {
            foreach (People people in allPeople)
                peopleDiscovered.Add(people, false);
        }
        #endregion

        #region [] modificator
        public bool this[Fruit fruitType]
        {
            get { return fruitsDiscovered[fruitType]; }
        }
        public bool this[Egg eggType]
        {
            get { return eggsDiscovered[eggType]; }
        }
        public bool this[BabyMonster babyMonsterType]
        {
            get { return babyMonsterDiscovered[babyMonsterType]; }
        }
        public bool this[GrownMonster grownMonsterType]
        {
            get { return grownMonsterDiscovered[grownMonsterType]; }
        }
        public bool this[Element elementType]
        {
            get { return elementsDiscovered[elementType]; }
        }
        public bool this[int fruitCombination]
        {
            get { return fruitCombinationsDiscovered[fruitCombination]; }
        }
        public bool this[Fruit firstFruit, Fruit secondFruit, Fruit thirdFruit]
        {
            get { return fruitCombinationsDiscovered[firstFruit.PrimeID * secondFruit.PrimeID * thirdFruit.PrimeID]; }
        }
        public bool this[People personType]
        {
            get { return peopleDiscovered[personType]; }
        }
        #endregion

        #region Found
        public void Found(Fruit fruitType)
        {
            fruitsDiscovered[fruitType] = true;
        }
        public void Found(Egg eggType)
        {
            eggsDiscovered[eggType] = true;
        }
        public void Found(BabyMonster babyMonsterType)
        {
            babyMonsterDiscovered[babyMonsterType] = true;
        }
        public void Found(GrownMonster grownMonsterType)
        {
            grownMonsterDiscovered[grownMonsterType] = true;
        }
        public void Found(Element element)
        {
            elementsDiscovered[element] = true;
        }
        public void Found(int fruitCombination)
        {
            fruitCombinationsDiscovered[fruitCombination] = true;
        }
        public void Found(Fruit firstFruit, Fruit secondFruit, Fruit thirdFruit)
        {
            fruitCombinationsDiscovered[firstFruit.PrimeID * secondFruit.PrimeID * thirdFruit.PrimeID] = true;
        }
        public void Found(People personType)
        {
            peopleDiscovered[personType] = true;
        }
        #endregion

        #region Debug
        public void DebugDiscovered()
        {
            string debugFruits = "Fruits discovered: ";
            string debugEgg = "Egg discovered: ";
            string debugBabyMonster = "BabyMonster discovered: ";
            string debugGrownMonster = "GrownMonster discovered: ";
            string debugElement = "Elements discovered: ";
            string debugPeople = "People discovered: ";

            foreach (KeyValuePair<Fruit, bool> item in fruitsDiscovered)
                debugFruits += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<Egg, bool> item in eggsDiscovered)
                debugEgg += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<BabyMonster, bool> item in babyMonsterDiscovered)
                debugBabyMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<GrownMonster, bool> item in grownMonsterDiscovered)
                debugGrownMonster += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<Element, bool> item in elementsDiscovered)
                debugElement += item.Value + " " + item.Key.ToString() + "; ";
            foreach (KeyValuePair<People, bool> item in peopleDiscovered)
                debugPeople += item.Value + " " + item.Key.ToString() + "; ";

            Debug.Log(debugFruits);
            Debug.Log(debugEgg);
            Debug.Log(debugBabyMonster);
            Debug.Log(debugGrownMonster);
            Debug.Log(debugElement);
            Debug.Log(debugPeople);
        }
        #endregion
    }
}
