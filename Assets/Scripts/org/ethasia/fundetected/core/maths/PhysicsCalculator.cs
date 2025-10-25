using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class PhysicsCalculator
    {
        private const int GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED = -27;

        public static int CalculateFalling(PhysicsCalculationContext parameters)
        {
            int result = 0;

            int targetPosLowerBorder = CalculateTargetPositionLowerBorder(parameters.PhysicsBody, parameters.RectangleCollisionShape, parameters.AreaDimensions);

            for (int i = parameters.RectangleCollisionShape.Position.Y - parameters.RectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1; i > targetPosLowerBorder; i--)
            {
                for (int x = parameters.RectangleCollisionShape.Position.X - parameters.RectangleCollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter; x <= parameters.RectangleCollisionShape.Position.X + parameters.RectangleCollisionShape.CollisionShapeDistanceToRightEdgeFromCenter; x++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(x, i))
                    {
                        parameters.RectangleCollisionShape.Position.Y -= result;
                        parameters.PhysicsBody.StopFalling();
                        return result;
                    }
                }

                result++;
            }

            if (targetPosLowerBorder == parameters.AreaDimensions.LowestScreenY)
            {
                parameters.PhysicsBody.StopFalling();
            }

            parameters.RectangleCollisionShape.Position.Y -= result;
            return result;
        }

        public static int CalculateFalling(RectangleCollisionShape rectangleCollisionShape, AreaDimensions areaDimensions)
        {
            int result = 0;

            for (int i = rectangleCollisionShape.Position.Y - rectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1; i > areaDimensions.LowestScreenY; i--)
            {
                for (int x = rectangleCollisionShape.Position.X - rectangleCollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter; x <= rectangleCollisionShape.Position.X + rectangleCollisionShape.CollisionShapeDistanceToRightEdgeFromCenter; x++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(x, i))
                    {
                        rectangleCollisionShape.Position.Y -= result;
                        return result;
                    }
                }

                result++;
            }

            rectangleCollisionShape.Position.Y -= result;
            return result;
        }

        private static int CalculateTargetPositionLowerBorder(PhysicsBody physicsBody, RectangleCollisionShape rectangleCollisionShape, AreaDimensions areaDimensions)
        {
            int totalFallDistance = CalculateDistanceForConstantAcceleration(physicsBody.TimePassedSinceVerticalMovementStart, GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED);
            int result = physicsBody.OriginalPosY + totalFallDistance - rectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1;

            if (result < areaDimensions.LowestScreenY)
            {
                result = areaDimensions.LowestScreenY;
            }

            return result;
        }

        protected static int CalculateDistanceForConstantAcceleration(double timeInSeconds, int acceleration)
        {
            return (int)(FastMath.Round(acceleration * (0.5 * timeInSeconds * timeInSeconds)));
        }
        
        public struct PhysicsCalculationContext
        {
            public PhysicsBody PhysicsBody
            {
                get;
                private set;
            }
            
            public RectangleCollisionShape RectangleCollisionShape
            {
                get;
                private set;
            }

            public AreaDimensions AreaDimensions
            {
                get;
                private set;
            }

            public class Builder
            {
                private PhysicsBody physicsBody;
                private RectangleCollisionShape rectangleCollisionShape;
                private AreaDimensions areaDimensions;

                public Builder SetPhysicsBody(PhysicsBody value)
                {
                    physicsBody = value;
                    return this;
                }

                public Builder SetRectangleCollisionShape(RectangleCollisionShape value)
                {
                    rectangleCollisionShape = value;
                    return this;
                }

                public Builder SetAreaDimensions(AreaDimensions value)
                {
                    areaDimensions = value;
                    return this;
                }

                public PhysicsCalculationContext Build()
                {
                    return new PhysicsCalculationContext
                    {
                        PhysicsBody = physicsBody,
                        RectangleCollisionShape = rectangleCollisionShape,
                        AreaDimensions = areaDimensions
                    };
                }
            }
        }
    }
}