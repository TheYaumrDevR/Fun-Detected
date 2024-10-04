using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
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
            damageTextDisplayInformation.PositionX = map.GetPlayerPositionX() + map.LowestScreenX;
            damageTextDisplayInformation.PositionY = map.GetPlayerPositionY() + map.LowestScreenY;

            damageTextPresenter.PresentPlayerDamageText(damageTextDisplayInformation);
        }       

        private void UpdateHealthBar(int currentHealth, int maximumHealth)
        {
            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();
            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(currentHealth, maximumHealth);
        } 
    }
}