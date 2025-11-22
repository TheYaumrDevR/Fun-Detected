using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnvironmentInteractionInteractor : IEnvironmentInteractionInteractor
    {
        public bool InteractWithEnvironment(int mousePositionX, int mousePositionY)
        {
            int pickedUpItemIndex = GetItemIndexInteractedWith(mousePositionX, mousePositionY);

            if (pickedUpItemIndex >= 0)
            {
                Area.ActiveArea.PickupItem(pickedUpItemIndex);
                return true;
            }

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

        public void ActivateMapSelection(string mapName, string destinationPortalId, List<Area> mapInstances)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();

            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowMapSelectionWindow(mapName, destinationPortalId, ConvertMapInstancesToInstanceIds(mapInstances));
            playerInputOnOffSwitch.DisableInput();
        }

        public void ActivateMapSelectionForSingletonMap(string mapName, string destinationPortalId)
        {
            IPlayerInputOnOffSwitch playerInputOnOffSwitch = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerInputOnOffSwitchInstance();

            IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
            guiWindowsPresenter.ShowMapSelectionWindowForSingletonMap(mapName, destinationPortalId, GetMapInstanceId(1));
            playerInputOnOffSwitch.DisableInput();
        }

        private int GetItemIndexInteractedWith(int mousePositionX, int mousePositionY)
        {
            Area activeArea = Area.ActiveArea;

            List<Item> droppedItems = activeArea.DroppedItems;

            int result = -1;
            foreach (Item droppedItem in droppedItems)
            {
                result++;

                RectangleCollisionShape itemCollisionShape = droppedItem.CollisionShape;
                CollisionCalculations.CollisionBoundingBoxContext interactableBoundingBox = CollisionCalculations.CollisionBoundingBoxContext.FromRectangleCollisionShape(itemCollisionShape);

                if (CollisionCalculations.IsMousePointerInsideBoundingBox(mousePositionX, mousePositionY, interactableBoundingBox))
                {
                    CollisionCalculations.CollisionBoundingBoxContext playerBoundingBoxContext = CollisionCalculations.CollisionBoundingBoxContext.FromPlayerCharacterInArea(activeArea);

                    if (CollisionCalculations.AreBoundingBoxesOverlapping(playerBoundingBoxContext, interactableBoundingBox))
                    {
                        return result;
                    }
                }
            }

            return -1;
        }

        private bool InteractWithEnvironment(int mousePositionX, int mousePositionY, Action<InteractableEnvironmentObject> interactionAction)
        {
            Area activeArea = Area.ActiveArea;

            foreach (InteractableEnvironmentObject interactableObject in activeArea.InteractableEnvironmentObjects)
            {
                CollisionCalculations.CollisionBoundingBoxContext interactableBoundingBox = interactableObject.GetCollisionBoundingBoxContext();

                if (CollisionCalculations.IsMousePointerInsideBoundingBox(mousePositionX, mousePositionY, interactableBoundingBox))
                {
                    CollisionCalculations.CollisionBoundingBoxContext playerBoundingBoxContext = CollisionCalculations.CollisionBoundingBoxContext.FromPlayerCharacterInArea(activeArea);

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