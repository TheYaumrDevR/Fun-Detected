using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core
{
    public class EnemySpawnLocation
    {
        private float spawnerActivationChance;

        public bool HasSpawned
        {
            get;
            private set;
        }

        public string SpawnedEnemyId
        {
            get;
            private set;
        }

        public Position MapLocation
        {
            get;
        }

        public EnemySpawnLocation(Position mapLocation, float spawnerActivationChance)
        {
            MapLocation = mapLocation;
            HasSpawned = false;
            SpawnedEnemyId = "";
            this.spawnerActivationChance = spawnerActivationChance;
        }

        public void TrySpawnEnemy(List<EnemySpawnChance> enemySpawnChances)
        {
            IRandomNumberGenerator randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();

            if (!HasSpawned)
            {
                if (randomNumberGenerator.CheckProbabilityIsHit(spawnerActivationChance))
                {
                    SpawnOneOfTheEnemies(enemySpawnChances);
                }
            }
        }

        private void SpawnOneOfTheEnemies(List<EnemySpawnChance> enemySpawnChances)
        {
            for (int i = 0; i < enemySpawnChances.Count; i++)
            {
                EnemySpawnChance enemySpawnChance = enemySpawnChances[i];

                if (i == enemySpawnChances.Count - 1)
                {
                    HasSpawned = true;
                    SpawnedEnemyId = enemySpawnChance.EnemySpawnId;
                }
                else
                {
                    IRandomNumberGenerator randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();

                    int spawnChanceMillis = enemySpawnChance.EnemySpawnChanceMillis;
                    int randomNumber = randomNumberGenerator.GenerateRandomPositiveInteger(1000);

                    if (randomNumber <= spawnChanceMillis)
                    {
                        HasSpawned = true;
                        SpawnedEnemyId = enemySpawnChance.EnemySpawnId;
                        return;
                    }                    
                }
            }
        }
    }
}