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

        protected override int CalculatePlayerPositionXOffsetByOne(Position playerPosition)
        {
            return playerPosition.X + 1;
        }

        protected override bool BorderCollides(int playerPositionOffsetX, int currentPlayerPositionY)
        {
            int rightBorderX = playerPositionOffsetX + MovementStrategy.UNITS_TO_PLAYER_RIGHT_BORDER;
            int yStart = currentPlayerPositionY - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER;           
            int yEnd = currentPlayerPositionY + MovementStrategy.UNITS_TO_PLAYER_TOP_BORDER;  

            while (yStart <= yEnd)
            {
                if (Area.ActiveArea.TileAtIsCollision(rightBorderX, yStart))
                {
                    return true;
                }

                yStart++;
            } 

            return false;
        }
    }
}