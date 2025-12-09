namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IDroppableItemRenderer
    {
        void ClearRenderedDroppedItems();
        void RenderDroppedItem(DroppedItemRenderProxy renderData);
        void MoveDroppedItemVertically(string itemId, float units);
        void MoveDroppedItemLeft(string itemId, float units);
        void MoveDroppedItemRight(string itemId, float units);
        void RenderDroppedItemLabel(DroppedItemRenderProxy renderData);
        void ClearRenderedItem(string itemId);
    }
}