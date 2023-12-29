using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class EnemySpawner
    {
        private int maximumMonsterAmount;
        private List<EnemySpawnLocation> enemySpawnLocations;
        private List<EnemySpawnChance> enemySpawnChances;

        public void SpawnEnemies()
        {
            int amountOfEnemiesSpawned = 0;
            SpawnEnemiesFromUnspawnedSpawners(amountOfEnemiesSpawned);
        }

        private void SpawnEnemiesFromUnspawnedSpawners(int amountOfEnemiesSpawned)
        {
            foreach (EnemySpawnLocation enemySpawnLocation in enemySpawnLocations)
            {
                if (amountOfEnemiesSpawned == maximumMonsterAmount || amountOfEnemiesSpawned == enemySpawnLocations.Count)
                {
                    return;
                }

                if (!enemySpawnLocation.HasSpawned)
                {
                    enemySpawnLocation.TrySpawnEnemy(enemySpawnChances);

                    if (enemySpawnLocation.HasSpawned)
                    {
                        amountOfEnemiesSpawned++;
                    }
                }
            }

            SpawnEnemiesFromUnspawnedSpawners(amountOfEnemiesSpawned);
        }
    }
}