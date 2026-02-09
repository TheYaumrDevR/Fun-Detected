using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class InventorySlot : VisualElement
    {
        private const string OVERLAY_NAME = "overlay-element";
        private const string ITEM_IMAGE_NAME = "item-image";
        private const string BLUE_OVERLAY_CLASS_NAME = "inventory-slot-overlay-blue";
        private const string RED_OVERLAY_CLASS_NAME = "inventory-slot-overlay-red";

        private VisualElement overlay;
        private VisualElement itemImage;

        public InventorySlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventorySlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            itemImage = this.Q<VisualElement>(ITEM_IMAGE_NAME);
        }     

        public void RenderItem(InventorySlotRenderContext renderContext)
        {
            if (renderContext.ShouldRenderSomething)
            {
                if (renderContext.ItemImageName != null && renderContext.ItemImageName.Length > 0)
                {
                    Sprite itemSprite = Resources.Load<Sprite>(renderContext.ItemImageName);

                    itemImage.style.backgroundImage = new StyleBackground(
                        itemSprite
                    );

                    itemImage.style.width = itemSprite.rect.width;
                    itemImage.style.height = itemSprite.rect.height;
                }

                RenderColorFromContext(renderContext);
            }
            else
            {
                RenderNothing();
            }
        }

        private void RenderColorFromContext(InventorySlotRenderContext renderContext)
        {
            if (renderContext.CanBeEquipped)
            {
                RenderCanBeEquippedColor();
            }
            else
            {
                RenderCannotBeEquippedColor();
            }
        }

        private void RenderCanBeEquippedColor()
        {
            overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);
            overlay.AddToClassList(BLUE_OVERLAY_CLASS_NAME);
        }   

        private void RenderCannotBeEquippedColor()
        {
            overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
            overlay.AddToClassList(RED_OVERLAY_CLASS_NAME);
        }

        private void RenderNothing()
        {
            itemImage.style.backgroundImage = new StyleBackground();

            overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
            overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);
        }
    }
}