namespace Org.Ethasia.Fundetected.Core
{
    public interface IHitboxPresenter
    {
        void PresentHitbox(int logicalPositionX, int logicalPositionY);
        void PresentStrikeRangeHitbox(int logicalPositionX, int logicalPositionY, int strikeRange);
    }
}