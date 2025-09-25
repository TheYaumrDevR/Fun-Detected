namespace Org.Ethasia.Fundetected.Core.Map
{
    public class RectangleCollisionShape
    {
        public Position Position
        {
            get;
            private set;
        }

        public int CollisionShapeDistanceToLeftEdgeFromCenter
        {
            get;
            private set;
        }

        public int CollisionShapeDistanceToRightEdgeFromCenter
        {
            get;
            private set;
        }

        public int CollisionShapeDistanceToTopEdgeFromCenter
        {
            get;
            private set;
        }

        public int CollisionShapeDistanceToBottomEdgeFromCenter
        {
            get;
            private set;
        }

        public class Builder
        {
            private Position position;
            private int collisionShapeDistanceToLeftEdgeFromCenter;
            private int collisionShapeDistanceToRightEdgeFromCenter;
            private int collisionShapeDistanceToTopEdgeFromCenter;
            private int collisionShapeDistanceToBottomEdgeFromCenter;

            public Builder SetPosition(Position vaLue)
            {
                position = vaLue;
                return this;
            }

            public Builder SetCollisionShapeDistanceToLeftEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToLeftEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToRightEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToRightEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToTopEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToTopEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToBottomEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToBottomEdgeFromCenter = value;
                return this;
            }

            public RectangleCollisionShape Build()
            {
                var result = new RectangleCollisionShape();

                result.Position = position;
                result.CollisionShapeDistanceToLeftEdgeFromCenter = collisionShapeDistanceToLeftEdgeFromCenter;
                result.CollisionShapeDistanceToRightEdgeFromCenter = collisionShapeDistanceToRightEdgeFromCenter;
                result.CollisionShapeDistanceToTopEdgeFromCenter = collisionShapeDistanceToTopEdgeFromCenter;
                result.CollisionShapeDistanceToBottomEdgeFromCenter = collisionShapeDistanceToBottomEdgeFromCenter;

                return result;
            }
        }         
    }
}