using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Momo.Player;

namespace Momo.MonsterManagerScene
{
    public class MonsterManagerPanelManager : MonoBehaviour
    {
        private MonsterManager monsterManager;
        [SerializeField] private GameObject monsterManagerGameObject;

        private Button exit;
        private Button grownMonsterOn;
        private Button eggsBabysOn;
        private Button monsterAction;
        private VisualElement grownMonster;
        private VisualElement eggsBabys;
        private VisualElement monsterPicture;
        private VisualElement inventoryDisplayEgg;
        private VisualElement inventoryDisplayBaby;
        private Label monsterName;

        private Color pink = new Color(0.69f, 0.19f, 0.6f, 1f);
        private Color green = new Color( 0.055f, 1f, 0f, 1f);
        private Color grey = new Color(0.75f, 0.75f, 0.75f, 1f);
        /*
        public void OnEnable()
        {
            monsterManager = monsterManagerGameObject.GetComponent<MonsterManager>();

            UpdateActiveMonster();


            var uiDocument = GetComponent<UIDocument>();
            exit = uiDocument.rootVisualElement.Q("Exit") as Button;
            grownMonsterOn = uiDocument.rootVisualElement.Q("GrownMonsterOn") as Button;
            eggsBabysOn = uiDocument.rootVisualElement.Q("EggsBabysOn") as Button;
            monsterAction = uiDocument.rootVisualElement.Q("MonsterAction") as Button;
            grownMonster = uiDocument.rootVisualElement.Q("GrownMonster") as VisualElement;
            eggsBabys = uiDocument.rootVisualElement.Q("EggsBabys") as VisualElement;
            monsterPicture = uiDocument.rootVisualElement.Q("MonsterPicture") as VisualElement;
            inventoryDisplayEgg = uiDocument.rootVisualElement.Q("InventoryDisplayEgg") as VisualElement;
            inventoryDisplayBaby = uiDocument.rootVisualElement.Q("InventoryDisplayBaby") as VisualElement;
            monsterName = uiDocument.rootVisualElement.Q("MonsterName") as Label;

            exit.RegisterCallback<ClickEvent>(ChangeToMainScene);
            grownMonsterOn.RegisterCallback<ClickEvent>(ChangeToGrownMonster);
            eggsBabysOn.RegisterCallback<ClickEvent>(ChangeToEggsBabys);
            monsterAction.RegisterCallback<ClickEvent>(OpenMonsterSelectOverlay);

            DisplayEggsAndBabiesFromInventory();
        }

        public void OnDisable()
        {
            monsterManagerGameObject = null;


            exit.UnregisterCallback<ClickEvent>(ChangeToMainScene);
            grownMonsterOn.UnregisterCallback<ClickEvent>(ChangeToGrownMonster);
            eggsBabysOn.UnregisterCallback<ClickEvent>(ChangeToEggsBabys);
            monsterAction.UnregisterCallback<ClickEvent>(OpenMonsterSelectOverlay);
        }


        public void UpdateActiveMonster()
        {
            

            if (activeMonster == GrownMonsterType.None)
            {
                monsterPicture.style.backgroundColor = grey;
                monsterName.text = "No active Monster";
                monsterAction.text = "Select";
            }
            else
            {
                monsterPicture.style.backgroundColor = pink;
                monsterName.text = activeMonster.ToString();
                monsterAction.text = "Change";
            }
        }




        #region Button Handling
        private void ChangeToMainScene(ClickEvent evt)
        {
            SceneManager.LoadScene("Main");
        }
        private void ChangeToGrownMonster(ClickEvent evt)
        {
            if (activeMonsterMenu == OpenMonsterMenu.eggsBabys)
            {
                activeMonsterMenu = OpenMonsterMenu.grownMonster;

                grownMonsterOn.style.backgroundColor = green;
                eggsBabysOn.style.backgroundColor = grey;

                grownMonster.style.display = DisplayStyle.Flex;
                eggsBabys.style.display = DisplayStyle.None;
            }
        }
        private void ChangeToEggsBabys(ClickEvent evt)
        {
            Debug.Log("Wechsel");
            if (activeMonsterMenu == OpenMonsterMenu.grownMonster)
            {
                activeMonsterMenu = OpenMonsterMenu.eggsBabys;

                grownMonsterOn.style.backgroundColor = grey;
                eggsBabysOn.style.backgroundColor = pink;

                grownMonster.style.display = DisplayStyle.None;
                eggsBabys.style.display = DisplayStyle.Flex;
            }
        }
        private void OpenMonsterSelectOverlay(ClickEvent evt)
        {
            GameObject.Find("MonsterSelectOverlayUI").GetComponent<UIDocument>().enabled = true;
            GameObject.Find("MonsterSelectOverlayUI").GetComponent<MonsterSelectOverlayPM>().OverlayOpen();
        }
        #endregion

        #region create / update displayed information
        private void DisplayEggsAndBabiesFromInventory()
        {
            Dictionary<BaseMonsterType, int> eggsInPosession = Player.Instance.inventory.getEggsInPosession();
            foreach (KeyValuePair<BaseMonsterType, int> monster in eggsInPosession)
                CreateInventoryItem(monster.Key, monster.Value, BabyOrEgg.Egg);

            Dictionary<BaseMonsterType, int> babiesInPosession = Player.Instance.inventory.getBabyMonsterInPosession();
            foreach (KeyValuePair<BaseMonsterType, int> monster in babiesInPosession)
                CreateInventoryItem(monster.Key, monster.Value, BabyOrEgg.Baby);
        }
        private void CreateInventoryItem(BaseMonsterType monster, int monsterAmount, BabyOrEgg babyOrEgg)
        {
            if (monsterAmount <= 0)
                return;

            string monsterName = monster.ToString();
            string invetoryItemName = "item" + monsterName + babyOrEgg.ToString();
            string invetoryPictureName = "picture" + monsterName + babyOrEgg.ToString();
            string invetoryLabelName = "label" + monsterName + babyOrEgg.ToString();

            VisualElement newItem = new VisualElement { name = invetoryItemName, tooltip = monsterName + babyOrEgg.ToString() };
            VisualElement newPicture = new VisualElement { name = invetoryPictureName };
            Label newLabel = new Label { name = invetoryLabelName };

            newLabel.text = monsterName + babyOrEgg.ToString() + " - " + monsterAmount;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");
            if (babyOrEgg == BabyOrEgg.Egg)
                inventoryDisplayEgg.Add(newItem);
            else if (babyOrEgg == BabyOrEgg.Baby)
                inventoryDisplayBaby.Add(newItem);

            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                if (babyOrEgg == BabyOrEgg.Egg)
                {
                    GameObject.Find("EggHatchOverlayUI").GetComponent<UIDocument>().enabled = true;
                    GameObject.Find("EggHatchOverlayUI").GetComponent<EggHatchOverlayPM>().OverlayOpen(monster, monsterAmount);
                }
                if (babyOrEgg == BabyOrEgg.Baby)
                {
                    GameObject.Find("BabyFeetOverlayUI").GetComponent<UIDocument>().enabled = true;
                    GameObject.Find("BabyFeetOverlayUI").GetComponent<BabyFeetOverlayPM>().OverlayOpen(monster, monsterAmount);
                }
            }));
        }
        public void ReloadInventory()
        {
            inventoryDisplayEgg.Clear();
            inventoryDisplayBaby.Clear();
            DisplayEggsAndBabiesFromInventory();
        }
        #endregion

        #region enums
        enum OpenMonsterMenu
        {
            grownMonster,
            eggsBabys
        }
        enum BabyOrEgg
        {
            Baby,
            Egg
        }
        #endregion
        */
    }
}
