using System.Collections.Generic;

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

        public MapDefinition(int maximumMonsters)
        {
            MaximumMonsters = maximumMonsters;
            
            Chunks = new List<Chunk>();
            SpawnableMonsters = new List<SpawnableMonster>();
        }
    }
}