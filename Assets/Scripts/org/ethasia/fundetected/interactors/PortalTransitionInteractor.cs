using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PortalTransitionInteractor : IPortalTransitionInteractor
    {
        public void TransitionToOtherMap(string destinationMapId, string destinationPortalId)
        {
            PerformTransition(destinationMapId, destinationPortalId, SwitchToAndShowNewMap);
        }

        public void TransitionToNewlyCreatedMap(string destinationMapId, string destinationPortalId)
        {
            PerformTransition(destinationMapId, destinationPortalId, SwitchToAndShowNewlyCreatedMap);
        }

        private void PerformTransition(string destinationMapId, string destinationPortalId, Action<string, string> switchMapAction)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();
            IMapPresenter mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
            IEnemyPresenter enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();

            soundPresenter.PlayPortalTransitionSound();
            playerInputOnOffSwitch.DisableInput();
            mapPresenter.PresentEmpty();
            enemyPresenter.PresentNothing();
            switchMapAction(destinationMapId, destinationPortalId);
            PresentPlayerOnNewPosition();
            playerInputOnOffSwitch.EnableInput();
        }        

        private void SwitchToAndShowNewlyCreatedMap(string destinationMapId, string destinationPortalId)
        {
            StoreCurrentMap();

            Area currentMap = Area.ActiveArea; 

            AreaSwitchingInteractor areaSwitchingInteractor = new AreaSwitchingInteractor();
            areaSwitchingInteractor.PortalPlayerIntoNewMap(destinationMapId, destinationPortalId, currentMap.Player);
        }

        private void SwitchToAndShowNewMap(string destinationMapId, string destinationPortalId)
        {
            StoreCurrentMap();

            Area currentMap = Area.ActiveArea; 

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

        private void StoreCurrentMap()
        {
            Area currentMap = Area.ActiveArea;
            CreatedMapsStorage.GetInstance().AddMapById(currentMap.Name, currentMap);
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