using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;

namespace Momo.PanelManager.SceneUI
{
    public class MainScenePM : MonoBehaviour
    {
        private Button setting;
        private Button quicktravel;
        private Button monsterSelect;
        private Button notes;
        private Button dummyAdventure;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            setting = uiDocument.rootVisualElement.Q("Setting") as Button;
            quicktravel = uiDocument.rootVisualElement.Q("Quicktravel") as Button;
            monsterSelect = uiDocument.rootVisualElement.Q("MonsterSelect") as Button;
            notes = uiDocument.rootVisualElement.Q("Notes") as Button;
            dummyAdventure = uiDocument.rootVisualElement.Q("Adventure") as Button;

            setting.RegisterCallback<ClickEvent>(ChangeToSettingScene);
            quicktravel.RegisterCallback<ClickEvent>(ChangeToQuicktravelScene);
            monsterSelect.RegisterCallback<ClickEvent>(ChangeToMonsterSelectScene);
            notes.RegisterCallback<ClickEvent>(ChangeToNotesScene);
            dummyAdventure.RegisterCallback<ClickEvent>(ChangeToAdventureScene);
        }
        private void OnDisable()
        {
            setting.UnregisterCallback<ClickEvent>(ChangeToSettingScene);
            quicktravel.UnregisterCallback<ClickEvent>(ChangeToQuicktravelScene);
            monsterSelect.UnregisterCallback<ClickEvent>(ChangeToMonsterSelectScene);
            notes.UnregisterCallback<ClickEvent>(ChangeToNotesScene);
            dummyAdventure.UnregisterCallback<ClickEvent>(ChangeToAdventureScene);
        }


        private void ChangeToSettingScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Setting");
        }


        private void ChangeToQuicktravelScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Quicktravel");
        }


        private void ChangeToMonsterSelectScene(ClickEvent evt)
        {
            SceneManager.LoadScene("MonsterManager");
        }


        private void ChangeToNotesScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Notes");
        }


        private void ChangeToAdventureScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Adventure");
        }
    }
}
