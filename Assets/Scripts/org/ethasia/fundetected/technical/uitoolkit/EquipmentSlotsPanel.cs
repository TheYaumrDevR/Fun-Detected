using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlotsPanel : VisualElement
    {
        public EquipmentSlotsPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlotsPanel");
            visualTree.CloneTree(this);
        }
    }
}