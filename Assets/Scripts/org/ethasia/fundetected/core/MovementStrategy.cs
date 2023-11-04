namespace Org.Ethasia.Fundetected.Core
{
    public abstract class MovementStrategy
    {
        public const int PLAYER_CHAR_HEIGHT_HALF = 16;

        public const int PLAYER_CHAR_WIDTH_HALF = 5; 

        public int CalculateUnitsPlayerCanMoveInHorizontalDirection(int requestedMovementDistance, Position playerPosition)
        {
            if (0 == requestedMovementDistance)
            {
                return 0;
            }

            for (int result = 1; result <= requestedMovementDistance; result++)
            {
                int tagetPositionX = CalculateTargetPositionX(result, playerPosition);

                for (int i = playerPosition.Y - PLAYER_CHAR_HEIGHT_HALF + 1; i <= playerPosition.Y + PLAYER_CHAR_HEIGHT_HALF; i++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(tagetPositionX, i))
                    {
                        AdjustPlayerPositionX(result - 1, playerPosition);
                        return result - 1;
                    }
                }                
            }
            
            AdjustPlayerPositionX(requestedMovementDistance, playerPosition);
            return requestedMovementDistance;
        }

        protected abstract int CalculateTargetPositionX(int requestedMovementDistance, Position playerPosition);
        protected abstract void AdjustPlayerPositionX(int requestedMovementDistance, Position playerPosition);
    }
}