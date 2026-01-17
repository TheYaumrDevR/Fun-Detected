using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{

    [UxmlElement]
    public partial class InventoryGridPanel : VisualElement
    {
        public InventoryGridPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryGridPanel");
            visualTree.CloneTree(this);
        }
    }
}