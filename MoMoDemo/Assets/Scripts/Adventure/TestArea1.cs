using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Momo.Adventure
{
    public class TestArea1 : MonoBehaviour
    {
        private VisualElement fruitSpot1;
        private VisualElement fruitSpot2;
        private VisualElement fruitSpot3;
        private VisualElement fruitSpot4;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            fruitSpot1 = uiDocument.rootVisualElement.Q("FruitSpot1") as VisualElement;
            fruitSpot2 = uiDocument.rootVisualElement.Q("FruitSpot2") as VisualElement;
            fruitSpot3 = uiDocument.rootVisualElement.Q("FruitSpot3") as VisualElement;
            fruitSpot4 = uiDocument.rootVisualElement.Q("FruitSpot4") as VisualElement;

            SpawnFruits();
        }

        private void Start()
        {
            StartCoroutine(GoBackAfter5s());
            SpawnFruits();
        }

        IEnumerator GoBackAfter5s()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Main");
        }

        private void SpawnFruits()
        {

        }
    }
}
