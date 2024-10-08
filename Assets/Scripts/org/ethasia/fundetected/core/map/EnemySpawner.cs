using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
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

        public List<EnemySpawnLocation> GetSpawnedEnemies()
        {
            List<EnemySpawnLocation> result = new List<EnemySpawnLocation>();

            foreach (EnemySpawnLocation enemySpawnLocation in enemySpawnLocations)
            {
                if (enemySpawnLocation.HasSpawned)
                {
                    result.Add(enemySpawnLocation);
                }
            }

            return result;
        }

        private void SpawnEnemiesFromUnspawnedSpawners(int amountOfEnemiesSpawned)
        {
            if (0 == enemySpawnLocations.Count)
            {
                return;
            }

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

        public class Builder
        {
            private int maximumMonsterAmount;
            private List<EnemySpawnLocation> enemySpawnLocations;
            private List<EnemySpawnChance> enemySpawnChances;   

            public Builder()
            {
                enemySpawnLocations = new List<EnemySpawnLocation>();
                enemySpawnChances = new List<EnemySpawnChance>();
            }         

            public Builder SetMaximumMonsterAmount(int value)
            {
                maximumMonsterAmount = value;
                return this;
            }

            public Builder SetEnemySpawnLocations(List<EnemySpawnLocation> value)
            {
                enemySpawnLocations = value;
                return this;
            }    

            public Builder SetEnemySpawnChances(List<EnemySpawnChance> value)
            {
                enemySpawnChances = value;
                return this;
            }   

            public EnemySpawner Build()
            {
                EnemySpawner result = new EnemySpawner();
                
                result.maximumMonsterAmount = maximumMonsterAmount;
                result.enemySpawnChances = enemySpawnChances;
                result.enemySpawnLocations = enemySpawnLocations;

                return result;
            }                 
        }
    }
}