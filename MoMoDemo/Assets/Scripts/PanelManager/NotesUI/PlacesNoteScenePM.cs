using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Momo.PanelManager.SceneUI
{
    public class PlacesNoteScenePM : MonoBehaviour
    {
        private Button exit;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            exit = uiDocument.rootVisualElement.Q("Exit") as Button;

            exit.RegisterCallback<ClickEvent>(ChangeToMainScene);
        }
        private void OnDisable()
        {
            exit.UnregisterCallback<ClickEvent>(ChangeToMainScene);
        }


        private void ChangeToMainScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Notes");
        }
    }
}
