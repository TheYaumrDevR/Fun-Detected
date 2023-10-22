using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{

    public class PlayerMovementInteractor
    {
        public void MovePlayerLeft(double deltaTime)
        {
            PlayerCharacter player = GetPlayerCharacter();
            int unitsMoved = player.MoveLeft(deltaTime);

            GetPlayerMovementController().MoveUnitsLeft(unitsMoved);
        }

        public void MovePlayerRight(double deltaTime)
        {
            PlayerCharacter player = GetPlayerCharacter();
            int unitsMoved = player.MoveRight(deltaTime);

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