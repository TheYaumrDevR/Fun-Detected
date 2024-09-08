using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IDamageTextPresenter
    {
        void PresentDamageText(DamageTextDisplayInformation displayInformation);
        void PresentPlayerDamageText(DamageTextDisplayInformation displayInformation);
        void PresentMissText(Position renderPosition);
        void PresentPlayerMissedText(Position renderPosition);
    }
}