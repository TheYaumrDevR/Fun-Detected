using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct Chunk
    {
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

        public List<string> MapChunkIds
        {
            get;
            private set;
        }

        public Chunk(int x, int y)
        {
            X = x;
            Y = y;
            
            MapChunkIds = new List<string>();
        }
    }
}