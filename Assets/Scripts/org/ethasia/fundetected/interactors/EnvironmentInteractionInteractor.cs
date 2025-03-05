using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnvironmentInteractionInteractor : IEnvironmentInteractionInteractor
    {
        public bool InteractWithEnvironment(int mousePositionX, int mousePositionY)
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
                        interactableObject.OnInteract(this);
                        PresentHealthAndManaBarState();

                        return true;
                    }
                }
            }

            return false;
        }

        public void PlayHealingWellUseSound(string playerCharacterName)
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            IPlayerCharacterPresenter playerCharacterPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetPlayerCharacterPresenterInstance();

            soundPresenter.PlayHealingWellUseSound(playerCharacterPresenter.GetPlayerCharacterIdPrefix() + playerCharacterName);
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
    }
}