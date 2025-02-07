using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class PlayerMovementControllerMock : IPlayerMovementController
    {
        public void MoveUnitsLeft(int units) {}

        public void MoveUnitsRight(int units) {}

        public void MoveUnitsDown(int units) {}

        public void MoveUnitsUp(int units) {}

        public void TeleportPlayerTo(int x, int y) {}
    }
}