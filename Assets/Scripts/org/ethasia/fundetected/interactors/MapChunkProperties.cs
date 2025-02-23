using System.Collections.Generic;
using System.Text;

using Org.Ethasia.Fundetected.Core.Map;

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

        public InfiniteHealingWell? InfiniteHealingWell
        {
            get;
            private set;
        }

        public List<ITile> TerrainTiles
        {
            get;
        }

        public List<ITile> GroundTiles
        {
            get;
        }

        public List<ITile> FoliageBackTiles
        {
            get;
        }

        public List<ITile> FoliageFrontTiles
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
            InfiniteHealingWell = null;
            
            TerrainTiles = new List<ITile>();
            GroundTiles = new List<ITile>();
            FoliageBackTiles = new List<ITile>();
            FoliageFrontTiles = new List<ITile>();
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
            private InfiniteHealingWell? infiniteHealingWell;

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

            public Builder SetInfiniteHealingWell(InfiniteHealingWell? value)
            {
                infiniteHealingWell = value;
                return this;
            }

            public MapChunkProperties Build()
            {
                MapChunkProperties result = new MapChunkProperties(id, playerSpawnPoint, portalProperties);

                result.InfiniteHealingWell = infiniteHealingWell;

                return result;
            }
        }
    }
}