using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class Area
    {
        public static Area ActiveArea;

        public PlayerCharacter Player
        {
            get;
            private set;
        }

        private List<Enemy> enemies;

        public Area()
        {
            enemies = new List<Enemy>();
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
    }
}