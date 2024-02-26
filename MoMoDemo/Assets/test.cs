using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Momo.ScriptableObjects;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Fruit> allFruits = AllScriptableObjects.GetAllFruits();
        foreach (Fruit fruit in allFruits)
        {
            Debug.Log(fruit.fruitName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
