using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Momo.Adventure;

namespace Momo.PanelManager.SceneUI
{
    public class DummyAdventureScenePM : MonoBehaviour
    {
        private Button goBack;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            goBack = uiDocument.rootVisualElement.Q("GoBack") as Button;

            goBack.RegisterCallback<ClickEvent>(ChangeToMainScene);
        }
        private void OnDisable()
        {
            goBack.UnregisterCallback<ClickEvent>(ChangeToMainScene);
        }


        private void ChangeToMainScene(ClickEvent evt)
        {
            DummyGoOnAdventure.GoOnAdventure();
            SceneManager.LoadScene("Main");
        }
    }
}
