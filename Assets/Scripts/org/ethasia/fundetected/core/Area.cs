using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class Area
    {
        public static Area ActiveArea;

        private static int PLAYER_CHAR_HEIGHT_HALF = 16;

        private static int PLAYER_CHAR_WIDTH_HALF = 5;

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
            if (0 == requestedMovementDistance)
            {
                return 0;
            }

            int tagetPositionX = playerPosition.X + PLAYER_CHAR_WIDTH_HALF + requestedMovementDistance;
            
            for (int i = playerPosition.Y - PLAYER_CHAR_HEIGHT_HALF + 1; i <= playerPosition.Y + PLAYER_CHAR_HEIGHT_HALF; i++)
            {
                if (TileAtIsCollision(tagetPositionX, i))
                {
                    return CalculateUnitsPlayerCanMoveRight(requestedMovementDistance - 1);
                }
            }

            playerPosition.X += requestedMovementDistance;
            return requestedMovementDistance; 
        }

        public int CalculateUnitsPlayerCanMoveLeft(int requestedMovementDistance)
        {
            if (0 == requestedMovementDistance)
            {
                return 0;
            }

            int tagetPositionX = playerPosition.X - PLAYER_CHAR_WIDTH_HALF - requestedMovementDistance;

            for (int i = playerPosition.Y - PLAYER_CHAR_HEIGHT_HALF + 1; i <= playerPosition.Y + PLAYER_CHAR_HEIGHT_HALF; i++)
            {
                if (TileAtIsCollision(tagetPositionX, i))
                {
                    return CalculateUnitsPlayerCanMoveLeft(requestedMovementDistance - 1);
                }
            }
            
            playerPosition.X -= requestedMovementDistance;
            return requestedMovementDistance;
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