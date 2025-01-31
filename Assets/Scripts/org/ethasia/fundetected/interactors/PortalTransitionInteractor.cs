using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PortalTransitionInteractor : IPortalTransitionInteractor
    {
        public void TransitionToOtherMap(string destinationMapId, string destinationPortalId)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();
            IMapPresenter mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
            IEnemyPresenter enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            
            playerInputOnOffSwitch.DisableInput();
            mapPresenter.PresentEmpty();
            enemyPresenter.PresentNothing();
            // Call area Switch interactor to load new map
            playerInputOnOffSwitch.EnableInput();
        }
    }
}