using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class PlayerDamageTakenInteractor : IPlayerDamageTakenInteractor
    {
        public void NotifyPlayerOfDamageTaken(IPlayerDamageTakenInteractor.PlayerDamageContext context)
        {
            PresentDamageTakenText(context.DamageTaken);
            UpdateHealthBar(context.CurrentHealth, context.MaximumHealth);
        }

        private void PresentDamageTakenText(int damageTaken)
        {
            IDamageTextPresenter damageTextPresenter = IoAdaptersFactoryForCore.GetInstance().GetDamageTextPresenterInstance();

            Area map = Area.ActiveArea;

            DamageTextDisplayInformation damageTextDisplayInformation = new DamageTextDisplayInformation();
            damageTextDisplayInformation.DamageValue = damageTaken;
            damageTextDisplayInformation.PositionX = map.GetPlayerPositionX();
            damageTextDisplayInformation.PositionY = map.GetPlayerPositionY();

            damageTextPresenter.PresentPlayerDamageText(damageTextDisplayInformation);
        }       

        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();
            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(currentHealth, maximumHealth);
        } 
    }
}