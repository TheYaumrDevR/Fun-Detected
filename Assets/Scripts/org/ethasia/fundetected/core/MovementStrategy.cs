namespace Org.Ethasia.Fundetected.Core
{
    public abstract class MovementStrategy
    {
        protected static int PLAYER_CHAR_HEIGHT_HALF = 16;

        protected static int PLAYER_CHAR_WIDTH_HALF = 5; 

        public int CalculateUnitsPlayerCanMoveInHorizontalDirection(int requestedMovementDistance, Position playerPosition)
        {
            if (0 == requestedMovementDistance)
            {
                return 0;
            }

            int tagetPositionX = CalculateTargetPositionX(requestedMovementDistance, playerPosition);

            for (int i = playerPosition.Y - PLAYER_CHAR_HEIGHT_HALF + 1; i <= playerPosition.Y + PLAYER_CHAR_HEIGHT_HALF; i++)
            {
                if (Area.ActiveArea.TileAtIsCollision(tagetPositionX, i))
                {
                    return CalculateUnitsPlayerCanMoveInHorizontalDirection(requestedMovementDistance - 1, playerPosition);
                }
            }
            
            AdjustPlayerPositionX(requestedMovementDistance, playerPosition);
            return requestedMovementDistance;
        }

        protected abstract int CalculateTargetPositionX(int requestedMovementDistance, Position playerPosition);
        protected abstract void AdjustPlayerPositionX(int requestedMovementDistance, Position playerPosition);
    }
}