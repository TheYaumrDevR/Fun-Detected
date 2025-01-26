namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class CollisionCalculations
    {
        public static bool AreBoundingBoxesOverlapping(CollisionBoundingBoxContext first, CollisionBoundingBoxContext second)
        {
            return (first.PositionX + first.DistanceToRightEdge >= second.PositionX - second.DistanceToLeftEdge
            && first.PositionX + first.DistanceToRightEdge <= second.PositionX + second.DistanceToRightEdge
            || first.PositionX - first.DistanceToLeftEdge >= second.PositionX - second.DistanceToLeftEdge
            && first.PositionX - first.DistanceToLeftEdge <= second.PositionX + second.DistanceToRightEdge
            || first.PositionX + first.DistanceToRightEdge >= second.PositionX + second.DistanceToRightEdge
            && first.PositionX - first.DistanceToLeftEdge <= second.PositionX - second.DistanceToLeftEdge)
            && (first.PositionY + first.DistanceToTopEdge >= second.PositionY - second.DistanceToBottomEdge
            && first.PositionY + first.DistanceToTopEdge <= second.PositionY + second.DistanceToTopEdge
            || first.PositionY - first.DistanceToBottomEdge >= second.PositionY - second.DistanceToBottomEdge
            && first.PositionY - first.DistanceToBottomEdge <= second.PositionY + second.DistanceToTopEdge
            || first.PositionY + first.DistanceToTopEdge >= second.PositionY + second.DistanceToTopEdge
            && first.PositionY - first.DistanceToBottomEdge <= second.PositionY - second.DistanceToBottomEdge);	
        }

        public struct CollisionBoundingBoxContext
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

            public int PositionX
            {
                get;
                private set;
            }

            public int PositionY
            {
                get;
                private set;
            }

            public class Builder
            {
                private int distanceToRightEdge;
                private int distanceToLeftEdge;
                private int distanceToBottomEdge;
                private int distanceToTopEdge;
                private int positionX;  
                private int positionY;

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

                public Builder SetPositionX(int value)
                {
                    positionX = value;
                    return this;
                }

                public Builder SetPositionY(int value)
                {
                    positionY = value;
                    return this;
                }

                public CollisionBoundingBoxContext Build()
                {
                    CollisionBoundingBoxContext result = new CollisionBoundingBoxContext();

                    result.DistanceToRightEdge = distanceToRightEdge;
                    result.DistanceToLeftEdge = distanceToLeftEdge;
                    result.DistanceToBottomEdge = distanceToBottomEdge;
                    result.DistanceToTopEdge = distanceToTopEdge;
                    result.PositionX = positionX;
                    result.PositionY = positionY;

                    return result;
                }
            }
        }
    }
}