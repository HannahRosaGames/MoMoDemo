using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.MonsterManagerScene
{
    public class NewObtainedOverlayPanelManager : MonoBehaviour
    {
        private MonsterManager monsterManager;
        #region Monster Manager Initialization
        [SerializeField] private GameObject monsterManagerGameObject;
        public void OnEnable()
        {
            monsterManager = monsterManagerGameObject.GetComponent<MonsterManager>();
        }
        public void OnDisable()
        {
            monsterManagerGameObject = null;
        }
        #endregion

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
