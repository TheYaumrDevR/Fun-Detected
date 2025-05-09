using System.Collections.Generic;
using System.Text;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapDefinition
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

        public int MaximumMonsters
        {
            get;
            private set;
        }

        public List<Chunk> Chunks
        {
            get;
            private set;
        }

        public List<SpawnableMonster> SpawnableMonsters
        {
            get;
            private set;
        }

        public MapDefinition(int maximumMonsters, string mapName)
        {
            MaximumMonsters = maximumMonsters;
            MapName = mapName;
            AreaLevel = 1;
            IsSingleton = false;
            
            Chunks = new List<Chunk>();
            SpawnableMonsters = new List<SpawnableMonster>();
        }

        public override string ToString()
        {
            StringBuilder resultBuilder = new StringBuilder();

            resultBuilder.Append("MapDefinition with maximum monsters: ");
            resultBuilder.Append(MaximumMonsters);
            resultBuilder.AppendLine();
            resultBuilder.Append("and chunks:");
            resultBuilder.AppendLine();

            foreach (Chunk chunk in Chunks)
            {
                resultBuilder.Append(chunk.ToString());
                resultBuilder.AppendLine();
            }   

            resultBuilder.Append("and spawnable monsters:");
            resultBuilder.AppendLine();

            foreach (SpawnableMonster spawnableMonster in SpawnableMonsters)
            {
                resultBuilder.Append(spawnableMonster.ToString());
                resultBuilder.AppendLine();                
            }

            return resultBuilder.ToString();
        }        

        public class Builder
        {
            private string mapName;
            private int maximumMonsters;
            private int areaLevel;
            private bool isSingleton;

            public Builder SetMapName(string value)
            {
                mapName = value;
                return this;
            }

            public Builder SetMaximumMonsters(int value)
            {
                maximumMonsters = value;
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

            public MapDefinition Build()
            {
                MapDefinition result = new MapDefinition(maximumMonsters, mapName);
                result.AreaLevel = areaLevel;
                result.IsSingleton = isSingleton;

                return result;
            }
        }
    }
}