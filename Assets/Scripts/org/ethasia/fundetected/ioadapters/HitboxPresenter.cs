using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class HitboxPresenter : IHitboxPresenter
    {
        private IHitboxDebugShapeRenderer hitboxRenderer;

        public void PresentHitbox(int logicalPositionX, int logicalPositionY)
        {

        }

        public void PresentStrikeRangeHitbox(int logicalPositionX, int logicalPositionY, int strikeRange)
        {

        }      

        public void PresentBoundingBox(Position position, BoundingBox boundingBox)
        {
            hitboxRenderer = TechnicalFactory.GetInstance().GetHitboxDebugShapeRendererInstance();

            for (int i = position.X - boundingBox.DistanceToLeftEdge; i <= position.X + boundingBox.DistanceToRightEdge; i++)
            {
                for (int j = position.Y - boundingBox.DistanceToBottomEdge; j <= position.Y + boundingBox.DistanceToTopEdge; j++)
                {
                    float posX = i / 10.0f;
                    float posY = j / 10.0f;

                    hitboxRenderer.RenderHitboxDebugShape(posX, posY);
                }
            }            
        }  

        private void PresentHitboxReal(int logicalPositionX, int logicalPositionY)
        {
            hitboxRenderer = TechnicalFactory.GetInstance().GetHitboxDebugShapeRendererInstance();

            float posX = logicalPositionX / 10.0f;
            float posY = logicalPositionY / 10.0f;

            hitboxRenderer.RenderHitboxDebugShape(posX, posY);
        }

        private void PresentStrikeRangeHitboxReal(int logicalPositionX, int logicalPositionY, int strikeRange)
        {
            hitboxRenderer = TechnicalFactory.GetInstance().GetHitboxDebugShapeRendererInstance();

            for (int i = logicalPositionX - strikeRange; i <= logicalPositionX + strikeRange; i++)
            {
                for (int j = logicalPositionY - strikeRange; j <= logicalPositionY + strikeRange; j++)
                {
                    float posX = i / 10.0f;
                    float posY = j / 10.0f;

                    hitboxRenderer.RenderHitboxDebugShape(posX, posY);
                }
            }
        }   
    }
}