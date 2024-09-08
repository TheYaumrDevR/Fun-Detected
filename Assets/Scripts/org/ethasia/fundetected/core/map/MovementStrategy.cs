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

        public int TryToMovePlayerStepUp(Position playerPosition)
        {
            int maximumStepHeight = 10;

            int startingClimbPositionY = playerPosition.Y - UNITS_TO_PLAYER_BOTTOM_BORDER + 1;
            int endingClimbPositionY = playerPosition.Y - UNITS_TO_PLAYER_BOTTOM_BORDER + maximumStepHeight;

            int playerPositionXOffsetByOne = CalculatePlayerPositionXOffsetByOne(playerPosition);

            while (startingClimbPositionY <= endingClimbPositionY)
            {
                int currentPlayerPositionY = startingClimbPositionY + UNITS_TO_PLAYER_BOTTOM_BORDER;

                if (TopBorderCollides(playerPositionXOffsetByOne, currentPlayerPositionY))
                {
                    return 0;
                }

                if (!BorderCollides(playerPositionXOffsetByOne, currentPlayerPositionY))
                {
                    int result = maximumStepHeight - (endingClimbPositionY - startingClimbPositionY);

                    if (result > 0)
                    {
                        AdjustPlayerPositionX(1, playerPosition);
                        playerPosition.Y += result;
                    }

                    return result;
                }

                startingClimbPositionY++;
            }

            return 0;
        }    

        private bool BorderCollides(int playerPositionOffsetX, int currentPlayerPositionY)
        {
            int borderX = CalculateBorderX(playerPositionOffsetX);
            int yStart = currentPlayerPositionY - UNITS_TO_PLAYER_BOTTOM_BORDER;           
            int yEnd = currentPlayerPositionY + UNITS_TO_PLAYER_TOP_BORDER;  

            while (yStart <= yEnd)
            {
                if (Area.ActiveArea.TileAtIsCollision(borderX, yStart))
                {
                    return true;
                }

                yStart++;
            } 

            return false;            
        }

        private bool TopBorderCollides(int playerPositionX, int playerPositionY)
        {
            int topBorderY = playerPositionY + UNITS_TO_PLAYER_TOP_BORDER;
            int xStart = playerPositionX - UNITS_TO_PLAYER_LEFT_BORDER;           
            int xEnd = playerPositionX + UNITS_TO_PLAYER_RIGHT_BORDER;  

            while (xStart <= xEnd)
            {
                if (Area.ActiveArea.TileAtIsCollision(xStart, topBorderY))
                {
                    return true;
                }

                xStart++;
            } 

            return false;
        }               

        protected abstract int CalculateTargetPositionX(int requestedMovementDistance, Position playerPosition);
        protected abstract void AdjustPlayerPositionX(int requestedMovementDistance, Position playerPosition);
        protected abstract int CalculatePlayerPositionXOffsetByOne(Position playerPosition);
        protected abstract int CalculateBorderX(int playerPositionOffsetX);
    }
}