using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.PanelManager.MonsterSelectUI
{
    public class NewObtainedOverlayPM : MonoBehaviour
    {
        private Button closeOverlay;
        private Label obtained;
        private Label monsterName;

        #region Open / Close Overlay
        public void OverlayOpen(string obtainedText, string monsterNameText)
        {
            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            obtained = uiDocument.rootVisualElement.Q("Obtained") as Label;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;

            obtained.text = obtainedText;
            monsterName.text = monsterNameText;

            closeOverlay.RegisterCallback<ClickEvent>(CloseOverlay);
        }
        private void OverlayClosed()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(CloseOverlay);
        }
        private void CloseOverlay(ClickEvent evt)
        {
            GetComponent<UIDocument>().enabled = false;
            OverlayClosed();
        }
        #endregion
    }
}
