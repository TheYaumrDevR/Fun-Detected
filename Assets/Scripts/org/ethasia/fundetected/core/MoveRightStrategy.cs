namespace Org.Ethasia.Fundetected.Core
{
    public class MoveRightStrategy : MovementStrategy
    {
        protected override int CalculateTargetPositionX(int requestedMovementDistance, Position playerPosition)
        {
            return playerPosition.X + PLAYER_CHAR_WIDTH_HALF + requestedMovementDistance;
        }

        protected override void AdjustPlayerPositionX(int requestedMovementDistance, Position playerPosition)
        {
            playerPosition.X += requestedMovementDistance;
        }
    }
}