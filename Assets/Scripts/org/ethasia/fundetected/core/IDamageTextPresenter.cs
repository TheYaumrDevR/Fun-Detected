namespace Org.Ethasia.Fundetected.Core
{
    public interface IDamageTextPresenter
    {
        void PresentDamageText(DamageTextDisplayInformation displayInformation);
        void PresentPlayerDamageText(DamageTextDisplayInformation displayInformation);
        void PresentMissText(Position renderPosition);
        void PresentPlayerMissedText(Position renderPosition);
    }
}