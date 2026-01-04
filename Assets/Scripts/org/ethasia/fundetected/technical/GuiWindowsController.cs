using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class GuiWindowsController : MonoBehaviour, IGuiWindowsController
    {
        private static GuiWindowsController instance;

        private VisualElement rootElement;
        private VisualElement mapSelectionWindow;     
        private VisualElement inventoryWindow;
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
            inventoryWindow.visible = false;

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
            if (mapSelectionWindow.visible)
            {
                mapSelectionWindow.visible = false;

                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }

            if (inventoryWindow.visible)
            {
                inventoryWindow.visible = false;

                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }
        }

        public void ToggleInventoryWindow()
        {
            if (inventoryWindow.visible)
            {
                CloseInventoryWindow();
            }
            else
            {
                OpenInventoryWindow();
            }
        }

        private void InitializeElementReferences()
        {
            rootElement = GetComponent<UIDocument>().rootVisualElement;

            mapSelectionWindow = rootElement.Q<VisualElement>("MapSelectionWindow");
            mapSelectionWindowCloseButton = rootElement.Q<Button>("MapSelectionWindowCloseButton");
            mapSelectionUsageHint = rootElement.Q<Label>("MapSelectionUsageHint");
            mapSelectionList = rootElement.Q<MultiColumnListView>("MapSelectionList");

            inventoryWindow = rootElement.Q<VisualElement>("InventoryWindow");
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

        private void OnCloseMapSelectionWindowClick(ClickEvent clickEvent)
        {
            this.CloseCurrentlyOpenWindow();
            PlayerInputHandler.GetInstance().EnableInput();

            SoundPlayer.GetInstance().PlayMouseClickSound();
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

        private void OpenInventoryWindow()
        {
            inventoryWindow.visible = true;
            SoundPlayer.GetInstance().PlayUiWindowOpenSound();
        }

        private void CloseInventoryWindow()
        {
            inventoryWindow.visible = false;
            SoundPlayer.GetInstance().PlayUiWindowOpenSound();
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
    }
}