using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class AreaSwitchingInteractor
    {
        private IEnemyMasterDataProvider enemyMasterDataProvider;
        private IMapPropertiesGateway mapPropertiesGateway;
        private IEnemyPresenter enemyPresenter;

        public AreaSwitchingInteractor()
        {
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapPropertiesGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapPropertiesGatewayInstance();
            enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
        }        

        public void SwitchActiveMap(string mapId, PlayerCharacter playerCharacter)
        {
            MapProperties mapProperties = mapPropertiesGateway.LoadMapProperties(mapId);

            Area map = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);
            map.AddPlayerAt(playerCharacter, 144, 46);

            List<EnemySpawnLocation> spawnedEnemies = map.SpawnEnemies();
            PopulateEnemiesFromSpawners(spawnedEnemies, map);

            Area.ActiveArea = map;

            ShowEnemies(map);
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
            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToRightEdge(enemyMasterData.DistanceToRightEdge)
                .SetDistanceToLeftEdge(enemyMasterData.DistanceToLeftEdge)
                .SetDistanceToBottomEdge(enemyMasterData.DistanceToBottomEdge)
                .SetDistanceToTopEdge(enemyMasterData.DistanceToTopEdge)
                .Build();

            return new Enemy.Builder()
                .SetId(enemyMasterData.Id)
                .SetName(enemyMasterData.Name)
                .SetLife(enemyMasterData.MaxLife)
                .SetArmor(enemyMasterData.Armor)
                .SetEvasionRating(enemyMasterData.EvasionRating)
                .SetBoundingBox(enemyBoundingBox)
                .SetPosition(spawnLocationData.MapLocation)
                .Build();
        }      

        private void ShowEnemies(Area map)
        {
            List<EnemyRenderData> enemiesToShow = new List<EnemyRenderData>();

            foreach (Enemy spawnedEnemy in map.Enemies)
            {
                EnemyMasterDataForRendering renderingMasterData = enemyMasterDataProvider.CreateEnemyMasterDataForRenderingById(spawnedEnemy.Id);

                EnemyRenderData enemyRenderData = new EnemyRenderData();
                enemyRenderData.EnemyId = spawnedEnemy.Id;

                enemyRenderData.PositionX = spawnedEnemy.Position.X + map.LowestScreenX;
                enemyRenderData.PositionY = spawnedEnemy.Position.Y + map.LowestScreenY;

                enemyRenderData.WidthX = renderingMasterData.DistanceToLeftRenderEdge + renderingMasterData.DistanceToRightRenderEdge + 1;
                enemyRenderData.WidthY = renderingMasterData.DistanceToBottomRenderEdge + renderingMasterData.DistanceToTopRenderEdge + 1;

                enemiesToShow.Add(enemyRenderData);
            }

            enemyPresenter.PresentEnemies(enemiesToShow);
        }  
    }
}