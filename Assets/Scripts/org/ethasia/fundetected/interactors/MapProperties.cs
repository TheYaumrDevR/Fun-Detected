using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Combat;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapProperties 
    {
        public string MapName
        {
            get;
            private set;
        }

        public int AreaLevel
        {
            get;
            private set;
        }

        public bool IsSingleton
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

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

        public int MaximumMonsters
        {
            get;
            private set;
        }
        
        public List<Collision> Collisions
        {
            get;
        }

        public Position PlayerSpawnPosition
        {
            get;
            private set;
        }

        public Dictionary<string, Position> SpawnPositionsByChunkId
        {
            get;
            private set;
        }   

        public List<MapPortalProperties> Portals
        {
            get;
        }

        public List<Spawner> Spawners
        {
            get;
        }

        public List<HealingWell> HealingWells
        {
            get;
        }

        public List<SpawnableMonster> SpawnableMonsters
        {
            get;
        }        

        #nullable enable
        public ReloadableTileMap? ReloadableTileMap
        {
            get;
            private set;
        }
        #nullable disable

        private MapProperties(int width, int height)
        {
            MapName = "";
            AreaLevel = 1;
            IsSingleton = false;
            Width = width;
            Height = height;
            MaximumMonsters = 0;
            LowestScreenX = 0;
            LowestScreenY = 0;
            Collisions = new List<Collision>();
            PlayerSpawnPosition = null;
            SpawnPositionsByChunkId = new Dictionary<string, Position>();
            Portals = new List<MapPortalProperties>();
            HealingWells = new List<HealingWell>();
            Spawners = new List<Spawner>();
            SpawnableMonsters = new List<SpawnableMonster>();
            ReloadableTileMap = null;
        }

        public void AddCollision(Collision value)
        {
            Collisions.Add(value);
        }

        public void AddAllCollisions(List<Collision> values)
        {
            Collisions.AddRange(values);
        }

        public void AddAllSpawners(List<Spawner> values)
        {
            Spawners.AddRange(values);
        }   

        public class Builder
        {
            private string mapName;
            private int areaLevel;
            private bool isSingleton;
            private int width;
            private int height;
            private int lowestScreenX;
            private int lowestScreenY;
            private int maximumMonsters;
            private Position playerSpawnPosition;
            private Dictionary<string, Position> SpawnPositionsByChunkId;
            private ReloadableTileMap reloadableTileMap;

            public Builder SetMapName(string value)
            {
                mapName = value;
                return this;
            }

            public Builder SetAreaLevel(int value)
            {
                areaLevel = value;
                return this;
            }

            public Builder SetIsSingleton(bool value)
            {
                isSingleton = value;
                return this;
            }

            public Builder SetWidth(int value)
            {
                width = value;
                return this;
            }

            public Builder SetHeight(int value)
            {
                height = value;
                return this;
            }

            public Builder SetLowestScreenX(int value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(int value)
            {
                lowestScreenY = value;
                return this;
            }   

            public Builder SetMaximumMonsters(int value)
            {
                maximumMonsters = value;
                return this;
            }       

            public Builder SetPlayerSpawnPosition(Position value)
            {
                playerSpawnPosition = value;
                return this;
            }    

            public Builder SetSpawnPositionsByChunkId(Dictionary<string, Position> value)
            {
                SpawnPositionsByChunkId = value;
                return this;
            }

            public Builder SetReloadableTileMap(ReloadableTileMap value)
            {
                reloadableTileMap = value;
                return this;
            }

            public MapProperties Build()
            {
                MapProperties result = new MapProperties(width, height);

                result.MapName = mapName;
                result.AreaLevel = areaLevel;
                result.IsSingleton = isSingleton;
                result.LowestScreenX = lowestScreenX;
                result.LowestScreenY = lowestScreenY;
                result.MaximumMonsters = maximumMonsters;
                result.PlayerSpawnPosition = playerSpawnPosition;
                result.SpawnPositionsByChunkId = SpawnPositionsByChunkId;
                result.ReloadableTileMap = reloadableTileMap;

                return result;
            }                                  
        }   
    }
}