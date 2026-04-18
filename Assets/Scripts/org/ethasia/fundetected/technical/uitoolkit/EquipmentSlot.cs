using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlot : VisualElement
    {
        private const string OVERLAY_NAME = "overlay-element";
        private const string ITEM_IMAGE_NAME = "item-image";

        private const string BLUE_OVERLAY_CLASS_NAME = "equipment-slot-overlay-blue";
        private const string RED_OVERLAY_CLASS_NAME = "equipment-slot-overlay-red";

        [UxmlAttribute]
        public EquipmentSlotPositionTypes SlotPosition;

        private VisualElement overlay;
        private VisualElement itemImage;

        private UiElementUtils.ItemHoverCallbacks itemHoverCallbacks;

        private PlayerInventoryController playerInventoryController;

        public EquipmentSlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlot");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            itemImage = this.Q<VisualElement>(ITEM_IMAGE_NAME);

            RegisterCallback<PointerDownEvent>(OnPointerDown);
            playerInventoryController = new PlayerInventoryController();
        }

        public void RenderEquippedItem(EquipmentSlotRenderContext renderContext)
        {
            UnregisterOldHoverCallbacks();

            if (renderContext.ItemImagePath != null && renderContext.ItemImagePath.Length > 0)
            {
                Sprite itemSprite = Resources.Load<Sprite>(renderContext.ItemImagePath);

                itemImage.style.backgroundImage = new StyleBackground(
                    itemSprite
                );

                itemImage.style.width = itemSprite.rect.width;
                itemImage.style.height = itemSprite.rect.height;

                SetOverlayColor(renderContext.IsEquipped);
                itemHoverCallbacks = UiElementUtils.RegisterItemHoverEvents(itemImage, renderContext);
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

        private void OnPointerDown(PointerDownEvent evt)
        {
            playerInventoryController.OnEquipmentSlotClicked(SlotPosition);
        }

        private void UnregisterOldHoverCallbacks()
        {
            if (itemHoverCallbacks.PointerEnterCallback != null)
            {
                itemImage.UnregisterCallback<PointerEnterEvent>(itemHoverCallbacks.PointerEnterCallback);
            }

            if (itemHoverCallbacks.PointerMoveCallback != null)
            {
                itemImage.UnregisterCallback<PointerMoveEvent>(itemHoverCallbacks.PointerMoveCallback);
            }

            if (itemHoverCallbacks.PointerLeaveCallback != null)
            {
                itemImage.UnregisterCallback<PointerLeaveEvent>(itemHoverCallbacks.PointerLeaveCallback);
            }

            IItemTooltipPresenter itemTooltipPresenter = TechnicalFactory.GetInstance().GetItemTooltipPresenterInstance();
            itemTooltipPresenter.HideItemTooltip();
        }
    }
}