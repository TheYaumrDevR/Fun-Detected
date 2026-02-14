using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class InventorySlot : VisualElement
    {
        private const string OVERLAY_NAME = "overlay-element";
        private const string BLUE_OVERLAY_CLASS_NAME = "inventory-slot-overlay-blue";
        private const string RED_OVERLAY_CLASS_NAME = "inventory-slot-overlay-red";

        private VisualElement overlay;

        public InventorySlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventorySlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
        }     

        public void RenderItem(InventorySlotRenderContext renderContext)
        {
            if (renderContext.ShouldRenderSomething)
            {
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
            overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
            overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);
        }
    }
}