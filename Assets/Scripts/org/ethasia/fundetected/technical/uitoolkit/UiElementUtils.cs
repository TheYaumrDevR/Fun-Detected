using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    public class UiElementUtils
    {
        public static ItemHoverCallbacks RegisterItemHoverEvents(VisualElement itemImage, InventorySlotRenderContext context)
        {
            NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder = new NormalItemTooltip.TooltipDisplayInformation.Builder()
                .SetItemName(context.ItemImageName)
                .SetTooltipRenderContext(context.ToolTipRenderContext);

            return RegisterItemHoverEvents(itemImage, tooltipContentBuilder);
        }

        public static ItemHoverCallbacks RegisterItemHoverEvents(VisualElement itemImage, EquipmentSlotRenderContext renderContext)
        {
            NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder = new NormalItemTooltip.TooltipDisplayInformation.Builder()
                .SetItemName(renderContext.ItemImagePath)
                .SetTooltipRenderContext(renderContext.ToolTipRenderContext);

            return RegisterItemHoverEvents(itemImage, tooltipContentBuilder);
        }

        private static ItemHoverCallbacks RegisterItemHoverEvents(VisualElement itemImage, NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder)
        {
            IItemTooltipPresenter itemTooltipPresenter = TechnicalFactory.GetInstance().GetItemTooltipPresenterInstance();

            EventCallback<PointerEnterEvent> pointerEnterCallback = evt =>
            {
                tooltipContentBuilder.SetPosition(evt.position.x + 15, evt.position.y + 15);
                itemTooltipPresenter.ShowItemTooltip(tooltipContentBuilder.Build());
            };

            EventCallback<PointerMoveEvent> pointerMoveCallback = evt =>
            {
                itemTooltipPresenter.RepositionItemTooltip(evt.position.x + 15, evt.position.y + 15);
            };

            EventCallback<PointerLeaveEvent> pointerLeaveCallback = evt =>
            {
                itemTooltipPresenter.HideItemTooltip();
            };

            itemImage.RegisterCallback<PointerEnterEvent>(pointerEnterCallback);
            itemImage.RegisterCallback<PointerMoveEvent>(pointerMoveCallback);
            itemImage.RegisterCallback<PointerLeaveEvent>(pointerLeaveCallback);

            return new ItemHoverCallbacks(pointerEnterCallback, pointerMoveCallback, pointerLeaveCallback);
        }

        public struct ItemHoverCallbacks
        {
            public EventCallback<PointerEnterEvent> PointerEnterCallback { get; }
            public EventCallback<PointerMoveEvent> PointerMoveCallback { get; }
            public EventCallback<PointerLeaveEvent> PointerLeaveCallback { get; }
    
            public ItemHoverCallbacks(
                EventCallback<PointerEnterEvent> pointerEnterCallback,
                EventCallback<PointerMoveEvent> pointerMoveCallback,
                EventCallback<PointerLeaveEvent> pointerLeaveCallback)
            {
                PointerEnterCallback = pointerEnterCallback;
                PointerMoveCallback = pointerMoveCallback;
                PointerLeaveCallback = pointerLeaveCallback;
            }
        }
    }
}