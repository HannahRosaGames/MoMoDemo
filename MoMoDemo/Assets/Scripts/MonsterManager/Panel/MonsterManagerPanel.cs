using UnityEngine;
using UnityEngine.UIElements;
using Momo.ScriptableObjects;

namespace Momo.MonsterManagerScene.Panel
{
    public class MonsterManagerPanel : MonoBehaviour
    {
        // The logic for this panel can be accessed with MonsterManager.Instance

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
        }
        private void SubscribeToButtonEvents()
        {
            exit.RegisterCallback<ClickEvent>(OnExitButtonClicked);
            grownMonsterOn.RegisterCallback<ClickEvent>(OnGrownMonsterOnClicked);
            eggsBabysOn.RegisterCallback<ClickEvent>(OnEggsBabysOnClicked);
            monsterAction.RegisterCallback<ClickEvent>(OnMonsterActionClicked);
        }
        private void SubscribeToLogicEvents()
        {
            while (MonsterManager.Instance == null)
                Debug.Log("MonsterManager existiert noch nicht");
            MonsterManager.Instance.ChangeDisplayToGrownMonster += OnChangeDisplayToGrownMonster;
            MonsterManager.Instance.ChangeDisplayToEggsBabys += OnChangeDisplayToEggsBabys;
            MonsterManager.Instance.ClearInventory += OnClearInventory;
            MonsterManager.Instance.CreateInventoryItemEgg += OnCreateInventoryItemEgg;
            MonsterManager.Instance.CreateInventoryItemBabyMonster += OnCreateInventoryItemBabyMonster;
            MonsterManager.Instance.NewActiveMonster += OnNewActiveMonster;
            MonsterManager.Instance.NoActiveMonster += OnNoActiveMonster;
        }
        private void LoadContent()
        {
            while (MonsterManager.Instance == null)
                Debug.Log("MonsterManager existiert noch nicht");
            MonsterManager.Instance.LoadContent();
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
            exit.UnregisterCallback<ClickEvent>(OnExitButtonClicked);
            grownMonsterOn.UnregisterCallback<ClickEvent>(OnGrownMonsterOnClicked);
            eggsBabysOn.UnregisterCallback<ClickEvent>(OnEggsBabysOnClicked);
            monsterAction.UnregisterCallback<ClickEvent>(OnMonsterActionClicked);
        }
        private void UnsubscribeToLogicEvents()
        {
            MonsterManager.Instance.ChangeDisplayToGrownMonster -= OnChangeDisplayToGrownMonster;
            MonsterManager.Instance.ChangeDisplayToEggsBabys -= OnChangeDisplayToEggsBabys;
            MonsterManager.Instance.ClearInventory -= OnClearInventory;
            MonsterManager.Instance.CreateInventoryItemEgg -= OnCreateInventoryItemEgg;
            MonsterManager.Instance.CreateInventoryItemBabyMonster -= OnCreateInventoryItemBabyMonster;
            MonsterManager.Instance.NewActiveMonster -= OnNewActiveMonster;
        }
        #endregion

        #region On MonsterManager Event Handling
        private void OnNewActiveMonster(GrownMonster activeGrownMonster)
        {
            this.monsterPicture.style.backgroundColor = new Color(0.69f, 0.19f, 0.6f, 1f);
            this.monsterName.text = activeGrownMonster.Name;
            this.monsterAction.text = "Change";
        }

        private void OnNoActiveMonster()
        {
            this.monsterPicture.style.backgroundColor = new Color(0.75f, 0.75f, 0.75f, 1f);
            this.monsterName.text = "No active Monster";
            this.monsterAction.text = "Select";
        }

        private void OnCreateInventoryItemEgg(string eggName, int eggAmount)
        {
            VisualElement newItem = new VisualElement { name = "Item" + eggName};
            VisualElement newPicture = new VisualElement { name = "Picture" + eggName };
            Label newLabel = new Label { name = "Label" + eggName };

            newLabel.text = eggName + " - " + eggAmount;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            inventoryDisplayEgg.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                OnEggInventoryItemClicked(eggName, eggAmount);
            }));
        }

        private void OnCreateInventoryItemBabyMonster(string babyMonsterName, int babyMonsterAmount)
        {
            VisualElement newItem = new VisualElement { name = "Item" + babyMonsterName};
            VisualElement newPicture = new VisualElement { name = "Picture" + babyMonsterName };
            Label newLabel = new Label { name = "Label" + babyMonsterName };

            newLabel.text = babyMonsterName + " - " + babyMonsterAmount;

            newItem.AddToClassList("inventoryItem");
            newPicture.AddToClassList("inventoryPicture");
            newLabel.AddToClassList("inventoryLabel");

            inventoryDisplayBaby.Add(newItem);
            newItem.Add(newPicture);
            newItem.Add(newLabel);

            newItem.AddManipulator(new Clickable(evt =>
            {
                OnBabyMonsterInventoryItemClicked(babyMonsterName);
            }));
        }

        private void OnChangeDisplayToGrownMonster()
        {
            grownMonsterOn.style.backgroundColor = new Color(0.055f, 1f, 0f, 1f);
            eggsBabysOn.style.backgroundColor = new Color(0.75f, 0.75f, 0.75f, 1f);

            grownMonster.style.display = DisplayStyle.Flex;
            eggsBabys.style.display = DisplayStyle.None;
        }

        private void OnChangeDisplayToEggsBabys()
        {
            grownMonsterOn.style.backgroundColor = new Color(0.75f, 0.75f, 0.75f, 1f);
            eggsBabysOn.style.backgroundColor = new Color(0.69f, 0.19f, 0.6f, 1f);

            grownMonster.style.display = DisplayStyle.None;
            eggsBabys.style.display = DisplayStyle.Flex;
        }

        private void OnClearInventory()
        {
            inventoryDisplayEgg.Clear();
            inventoryDisplayBaby.Clear();
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnExitButtonClicked(ClickEvent evt)
        {
            MonsterManager.Instance.OnExitButtonClicked();
        }
        private void OnGrownMonsterOnClicked(ClickEvent evt)
        {
            MonsterManager.Instance.OnGrownMonsterOnClicked();
        }
        private void OnEggsBabysOnClicked(ClickEvent evt)
        {
            MonsterManager.Instance.OnEggsBabysOnClicked();
        }
        private void OnMonsterActionClicked(ClickEvent evt)
        {
            MonsterManager.Instance.OnMonsterActionClicked();
        }
        private void OnEggInventoryItemClicked(string eggName, int eggAmount)
        {
            MonsterManager.Instance.OnEggInventoryItemClicked(eggName, eggAmount);
        }
        private void OnBabyMonsterInventoryItemClicked(string babyMonsterName)
        {
            MonsterManager.Instance.OnBabyMonsterInventoryItemClicked(babyMonsterName);
        }
        #endregion
    }
}
