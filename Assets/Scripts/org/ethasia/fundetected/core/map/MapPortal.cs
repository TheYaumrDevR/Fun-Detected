using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class MapPortal : IInteractableEnvironmentObject
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

        public CollisionCalculations.CollisionBoundingBoxContext GetCollisionBoundingBoxContext()
        {
            int distanceToRightEdge = Width / 2;
            int distanceToLeftEdge = 0 == Width % 2 ? Width / 2 - 1 : Width / 2;
            int distanceToTopEdge = Height / 2;
            int distanceToBottomEdge = 0 == Height % 2 ? Height / 2 - 1 : Height / 2;

            return new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(Position.X)
                .SetPositionY(Position.Y)
                .SetDistanceToLeftEdge(distanceToLeftEdge)
                .SetDistanceToRightEdge(distanceToRightEdge)
                .SetDistanceToTopEdge(distanceToTopEdge)
                .SetDistanceToBottomEdge(distanceToBottomEdge)
                .Build();
        }

        public void OnInteract()
        {
            // Call AreaSwitchInteractor to switch to the destination map
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