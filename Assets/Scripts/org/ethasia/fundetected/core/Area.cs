using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class Area
    {
        public static Area ActiveArea;

        private static MovementStrategy MOVE_LEFT_STRATEGY = new MoveLeftStrategy();

        private static MovementStrategy MOVE_RIGHT_STRATEGY = new MoveRightStrategy();

        private int width;

        private int height;

        private bool[,] isCollisionTile;

        private Position playerPosition;

        public PlayerCharacter Player
        {
            get;
            private set;
        }

        private List<Enemy> enemies;

        private Area(bool[,] isCollisionTile)
        {
            width = isCollisionTile.GetLength(0);
            height = isCollisionTile.GetLength(1);

            enemies = new List<Enemy>();
            this.isCollisionTile = isCollisionTile; 
            playerPosition = new Position();
        }

        public bool TileAtIsCollision(int x, int y)
        {   
            if (x < 0 || y < 0)
            {
                return true;
            }

            if (x >= width || y >= height)
            {
                return true;
            }

            return isCollisionTile[x, y];
        }

        public List<Enemy> GetEnemies()
        {
            return enemies;
        }        
        public void AddPlayerAt(PlayerCharacter value, int x, int y)
        {
            if (null != value && Player == null)
            {
                Player = value;
                playerPosition.X = x;
                playerPosition.Y = y;
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }        

        public Enemy GetEnemyHit()
        {
            if (enemies.Count > 0)
            {
                return enemies[0];
            }

            return null;
        }

        public int CalculateUnitsPlayerCanMoveRight(int requestedMovementDistance)
        {
            return MOVE_RIGHT_STRATEGY.CalculateUnitsPlayerCanMoveInHorizontalDirection(requestedMovementDistance, playerPosition);
        }

        public int CalculateUnitsPlayerCanMoveLeft(int requestedMovementDistance)
        {
            return MOVE_LEFT_STRATEGY.CalculateUnitsPlayerCanMoveInHorizontalDirection(requestedMovementDistance, playerPosition);
        }       

        public int CalculateFallDepth()
        {
            int result = 0;

            for (int i = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER - 1; i > 0; i--)
            {
                for (int x = playerPosition.X - MovementStrategy.UNITS_TO_PLAYER_LEFT_BORDER; x <= playerPosition.X + MovementStrategy.UNITS_TO_PLAYER_RIGHT_BORDER; x++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(x, i))
                    {
                        playerPosition.Y -= result;
                        return result;
                    }
                }

                result++;
            }

            playerPosition.Y -= result;
            return result;
        } 

        public int TryToMovePlayerRightStepUp()
        {
            int maximumStepHeight = 10;

            int targetPositionRightBorderX = playerPosition.X + MovementStrategy.UNITS_TO_PLAYER_RIGHT_BORDER + 1;
            int startingClimbPositionY = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER + 1;
            int endingClimbPositionY = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER + maximumStepHeight;

            int playerPositionOneRightX = playerPosition.X + 1;

            while (startingClimbPositionY <= endingClimbPositionY)
            {
                int currentPlayerPositionY = startingClimbPositionY + MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER;

                if (TopBorderCollides(playerPositionOneRightX, currentPlayerPositionY))
                {
                    return 0;
                }

                if (!RightBorderCollides(playerPositionOneRightX, currentPlayerPositionY))
                {
                    int result = maximumStepHeight - (endingClimbPositionY - startingClimbPositionY);

                    if (result > 0)
                    {
                        playerPosition.X += 1;
                        playerPosition.Y += result;
                    }

                    return result;
                }

                startingClimbPositionY++;
            }

            return 0;
        }

        public int TryToMovePlayerLeftStepUp()
        {
            int maximumStepHeight = 10;

            int targetPositionLeftBorderX = playerPosition.X - MovementStrategy.UNITS_TO_PLAYER_LEFT_BORDER - 1;
            int startingClimbPositionY = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER + 1;
            int endingClimbPositionY = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER + maximumStepHeight;

            int playerPositionOneLeftX = playerPosition.X - 1;

            while (startingClimbPositionY <= endingClimbPositionY)
            {
                int currentPlayerPositionY = startingClimbPositionY + MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER;

                if (TopBorderCollides(playerPositionOneLeftX, currentPlayerPositionY))
                {
                    return 0;
                }

                if (!LeftBorderCollides(playerPositionOneLeftX, currentPlayerPositionY))
                {
                    int result = maximumStepHeight - (endingClimbPositionY - startingClimbPositionY);

                    if (result > 0)
                    {
                        playerPosition.X -= 1;
                        playerPosition.Y += result;
                    }

                    return result;
                }

                startingClimbPositionY++;
            }

            return 0;            
        }

        private bool RightBorderCollides(int playerPositionX, int playerPositionY)
        {
            int rightBorderX = playerPositionX + MovementStrategy.UNITS_TO_PLAYER_RIGHT_BORDER;
            int yStart = playerPositionY - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER;           
            int yEnd = playerPositionY + MovementStrategy.UNITS_TO_PLAYER_TOP_BORDER;  

            while (yStart <= yEnd)
            {
                if (TileAtIsCollision(rightBorderX, yStart))
                {
                    return true;
                }

                yStart++;
            } 

            return false;
        }

        private bool LeftBorderCollides(int playerPositionX, int playerPositionY)
        {
            int leftBorderX = playerPositionX - MovementStrategy.UNITS_TO_PLAYER_LEFT_BORDER;
            int yStart = playerPositionY - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER;           
            int yEnd = playerPositionY + MovementStrategy.UNITS_TO_PLAYER_TOP_BORDER;  

            while (yStart <= yEnd)
            {
                if (TileAtIsCollision(leftBorderX, yStart))
                {
                    return true;
                }

                yStart++;
            } 

            return false;
        }        

        private bool TopBorderCollides(int playerPositionX, int playerPositionY)
        {
            int topBorderY = playerPositionY + MovementStrategy.UNITS_TO_PLAYER_TOP_BORDER;
            int xStart = playerPositionX - MovementStrategy.UNITS_TO_PLAYER_LEFT_BORDER;           
            int xEnd = playerPositionX + MovementStrategy.UNITS_TO_PLAYER_RIGHT_BORDER;  

            while (xStart <= xEnd)
            {
                if (TileAtIsCollision(xStart, topBorderY))
                {
                    return true;
                }

                xStart++;
            } 

            return false;
        }        

        public class Builder
        {
            private bool[,] isCollisionTile;

            public Builder SetWidthAndHeight(int width, int height)
            {
                isCollisionTile = new bool[width, height];
                return this;
            }

            public Builder SetIsColliding(int x, int y)
            {
                isCollisionTile[x, y] = true;
                return this;
            }
                     
            public Area Build()
            {
                Area result = new Area(isCollisionTile);
                return result;
            }            
        }
    }
}