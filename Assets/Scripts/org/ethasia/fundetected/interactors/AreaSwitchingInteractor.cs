using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class AreaSwitchingInteractor
    {
        private IEnemyMasterDataProvider enemyMasterDataProvider;
        private IMapPropertiesGateway mapPropertiesGateway;

        public AreaSwitchingInteractor()
        {
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapPropertiesGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapPropertiesGatewayInstance();
        }        

        public void SwitchActiveMap(string mapId, PlayerCharacter playerCharacter)
        {
            MapProperties mapProperties = mapPropertiesGateway.LoadMapProperties(mapId);

            Area map = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);
            map.AddPlayerAt(playerCharacter, 144, 46);

            List<EnemySpawnLocation> spawnedEnemies = map.SpawnEnemies();
            PopulateEnemiesFromSpawners(spawnedEnemies, map);

            Area.ActiveArea = map;

            // TODO: Add width and height to enemy master data
            // Add enemy ID to Enemy
            // Transform enemy master data width and height to Enemy width and height
            // Load animation graph for each enemy using their ID
            // Create EnemyPresenterData with x, y, scaleX, scaleY, enemyName, animationGraph
        }

        private void PopulateEnemiesFromSpawners(List<EnemySpawnLocation> spawnedEnemies, Area map)
        {
            foreach (EnemySpawnLocation spawnedEnemy in spawnedEnemies)
            {
                map.AddEnemy(CreateEnemyFromMasterData(enemyMasterDataProvider.CreateEnemyMasterDataById(spawnedEnemy.SpawnedEnemyId), spawnedEnemy));
            }
        }

        private Enemy CreateEnemyFromMasterData(EnemyMasterData enemyMasterData, EnemySpawnLocation spawnLocationData)
        {
            return new Enemy.Builder()
                .SetName(enemyMasterData.Name)
                .SetLife(enemyMasterData.MaxLife)
                .SetArmor(enemyMasterData.Armor)
                .SetEvasionRating(enemyMasterData.EvasionRating)
                .SetPosition(spawnLocationData.MapLocation)
                .Build();
        }        
    }
}