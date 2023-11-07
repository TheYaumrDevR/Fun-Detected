namespace Org.Ethasia.Fundetected.Core
{
    public class MoveRightStrategy : MovementStrategy
    {
        protected override int CalculateTargetPositionX(int requestedMovementDistance, Position playerPosition)
        {
            return playerPosition.X + UNITS_TO_PLAYER_RIGHT_BORDER + requestedMovementDistance;
        }

        protected override void AdjustPlayerPositionX(int requestedMovementDistance, Position playerPosition)
        {
            playerPosition.X += requestedMovementDistance;
        }
    }
}