using System.Collections.Generic;
using System.Text;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapChunkProperties
    {
        public string Id
        {
            get;
        }

        public PlayerSpawn PlayerSpawnPoint
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

        public MapChunkProperties(string id, PlayerSpawn playerSpawnPoint)
        {
            Id = id;
            PlayerSpawnPoint = playerSpawnPoint;
            
            TerrainTiles = new List<Tile>();
            GroundTiles = new List<Tile>();
            CollisionProperties = new List<Collision>();
            Spawners = new List<Spawner>();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("MapChunkProperties with id: " + Id);
            result.AppendLine();
            result.Append("player spawn point is set " + PlayerSpawnPoint.IsSet + " X: " + PlayerSpawnPoint.X + ", Y: " + PlayerSpawnPoint.Y);

            return result.ToString();
        }
    }
}