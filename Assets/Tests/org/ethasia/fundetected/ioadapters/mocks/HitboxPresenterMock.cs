using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class HitboxPresenterMock : IHitboxPresenter
    {
        public void PresentHitbox(int logicalPositionX, int logicalPositionY)
        {

        }

        public void PresentStrikeRangeHitbox(int logicalPositionX, int logicalPositionY, int strikeRange)
        {

        }          

        public void PresentBoundingBox(Position position, BoundingBox boundingBox)
        {
            
        } 
    }
}