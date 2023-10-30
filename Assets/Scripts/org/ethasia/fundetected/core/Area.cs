using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class Area
    {
        public static Area ActiveArea;

        private bool[,] isCollisionTile;

        public PlayerCharacter Player
        {
            get;
            private set;
        }

        private List<Enemy> enemies;

        private Area(bool[,] isCollisionTile)
        {
            enemies = new List<Enemy>();
            this.isCollisionTile = isCollisionTile; 
        }

        public bool TileAtIsCollision(int x, int y)
        {
            return isCollisionTile[x, y];
        }

        public List<Enemy> GetEnemies()
        {
            return enemies;
        }        

        public void AddPlayer(PlayerCharacter value)
        {
            if (null != value && Player == null)
            {
                Player = value;
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