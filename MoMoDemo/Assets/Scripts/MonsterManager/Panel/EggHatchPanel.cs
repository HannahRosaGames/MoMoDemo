using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.MonsterManagerScene.Panel
{
    public class EggHatchPanel : MonoBehaviour
    {
        // The logic for this panel can be accessed with EggHatch.Instance

        private Button closeOverlay;
        private Button hatch;
        private Button hatchAll;
        private Label monsterName;

        public void OnEnable()
        {
            RegisterUIElements();
            SubscribeToButtonEvents();
            SubscribeToLogicEvents();
            LoadContent();
        }

        #region OnEnable
        private void RegisterUIElements()
        {
            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            hatch = uiDocument.rootVisualElement.Q("Hatch") as Button;
            hatchAll = uiDocument.rootVisualElement.Q("HatchAll") as Button;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;
        }
        private void SubscribeToButtonEvents()
        {
            closeOverlay.RegisterCallback<ClickEvent>(OnCloseOverlayClicked);
            hatch.RegisterCallback<ClickEvent>(OnHatchClicked);
            hatchAll.RegisterCallback<ClickEvent>(OnHatchAllClicked);
        }
        private void SubscribeToLogicEvents()
        {
            EggHatch.Instance.LoadSelectedEgg += OnLoadSelectedEgg;
        }
        private void LoadContent()
        {
            EggHatch.Instance.LoadContent();
        }
        #endregion

        public void OnDisable()
        {
            UnsubscribeToButtonEvents();
            UnsubscribeToLogicEvents();
        }

        #region OnDisable
        private void UnsubscribeToButtonEvents()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(OnCloseOverlayClicked);
            hatch.UnregisterCallback<ClickEvent>(OnHatchClicked);
            hatchAll.UnregisterCallback<ClickEvent>(OnHatchAllClicked);
        }
        private void UnsubscribeToLogicEvents()
        {
            EggHatch.Instance.LoadSelectedEgg -= OnLoadSelectedEgg;
        }
        #endregion

        #region On EggHatch Event Handling
        private void OnLoadSelectedEgg(string eggName, int eggAmount)
        {
            monsterName.text = eggName + " x " + eggAmount;
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnCloseOverlayClicked(ClickEvent evt)
        {
            EggHatch.Instance.OnCloseOverlayClicked();
        }
        private void OnHatchClicked(ClickEvent evt)
        {
            EggHatch.Instance.OnHatchClicked();
        }
        private void OnHatchAllClicked(ClickEvent evt)
        {
            EggHatch.Instance.OnHatchAllClicked();
        }
        #endregion
    }
}
