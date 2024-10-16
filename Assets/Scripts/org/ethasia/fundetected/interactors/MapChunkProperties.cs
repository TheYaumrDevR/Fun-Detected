using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapChunkProperties
    {
        public string Id
        {
            get;
        }

        public List<Tile> TerrainTiles
        {
            get;
        }

        public List<Tile> GroundTiles
        {
            get;
        }

        public List<Collision> CollisionProperties
        {
            get;
        }

        public List<Spawner> Spawners
        {
            get;
        }

        public MapChunkProperties(string id)
        {
            Id = id;
            TerrainTiles = new List<Tile>();
            GroundTiles = new List<Tile>();
            CollisionProperties = new List<Collision>();
            Spawners = new List<Spawner>();
        }
    }
}