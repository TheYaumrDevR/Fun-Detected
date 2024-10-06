using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class GuiSetupInteractor
    {
        public void InitializeGui()
        {
            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();

            PlayerCharacterBaseStats playerBaseStats = Area.ActiveArea.Player.BaseStats;

            int maximumLife = playerBaseStats.MaximumLife;
            int currentLife = playerBaseStats.CurrentLife;

            int maximumMana = playerBaseStats.MaximumMana;
            int currentMana = playerBaseStats.CurrentMana;

            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(currentLife, maximumLife);
            resourceBarPresenter.PresentManaBarBasedOnCurrentAndMaximumMana(currentMana, maximumMana);
        }
    }
}