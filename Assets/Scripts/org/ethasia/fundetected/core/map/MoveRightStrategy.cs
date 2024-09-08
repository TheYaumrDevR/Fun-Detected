namespace Org.Ethasia.Fundetected.Core.Map
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

        protected override int CalculatePlayerPositionXOffsetByOne(Position playerPosition)
        {
            return playerPosition.X + 1;
        }

        protected override int CalculateBorderX(int playerPositionOffsetX)
        {
            return playerPositionOffsetX + UNITS_TO_PLAYER_RIGHT_BORDER;
        }
    }
}