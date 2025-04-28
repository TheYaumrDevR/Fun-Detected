using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class GuiWindowsController : MonoBehaviour, IGuiWindowsController
    {
        private static GuiWindowsController instance;

        private VisualElement rootElement;
        private VisualElement mapSelectionWindow;     
        private Button mapSelectionWindowCloseButton;
        private Label mapSelectionUsageHint;
        private string mapSelectionUsageHintOriginalText;
        private MultiColumnListView mapSelectionList;

        public static GuiWindowsController GetInstance()
        {
            return instance;
        }   

        // TODO: Style header of map seleciton list
        // TODO: Make map selection list columns not rearrangable
        // TODO: Use custom template and style for map selection list rows with the button and id
        // TODO: Add first row to map selection list which allows for the creation of a new map

        void Awake()
        {
            instance = this;

            InitializeElementReferences();

            mapSelectionWindowCloseButton.RegisterCallback<ClickEvent>(OnCloseMapSelectionWindowClick);

            mapSelectionUsageHintOriginalText = mapSelectionUsageHint.text;

            mapSelectionWindow.visible = false;

            SetupMapSelectionList();
        }

        public void OpenMapSelectionWindow(MapSelectionWindowContent windowContent)
        {
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
        }

        private void InitializeElementReferences()
        {
            rootElement = GetComponent<UIDocument>().rootVisualElement;
            mapSelectionWindow = rootElement.Q<VisualElement>("MapSelectionWindow");
            mapSelectionWindowCloseButton = rootElement.Q<Button>("MapSelectionWindowCloseButton");
            mapSelectionUsageHint = rootElement.Q<Label>("MapSelectionUsageHint");
            mapSelectionList = rootElement.Q<MultiColumnListView>("MapSelectionList");
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

        private void PopulateMapSelectionList(MapSelectionWindowContent windowContent)
        {
            List<string> mapIds = windowContent.MapIds;
            List<MapSelectionRow> itemsSource = new List<MapSelectionRow>(mapIds.Count + 1);

            for (int i = 0; i < mapIds.Count; i++)
            {
                itemsSource.Add(new MapSelectionRow(MapSelectionRowType.STANDARD, mapIds[i]));
            }

            itemsSource.Add(new MapSelectionRow(MapSelectionRowType.NEW_INSTANCE, "Create new instance"));
            itemsSource.Reverse();

            mapSelectionList.Clear();
            mapSelectionList.itemsSource = itemsSource;
        }

        private VisualElement MakeButtonCell()
        {
            var result = new Button();
            return result;
        }

        private void BindButtonCell(VisualElement element, int index)
        {
            var button = (Button)element;
            var selectionListRow = (MapSelectionRow)mapSelectionList.viewController.GetItemForIndex(index);

            if (selectionListRow.Type == MapSelectionRowType.NEW_INSTANCE)
            {
                button.text = "New";
            }
            else
            {
                button.text = "Enter";
            }
        }

        private void BindMapIdToCell(VisualElement element, int index)
        {
			var cellLabel = (Label)element;
			var selectionLitRow = (MapSelectionRow)mapSelectionList.viewController.GetItemForIndex(index);
			cellLabel.text = selectionLitRow.Id;       
        }

        private void OnCloseMapSelectionWindowClick(ClickEvent clickEvent)
        {
            this.CloseCurrentlyOpenWindow();
            PlayerInputHandler.GetInstance().EnableInput();

            SoundPlayer.GetInstance().PlayMouseClickSound();
        }

        private enum MapSelectionRowType
        {
            STANDARD,
            NEW_INSTANCE
        }

        private class MapSelectionRow
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