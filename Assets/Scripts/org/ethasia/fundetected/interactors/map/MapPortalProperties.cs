using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public struct MapPortalProperties
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

        private MapPortalProperties(Position position, int width, int height, string destinationMapId, string destinationPortalId)
        {
            Position = position;
            Width = width;
            Height = height;
            DestinationMapId = destinationMapId;
            DestinationPortalId = destinationPortalId;
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

            public MapPortalProperties Build()
            {
                return new MapPortalProperties(position, width, height, destinationMapId, destinationPortalId);
            }
        }
    }
}