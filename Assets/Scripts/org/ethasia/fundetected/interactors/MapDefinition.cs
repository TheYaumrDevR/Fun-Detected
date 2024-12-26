using System.Collections.Generic;
using System.Text;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapDefinition
    {
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

        public MapDefinition(int maximumMonsters)
        {
            MaximumMonsters = maximumMonsters;
            
            Chunks = new List<Chunk>();
            SpawnableMonsters = new List<SpawnableMonster>();
        }
    }
}