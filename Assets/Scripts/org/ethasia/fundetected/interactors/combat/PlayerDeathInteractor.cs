using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class PlayerDeathInteractor : IPlayerDeathInteractor
    {
        public void NotifyPlayerDied()
        {
            InternalInteractorsFactory.GetInstance().GetPlayerAnimationPresenterInstance().StartDeadAnimation();
        }

        public void NotifyPlayerTombstoneLanded(int lostExperiencePoints)
        {
            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowDeathOverlay(lostExperiencePoints);
        }
    }
}