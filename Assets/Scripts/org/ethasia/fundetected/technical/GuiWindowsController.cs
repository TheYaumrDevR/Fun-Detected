using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.UIToolkit;

namespace Org.Ethasia.Fundetected.Technical
{
    public class GuiWindowsController : MonoBehaviour, IGuiWindowsController
    {
        private static GuiWindowsController instance;

        private VisualElement rootElement;
        private VisualElement mapSelectionWindow;     
        private InventoryWindow inventoryWindow;
        private Button mapSelectionWindowCloseButton;
        private Label mapSelectionUsageHint;
        private string mapSelectionUsageHintOriginalText;
        private MultiColumnListView mapSelectionList;
        private MapSelectionWindowContext model;

        public static GuiWindowsController GetInstance()
        {
            return instance;
        }   

        void Awake()
        {
            instance = this;

            InitializeElementReferences();

            mapSelectionWindowCloseButton.RegisterCallback<ClickEvent>(OnCloseMapSelectionWindowClick);

            mapSelectionUsageHintOriginalText = mapSelectionUsageHint.text;

            mapSelectionWindow.visible = false;
            inventoryWindow.IsOpen = false;

            SetupMapSelectionList();
        }

        public void OpenMapSelectionWindow(MapSelectionWindowContext windowContent)
        {
            model = windowContent;

            mapSelectionUsageHint.text = TechnicalUtils.ReplacePlaceHoldersInText(mapSelectionUsageHintOriginalText, windowContent.MapName);
            mapSelectionWindow.visible = true;

            SoundPlayer.GetInstance().PlayUiWindowOpenSound();

            PopulateMapSelectionList(windowContent);
        }

        public void CloseCurrentlyOpenWindow()
        {
            CloseMapSelectionWindow();
            CloseInventoryWindow();
        }

        public void ToggleInventoryWindow()
        {
            if (inventoryWindow.IsOpen)
            {
                CloseInventoryWindow();
            }
            else
            {
                OpenInventoryWindow(CreateTestRenderContextForInventory());
            }
        }

        public void OpenInventoryWindow(InventoryRenderContext context)
        {
            inventoryWindow.Open(context);
            PlayerInputHandler.GetInstance().DisableInput();
            SoundPlayer.GetInstance().PlayUiWindowOpenSound();
        }

        public void EnablePlayerInputIfAllWindowsAreClosed()
        {
            PlayerInputHandler playerInputHandler = PlayerInputHandler.GetInstance();

            if (!mapSelectionWindow.visible && !inventoryWindow.IsOpen)
            {
                playerInputHandler.EnableInput();
            }
        }

        private void InitializeElementReferences()
        {
            rootElement = GetComponent<UIDocument>().rootVisualElement;

            mapSelectionWindow = rootElement.Q<VisualElement>("MapSelectionWindow");
            mapSelectionWindowCloseButton = rootElement.Q<Button>("MapSelectionWindowCloseButton");
            mapSelectionUsageHint = rootElement.Q<Label>("MapSelectionUsageHint");
            mapSelectionList = rootElement.Q<MultiColumnListView>("MapSelectionList");

            inventoryWindow = rootElement.Q<InventoryWindow>("InventoryWindow");
        }        

        private void SetupMapSelectionList()
        {
            mapSelectionList.AddToClassList("MultiColumnListViewIngameUi");
            mapSelectionList.reorderable = false;

            mapSelectionList.columns.Add(MakeColumn("Action", 127, BindButtonCell, MakeButtonCell));
            mapSelectionList.columns.Add(MakeColumn("ID", 993, BindMapIdToCell));
        }     

        private Column MakeColumn(string title, int width, Action<VisualElement, int> bindCellFunction = null, Func<VisualElement> makeCellFunction = null)
        {
            return new Column 
            {
                title = title,
                width = width,
                resizable = false,
                sortable = false,
                bindCell = bindCellFunction,
                makeCell = makeCellFunction
            };
        }   

        private void PopulateMapSelectionList(MapSelectionWindowContext windowContent)
        {
            mapSelectionList.Clear();
            mapSelectionList.itemsSource = GuiContentFactory.CreateMapSelectionRows(windowContent);
        }

        private VisualElement MakeButtonCell()
        {
            var result = new Button();

            result.AddToClassList("WindowsButton");
            result.RegisterCallback<ClickEvent>(OnButtonClick);

            return result;
        }

        private void BindButtonCell(VisualElement element, int index)
        {
            var button = (Button)element;
            var selectionListRow = (MapSelectionRow)mapSelectionList.viewController.GetItemForIndex(index);

            if (selectionListRow.Type == MapSelectionRowType.NEW_INSTANCE)
            {
                button.text = "New";
                button.userData = new EventCallback<ClickEvent>(OnNewMapButtonClick);
            }
            else
            {
                button.text = "Enter";
                button.userData = CreateOnMapButtonClickAction(index);
            }
        }

        private void BindMapIdToCell(VisualElement element, int index)
        {
			var cellLabel = (Label)element;
			var selectionListRow = (MapSelectionRow)mapSelectionList.viewController.GetItemForIndex(index);
			cellLabel.text = selectionListRow.Id;       
        }

        private void OnButtonClick(ClickEvent clickEvent)
        {
            var button = (Button)clickEvent.target;
            EventCallback<ClickEvent> callback = button.userData as EventCallback<ClickEvent>;

            if (callback != null)
            {
                callback(clickEvent);
            }
        }

        private void OnCloseMapSelectionWindowClick(ClickEvent clickEvent)
        {
            CloseMapSelectionWindow();
            EnablePlayerInputIfAllWindowsAreClosed();

            SoundPlayer.GetInstance().PlayMouseClickSound();
        }

        private void OnNewMapButtonClick(ClickEvent clickEvent)
        {
            PortalTransitionInteractor portalTransitionInteractor = new PortalTransitionInteractor();

            OnCloseMapSelectionWindowClick(null);

            portalTransitionInteractor.TransitionToNewlyCreatedMap(model.MapName, model.DestinationPortalId);
        }

        private EventCallback<ClickEvent> CreateOnMapButtonClickAction(int index)
        {
            return (clickEvent) =>
            {
                PortalTransitionInteractor portalTransitionInteractor = new PortalTransitionInteractor();

                OnCloseMapSelectionWindowClick(null);

                index = index > 0 ? index - 1 : index;
                index = model.MapIds.Count - index - 1;

                portalTransitionInteractor.TransitionToSpecificMap(model.MapName, model.DestinationPortalId, index);
            };
        }

        private void CloseMapSelectionWindow()
        {
            CloseWindow(mapSelectionWindow);
        }

        private void CloseInventoryWindow()
        {
            if (inventoryWindow.IsOpen)
            {
                inventoryWindow.IsOpen = false;
                EnablePlayerInputIfAllWindowsAreClosed();
                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }
        }

        private void CloseWindow(VisualElement window)
        {
            if (window.visible)
            {
                window.visible = false;
                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }
        }

        public enum MapSelectionRowType
        {
            STANDARD,
            NEW_INSTANCE
        }

        public class MapSelectionRow
        {
            public MapSelectionRowType Type 
            { 
                get; 
                private set; 
            }

            public string Id 
            { 
                get; 
                private set; 
            }

            public MapSelectionRow(MapSelectionRowType type, string id)
            {
                Type = type;
                Id = id;
            }
        }

        private InventoryRenderContext CreateTestRenderContextForInventory()
        {
            EquipmentSlotsRenderContext equipmentSlotsRenderContext = new EquipmentSlotsRenderContext.Builder()
                .Build();

            return new InventoryRenderContext(equipmentSlotsRenderContext);
        }
    }
}