namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IDroppableItemRenderer
    {
        void ClearRenderedDroppedItems();
        void RenderDroppedItem(DroppedItemRenderProxy renderData);
        void MoveDroppedItemUp(string itemId, int units);
        void MoveDroppedItemDown(string itemId, int units);
        void MoveDroppedItemLeft(string itemId, int units);
        void MoveDroppedItemRight(string itemId, int units);
    }
}