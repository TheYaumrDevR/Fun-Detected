using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class InventoryWindow : VisualElement
    {
        private const string BASE_WINDOW_NAME = "base-window";

        private FunDetectedWindow baseWindow;

        [UxmlAttribute]
        public bool IsOpen 
        { 
            get => this.visible && (baseWindow?.visible ?? false);
            set 
            {
                this.visible = value;

                if (baseWindow != null) baseWindow.visible = value;
            }
        }

        public InventoryWindow()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryWindow");
            visualTree.CloneTree(this);

            baseWindow = this.Q<FunDetectedWindow>(BASE_WINDOW_NAME);
        }
    }
}