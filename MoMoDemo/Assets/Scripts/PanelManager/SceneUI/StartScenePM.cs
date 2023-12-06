using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Momo.PanelManager.SceneUI
{
    public class StartScenePM : MonoBehaviour
    {
        private Button startAdventure;
        public GameObject player;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            startAdventure = uiDocument.rootVisualElement.Q("Start") as Button;

            startAdventure.RegisterCallback<ClickEvent>(ChangeToMainScene);
        }
        private void OnDisable()
        {
            startAdventure.UnregisterCallback<ClickEvent>(ChangeToMainScene);
        }


        private void ChangeToMainScene(ClickEvent evt)
        {
            GameObject createdPlayer = Instantiate(player);
            DontDestroyOnLoad(createdPlayer);
            SceneManager.LoadScene("Main");
        }
    }
}
