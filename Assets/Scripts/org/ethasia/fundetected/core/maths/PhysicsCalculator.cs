using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class PhysicsCalculator
    {
        private const int GRAVITY_ACCELERATION_UNITS_PER_SECOND_SQUARED = -9;

        public static int CalculateFalling(PhysicsBody physicsBody, RectangleCollisionShape rectangleCollisionShape, AreaDimensions areaDimensions)
        {
            int result = 0;

            int targetPosLowerBorder = CalculateTargetPositionLowerBorder(physicsBody, rectangleCollisionShape, areaDimensions);

            for (int i = rectangleCollisionShape.Position.Y - rectangleCollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter - 1; i > targetPosLowerBorder; i--)
            {
                for (int x = rectangleCollisionShape.Position.X - rectangleCollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter; x <= rectangleCollisionShape.Position.X + rectangleCollisionShape.CollisionShapeDistanceToRightEdgeFromCenter; x++)
                {
                    if (Area.ActiveArea.TileAtIsCollision(x, i))
                    {
                        rectangleCollisionShape.Position.Y -= result;
                        physicsBody.StopFalling();
                        return result;
                    }
                }

                result++;
            }

            if (targetPosLowerBorder == areaDimensions.LowestScreenY)
            {
                physicsBody.StopFalling();
            }

            rectangleCollisionShape.Position.Y -= result;
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
    }
}