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

        public static GuiWindowsController GetInstance()
        {
            return instance;
        }   

        void Awake()
        {
            instance = this;
            rootElement = GetComponent<UIDocument>().rootVisualElement;
            mapSelectionWindow = rootElement.Q<VisualElement>("MapSelectionWindow");
            mapSelectionWindowCloseButton = rootElement.Q<Button>("MapSelectionWindowCloseButton");
            mapSelectionUsageHint = rootElement.Q<Label>("MapSelectionUsageHint");

            mapSelectionWindowCloseButton.RegisterCallback<ClickEvent>(OnCloseMapSelectionWindowClick);

            mapSelectionUsageHintOriginalText = mapSelectionUsageHint.text;

            mapSelectionWindow.visible = false;
        }

        public void OpenMapSelectionWindow(MapSelectionWindowContent windowContent)
        {
            mapSelectionUsageHint.text = TechnicalUtils.ReplacePlaceHoldersInText(mapSelectionUsageHintOriginalText, windowContent.MapName);
            mapSelectionWindow.visible = true;

            SoundPlayer.GetInstance().PlayUiWindowOpenSound();
        }

        public void CloseCurrentlyOpenWindow()
        {
            if (mapSelectionWindow.visible)
            {
                mapSelectionWindow.visible = false;

                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }
        }

        private void OnCloseMapSelectionWindowClick(ClickEvent clickEvent)
        {
            this.CloseCurrentlyOpenWindow();
            PlayerInputHandler.GetInstance().EnableInput();

            SoundPlayer.GetInstance().PlayMouseClickSound();
        }
    }
}