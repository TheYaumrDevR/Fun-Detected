namespace Org.Ethasia.Fundetected.Core
{
    public struct BoundingBox
    {
        public int DistanceToRightEdge
        {
            get;
            private set;
        }

        public int DistanceToLeftEdge
        {
            get;
            private set;
        }

        public int DistanceToBottomEdge
        {
            get;
            private set;
        }

        public int DistanceToTopEdge
        {
            get;
            private set;
        }

        public int Width
        {
            get
            {
                return DistanceToLeftEdge + 1 + DistanceToRightEdge;
            }
        }

        public int Height
        {
            get
            {
                return DistanceToBottomEdge + 1 + DistanceToTopEdge;
            }
        }       

        public class Builder
        {
            private int distanceToRightEdge;
            private int distanceToLeftEdge;
            private int distanceToBottomEdge;
            private int distanceToTopEdge;

            public Builder SetDistanceToRightEdge(int value)
            {
                distanceToRightEdge = value;
                return this;
            }

            public Builder SetDistanceToLeftEdge(int value)
            {
                distanceToLeftEdge = value;
                return this;
            }

            public Builder SetDistanceToBottomEdge(int value)
            {
                distanceToBottomEdge = value;
                return this;
            }

            public Builder SetDistanceToTopEdge(int value)
            {
                distanceToTopEdge = value;
                return this;
            }   

            public BoundingBox Build()
            {
                BoundingBox result = new BoundingBox();

                result.DistanceToRightEdge = distanceToRightEdge;
                result.DistanceToLeftEdge = distanceToLeftEdge;
                result.DistanceToBottomEdge = distanceToBottomEdge;
                result.DistanceToTopEdge = distanceToTopEdge;

                return result;
            }                                 
        }
    }
}