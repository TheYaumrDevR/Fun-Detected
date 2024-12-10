using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class MapDefinitionToMapPropertiesConverter
    {
        public static MapProperties ConvertMapDefinitionToMapProperties(MapDefinition mapDefinition)
        {
            ScreenDimensionProperties screenDimensionProperties = CalculateInitialScreenDimensionProperties(mapDefinition.Chunks);
            List<Collision> absolutePositionCollisions = new List<Collision>();
            List<Spawner> absolutePositionSpawners = new List<Spawner>();
            Position playerSpawnPosition = null;

            foreach (Chunk chunk in mapDefinition.Chunks)
            {
                screenDimensionProperties = CalculateNewLowestAndHighestScreenProperties(screenDimensionProperties, chunk);
                CalculateAbsolutePositionCollisionsAndSpawners(chunk, absolutePositionCollisions, absolutePositionSpawners);

                if (null == playerSpawnPosition)
                {
                    playerSpawnPosition = DeterminePlayerSpawnPosition(chunk);
                }
            }

            MapProperties result = new MapProperties.Builder()
                .SetMaximumMonsters(mapDefinition.MaximumMonsters)
                .SetLowestScreenX(screenDimensionProperties.LowestScreenX)
                .SetLowestScreenY(screenDimensionProperties.LowestScreenY)
                .SetWidth(screenDimensionProperties.HighestScreenX - screenDimensionProperties.LowestScreenX)
                .SetHeight(screenDimensionProperties.HighestScreenY - screenDimensionProperties.LowestScreenY)
                .SetPlayerSpawnPosition(playerSpawnPosition)
                .Build();    

            result.AddAllCollisions(absolutePositionCollisions);
            result.AddAllSpawners(absolutePositionSpawners);   
            result.SpawnableMonsters.AddRange(mapDefinition.SpawnableMonsters);     

            return result;
        }

        private static ScreenDimensionProperties CalculateInitialScreenDimensionProperties(List<Chunk> chunks)
        {
            ScreenDimensionProperties result = new ScreenDimensionProperties(0, 0, 0, 0);

            int amountOfLogicalTilesPerChunkEdge = Area.LOGICAL_TILES_PER_VISUAL_TILE_EDGE * Area.VISUAL_TILES_PER_CHUNK_EDGE;

            if (chunks.Count > 0)
            {
                int lowestScreenX = chunks[0].X * amountOfLogicalTilesPerChunkEdge;
                int lowestScreenY = chunks[0].Y * amountOfLogicalTilesPerChunkEdge;

                int highestScreenX = chunks[0].X * amountOfLogicalTilesPerChunkEdge + amountOfLogicalTilesPerChunkEdge;
                int highestScreenY = chunks[0].Y * amountOfLogicalTilesPerChunkEdge + amountOfLogicalTilesPerChunkEdge;

                result = new ScreenDimensionProperties(lowestScreenX, lowestScreenY, highestScreenX, highestScreenY);
            }

            return result;
        }

        private static ScreenDimensionProperties CalculateNewLowestAndHighestScreenProperties(ScreenDimensionProperties currentProperties, Chunk chunk)
        {
            int amountOfLogicalTilesPerChunkEdge = Area.LOGICAL_TILES_PER_VISUAL_TILE_EDGE * Area.VISUAL_TILES_PER_CHUNK_EDGE;

            int screenX = chunk.X * amountOfLogicalTilesPerChunkEdge;
            int screenY = chunk.Y * amountOfLogicalTilesPerChunkEdge;

            int lowestScreenX = FastMath.Min(screenX, currentProperties.LowestScreenX);
            int lowestScreenY = FastMath.Min(screenY, currentProperties.LowestScreenY);

            int highestScreenX = FastMath.Max(screenX + amountOfLogicalTilesPerChunkEdge, currentProperties.HighestScreenX);
            int highestScreenY = FastMath.Max(screenY + amountOfLogicalTilesPerChunkEdge, currentProperties.HighestScreenY);

            return new ScreenDimensionProperties(lowestScreenX, lowestScreenY, highestScreenX, highestScreenY);
        }

        private static void CalculateAbsolutePositionCollisionsAndSpawners(Chunk chunk, List<Collision> absolutePositionCollisions, List<Spawner> absolutePositionSpawners)
        {
            int amountOfLogicalTilesPerChunkEdge = Area.LOGICAL_TILES_PER_VISUAL_TILE_EDGE * Area.VISUAL_TILES_PER_CHUNK_EDGE;

            if (chunk.PropertiesOfPossibleChunks.Count > 0)
            {
                MapChunkProperties mapChunkProperties = chunk.PropertiesOfPossibleChunks[0];

                foreach (Collision collision in mapChunkProperties.CollisionProperties)
                {
                    Collision collisionWithAbsolutePosition = new Collision.Builder()
                        .SetStartX(collision.StartX + (chunk.X * amountOfLogicalTilesPerChunkEdge))
                        .SetStartY(collision.StartY + (chunk.Y * amountOfLogicalTilesPerChunkEdge))
                        .SetWidth(collision.Width)
                        .SetHeight(collision.Height)
                        .Build();

                    absolutePositionCollisions.Add(collisionWithAbsolutePosition);
                }

                foreach (Spawner spawner in mapChunkProperties.Spawners)
                {
                    int absoluteX = spawner.X + (chunk.X * amountOfLogicalTilesPerChunkEdge);
                    int absoluteY = spawner.Y + (chunk.Y * amountOfLogicalTilesPerChunkEdge);

                    Spawner spawnerWithAbsolutePosition = new Spawner(absoluteX, absoluteY);

                    absolutePositionSpawners.Add(spawnerWithAbsolutePosition);
                }
            }
        }

        private static Position DeterminePlayerSpawnPosition(Chunk chunk)
        {
            if (chunk.Spawn)
            {
                if (chunk.PropertiesOfPossibleChunks.Count > 0)
                {
                    MapChunkProperties mapChunkProperties = chunk.PropertiesOfPossibleChunks[0];

                    if (mapChunkProperties.PlayerSpawnPoint.IsSet)
                    {
                        int amountOfLogicalTilesPerChunkEdge = Area.LOGICAL_TILES_PER_VISUAL_TILE_EDGE * Area.VISUAL_TILES_PER_CHUNK_EDGE;

                        return new Position(mapChunkProperties.PlayerSpawnPoint.X + (chunk.X * amountOfLogicalTilesPerChunkEdge), mapChunkProperties.PlayerSpawnPoint.Y + (chunk.Y * amountOfLogicalTilesPerChunkEdge));
                    }
                }
            }

            return null;
        }

        private struct ScreenDimensionProperties
        {
            public int LowestScreenX
            {
                get;
                private set;
            }

            public int LowestScreenY
            {
                get;
                private set;
            }

            public int HighestScreenX
            {
                get;
                private set;
            }

            public int HighestScreenY
            {
                get;
                private set;
            }

            public ScreenDimensionProperties(int lowestScreenX, int lowestScreenY, int highestScreenX, int highestScreenY)
            {
                LowestScreenX = lowestScreenX;
                LowestScreenY = lowestScreenY;
                HighestScreenX = highestScreenX;
                HighestScreenY = highestScreenY;
            }
        }
    }
}