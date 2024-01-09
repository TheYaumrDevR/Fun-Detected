using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class Area
    {
        public static Area ActiveArea;

        private static MovementStrategy MOVE_LEFT_STRATEGY = new MoveLeftStrategy();

        private static MovementStrategy MOVE_RIGHT_STRATEGY = new MoveRightStrategy();

        private AreaDimensions areaDimensions;

        private bool[,] isCollisionTile;

        private EnemySpawner enemySpawner;

        private Position playerPosition;

        public PlayerCharacter Player
        {
            get;
            private set;
        }

        private List<Enemy> enemies;

        private Area(bool[,] isCollisionTile, AreaDimensions areaDimensions)
        {
            this.areaDimensions = areaDimensions;

            enemies = new List<Enemy>();
            this.isCollisionTile = isCollisionTile; 
            playerPosition = new Position(0, 0);
        }

        public bool TileAtIsCollision(int x, int y)
        {   
            if (x < 0 || y < 0)
            {
                return true;
            }

            if (x >= areaDimensions.Width || y >= areaDimensions.Height)
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

        public List<EnemySpawnLocation> SpawnEnemies()
        {
            if (null != enemySpawner)
            {
                enemySpawner.SpawnEnemies();
                return enemySpawner.GetSpawnedEnemies();
            }

            return new List<EnemySpawnLocation>();
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
            private int width;
            private int height;
            private float lowestScreenX;
            private float lowestScreenY;
            private bool[,] isCollisionTile;
            private EnemySpawner enemySpawner;

            public Builder SetWidthAndHeight(int width, int height)
            {
                isCollisionTile = new bool[width, height];
                this.width = width;
                this.height = height;
                return this;
            }

            public Builder SetLowestScreenX(float value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(float value)
            {
                lowestScreenY = value;
                return this;
            }            

            public Builder SetIsColliding(int x, int y)
            {
                isCollisionTile[x, y] = true;
                return this;
            }

            public Builder SetEnemySpawner(EnemySpawner value)
            {
                enemySpawner = value;
                return this;
            }
                     
            public Area Build()
            {
                AreaDimensions areaDimensions = new AreaDimensions.Builder()
                    .SetWidth(width)
                    .SetHeight(height)
                    .SetLowestScreenX(lowestScreenX)
                    .SetLowestScreenY(lowestScreenY)
                    .Build();

                Area result = new Area(isCollisionTile, areaDimensions);
                result.enemySpawner = enemySpawner;
                return result;
            }            
        }
    }
}