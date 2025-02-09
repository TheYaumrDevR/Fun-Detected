using System.Collections.Generic;

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
            SwitchToAndShowNewMap(destinationMapId, destinationPortalId);
            PresentPlayerOnNewPosition();
            playerInputOnOffSwitch.EnableInput();
        }

        private void SwitchToAndShowNewMap(string destinationMapId, string destinationPortalId)
        {
            Area currentMap = Area.ActiveArea;
            CreatedMapsStorage.GetInstance().AddMapById(currentMap.Name, currentMap);
            List<Area> maybeTargetMaps = CreatedMapsStorage.GetInstance().GetStoredMapsById(destinationMapId);

            AreaSwitchingInteractor areaSwitchingInteractor = new AreaSwitchingInteractor();

            if (null != maybeTargetMaps && maybeTargetMaps.Count > 0)
            {
                areaSwitchingInteractor.PortalPlayerIntoExistingMap(maybeTargetMaps[0], destinationPortalId, currentMap.Player);
            }
            else
            {
                areaSwitchingInteractor.PortalPlayerIntoNewMap(destinationMapId, destinationPortalId, currentMap.Player);
            }
        }

        private void PresentPlayerOnNewPosition()
        {
            int playerPositionX = Area.ActiveArea.GetPlayerPositionX();
            int playerPositionY = Area.ActiveArea.GetPlayerPositionY();
            GetPlayerMovementController().TeleportPlayerTo(playerPositionX, playerPositionY);
        }

        private IPlayerMovementController GetPlayerMovementController()
        {
            return IoAdaptersFactoryForInteractors.GetInstance().GetPlayerMovementControllerInstance();
        } 
    }
}