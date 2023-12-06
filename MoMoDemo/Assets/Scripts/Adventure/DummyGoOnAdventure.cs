using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.Types;
using Momo.PlayerInformation;
using System;

namespace Momo.Adventure
{
    public static class DummyGoOnAdventure
    {
        public static void GoOnAdventure()
        {
            /*
            Pear = 90%
            Banana = 80%
            Strawberry = 70%
            Watermelon = 60%
            Lemon = 50%
            Orange = 40%
            Apple = 30%
            Avocado = 20%
            Cherry = 10%
            */

            /*if (Random.Range(1, 10) > 1)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Pear);
            if (Random.Range(1, 10) > 2)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Banana);
            if (Random.Range(1, 10) > 3)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Strawberry);
            if (Random.Range(1, 10) > 4)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Watermelon);
            if (Random.Range(1, 10) > 5)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Lemon);
            if (Random.Range(1, 10) > 6)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Orange);
            if (Random.Range(1, 10) > 7)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Apple);
            if (Random.Range(1, 10) > 8)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Avocado);
            if (Random.Range(1, 10) > 9)
                PlayerInformation.Instance.inventory.addItemToInventory(FruitType.Cherry);*/
            /*
            FruitType foundFruit = (FruitType)Random.Range(1, 10);
            BaseMonsterType foundBaseMonster = (BaseMonsterType)Random.Range(0, 3);
            GrownMonsterType foundGrownMonster = (GrownMonsterType)Random.Range(1, 28);

            Player.Instance.inventory.AddItemToInventory(foundFruit);
            Player.Instance.inventory.AddItemToInventory(foundBaseMonster, false);
            Player.Instance.inventory.AddItemToInventory(foundGrownMonster);

            Player.Instance.discovered.Found(foundFruit);
            Player.Instance.discovered.Found(foundBaseMonster);
            Player.Instance.discovered.Found(foundGrownMonster);
            */

            foreach (int i in Enum.GetValues(typeof(FruitType)))
                if(i != 0)
                    Player.Instance.inventory.AddItemToInventory((FruitType)i, 10);
            foreach (int i in Enum.GetValues(typeof(BaseMonsterType)))
                Player.Instance.inventory.AddItemToInventory((BaseMonsterType)i, false, 10);

            GrownMonsterType activeMonster = Player.Instance.GetActiveMonster();
            if (activeMonster == GrownMonsterType.None)
                Debug.Log("No Monster was used up.");
            else
                Debug.Log(activeMonster + " run away.");
            Player.Instance.UseUpActiveMonster();
        }
    }
}
