using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DroppedItemPresenter : SpritesPresenter, IDroppedItemPresenter
    {
        private IDroppableItemRenderer droppableItemRenderer;

        public void PresentItemDrop(ItemDropPresentationInformation itemDropInfo)
        {
            GetDroppableItemRendererInstance().RenderDroppedItem(ConvertDropPresentationInformationToRenderProxy(itemDropInfo));
        }

        public void MovePresentedItemVertically(string itemId, int units)
        {
            float engineUnits = ConvertMapPositionToScreenPosition(units);
            GetDroppableItemRendererInstance().MoveDroppedItemVertically(itemId, engineUnits);
        }

        public void MovePresentedItemLeft(string itemId, int units)
        {
            float engineUnits = ConvertMapPositionToScreenPosition(units);
            GetDroppableItemRendererInstance().MoveDroppedItemLeft(itemId, engineUnits);
        }

        public void MovePresentedItemRight(string itemId, int units)
        {
            float engineUnits = ConvertMapPositionToScreenPosition(units);
            GetDroppableItemRendererInstance().MoveDroppedItemRight(itemId, engineUnits);
        }

        public void UpdateItemPresentationWhenRestingOnGround(ItemDropPresentationInformation itemDropInfo)
        {
            DroppedItemRenderProxy renderData = ConvertDropPresentationInformationToRenderProxy(itemDropInfo);
            droppableItemRenderer.RenderDroppedItemLabel(renderData);
        }

        public void ClearPresentedItem(string itemId)
        {
            droppableItemRenderer.ClearRenderedItem(itemId);
        }

        private IDroppableItemRenderer GetDroppableItemRendererInstance()
        {
            if (null == droppableItemRenderer)
            {
                droppableItemRenderer = TechnicalFactory.GetInstance().GetDroppableItemRendererInstance();
            }

            return droppableItemRenderer;
        }

        private DroppedItemRenderProxy ConvertDropPresentationInformationToRenderProxy(ItemDropPresentationInformation itemDropInfo)
        {
            float posX = ConvertMapPositionToScreenPosition(itemDropInfo.PositionX);
            float posY = ConvertMapPositionToScreenPosition(itemDropInfo.PositionY);

            DroppedItemRenderProxy.Builder resultBuilder = new DroppedItemRenderProxy.Builder()
                .SetId(itemDropInfo.UniqueId)
                .SetItemName(itemDropInfo.BaseTypeOrUniqueName)
                .SetRenderImageName(itemDropInfo.BaseTypeOrUniqueName)
                .SetPosX(posX)
                .SetPosY(posY);

            if (itemDropInfo.Potential == ItemPotential.LATENT)
            {
                resultBuilder
                    .SetItemLabelTextColor("#9595fc")
                    .SetItemLabelBorderColor("#000000")
                    .SetItemLabelBackgroundColor("#1a192b")
                    .SetItemLabelFontSize(30)
                    .SetRenderBeam(true)
                    .SetBeamColor("#9595fc");
            }

            return resultBuilder.Build();
        }
    }
}