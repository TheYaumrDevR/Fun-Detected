using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class GuiSetupInteractor
    {
        public void InitializeGui()
        {
            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();

            PlayerCharacterTotalStats playerStats = Area.ActiveArea.Player.TotalStats;

            int maximumLife = playerStats.MaximumLife;
            int currentLife = playerStats.CurrentLife;

            int maximumMana = playerStats.MaximumMana;
            int currentMana = playerStats.CurrentMana;

            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(currentLife, maximumLife);
            resourceBarPresenter.PresentManaBarBasedOnCurrentAndMaximumMana(currentMana, maximumMana);
        }
    }
}