using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    public class UiElementUtils
    {
        public static void RegisterItemHoverEvents(VisualElement itemImage, InventorySlotRenderContext context)
        {
            NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder = new NormalItemTooltip.TooltipDisplayInformation.Builder()
                .SetItemName(context.ItemImageName);

            RegisterItemHoverEvents(itemImage, tooltipContentBuilder);
        }

        public static void RegisterItemHoverEvents(VisualElement itemImage, EquipmentSlotRenderContext renderContext)
        {
            NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder = new NormalItemTooltip.TooltipDisplayInformation.Builder()
                .SetItemName(renderContext.ItemImagePath);

            RegisterItemHoverEvents(itemImage, tooltipContentBuilder);
        }

        private static void RegisterItemHoverEvents(VisualElement itemImage, NormalItemTooltip.TooltipDisplayInformation.Builder tooltipContentBuilder)
        {
            IItemTooltipPresenter itemTooltipPresenter = TechnicalFactory.GetInstance().GetItemTooltipPresenterInstance();

            itemImage.RegisterCallback<PointerEnterEvent>(evt =>
            {
                tooltipContentBuilder.SetPosition(evt.position.x + 15, evt.position.y + 15);
                itemTooltipPresenter.ShowItemTooltip(tooltipContentBuilder.Build());
            });

            itemImage.RegisterCallback<PointerMoveEvent>(evt =>
            {
                itemTooltipPresenter.RepositionItemTooltip(evt.position.x + 15, evt.position.y + 15);
            });

            itemImage.RegisterCallback<PointerLeaveEvent>(evt =>
            {
                itemTooltipPresenter.HideItemTooltip();
            });
        }
    }
}