using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class NewAreaSwitchInteractor
    {
        private IEnemyMasterDataProvider enemyMasterDataProvider;
        private IMapDefinitionGateway mapDefinitionGateway;
        private IRandomNumberGenerator randomNumberGenerator;
        private IEnemyPresenter enemyPresenter;
        private IMapPresenter mapPresenter;

        public NewAreaSwitchInteractor()
        {
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapDefinitionGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapDefinitionGatewayInstance();
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            enemyPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyPresenterInstance();
            mapPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetMapPresenterInstance();
        }   

        public void SwitchActiveMap(string mapId, PlayerCharacter playerCharacter)
        {
            MapDefinition mapDefinition = mapDefinitionGateway.LoadMapDefinition(mapId);
            RandomizeMap(mapDefinition);
            PresentTiles(mapDefinition);
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
            List<Tile> terrainTiles = new List<Tile>();
            List<Tile> groundTiles = new List<Tile>();

            foreach (Chunk chunk in mapDefinition.Chunks)
            {
                if (chunk.PropertiesOfPossibleChunks.Count > 0)
                {
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(terrainTiles, chunk.PropertiesOfPossibleChunks[0].TerrainTiles, chunk);
                    CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(groundTiles, chunk.PropertiesOfPossibleChunks[0].GroundTiles, chunk); 
                }
            }

            mapPresenter.PresentTiles(terrainTiles, "terrain");
            mapPresenter.PresentTiles(groundTiles, "ground");
        }

        private void CreateTilesWithAbsolutePositionFromTilesWithChunkPositions(List<Tile> resultTiles, List<Tile> sourceTiles, Chunk chunk)
        {
            foreach (Tile sourceTile in sourceTiles)
            {
                Tile tileWithAbsolutePosition = new Tile.Builder()
                    .SetId(sourceTile.Id)
                    .SetStartX(sourceTile.StartX + (chunk.X * 8))
                    .SetStartY(sourceTile.StartY + (chunk.Y * 8))
                    .SetWidth(sourceTile.Width)
                    .SetHeight(sourceTile.Height)
                    .Build();
                        
                resultTiles.Add(tileWithAbsolutePosition);
            }
        }
    }
}