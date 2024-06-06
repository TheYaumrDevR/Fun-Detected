using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class HitboxPresenter : IHitboxPresenter
    {
        private IHitboxDebugShapeRenderer hitboxRenderer;

        public void PresentHitbox(int logicalPositionX, int logicalPositionY)
        {
            hitboxRenderer = TechnicalFactory.GetInstance().GetHitboxDebugShapeRendererInstance();

            float posX = logicalPositionX / 10.0f;
            float posY = logicalPositionY / 10.0f;

            hitboxRenderer.RenderHitboxDebugShape(posX, posY);
        }
    }
}