using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class GuiWindowsController : MonoBehaviour, IGuiWindowsController
    {
        private static GuiWindowsController instance;

        private VisualElement rootElement;
        private VisualElement mapSelectionWindow;     
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
            mapSelectionUsageHint = rootElement.Q<Label>("MapSelectionUsageHint");

            mapSelectionUsageHintOriginalText = mapSelectionUsageHint.text;

            mapSelectionWindow.visible = false;
        }

        public void OpenMapSelectionWindow(MapSelectionWindowContent windowContent)
        {
            mapSelectionUsageHint.text = TechnicalUtils.ReplacePlaceHoldersInText(mapSelectionUsageHintOriginalText, windowContent.MapName);
            mapSelectionWindow.visible = true;
        }

        public void CloseMapSelectionWindow()
        {
            mapSelectionWindow.visible = false;
        }
    }
}