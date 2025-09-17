using System;   

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DamageTextPresenter : SpritesPresenter, IDamageTextPresenter
    {
        private IFloatingDamageTextRenderer damageTextRenderer;

        public void PresentDamageText(DamageTextDisplayInformation displayInformation)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();
            PresentDamageText(displayInformation, damageTextRenderer.RenderFloatingDamageText);
        }

        public void PresentPlayerDamageText(DamageTextDisplayInformation displayInformation)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();
            PresentDamageText(displayInformation, damageTextRenderer.RenderFloatingPlayerDamageText);
        }

        public void PresentMissText(Position renderPosition)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();
            PresentMissText(renderPosition, damageTextRenderer.RenderFloatingDamageText);
        }

        public void PresentPlayerMissedText(Position renderPosition)
        {
            damageTextRenderer = TechnicalFactory.GetInstance().GetFloatingDamageTextRendererInstance();
            PresentMissText(renderPosition, damageTextRenderer.RenderFloatingPlayerDamageText);
        }        

        private void PresentDamageText(DamageTextDisplayInformation displayInformation, Action<string, float, float> renderMethod)
        {
            int damageAmount = displayInformation.DamageValue;
            float posX = ConvertMapPositionToScreenPosition(displayInformation.PositionX);
            float posY = ConvertMapPositionToScreenPosition(displayInformation.PositionY);

            renderMethod(damageAmount.ToString(), posX, posY);
        }

        private void PresentMissText(Position renderPosition, Action<string, float, float> renderMethod)
        {
            float posX = ConvertMapPositionToScreenPosition(renderPosition.X);
            float posY = ConvertMapPositionToScreenPosition(renderPosition.Y);

            renderMethod("MISS", posX, posY);
        }
    }
}