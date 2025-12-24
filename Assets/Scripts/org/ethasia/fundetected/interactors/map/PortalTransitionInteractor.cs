using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public class PortalTransitionInteractor : IPortalTransitionInteractor
    {
        public void TransitionToOtherMap(string destinationMapId, string destinationPortalId)
        {
            ISwitchMapActionStrategy switchMapActionStrategy = new SwitchMapActionStrategyWithoutSpecificMapIndex(destinationMapId, destinationPortalId, SwitchToAndShowNewMap);
            PerformTransition(switchMapActionStrategy);
        }

        public void TransitionToNewlyCreatedMap(string destinationMapId, string destinationPortalId)
        {
            ISwitchMapActionStrategy switchMapActionStrategy = new SwitchMapActionStrategyWithoutSpecificMapIndex(destinationMapId, destinationPortalId, SwitchToAndShowNewlyCreatedMap);
            PerformTransition(switchMapActionStrategy);
        }

        public void TransitionToSpecificMap(string destinationMapId, string destinationPortalId, int mapIndex)
        {
            ISwitchMapActionStrategy switchMapActionStrategy = new SwitchMapActionStrategyWithSpecificMapIndex(destinationMapId, destinationPortalId, mapIndex, SwitchToAndShowSpecificMap);
            PerformTransition(switchMapActionStrategy);
        }

        private void PerformTransition(ISwitchMapActionStrategy switchMapActionStrategy)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();
            IMapPresenter mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
            IEnemyPresenter enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();

            soundPresenter.PlayPortalTransitionSound();
            playerInputOnOffSwitch.DisableInput();
            mapPresenter.PresentEmpty();
            enemyPresenter.PresentNothing();
            switchMapActionStrategy.ExecuteSwitchMapAction();
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
                areaSwitchingInteractor.PortalPlayerIntoExistingMap(maybeTargetMaps[maybeTargetMaps.Count - 1], destinationPortalId, currentMap.Player);
            }
            else
            {
                areaSwitchingInteractor.PortalPlayerIntoNewMap(destinationMapId, destinationPortalId, currentMap.Player);
            }
        }

        private void SwitchToAndShowSpecificMap(string destinationMapId, string destinationPortalId, int mapIndex)
        {
            StoreCurrentMap();

            Area currentMap = Area.ActiveArea; 

            List<Area> maybeTargetMaps = CreatedMapsStorage.GetInstance().GetStoredMapsById(destinationMapId);

            AreaSwitchingInteractor areaSwitchingInteractor = new AreaSwitchingInteractor();

            if (null != maybeTargetMaps && maybeTargetMaps.Count > mapIndex)
            {
                areaSwitchingInteractor.PortalPlayerIntoExistingMap(maybeTargetMaps[mapIndex], destinationPortalId, currentMap.Player);
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

        private interface ISwitchMapActionStrategy
        {
            void ExecuteSwitchMapAction();       
        }

        private class SwitchMapActionStrategyWithoutSpecificMapIndex : ISwitchMapActionStrategy
        {
            private string destinationMapId;
            private string destinationPortalId;
            private Action<string, string> switchMapAction;

            public SwitchMapActionStrategyWithoutSpecificMapIndex(string destinationMapId, string destinationPortalId, Action<string, string> switchMapAction)
            {
                this.destinationMapId = destinationMapId;
                this.destinationPortalId = destinationPortalId;
                this.switchMapAction = switchMapAction;
            }

            public void ExecuteSwitchMapAction()
            {
                switchMapAction(destinationMapId, destinationPortalId);
            }
        }

        private class SwitchMapActionStrategyWithSpecificMapIndex : ISwitchMapActionStrategy
        {
            private string destinationMapId;
            private string destinationPortalId;
            private int mapIndex;
            private Action<string, string, int> switchMapAction;

            public SwitchMapActionStrategyWithSpecificMapIndex(string destinationMapId, string destinationPortalId, int mapIndex, Action<string, string, int> switchMapAction)
            {
                this.destinationMapId = destinationMapId;
                this.destinationPortalId = destinationPortalId;
                this.mapIndex = mapIndex;
                this.switchMapAction = switchMapAction;
            }

            public void ExecuteSwitchMapAction()
            {
                switchMapAction(destinationMapId, destinationPortalId, mapIndex);
            }
        }
    }
}