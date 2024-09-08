namespace Org.Ethasia.Fundetected.Core
{
    public class EnemySpawnChance
    {
        public string EnemySpawnId
        {
            get;
        }

        public int EnemySpawnChanceMillis
        {
            get;
        }

        public EnemySpawnChance(string enemySpawnId, int spawnChanceMillis)
        {
            EnemySpawnId = enemySpawnId;
            EnemySpawnChanceMillis = spawnChanceMillis;
        }
    }
}