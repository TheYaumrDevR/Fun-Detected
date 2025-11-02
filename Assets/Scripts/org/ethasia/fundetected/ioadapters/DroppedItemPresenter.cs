using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DroppedItemPresenter : SpritesPresenter, IDroppedItemPresenter
    {
        private IDroppableItemRenderer droppableItemRenderer;

        public void PresentItemDrop(ItemDropPresentationInformation itemDropInfo)
        {
            droppableItemRenderer = TechnicalFactory.GetInstance().GetDroppableItemRendererInstance();
            droppableItemRenderer.RenderDroppedItem(ConvertDropPresentationInformationToRenderProxy(itemDropInfo));
        }

        public void MovePresentedItemVertically(string itemId, int units)
        {
            droppableItemRenderer.MoveDroppedItemVertically(itemId, units);
        }

        public void MovePresentedItemLeft(string itemId, int units)
        {
            droppableItemRenderer.MoveDroppedItemLeft(itemId, units);
        }

        public void MovePresentedItemRight(string itemId, int units)
        {
            droppableItemRenderer.MoveDroppedItemRight(itemId, units);
        }

        private DroppedItemRenderProxy ConvertDropPresentationInformationToRenderProxy(ItemDropPresentationInformation itemDropInfo)
        {
            float posX = ConvertMapPositionToScreenPosition(itemDropInfo.PositionX);
            float posY = ConvertMapPositionToScreenPosition(itemDropInfo.PositionY);

            return new DroppedItemRenderProxy.Builder()
                .SetId(itemDropInfo.UniqueId)
                .SetItemName(itemDropInfo.BaseTypeOrUniqueName)
                .SetRenderImageName(itemDropInfo.BaseTypeOrUniqueName)
                .SetPosX(posX)
                .SetPosY(posY)
                .Build();
        }
    }
}