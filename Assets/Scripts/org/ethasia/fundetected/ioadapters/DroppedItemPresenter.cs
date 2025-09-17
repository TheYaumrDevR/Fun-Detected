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

        private DroppedItemRenderProxy ConvertDropPresentationInformationToRenderProxy(ItemDropPresentationInformation itemDropInfo)
        {
            float posX = ConvertMapPositionToScreenPosition(itemDropInfo.PositionX);
            float posY = ConvertMapPositionToScreenPosition(itemDropInfo.PositionY);

            return new DroppedItemRenderProxy.Builder()
                .SetId(itemDropInfo.BaseTypeOrUniqueName)
                .SetItemName(itemDropInfo.BaseTypeOrUniqueName)
                .SetRenderImageName(itemDropInfo.BaseTypeOrUniqueName)
                .SetPosX(posX)
                .SetPosY(posY)
                .Build();
        }
    }
}