using System.Collections.Generic;
using System.Text;

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

        public PortalTo? PortalTo
        {
            get;
            private set;
        }

        public string Id
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
            Id = "";
            PortalTo = null;

            Spawn = false;
        }    

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Chunk with spawn: " + Spawn);
            result.AppendLine();
            result.Append("at position " + X + ", " + Y);
            result.AppendLine();
            result.Append("and chunk properties");
            result.AppendLine();

            foreach (MapChunkProperties chunkProperties in PropertiesOfPossibleChunks)
            {
                result.Append(chunkProperties.ToString());
                result.AppendLine();
            }

            return result.ToString();
        }

        public class Builder
        {
            private bool spawn;
            private int x;
            private int y;
            private string id;
            private PortalTo? portalTo;
            private List<MapChunkProperties> propertiesOfPossibleChunks = new List<MapChunkProperties>();

            public Builder SetSpawn(bool value)
            {
                spawn = value;
                return this;
            }

            public Builder SetX(int value)
            {
                x = value;
                return this;
            }

            public Builder SetY(int value)
            {
                y = value;
                return this;
            }

            public Builder SetId(string value)
            {
                id = value;
                return this;
            }

            public Builder SetPortalTo(PortalTo? value)
            {
                portalTo = value;
                return this;
            }

            public Builder SetPropertiesOfPossibleChunks(List<MapChunkProperties> value)
            {
                propertiesOfPossibleChunks = value;
                return this;
            }

            public Chunk Build()
            {
                Chunk result = new Chunk(x, y);
                result.Spawn = spawn;
                result.Id = id;
                result.PortalTo = portalTo;
                result.PropertiesOfPossibleChunks = propertiesOfPossibleChunks;

                return result;
            }
        }
    }
}