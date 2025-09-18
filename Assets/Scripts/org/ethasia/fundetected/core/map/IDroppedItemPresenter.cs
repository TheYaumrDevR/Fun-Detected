namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IDroppedItemPresenter
    {
        void PresentItemDrop(ItemDropPresentationInformation itemDropInfo);
        void MovePresentedItemUp(string itemId, int units);
        void MovePresentedItemDown(string itemId, int units);
        void MovePresentedItemLeft(string itemId, int units);
        void MovePresentedItemRight(string itemId, int units);
    }
}