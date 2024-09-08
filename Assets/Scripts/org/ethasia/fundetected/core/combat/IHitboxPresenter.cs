using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public interface IHitboxPresenter
    {
        void PresentHitbox(int logicalPositionX, int logicalPositionY);
        void PresentStrikeRangeHitbox(int logicalPositionX, int logicalPositionY, int strikeRange);
        void PresentBoundingBox(Position position, BoundingBox boundingBox);
    }
}