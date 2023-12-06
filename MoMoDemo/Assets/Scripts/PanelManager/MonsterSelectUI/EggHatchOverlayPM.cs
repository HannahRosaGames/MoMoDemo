using UnityEngine;
using UnityEngine.UIElements;
using Momo.Types;
using Momo.PlayerInformation;

namespace Momo.PanelManager.MonsterSelectUI
{
    public class EggHatchOverlayPM : MonoBehaviour
    {
        private BaseMonsterType selectedEgg;
        private int eggAmount;

        private Button closeOverlay;
        private Button hatch;
        private Button hatchAll;
        private Label monsterName;

        #region Open / Close Overlay
        public void OverlayOpen(BaseMonsterType monster, int monsterAmount)
        {
            selectedEgg = monster;
            eggAmount = monsterAmount;

            UIDocument uiDocument = GetComponent<UIDocument>();
            closeOverlay = uiDocument.rootVisualElement.Q("CloseOverlay") as Button;
            hatch = uiDocument.rootVisualElement.Q("Hatch") as Button;
            hatchAll = uiDocument.rootVisualElement.Q("HatchAll") as Button;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;

            monsterName.text = selectedEgg.ToString() + " x " + eggAmount;

            closeOverlay.RegisterCallback<ClickEvent>(CloseOverlay);
            hatch.RegisterCallback<ClickEvent>(Hatch);
            hatchAll.RegisterCallback<ClickEvent>(HatchAll);
        }
        private void OverlayClosed()
        {
            closeOverlay.UnregisterCallback<ClickEvent>(CloseOverlay);
            hatch.UnregisterCallback<ClickEvent>(Hatch);
            hatchAll.UnregisterCallback<ClickEvent>(HatchAll);
        }
        private void CloseOverlay(ClickEvent evt)
        {
            GetComponent<UIDocument>().enabled = false;
            OverlayClosed();
        }
        #endregion

        #region Hatch
        private void Hatch(ClickEvent evt)
        {
            Player.Instance.inventory.RemoveItemFromInventory(selectedEgg, false);
            Player.Instance.inventory.AddItemToInventory(selectedEgg, true);
            CloseOverlay(evt);
            GameObject.Find("MonsterSelectSceneUI").GetComponent<MonsterSelectScenePM>().ReloadInventory();

            GameObject.Find("NewObtainedOverlayUI").GetComponent<UIDocument>().enabled = true;
            GameObject.Find("NewObtainedOverlayUI").GetComponent<NewObtainedOverlayPM>().OverlayOpen("a baby Monster", selectedEgg.ToString());
        }
        private void HatchAll(ClickEvent evt)
        {
            Player.Instance.inventory.RemoveItemFromInventory(selectedEgg, false, eggAmount);
            Player.Instance.inventory.AddItemToInventory(selectedEgg, true, eggAmount);
            CloseOverlay(evt);
            GameObject.Find("MonsterSelectSceneUI").GetComponent<MonsterSelectScenePM>().ReloadInventory();

            GameObject.Find("NewObtainedOverlayUI").GetComponent<UIDocument>().enabled = true;
            GameObject.Find("NewObtainedOverlayUI").GetComponent<NewObtainedOverlayPM>().OverlayOpen("baby Monster", selectedEgg.ToString() + " x " + eggAmount);
        }
        #endregion
    }

}
