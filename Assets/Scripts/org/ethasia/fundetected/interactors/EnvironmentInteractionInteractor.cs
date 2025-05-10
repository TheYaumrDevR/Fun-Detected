using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnvironmentInteractionInteractor : IEnvironmentInteractionInteractor
    {
        public bool InteractWithEnvironment(int mousePositionX, int mousePositionY)
        {
            return InteractWithEnvironment(mousePositionX, mousePositionY, (interactableObject) => 
            {
                interactableObject.OnInteract(this);
                PresentHealthAndManaBarState();
            });
        }

        public bool SecondaryInteractWithEnvironment(int mousePositionX, int mousePositionY)
        {
            return InteractWithEnvironment(mousePositionX, mousePositionY, (interactableObject) => 
            {
                interactableObject.OnSecondaryInteract(this);
            });
        }

        public void PlayHealingWellUseSound(string playerCharacterName)
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            IPlayerCharacterPresenter playerCharacterPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerCharacterPresenterInstance();

            soundPresenter.PlayHealingWellUseSound(playerCharacterPresenter.GetPlayerCharacterIdPrefix() + playerCharacterName);
        }

        public void ActivateMapSelection(string mapName, List<Area> mapInstances)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();

            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowMapSelectionWindow(mapName, ConvertMapInstancesToInstanceIds(mapInstances));
            playerInputOnOffSwitch.DisableInput();
        }

        public void ActivateMapSelectionForSingletonMap(string mapName)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();

            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowMapSelectionWindowForSingletonMap(mapName, GetMapInstanceId(1));
            playerInputOnOffSwitch.DisableInput();
        }

        private bool InteractWithEnvironment(int mousePositionX, int mousePositionY, Action<InteractableEnvironmentObject> interactionAction)
        {
            Area activeArea = Area.ActiveArea;

            foreach (InteractableEnvironmentObject interactableObject in activeArea.InteractableEnvironmentObjects)
            {
                CollisionCalculations.CollisionBoundingBoxContext interactableBoundingBox = interactableObject.GetCollisionBoundingBoxContext();

                if (mousePositionX >= interactableBoundingBox.PositionX - interactableBoundingBox.DistanceToLeftEdge
                    && mousePositionX <= interactableBoundingBox.PositionX + interactableBoundingBox.DistanceToRightEdge
                    && mousePositionY >= interactableBoundingBox.PositionY - interactableBoundingBox.DistanceToBottomEdge
                    && mousePositionY <= interactableBoundingBox.PositionY + interactableBoundingBox.DistanceToTopEdge)
                {
                    BoundingBox playerBoundingBox = activeArea.Player.BoundingBox;
                    CollisionCalculations.CollisionBoundingBoxContext playerBoundingBoxContext = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                        .SetPositionX(activeArea.GetPlayerPositionX())
                        .SetPositionY(activeArea.GetPlayerPositionY())
                        .SetDistanceToLeftEdge(playerBoundingBox.DistanceToLeftEdge)
                        .SetDistanceToRightEdge(playerBoundingBox.DistanceToRightEdge)
                        .SetDistanceToBottomEdge(playerBoundingBox.DistanceToBottomEdge)
                        .SetDistanceToTopEdge(playerBoundingBox.DistanceToTopEdge)
                        .Build();

                    if (CollisionCalculations.AreBoundingBoxesOverlapping(playerBoundingBoxContext, interactableBoundingBox))
                    {
                        interactionAction(interactableObject);
                        return true;
                    }
                }
            }

            return false;
        }        

        private void PresentHealthAndManaBarState()
        {
            PlayerCharacterBaseStats playerBaseStats = Area.ActiveArea.Player.BaseStats;

            int maximumLife = playerBaseStats.MaximumLife;
            int currentLife = playerBaseStats.CurrentLife;             

            int maximumMana = playerBaseStats.MaximumMana;
            int currentMana = playerBaseStats.CurrentMana;                       

            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();
            
            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(currentLife, maximumLife);
            resourceBarPresenter.PresentManaBarBasedOnCurrentAndMaximumMana(currentMana, maximumMana);
        }

        private List<string> ConvertMapInstancesToInstanceIds(List<Area> mapInstances)
        {
            List<string> result = new List<string>();

            int i = 1;
            foreach (Area map in mapInstances)
            {
                result.Add(GetMapInstanceId(i));
                i++;
            }

            return result;
        }

        private string GetMapInstanceId(int instanceIndex)
        {
            return "Instance #" + instanceIndex;
        }
    }
}