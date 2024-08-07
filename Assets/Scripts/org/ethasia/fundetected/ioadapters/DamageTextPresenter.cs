using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DamageTextPresenter : IDamageTextPresenter
    {
        private IFloatingDamageTextRenderer damageTextRenderer;

        public void PresentDamageText(DamageTextDisplayInformation displayInformation)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();

            int damageAmount = displayInformation.DamageValue;
            float posX = displayInformation.PositionX / 10.0f;
            float posY = displayInformation.PositionY / 10.0f;

            damageTextRenderer.RenderFloatingDamageText(damageAmount.ToString(), posX, posY);
        }

        public void PresentMissText(Position renderPosition)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();

            float posX = renderPosition.X / 10.0f;
            float posY = renderPosition.Y / 10.0f;

            damageTextRenderer.RenderFloatingDamageText("MISS", posX, posY);
        }
    }
}