using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{

    public class PlayerMovementInteractor
    {
        public void MovePlayerLeft(double deltaTime)
        {
            Area activeArea = Area.ActiveArea;
            PlayerCharacter player = GetPlayerCharacter();
            int unitsToMove = player.MoveLeft(deltaTime);
            int unitsMoved = activeArea.CalculateUnitsPlayerCanMoveLeft(unitsToMove);

            GetPlayerMovementController().MoveUnitsLeft(unitsMoved);
        }

        public void MovePlayerRight(double deltaTime)
        {
            Area activeArea = Area.ActiveArea;
            PlayerCharacter player = GetPlayerCharacter();
            int unitsToMove = player.MoveRight(deltaTime);
            int unitsMoved = activeArea.CalculateUnitsPlayerCanMoveRight(unitsToMove);

            GetPlayerMovementController().MoveUnitsRight(unitsMoved);
        }

        private PlayerCharacter GetPlayerCharacter()
        {
            Area activeArea = Area.ActiveArea;
            return activeArea.Player;
        }

        private IPlayerMovementController GetPlayerMovementController()
        {
            return IoAdaptersFactoryForInteractors.GetInstance().GetPlayerMovementControllerInstance();
        }
    }
}