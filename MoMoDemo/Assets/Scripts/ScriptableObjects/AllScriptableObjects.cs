using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Momo.ScriptableObjects
{
    public static class AllScriptableObjects
    {
        private static List<Fruit> allFruits = new List<Fruit>();
        private static List<Egg> allEggs = new List<Egg>();
        private static List<BabyMonster> allBabyMonster = new List<BabyMonster>();
        private static List<GrownMonster> allGrownMonster = new List<GrownMonster>();
        private static List<Element> allElements = new List<Element>();
        private static List<People> allPeople = new List<People>();
        private static List<Area> allAreas = new List<Area>();
        private static List<SpawnSpot> allSpawnSpots = new List<SpawnSpot>();

        static AllScriptableObjects()
        {
            FillAllFruits();
            FillAllEggs();
            FillAllBabyMonster();
            FillAllGrownMonster();
            FillAllElements();
            FillAllPeople();
            FillAllAreas();
            FillAllSpawnSpots();
        }

        #region Public Functions
        public static List<Fruit> GetAllFruits()
        {
            return allFruits;
        }
        public static List<Egg> GetAllEggs()
        {
            return allEggs;
        }
        public static List<BabyMonster> GetAllBabyMonster()
        {
            return allBabyMonster;
        }
        public static List<GrownMonster> GetAllGrownMonster()
        {
            return allGrownMonster;
        }
        public static List<Element> GetAllElements()
        {
            return allElements;
        }
        public static List<People> GetAllPeople()
        {
            return allPeople;
        }
        public static List<Area> GetAllAreas()
        {
            return allAreas;
        }
        public static List<SpawnSpot> GetAllSpawnSpots()
        {
            return allSpawnSpots;
        }
        #endregion

        #region Fill Lists
        private static void FillAllFruits()
        {
            allFruits.Clear();
            string[] fruitAssetNames = FindAllScriptableObjects("Fruits");
            foreach (string assetName in fruitAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                Fruit fruit = AssetDatabase.LoadAssetAtPath<Fruit>(assetPath);
                allFruits.Add(fruit);
            }
        }
        private static void FillAllEggs()
        {
            allEggs.Clear();
            string[] eggAssetNames = FindAllScriptableObjects("Eggs");
            foreach (string assetName in eggAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                Egg egg = AssetDatabase.LoadAssetAtPath<Egg>(assetPath);
                allEggs.Add(egg);
            }
        }
        private static void FillAllBabyMonster()
        {
            allBabyMonster.Clear();
            string[] babyMonsterAssetNames = FindAllScriptableObjects("BabyMonster");
            foreach (string assetName in babyMonsterAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                BabyMonster babyMonster = AssetDatabase.LoadAssetAtPath<BabyMonster>(assetPath);
                allBabyMonster.Add(babyMonster);
            }
        }
        private static void FillAllGrownMonster()
        {
            allGrownMonster.Clear();
            string[] grownMonsterAssetNames = FindAllScriptableObjects("GrownMonster");
            foreach (string assetName in grownMonsterAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                GrownMonster grownMonster = AssetDatabase.LoadAssetAtPath<GrownMonster>(assetPath);
                allGrownMonster.Add(grownMonster);
            }
        }
        private static void FillAllElements()
        {
            allElements.Clear();
            string[] elementAssetNames = FindAllScriptableObjects("Elements");
            foreach (string elementName in elementAssetNames)
            {
                string elementPath = AssetDatabase.GUIDToAssetPath(elementName);
                Element element = AssetDatabase.LoadAssetAtPath<Element>(elementPath);
                allElements.Add(element);
            }
        }
        private static void FillAllPeople()
        {
            allPeople.Clear();
            string[] peopleAssetNames = FindAllScriptableObjects("People");
            foreach (string assetName in peopleAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                People people = AssetDatabase.LoadAssetAtPath<People>(assetPath);
                allPeople.Add(people);
            }
        }
        private static void FillAllAreas()
        {
            allAreas.Clear();
            string[] areaAssetNames = FindAllScriptableObjects("Areas");
            foreach (string assetName in areaAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                Area area = AssetDatabase.LoadAssetAtPath<Area>(assetPath);
                allAreas.Add(area);
            }
        }
        private static void FillAllSpawnSpots()
        {
            allSpawnSpots.Clear();
            string[] spawnSpotAssetNames = FindAllScriptableObjects("SpawnSpots");
            foreach (string assetName in spawnSpotAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                SpawnSpot spawnSpot = AssetDatabase.LoadAssetAtPath<SpawnSpot>(assetPath);
                allSpawnSpots.Add(spawnSpot);
            }
        }

        private static string[] FindAllScriptableObjects (string folderName)
        {
            string directory = "Assets/ScriptableObjects/" + folderName;
            string[] assetNames = AssetDatabase.FindAssets(null, new[] { directory });
            return assetNames;
        }
        #endregion
    }
}
