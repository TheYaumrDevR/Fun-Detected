namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IPlayerMovementController
    {
        void MoveUnitsLeft(int units);
        void MoveUnitsRight(int units);
        void MoveUnitsDown(int units);
    }
}