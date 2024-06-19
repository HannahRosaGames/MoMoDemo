using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace Momo.PanelManager.NotesUI
{
    public class NotesScenePM : MonoBehaviour
    {
        private Button exit;
        private Button monsterNote;
        private Button fruitNote;
        private Button itemNote;
        private Button placeNote;
        private Button peopleNote;

        private void OnEnable()
        {
            var uiDocument = GetComponent<UIDocument>();
            exit = uiDocument.rootVisualElement.Q("Exit") as Button;
            monsterNote = uiDocument.rootVisualElement.Q("toMonsterNote") as Button;
            fruitNote = uiDocument.rootVisualElement.Q("toFruitNote") as Button;
            itemNote = uiDocument.rootVisualElement.Q("toItemNote") as Button;
            placeNote = uiDocument.rootVisualElement.Q("toPlaceNote") as Button;
            peopleNote = uiDocument.rootVisualElement.Q("toPeopleNote") as Button;

            exit.RegisterCallback<ClickEvent>(ChangeToMainScene);
            monsterNote.RegisterCallback<ClickEvent>(ChangeToMonsterNoteScene);
            fruitNote.RegisterCallback<ClickEvent>(ChangeToFruitNoteScene);
            itemNote.RegisterCallback<ClickEvent>(ChangeToItemNoteScene);
            placeNote.RegisterCallback<ClickEvent>(ChangeToPlaceNoteScene);
            peopleNote.RegisterCallback<ClickEvent>(ChangeToPeopleNoteScene);
        }
        private void OnDisable()
        {
            exit.UnregisterCallback<ClickEvent>(ChangeToMainScene);
            monsterNote.UnregisterCallback<ClickEvent>(ChangeToMonsterNoteScene);
            fruitNote.UnregisterCallback<ClickEvent>(ChangeToFruitNoteScene);
            itemNote.UnregisterCallback<ClickEvent>(ChangeToItemNoteScene);
            placeNote.UnregisterCallback<ClickEvent>(ChangeToPlaceNoteScene);
            peopleNote.UnregisterCallback<ClickEvent>(ChangeToPeopleNoteScene);
        }


        private void ChangeToMainScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Main");
        }


        private void ChangeToMonsterNoteScene(ClickEvent evt)
        {
            SceneManager.LoadScene("MonsterNote");
        }


        private void ChangeToFruitNoteScene(ClickEvent evt)
        {
            SceneManager.LoadScene("FruitNote");
        }


        private void ChangeToItemNoteScene(ClickEvent evt)
        {
            SceneManager.LoadScene("ItemNote");
        }


        private void ChangeToPlaceNoteScene(ClickEvent evt)
        {
            SceneManager.LoadScene("PlaceNote");
        }


        private void ChangeToPeopleNoteScene(ClickEvent evt)
        {
            SceneManager.LoadScene("PeopleNote");
        }
    }
}
