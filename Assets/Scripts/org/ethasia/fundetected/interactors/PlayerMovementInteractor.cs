using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{

    public class PlayerMovementInteractor
    {
        public void MovePlayerLeft(double deltaTime)
        {
            PlayerCharacter player = GetPlayerCharacter();
            int unitsToMove = player.MoveLeft(deltaTime);

            MovePlayerLeft(unitsToMove);
        }

        public void MovePlayerRight(double deltaTime)
        {
            PlayerCharacter player = GetPlayerCharacter();
            int unitsToMove = player.MoveRight(deltaTime);

            MovePlayerRight(unitsToMove);
        }

        private PlayerCharacter GetPlayerCharacter()
        {
            Area activeArea = Area.ActiveArea;
            return activeArea.Player;
        }

        private bool PlayerCollidedWithWallAndIsOnFloor(int deltaUnitsMoved, int unitsDropped)
        {
            return deltaUnitsMoved > 0 && unitsDropped == 0;
        }

        private void MovePlayerRight(int unitsToMove)
        {
            Area activeArea = Area.ActiveArea;
            int unitsMoved = activeArea.CalculateUnitsPlayerCanMoveRight(unitsToMove);
            int unitsDropped = activeArea.CalculateFallDepth();

            if (PlayerCollidedWithWallAndIsOnFloor(unitsToMove - unitsMoved, unitsDropped))
            {
                int stepHeight = activeArea.TryToMovePlayerRightStepUp();

                if (stepHeight > 0)
                {
                    GetPlayerMovementController().MoveUnitsRight(1);
                    GetPlayerMovementController().MoveUnitsUp(stepHeight);

                    if (unitsToMove - unitsMoved - 1 > 0)
                    {
                        MovePlayerRight(unitsToMove - unitsMoved - 1);
                    }                    
                }
            }

            GetPlayerMovementController().MoveUnitsRight(unitsMoved);
            GetPlayerMovementController().MoveUnitsDown(unitsDropped);

            GetPlayerAnimationPresenter().StartWalkAnimation();
        }

        private void MovePlayerLeft(int unitsToMove)
        {
            Area activeArea = Area.ActiveArea;
            int unitsMoved = activeArea.CalculateUnitsPlayerCanMoveLeft(unitsToMove);
            int unitsDropped = activeArea.CalculateFallDepth();

            if (PlayerCollidedWithWallAndIsOnFloor(unitsToMove - unitsMoved, unitsDropped))
            {
                int stepHeight = activeArea.TryToMovePlayerLeftStepUp();

                if (stepHeight > 0)
                {
                    GetPlayerMovementController().MoveUnitsLeft(1);
                    GetPlayerMovementController().MoveUnitsUp(stepHeight);

                    if (unitsToMove - unitsMoved - 1 > 0)
                    {
                        MovePlayerLeft(unitsToMove - unitsMoved - 1);
                    }                    
                }
            }            

            GetPlayerMovementController().MoveUnitsLeft(unitsMoved);
            GetPlayerMovementController().MoveUnitsDown(unitsDropped);

            GetPlayerAnimationPresenter().StartWalkAnimation();
        }

        private IPlayerMovementController GetPlayerMovementController()
        {
            return IoAdaptersFactoryForInteractors.GetInstance().GetPlayerMovementControllerInstance();
        }

        private PlayerAnimationPresenter GetPlayerAnimationPresenter()
        {
            return IoAdaptersFactoryForInteractors.GetInstance().GetPlayerAnimationPresenterInstance();
        }        
    }
}