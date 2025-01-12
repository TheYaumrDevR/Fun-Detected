namespace Org.Ethasia.Fundetected.Core.Map
{
    public class MapPortal
    {
        public Position Position
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

        public string DestinationMapId
        {
            get;
            private set;
        }

        public string DestinationPortalId
        {
            get;
            private set;
        }

        public class Builder
        {
            private Position position;
            private int width;
            private int height;
            private string destinationMapId;
            private string destinationPortalId;

            public Builder SetPosition(Position value)
            {
                position = value;
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

            public Builder SetDestinationMapId(string value)
            {
                destinationMapId = value;
                return this;
            }   

            public Builder SetDestinationPortalId(string value)
            {
                destinationPortalId = value;
                return this;
            }

            public MapPortal Build()
            {
                MapPortal result = new MapPortal();

                result.Position = position;
                result.Width = width;
                result.Height = height;
                result.DestinationMapId = destinationMapId;
                result.DestinationPortalId = destinationPortalId;

                return result;
            }
        }
    }
}