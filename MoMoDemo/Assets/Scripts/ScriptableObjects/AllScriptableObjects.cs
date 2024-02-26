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
        private static List<Attribute> allAttributes = new List<Attribute>();
        private static List<People> allPeople = new List<People>();

        static AllScriptableObjects()
        {
            FillAllFruits();
            FillAllEggs();
            FillAllBabyMonster();
            FillAllGrownMonster();
            FillAllAttributes();
            FillAllPeople();
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
        public static List<Attribute> GetAllAttributes()
        {
            return allAttributes;
        }
        public static List<People> GetAllPeople()
        {
            return allPeople;
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
            string[] babyMonsterAssetNames = FindAllScriptableObjects("Fruits");
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
            string[] grownMonsterAssetNames = FindAllScriptableObjects("Fruits");
            foreach (string assetName in grownMonsterAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                GrownMonster grownMonster = AssetDatabase.LoadAssetAtPath<GrownMonster>(assetPath);
                allGrownMonster.Add(grownMonster);
            }
        }
        private static void FillAllAttributes()
        {
            allAttributes.Clear();
            string[] attributesAssetNames = FindAllScriptableObjects("Attributes");
            foreach (string assetName in attributesAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                Attribute attribute = AssetDatabase.LoadAssetAtPath<Attribute>(assetPath);
                allAttributes.Add(attribute);
            }
        }
        private static void FillAllPeople()
        {
            allPeople.Clear();
            string[] peopleAssetNames = FindAllScriptableObjects("Fruits");
            foreach (string assetName in peopleAssetNames)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(assetName);
                People people = AssetDatabase.LoadAssetAtPath<People>(assetPath);
                allPeople.Add(people);
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
