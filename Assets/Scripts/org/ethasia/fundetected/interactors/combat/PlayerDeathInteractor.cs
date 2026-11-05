using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class PlayerDeathInteractor : IPlayerDeathInteractor
    {
        public void NotifyPlayerDied(int lostExperiencePoints)
        {
            PresentTombstoneAtPlayerPosition();

            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowDeathOverlay(lostExperiencePoints);
        }

        private void PresentTombstoneAtPlayerPosition()
        {
            IMapPresenter mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
            mapPresenter.PresentTombstone(Area.ActiveArea.GetPlayerPositionX(), Area.ActiveArea.GetPlayerPositionY());
        }
    }
}