using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class PhysicsCalculator
    {
        private const int GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED = -27;

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

        public static int CalculateHorizontalMovement(PhysicsCalculationContext parameters)
        {
            int targetPosLowerBorder = CalculateTargetPositionLowerBorder(parameters);
            int currentYPosLowerBorder = parameters.RectangleCollisionShape.Position.Y - parameters.RectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1;

            if (currentYPosLowerBorder >= targetPosLowerBorder)
            {
                return CalculateFalling(parameters);
            }
            else
            {
                return CalculateRising(parameters);
            }
        }

        protected static int CalculateFalling(PhysicsCalculationContext parameters)
        {
            int result = 0;

            int targetPosLowerBorder = CalculateTargetPositionLowerBorder(parameters);

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

        protected static int CalculateRising(PhysicsCalculationContext parameters)
        {
            int result = 0;

            int targetPosUpperBorder = CalculateTargetPositionUpperBorder(parameters);

            for (int i = parameters.RectangleCollisionShape.Position.Y + parameters.RectangleCollisionShape.CollisionShapeDistanceToTopEdgeFromCenter - 1; i < targetPosUpperBorder; i++)
            {
                for (int x = parameters.RectangleCollisionShape.Position.X - parameters.RectangleCollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter; x <= parameters.RectangleCollisionShape.Position.X + parameters.RectangleCollisionShape.CollisionShapeDistanceToRightEdgeFromCenter; x++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(x, i))
                    {
                        parameters.RectangleCollisionShape.Position.Y += result;
                        return result;
                    }
                }

                result++;
            }

            parameters.RectangleCollisionShape.Position.Y += result;
            return result;
        }

        private static int CalculateTargetPositionLowerBorder(PhysicsCalculationContext parameters)
        {
            int totalFallDistance = CalculateDistanceForConstantAccelerationWithInitialVelocity(parameters.PhysicsBody.TimePassedSinceVerticalMovementStart, parameters.PhysicsBody.InitialVerticalVelocityUnitsPerSecond
                , GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED);
            int result = parameters.PhysicsBody.OriginalPosY + totalFallDistance - parameters.RectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1;

            if (result < parameters.AreaDimensions.LowestScreenY)
            {
                result = parameters.AreaDimensions.LowestScreenY;
            }

            return result;
        }

        protected static int CalculateTargetPositionUpperBorder(PhysicsCalculationContext parameters)
        {
            int totalRisingDistance = CalculateDistanceForConstantAccelerationWithInitialVelocity(parameters.PhysicsBody.TimePassedSinceVerticalMovementStart, parameters.PhysicsBody.InitialVerticalVelocityUnitsPerSecond
                , GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED);
            int result = parameters.PhysicsBody.OriginalPosY + totalRisingDistance + parameters.RectangleCollisionShape.CollisionShapeDistanceToTopEdgeFromCenter - 1;

            int highestScreenY = parameters.AreaDimensions.LowestScreenY + parameters.AreaDimensions.Height - 1;

            if (result > highestScreenY)
            {
                result = highestScreenY;
            }

            return result;
        }

        protected static int CalculateDistanceForConstantAcceleration(double timeInSeconds, int acceleration)
        {
            return (int)(FastMath.Round(acceleration * (0.5 * timeInSeconds * timeInSeconds)));
        }

        protected static int CalculateDistanceForConstantAccelerationWithInitialVelocity(double timeInSeconds, int initialVelocityUnitsPerSecond, int acceleration)
        {
            return (int)(FastMath.Round(initialVelocityUnitsPerSecond * timeInSeconds + (acceleration * (0.5 * timeInSeconds * timeInSeconds))));
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