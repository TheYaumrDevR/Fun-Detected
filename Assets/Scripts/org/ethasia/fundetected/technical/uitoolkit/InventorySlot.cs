using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Interactors.Items;
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

        private int posX;
        private int posY;

        private UiElementUtils.ItemHoverCallbacks itemHoverCallbacks;

        private PlayerInventoryInteractor playerInventoryInteractor;

        public InventorySlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventorySlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);

            RegisterCallback<PointerDownEvent>(OnPointerDown);

            playerInventoryInteractor = new PlayerInventoryInteractor();
        }     

        public void SetPositionInGrid(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void RenderItem(InventorySlotRenderContext renderContext)
        {
            if (renderContext.ShouldRenderSomething)
            {
                RenderColorFromContext(renderContext);
                itemHoverCallbacks = UiElementUtils.RegisterItemHoverEvents(this, renderContext);
            }
            else
            {
                RenderNothing();
            }
        }

        public void RenderNothing()
        {
            overlay.RemoveFromClassList(BLUE_OVERLAY_CLASS_NAME);
            overlay.RemoveFromClassList(RED_OVERLAY_CLASS_NAME);

            UnregisterOldHoverCallbacks();
        }

        public void OnPointerDown(PointerDownEvent evt)
        {
            playerInventoryInteractor.PickItemFromGridAtPosition(posX, posY);
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

        private void UnregisterOldHoverCallbacks()
        {
            if (itemHoverCallbacks.PointerEnterCallback != null)
            {
                this.UnregisterCallback<PointerEnterEvent>(itemHoverCallbacks.PointerEnterCallback);
            }

            if (itemHoverCallbacks.PointerMoveCallback != null)
            {
                this.UnregisterCallback<PointerMoveEvent>(itemHoverCallbacks.PointerMoveCallback);
            }

            if (itemHoverCallbacks.PointerLeaveCallback != null)
            {
                this.UnregisterCallback<PointerLeaveEvent>(itemHoverCallbacks.PointerLeaveCallback);
            }

            IItemTooltipPresenter itemTooltipPresenter = TechnicalFactory.GetInstance().GetItemTooltipPresenterInstance();
            itemTooltipPresenter.HideItemTooltip();
        }
    }
}