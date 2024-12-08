using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct Chunk
    {
        public bool Spawn;

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public List<MapChunkProperties> PropertiesOfPossibleChunks
        {
            get;
            private set;
        }

        public Chunk(int x, int y)
        {
            X = x;
            Y = y;
            
            PropertiesOfPossibleChunks = new List<MapChunkProperties>();

            Spawn = false;
        }
    }
}