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

        public PortalProperties PortalProperties
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

        public List<Tile> FoliageBackTiles
        {
            get;
        }

        public List<Tile> FoliageFrontTiles
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

        private MapChunkProperties(string id, PlayerSpawn playerSpawnPoint, PortalProperties portalProperties)
        {
            Id = id;
            PlayerSpawnPoint = playerSpawnPoint;
            PortalProperties = portalProperties;
            
            TerrainTiles = new List<Tile>();
            GroundTiles = new List<Tile>();
            FoliageBackTiles = new List<Tile>();
            FoliageFrontTiles = new List<Tile>();
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

        public class Builder
        {
            private string id;
            private PlayerSpawn playerSpawnPoint;
            private PortalProperties portalProperties;

            public Builder SetId(string value)
            {
                id = value;
                return this;
            }

            public Builder SetPlayerSpawnPoint(PlayerSpawn value)
            {
                playerSpawnPoint = value;
                return this;    
            }

            public Builder SetPortalProperties(PortalProperties value)
            {
                portalProperties = value;
                return this;
            }            

            public MapChunkProperties Build()
            {
                return new MapChunkProperties(id, playerSpawnPoint, portalProperties);
            }
        }
    }
}