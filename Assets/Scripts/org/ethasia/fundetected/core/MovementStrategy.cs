namespace Org.Ethasia.Fundetected.Core
{
    public abstract class MovementStrategy
    {

        public const int UNITS_TO_PLAYER_BOTTOM_BORDER = 15;

        public const int UNITS_TO_PLAYER_TOP_BORDER = UNITS_TO_PLAYER_BOTTOM_BORDER + 1;

        public const int UNITS_TO_PLAYER_LEFT_BORDER = 4; 

        public const int UNITS_TO_PLAYER_RIGHT_BORDER = UNITS_TO_PLAYER_LEFT_BORDER + 1; 

        public int CalculateUnitsPlayerCanMoveInHorizontalDirection(int requestedMovementDistance, Position playerPosition)
        {
            if (0 == requestedMovementDistance)
            {
                return 0;
            }

            for (int result = 1; result <= requestedMovementDistance; result++)
            {
                int tagetPositionX = CalculateTargetPositionX(result, playerPosition);

                for (int i = playerPosition.Y - UNITS_TO_PLAYER_BOTTOM_BORDER; i <= playerPosition.Y + UNITS_TO_PLAYER_TOP_BORDER; i++)
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