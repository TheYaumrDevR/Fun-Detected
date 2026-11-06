namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IStaticPlaceablesPresenter
    {
        void PresentTombstone(string id, int positionX, int positionY);
        void MovePresentedTombstoneVertically(string id, int units);
    }
}