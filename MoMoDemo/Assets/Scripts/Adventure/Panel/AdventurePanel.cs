using Momo.ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;

namespace Momo.AdventureScene.Panel
{
    public class AdventurePanel : MonoBehaviour
    {
        // The logic for this panel can be accessed with Adventure.Instance

        private VisualElement background;
        private VisualElement lootArea;
        private Button goFurther;

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

            background = uiDocument.rootVisualElement.Q("Background");
            lootArea = uiDocument.rootVisualElement.Q("LootArea");
            goFurther = uiDocument.rootVisualElement.Q("GoFurther") as Button;
        }
        private void SubscribeToButtonEvents()
        {
            goFurther.RegisterCallback<ClickEvent>(OnGoFurtherClicked);
        }
        private void SubscribeToLogicEvents()
        {
            Adventure.Instance.LoadNewArea += OnLoadNewArea;
            Adventure.Instance.HideGoFurtherButton += OnHideGoFurtherButton;
        }
        private void LoadContent()
        {
            Adventure.Instance.LoadContent();
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
            goFurther.UnregisterCallback<ClickEvent>(OnGoFurtherClicked);
        }
        private void UnsubscribeToLogicEvents()
        {
            Adventure.Instance.LoadNewArea -= OnLoadNewArea;
            Adventure.Instance.HideGoFurtherButton -= OnHideGoFurtherButton;
        }
        #endregion

        #region On Adventure Event Handling
        private void OnLoadNewArea(Area area)
        {
            lootArea.Clear();

            LoadArea(area);
        }
        private void LoadArea(Area area)
        {
            background.style.backgroundImage = new StyleBackground(area.Background);
            foreach (SpawnSpot spot in area.SpawnSpots)
                CreateSpawnSpot(spot);
        }
        private void CreateSpawnSpot(SpawnSpot spawnSpot)
        {
            Loot loot = spawnSpot.GenerateLoot();

            if (loot == null)
                return;

            VisualElement spot = new VisualElement();
            spot.AddToClassList("loot");
            spot.style.left = spawnSpot.Position.x;
            spot.style.top = spawnSpot.Position.y;

            if (loot.GetType() == typeof(Fruit))
                CreateFruitSpawn(spot, loot as Fruit);

            if (loot.GetType() == typeof(Egg))
                CreateEggSpawn(spot, loot as Egg);

            lootArea.Add(spot);
        }

        private void CreateFruitSpawn(VisualElement spot, Fruit fruit)
        {
            spot.AddToClassList("fruit");
            spot.style.backgroundColor = fruit.Color;

            spot.AddManipulator(new Clickable(evt =>
            {
                OnFruitClicked(spot, fruit);
            }));
        }
        private void CreateEggSpawn(VisualElement spot, Egg egg)
        {
            spot.AddToClassList("egg");
            spot.style.backgroundColor = egg.Color;

            spot.AddManipulator(new Clickable(evt =>
            {
                OnEggClicked(spot, egg);
            }));
        }
        private void OnHideGoFurtherButton()
        {
            goFurther.style.display = DisplayStyle.None;
        }
        #endregion

        #region On Button Clicked Event Handling
        private void OnGoFurtherClicked(ClickEvent evt)
        {
            Adventure.Instance.OnGoFurtherClicked();
        }
        private void OnFruitClicked(VisualElement spot, Fruit fruit)
        {
            spot.RemoveFromHierarchy();
            Adventure.Instance.OnFruitClicked(fruit);
        }
        private void OnEggClicked(VisualElement spot, Egg egg)
        {
            spot.RemoveFromHierarchy();
            Adventure.Instance.OnEggClicked(egg);
        }
        #endregion
    }
}
