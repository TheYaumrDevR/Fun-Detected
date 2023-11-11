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
            return MOVE_RIGHT_STRATEGY.TryToMovePlayerStepUp(playerPosition);
        }

        public int TryToMovePlayerLeftStepUp()
        {
            return MOVE_LEFT_STRATEGY.TryToMovePlayerStepUp(playerPosition);
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