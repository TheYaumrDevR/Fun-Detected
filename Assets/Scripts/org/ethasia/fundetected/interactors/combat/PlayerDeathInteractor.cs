using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class PlayerDeathInteractor : IPlayerDeathInteractor
    {
        public void NotifyPlayerDied(int lostExperiencePoints)
        {
            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowDeathOverlay(lostExperiencePoints);
        }
    }
}