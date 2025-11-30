namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IDroppedItemPresenter
    {
        void PresentItemDrop(ItemDropPresentationInformation itemDropInfo);
        void MovePresentedItemVertically(string itemId, int units);
        void MovePresentedItemLeft(string itemId, int units);
        void MovePresentedItemRight(string itemId, int units);
        void UpdateItemPresentationWhenRestingOnGround(ItemDropPresentationInformation itemDropInfo);
        void ClearPresentedItem(string itemId);
    }
}