using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlot : VisualElement
    {
        private const string OVERLAY_NAME = "overlay-element";
        private const string ITEM_IMAGE_NAME = "item-image";
        private const string BORDER_IMAGE_NAME = "border-image";

        private const string BLUE_OVERLAY_CLASS_NAME = "equipment-slot-overlay-blue";
        private const string RED_OVERLAY_CLASS_NAME = "equipment-slot-overlay-red";

        private VisualElement overlay;
        private VisualElement itemImage;
        private VisualElement borderImage;

        private EquipmentSlotDimensions slotDimension;

        [UxmlAttribute]
        public EquipmentSlotDimensions SlotDimension 
        { 
            get => slotDimension;
            set 
            {
                slotDimension = value;
                UpdateBorderClass();
            }
        }

        public EquipmentSlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            itemImage = this.Q<VisualElement>(ITEM_IMAGE_NAME);
            borderImage = this.Q<VisualElement>(BORDER_IMAGE_NAME);
        }

        public void RenderEquippedItem(EquipmentSlotRenderContext renderContext)
        {
            if (renderContext.ItemImagePath != null && renderContext.ItemImagePath.Length > 0)
            {
                Sprite itemSprite = Resources.Load<Sprite>(renderContext.ItemImagePath);

                itemImage.style.backgroundImage = new StyleBackground(
                    itemSprite
                );

                itemImage.style.width = itemSprite.rect.width;
                itemImage.style.height = itemSprite.rect.height;

                SetOverlayColor(renderContext.IsEquipped);
            }
            else
            {
                itemImage.style.backgroundImage = new StyleBackground();
                RemoveOverlayColor();
            }
        }

        private void SetOverlayColor(bool isEquipped)
        {
            if (isEquipped)
            {
                overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);
                overlay.AddToClassList(BLUE_OVERLAY_CLASS_NAME);
            }
            else
            {
                overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
                overlay.AddToClassList(RED_OVERLAY_CLASS_NAME);
            }
        }

        private void RemoveOverlayColor()
        {
            overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
            overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);
        }

        private void UpdateBorderClass()
        {
            if (borderImage != null)
            {
                switch (slotDimension)
                {
                    case EquipmentSlotDimensions.EXTRA_LARGE:
                        borderImage.AddToClassList("equipment-slot-border-large");
                        break;
                    case EquipmentSlotDimensions.LARGE:
                        borderImage.AddToClassList("equipment-slot-border-medium");
                        break;
                    case EquipmentSlotDimensions.MEDIUM:
                        borderImage.AddToClassList("equipment-slot-border-small");
                        break;
                    case EquipmentSlotDimensions.BELT:
                        borderImage.AddToClassList("equipment-slot-border-belt");
                        break;
                    case EquipmentSlotDimensions.SMALL:
                        borderImage.AddToClassList("equipment-slot-border-jewelry");
                        break;
                    case EquipmentSlotDimensions.POTION:
                        borderImage.AddToClassList("equipment-slot-border-potion");
                        break;
                }
            }
        }

        public enum EquipmentSlotDimensions
        {
            EXTRA_LARGE,
            LARGE,
            MEDIUM,
            BELT,
            SMALL,
            POTION
        }
    }
}