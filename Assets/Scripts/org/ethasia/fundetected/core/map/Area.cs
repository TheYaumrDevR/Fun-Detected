using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class Area
    {
        public const int VISUAL_TILES_PER_CHUNK_EDGE = 8;
        public const int LOGICAL_TILES_PER_VISUAL_TILE_EDGE = 10;

        public static Area ActiveArea;

        private static MovementStrategy MOVE_LEFT_STRATEGY = new MoveLeftStrategy();

        private static MovementStrategy MOVE_RIGHT_STRATEGY = new MoveRightStrategy();

        private AreaDimensions areaDimensions;

        private Dictionary<PositionImmutable, bool> isCollisionTile;

        private Dictionary<HitboxTilePosition, List<Enemy>> enemyHitTiles;

        private Position playerSpawnPosition;

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

        public List<MapPortal> Portals
        {
            get;
            private set;
        }    

        public List<IInteractableEnvironmentObject> InteractableEnvironmentObjects
        {
            get;
            private set;
        }

        public int GetPlayerPositionX()
        {
            return playerPosition.X;
        }

        public int GetPlayerPositionY()
        {
            return playerPosition.Y;
        }

        private Area(Dictionary<PositionImmutable, bool> isCollisionTile, AreaDimensions areaDimensions)
        {
            this.areaDimensions = areaDimensions;

            Enemies = new List<Enemy>();
            Portals = new List<MapPortal>();
            InteractableEnvironmentObjects = new List<IInteractableEnvironmentObject>();
            this.isCollisionTile = isCollisionTile; 
            playerPosition = new Position(0, 0);
            enemyHitTiles = new Dictionary<HitboxTilePosition, List<Enemy>>();
        }

        public bool TileAtIsCollision(int x, int y)
        {   
            if (x < areaDimensions.LowestScreenX || y < areaDimensions.LowestScreenY)
            {
                return true;
            }

            if (x >= areaDimensions.Width + areaDimensions.LowestScreenX || y >= areaDimensions.Height + areaDimensions.LowestScreenY)
            {
                return true;
            }

            PositionImmutable position = new PositionImmutable(x, y);

            if (!isCollisionTile.ContainsKey(position))
            {
                return false;
            }

            return isCollisionTile[position];
        }     

        public void SpawnPlayer(PlayerCharacter playerCharacter)
        {
            if (null != playerSpawnPosition)
            {
                AddPlayerAt(playerCharacter, playerSpawnPosition.X, playerSpawnPosition.Y);
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
            SetEnemyHitBox(enemy);
        }    

        public void AddPortal(MapPortal portal)
        {
            Portals.Add(portal);
            InteractableEnvironmentObjects.Add(portal);
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

        public void RemoveEnemies()
        {
            Enemies.Clear();
            enemyHitTiles.Clear();
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
                hitboxPresenter.PresentHitbox(offSetHitArcTile.X, offSetHitArcTile.Y);

                if (enemyHitTiles.ContainsKey(offSetHitArcTile))
                {
                    result.UnionWith(enemyHitTiles[offSetHitArcTile]);
                }
            }

            foreach (Enemy enemy in result)
            {
                IHitboxPresenter hitboxPresenter = IoAdaptersFactoryForCore.GetInstance().GetHitboxPresenterInstance();
                hitboxPresenter.PresentStrikeRangeHitbox(enemy.Position.X, enemy.Position.Y, enemy.UnarmedStrikeRange);
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

            for (int i = playerPosition.Y - MovementStrategy.UNITS_TO_PLAYER_BOTTOM_BORDER - 1; i > areaDimensions.LowestScreenY; i--)
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

        private void AddPlayerAt(PlayerCharacter value, int x, int y)
        {
            if (null != value && Player == null)
            {
                Player = value;
                playerPosition.X = x;
                playerPosition.Y = y;             
            }
        }               

        public class Builder
        {
            private int width;
            private int height;
            private int lowestScreenX;
            private int lowestScreenY;
            private Dictionary<PositionImmutable, bool> isCollisionTile;
            private Position playerSpawnPosition;
            private EnemySpawner enemySpawner;

            public Builder SetWidthAndHeight(int width, int height)
            {
                isCollisionTile = new Dictionary<PositionImmutable, bool>();
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
                PositionImmutable position = new PositionImmutable(x, y);
                isCollisionTile.Add(position, true);

                return this;
            }

            public Builder SetPlayerSpawnPosition(Position value)
            {
                playerSpawnPosition = value;
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
                result.playerSpawnPosition = playerSpawnPosition;
                result.enemySpawner = enemySpawner;
                return result;
            }            
        }
    }
}