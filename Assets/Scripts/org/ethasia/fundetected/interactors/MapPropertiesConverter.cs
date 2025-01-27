using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class MapPropertiesConverter
    {
        public static Area ConvertMapPropertiesToArea(MapProperties mapProperties)
        {
            Area.Builder areaBuilder = new Area.Builder()
                .SetWidthAndHeight(mapProperties.Width, mapProperties.Height)
                .SetLowestScreenX(mapProperties.LowestScreenX)
                .SetLowestScreenY(mapProperties.LowestScreenY)
                .SetPlayerSpawnPosition(mapProperties.PlayerSpawnPosition);

            ConvertCollisions(mapProperties, areaBuilder);
            ConvertAndSetEnemySpawner(mapProperties, areaBuilder);

            Area result = areaBuilder.Build();

            ConvertAllMapPortalPropertiesToMapPortals(result, mapProperties);

            return result;
        } 

        private static void ConvertCollisions(MapProperties mapProperties, Area.Builder areaBuilder)
        {
            foreach (Collision collision in mapProperties.Collisions)
            {
                for (int i = 0; i < collision.Width; i++)
                {
                    for (int j = 0; j < collision.Height; j++)
                    {
                        int x = collision.StartX + i;
                        int y = collision.StartY + j;
                        areaBuilder.SetIsColliding(x, y);
                    }
                }
            }
        }

        private static void ConvertAndSetEnemySpawner(MapProperties mapProperties, Area.Builder areaBuilder)
        {
            EnemySpawner spawner = ConvertMapPropertiesToEnemySpawner(mapProperties);
            areaBuilder.SetEnemySpawner(spawner);
        }

        private static EnemySpawner ConvertMapPropertiesToEnemySpawner(MapProperties mapProperties)
        {
            List<EnemySpawnLocation> enemySpawnLocations = ConvertEnemySpawnLocations(mapProperties);
            List<EnemySpawnChance> enemySpawnChances = ConvertEnemySpawnChances(mapProperties);

            return new EnemySpawner.Builder()
                .SetMaximumMonsterAmount(mapProperties.MaximumMonsters)
                .SetEnemySpawnLocations(enemySpawnLocations)
                .SetEnemySpawnChances(enemySpawnChances)
                .Build();
        } 

        private static List<EnemySpawnLocation> ConvertEnemySpawnLocations(MapProperties mapProperties)
        {
            List<EnemySpawnLocation> result = new List<EnemySpawnLocation>();
            float spawnerActivationChance = 1 / (float) mapProperties.Spawners.Count;

            foreach (Spawner spawner in mapProperties.Spawners)
            {
                Position spawnerPosition = new Position(spawner.X, spawner.Y);
                EnemySpawnLocation enemySpawnLocation = new EnemySpawnLocation(spawnerPosition, spawnerActivationChance);
                result.Add(enemySpawnLocation);
            }

            return result;
        }      

        private static List<EnemySpawnChance> ConvertEnemySpawnChances(MapProperties mapProperties)
        {
            List<EnemySpawnChance> result = new List<EnemySpawnChance>();

            foreach (SpawnableMonster spawnableMonster in mapProperties.SpawnableMonsters)
            {
                EnemySpawnChance enemySpawnChance = new EnemySpawnChance(spawnableMonster.Name, spawnableMonster.SpawnChanceMillis);
                result.Add(enemySpawnChance);
            }

            return result;
        } 
    
        private static void ConvertAllMapPortalPropertiesToMapPortals(Area resultArea, MapProperties mapProperties)
        {
            foreach (MapPortalProperties portalProperties in mapProperties.Portals)
            {
                resultArea.AddPortal(ConvertMapPortalPropertiesToMapPortal(portalProperties));
            }
        }

        private static MapPortal ConvertMapPortalPropertiesToMapPortal(MapPortalProperties toConvert)
        {
            return new MapPortal.Builder().SetPosition(toConvert.Position)
                .SetWidth(toConvert.Width)
                .SetHeight(toConvert.Height)
                .SetDestinationMapId(toConvert.DestinationMapId)
                .SetDestinationPortalId(toConvert.DestinationPortalId)
                .Build();
        }       
    }
}