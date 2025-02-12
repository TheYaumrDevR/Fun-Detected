using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
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

        public AreaSwitchingInteractor()
        {
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapDefinitionGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapDefinitionGatewayInstance();
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
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
            ShowEnemies(existingMap);   

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
            ShowEnemies(map);
        }

        private void PopulateEnemiesFromSpawners(List<EnemySpawnLocation> spawnedEnemies, Area map)
        {
            int spawnId = 0;

            foreach (EnemySpawnLocation spawnedEnemy in spawnedEnemies)
            {
                map.AddEnemy(CreateEnemyFromMasterData(enemyMasterDataProvider.CreateEnemyMasterDataById(spawnedEnemy.SpawnedEnemyId), spawnedEnemy, spawnId));
                spawnId++;
            }
        }

        private Enemy CreateEnemyFromMasterData(EnemyMasterData enemyMasterData, EnemySpawnLocation spawnLocationData, int spawnId)
        {
            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToRightEdge(enemyMasterData.DistanceToRightEdge)
                .SetDistanceToLeftEdge(enemyMasterData.DistanceToLeftEdge)
                .SetDistanceToBottomEdge(enemyMasterData.DistanceToBottomEdge)
                .SetDistanceToTopEdge(enemyMasterData.DistanceToTopEdge)
                .Build();

            Enemy result = new Enemy.Builder()
                .SetIndividualId(enemyMasterData.Id + spawnId)
                .SetTypeId(enemyMasterData.Id)
                .SetName(enemyMasterData.Name)
                .SetIsAggressiveOnSight(enemyMasterData.IsAggressiveOnSight)
                .SetAttacksPerSecond(enemyMasterData.AttacksPerSecond)
                .SetUnarmedStrikeRange(enemyMasterData.UnarmedStrikeRange)
                .SetCorpseMass(enemyMasterData.CorpseMass)
                .SetMinToMaxPhysicalDamage(new DamageRange(enemyMasterData.MinPhysicalDamage, enemyMasterData.MaxPhysicalDamage))
                .SetLife(enemyMasterData.MaxLife)
                .SetArmor(enemyMasterData.Armor)
                .SetAccuracyRating(enemyMasterData.AccuracyRating)
                .SetEvasionRating(enemyMasterData.EvasionRating)
                .SetBoundingBox(enemyBoundingBox)
                .SetPosition(spawnLocationData.MapLocation)
                .Build();

            EnemyAbility enemyAbility = enemyMasterData.AbilityMasterData.CreateAbilityForEnemy(result);
            string abilityName = enemyMasterData.AbilityMasterData.GetAbilityName();

            result.AddAbilityByName(abilityName, enemyAbility);

            return result;
        }   

        private void ShowPortals(Area map)
        {
            foreach (MapPortal portal in map.Portals)
            {
                mapPresenter.PresentPortal(portal);
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
    }
}