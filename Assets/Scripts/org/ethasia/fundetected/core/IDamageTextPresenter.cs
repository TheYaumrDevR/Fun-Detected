namespace Org.Ethasia.Fundetected.Core
{
    public interface IDamageTextPresenter
    {
        void PresentDamageText(DamageTextDisplayInformation displayInformation);
        void PresentMissText(Position renderPosition);
    }
}