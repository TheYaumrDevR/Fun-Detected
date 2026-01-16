using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlot : VisualElement
    {
        private const string OVERLAY_NAME = "overlay-element";
        private const string ITEM_IMAGE_NAME = "item-image";

        private VisualElement overlay;
        private VisualElement itemImage;

        public EquipmentSlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            itemImage = this.Q<VisualElement>(ITEM_IMAGE_NAME);
        }
    }
}