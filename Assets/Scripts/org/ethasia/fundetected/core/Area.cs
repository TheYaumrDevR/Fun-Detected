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

        private Dictionary<HitboxTilePosition, List<Enemy>> enemyHitTiles;

        private EnemySpawner enemySpawner;

        private Position playerPosition;

        public PlayerCharacter Player
        {
            get;
            private set;
        }

        public List<Enemy> Enemies
        {
            get;
            private set;
        }

        public int LowestScreenX
        { 
            get
            {
                return areaDimensions.LowestScreenX;
            }
        }

        public int LowestScreenY
        { 
            get
            {
                return areaDimensions.LowestScreenY;
            }
        }        

        public int GetPlayerPositionX()
        {
            return playerPosition.X;
        }

        public int GetPlayerPositionY()
        {
            return playerPosition.Y;
        }

        private Area(bool[,] isCollisionTile, AreaDimensions areaDimensions)
        {
            this.areaDimensions = areaDimensions;

            Enemies = new List<Enemy>();
            this.isCollisionTile = isCollisionTile; 
            playerPosition = new Position(0, 0);
            enemyHitTiles = new Dictionary<HitboxTilePosition, List<Enemy>>();
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
            Enemies.Add(enemy);
            SetEnemyHitBox(enemy);
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

        public HashSet<Enemy> GetEnemiesHit(List<HitboxTilePosition> hitArc, Position positionOffsetRightSwingToPlayerCharacterCenter)
        {
            HashSet<Enemy> result = new HashSet<Enemy>();

            int reflectionFactor = Player.FacingDirection == FacingDirection.LEFT ? -1 : 1;

            int hitArcCenterOffsetX = playerPosition.X + positionOffsetRightSwingToPlayerCharacterCenter.X * reflectionFactor;
            int hitArcCenterOffsetY = playerPosition.Y + positionOffsetRightSwingToPlayerCharacterCenter.Y;

            foreach (HitboxTilePosition hitArcTile in hitArc)
            {
                HitboxTilePosition offSetHitArcTile = new HitboxTilePosition(hitArcTile.X * reflectionFactor + hitArcCenterOffsetX, hitArcTile.Y + hitArcCenterOffsetY);

                IHitboxPresenter hitboxPresenter = IoAdaptersFactoryForCore.GetInstance().GetHitboxPresenterInstance();
                hitboxPresenter.PresentHitbox(offSetHitArcTile.X + LowestScreenX, offSetHitArcTile.Y + LowestScreenY);

                if (enemyHitTiles.ContainsKey(offSetHitArcTile))
                {
                    result.UnionWith(enemyHitTiles[offSetHitArcTile]);
                }
            }

            foreach (Enemy enemy in result)
            {
                IHitboxPresenter hitboxPresenter = IoAdaptersFactoryForCore.GetInstance().GetHitboxPresenterInstance();
                hitboxPresenter.PresentStrikeRangeHitbox(enemy.Position.X + LowestScreenX, enemy.Position.Y + LowestScreenY, enemy.UnarmedStrikeRange);
            }
            
            return result;
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

        private void SetEnemyHitBox(Enemy enemy)
        {
            BoundingBox enemyBoundingBox = enemy.BoundingBox;
            Position enemyPosition = enemy.Position;

            int topLeftPosX = enemyPosition.X - enemyBoundingBox.DistanceToLeftEdge;
            int topLeftPosY = enemyPosition.Y + enemyBoundingBox.DistanceToTopEdge;

            int bottomRightPosX = enemyPosition.X + enemyBoundingBox.DistanceToRightEdge;
            int bottomRightPosY = enemyPosition.Y - enemyBoundingBox.DistanceToBottomEdge;

            for (int i = topLeftPosX; i <= bottomRightPosX; i++)
            {
                for (int j = bottomRightPosY; j <= topLeftPosY; j++)
                {
                    HitboxTilePosition hitboxTilePosition = new HitboxTilePosition(i, j);

                    if (enemyHitTiles.ContainsKey(hitboxTilePosition))
                    {
                        enemyHitTiles[hitboxTilePosition].Add(enemy);
                    } 
                    else 
                    {
                        List<Enemy> enemies = new List<Enemy>();
                        enemies.Add(enemy);
                        enemyHitTiles.Add(hitboxTilePosition, enemies);
                    }
                }
            }
        }           

        public class Builder
        {
            private int width;
            private int height;
            private int lowestScreenX;
            private int lowestScreenY;
            private bool[,] isCollisionTile;
            private EnemySpawner enemySpawner;

            public Builder SetWidthAndHeight(int width, int height)
            {
                isCollisionTile = new bool[width, height];
                this.width = width;
                this.height = height;
                return this;
            }

            public Builder SetLowestScreenX(int value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(int value)
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