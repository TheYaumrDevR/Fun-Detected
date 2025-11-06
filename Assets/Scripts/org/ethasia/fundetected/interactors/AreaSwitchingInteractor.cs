using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class AreaSwitchingInteractor
    {
        private IEnemyMasterDataProvider enemyMasterDataProvider;
        private IMapDefinitionGateway mapDefinitionGateway;
        private IRandomNumberGenerator randomNumberGenerator;
        private IEnemyPresenter enemyPresenter;
        private IMapPresenter mapPresenter;
        private IDroppedItemPresenter droppedItemPresenter;

        public AreaSwitchingInteractor()
        {
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapDefinitionGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapDefinitionGatewayInstance();
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
            droppedItemPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetDroppedItemPresenterInstance();
        }   

        public void SpawnPlayerIntoNewMap(string mapId, PlayerCharacter playerCharacter)
        {
            LoadAndSetupMap(mapId, playerCharacter);

            Area map = Area.ActiveArea;
            map.SpawnPlayer(playerCharacter);
        }           

        public void PortalPlayerIntoNewMap(string mapId, string spawnDestinationId, PlayerCharacter playerCharacter)
        {
            LoadAndSetupMap(mapId, playerCharacter);

            Area map = Area.ActiveArea;
            map.PortPlayerTo(playerCharacter, spawnDestinationId);
        }

        public void PortalPlayerIntoExistingMap(Area existingMap, string spawnDestinationId, PlayerCharacter playerCharacter)
        {
            Area.ActiveArea = existingMap;

            PresentTiles(existingMap.ReloadableTileMap);
            ShowPortals(existingMap);
            ShowHealingWells(existingMap);
            ShowEnemies(existingMap);   
            ShowDroppedItems(existingMap);

            existingMap.PortPlayerTo(playerCharacter, spawnDestinationId);         
        }

        public void LoadPlayerIntoNewMap(string mapId, Position loadPosition, PlayerCharacter playerCharacter)
        {
            
        }

        private void LoadAndSetupMap(string mapId, PlayerCharacter playerCharacter)
        {
            MapDefinition mapDefinition = LoadMapDefinitionAndPresentTiles(mapId);
            ConvertAndSetupMap(mapDefinition, playerCharacter);
        }

        private MapDefinition LoadMapDefinitionAndPresentTiles(string mapId)
        {
            MapDefinition mapDefinition = mapDefinitionGateway.LoadMapDefinition(mapId);

            RandomizeMap(mapDefinition);
            PresentTiles(mapDefinition);

            return mapDefinition;
        }

        private void ConvertAndSetupMap(MapDefinition mapDefinition, PlayerCharacter playerCharacter)
        {
            MapProperties mapProperties = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition); 
            SetUpAreaAndEnemies(mapProperties, playerCharacter);            
        }

        private void RandomizeMap(MapDefinition mapDefinition)
        {
            foreach (Chunk chunk in mapDefinition.Chunks)
            {
                if (chunk.PropertiesOfPossibleChunks.Count > 1)
                {
                    int randomIndex = randomNumberGenerator.GenerateIntegerBetweenAnd(0, chunk.PropertiesOfPossibleChunks.Count - 1);
                    MapChunkProperties selectedChunkProperties = chunk.PropertiesOfPossibleChunks[randomIndex];
                    
                    chunk.PropertiesOfPossibleChunks.Clear();
                    chunk.PropertiesOfPossibleChunks.Add(selectedChunkProperties);
                }
            }
        }

        private void PresentTiles(MapDefinition mapDefinition)
        {
            List<ITile> terrainTiles = new List<ITile>();
            List<ITile> foliageBackTiles = new List<ITile>();
            List<ITile> foliageFrontTiles = new List<ITile>();
            List<ITile> groundTiles = new List<ITile>();

            foreach (Chunk chunk in mapDefinition.Chunks)
            {
                if (chunk.PropertiesOfPossibleChunks.Count > 0)
                {
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(terrainTiles, chunk.PropertiesOfPossibleChunks[0].TerrainTiles, chunk);
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(foliageBackTiles, chunk.PropertiesOfPossibleChunks[0].FoliageBackTiles, chunk);
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(foliageFrontTiles, chunk.PropertiesOfPossibleChunks[0].FoliageFrontTiles, chunk);
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(groundTiles, chunk.PropertiesOfPossibleChunks[0].GroundTiles, chunk); 
                }
            }

            mapPresenter.PresentTiles(terrainTiles, "terrain");
            mapPresenter.PresentTiles(foliageBackTiles, "foliageBack");
            mapPresenter.PresentTiles(foliageFrontTiles, "foliageFront");
            mapPresenter.PresentTiles(groundTiles, "ground");
        }

        private void PresentTiles(ReloadableTileMap tileMap)
        {
            mapPresenter.PresentTiles(tileMap.TerrainTiles, "terrain");
            mapPresenter.PresentTiles(tileMap.FoliageBackTiles, "foliageBack");
            mapPresenter.PresentTiles(tileMap.FoliageFrontTiles, "foliageFront");
            mapPresenter.PresentTiles(tileMap.GroundTiles, "ground");
        }

        private void CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(List<ITile> resultTiles, List<ITile> sourceTiles, Chunk chunk)
        {
            foreach (ITile sourceTile in sourceTiles)
            {
                Tile tileWithAbsolutePosition = new Tile.Builder()
                    .SetId(sourceTile.Id)
                    .SetStartX(sourceTile.StartX + (chunk.X * Area.VISUAL_TILES_PER_CHUNK_EDGE))
                    .SetStartY(sourceTile.StartY + (chunk.Y * Area.VISUAL_TILES_PER_CHUNK_EDGE))
                    .SetWidth(sourceTile.Width)
                    .SetHeight(sourceTile.Height)
                    .Build();
                        
                resultTiles.Add(tileWithAbsolutePosition);
            }
        }

        private void SetUpAreaAndEnemies(MapProperties mapProperties, PlayerCharacter playerCharacter)
        {
            Area map = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);

            List<EnemySpawnLocation> spawnedEnemies = map.SpawnEnemies();
            PopulateEnemiesFromSpawners(spawnedEnemies, map);

            Area.ActiveArea = map;

            ShowPortals(map);
            ShowHealingWells(map);
            ShowEnemies(map);
        }

        private void PopulateEnemiesFromSpawners(List<EnemySpawnLocation> spawnedEnemies, Area map)
        {
            int spawnId = 0;

            foreach (EnemySpawnLocation spawnedEnemy in spawnedEnemies)
            {
                EnemyMasterData enemyMasterData = enemyMasterDataProvider.CreateEnemyMasterDataById(spawnedEnemy.SpawnedEnemyId);

                if (spawnedEnemy.SpawnedEnemyLevel >= enemyMasterData.MinimumSpawnLevel)
                {
                    enemyMasterData = enemyMasterData.ScalingStrategy.ScaleMasterData(enemyMasterData, spawnedEnemy.SpawnedEnemyLevel);

                    EnemyMasterDataToEnemyConverter.EnemyCreationContext enemyCreationContext = new EnemyMasterDataToEnemyConverter.EnemyCreationContext
                    {
                        EnemyMasterData = enemyMasterData,
                        SpawnLocation = spawnedEnemy,
                        SpawnId = spawnId,
                        EnemyLevel = spawnedEnemy.SpawnedEnemyLevel
                    };

                    map.AddEnemy(CreateEnemyFromMasterData(enemyCreationContext));
                    spawnId++;
                }
            }
        }

        private Enemy CreateEnemyFromMasterData(EnemyMasterDataToEnemyConverter.EnemyCreationContext enemyCreationContext)
        {
            return EnemyMasterDataToEnemyConverter.CreateEnemyFromMasterData(enemyCreationContext);
        }   

        private void ShowPortals(Area map)
        {
            foreach (MapPortal portal in map.Portals)
            {
                mapPresenter.PresentPortal(portal);
            }
        }   

        private void ShowHealingWells(Area map)
        {
            foreach (HealingWell healingWell in map.HealingWells)
            {
                mapPresenter.PresentHealingWell(healingWell);
            }
        }

        private void ShowEnemies(Area map)
        {
            List<EnemyRenderData> enemiesToShow = new List<EnemyRenderData>();

            foreach (Enemy spawnedEnemy in map.Enemies)
            {
                EnemyMasterDataForRendering renderingMasterData = enemyMasterDataProvider.CreateEnemyMasterDataForRenderingById(spawnedEnemy.TypeId);

                AnimationStateMachineAssignmentFunction animationStateMachineAssignmentFunction = new AnimationStateMachineAssignmentFunction();
                animationStateMachineAssignmentFunction.Enemy = spawnedEnemy;

                EnemyRenderData enemyRenderData = new EnemyRenderData();
                enemyRenderData.TypeId = spawnedEnemy.TypeId;
                enemyRenderData.IndividualId = spawnedEnemy.IndividualId;

                enemyRenderData.PositionX = spawnedEnemy.Position.X;
                enemyRenderData.PositionY = spawnedEnemy.Position.Y;

                enemyRenderData.WidthX = renderingMasterData.DistanceToLeftRenderEdge + renderingMasterData.DistanceToRightRenderEdge + 1;
                enemyRenderData.WidthY = renderingMasterData.DistanceToBottomRenderEdge + renderingMasterData.DistanceToTopRenderEdge + 1;

                enemyRenderData.AnimationStateMachineAssignmentFunction = animationStateMachineAssignmentFunction;

                enemiesToShow.Add(enemyRenderData);
            }

            enemyPresenter.PresentEnemies(enemiesToShow);
        } 

        private void ShowDroppedItems(Area map)
        {
            foreach (Item droppedItem in map.DroppedItems)
            {
                ItemDropPresentationInformation itemDropInfo = new ItemDropPresentationInformation();
                itemDropInfo.UniqueId = droppedItem.UniqueId;
                itemDropInfo.BaseTypeOrUniqueName = droppedItem.Name;
                itemDropInfo.PositionX = droppedItem.CollisionShape.Position.X;
                itemDropInfo.PositionY = droppedItem.CollisionShape.Position.Y;

                droppedItemPresenter.PresentItemDrop(itemDropInfo);
            }
        }      
    }
}