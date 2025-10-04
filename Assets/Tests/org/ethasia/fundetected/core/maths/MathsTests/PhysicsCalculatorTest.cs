using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class PhysicsCalculatorTest
    {
        [Test]
        public void TestCalculateFallingSubtractsYPositionCorrectly()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(3, 8);

            int resultFallingDistance = PhysicsCalculator.CalculateFalling(testRectangleCollisionShape, areaDimensions);

            Assert.That(resultFallingDistance, Is.EqualTo(2));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(6));
        }

        [Test]
        public void TestCalculateFallingDoesNotSubtractYPositionIfOnGround()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(6, 6);

            int resultFallingDistance = PhysicsCalculator.CalculateFalling(testRectangleCollisionShape, areaDimensions);

            Assert.That(resultFallingDistance, Is.EqualTo(0));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(6));
        }

        [Test]
        public void TestCalculateFallingFallsIntoHoleWithSameWidthAsShape()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(5, 9);

            int resultFallingDistance = PhysicsCalculator.CalculateFalling(testRectangleCollisionShape, areaDimensions);

            Assert.That(resultFallingDistance, Is.EqualTo(5));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(4));
        }

        private AreaDimensions CreateAreaDimensions()
        {
            return new AreaDimensions.Builder()
                .SetWidth(14)
                .SetHeight(13)
                .SetLowestScreenX(0)
                .SetLowestScreenY(0)
                .Build();
        }

        private RectangleCollisionShape CreateTestRectangleCollisionShape(int posX, int posY)
        {
            return new RectangleCollisionShape.Builder()
                .SetPosition(new Position(posX, posY))
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(2)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(2)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(3)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(3)
                .Build();
        }

        private void SetupTestArea()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(14, 13)
                .SetIsColliding(0, 2)
                .SetIsColliding(1, 2)
                .SetIsColliding(2, 2)
                .SetIsColliding(2, 1)
                .SetIsColliding(2, 0)
                .SetIsColliding(3, 0)
                .SetIsColliding(4, 0)
                .SetIsColliding(5, 0)
                .SetIsColliding(6, 0)
                .SetIsColliding(7, 0)
                .SetIsColliding(8, 0)
                .SetIsColliding(8, 1)
                .SetIsColliding(8, 2)
                .SetIsColliding(9, 2)
                .SetIsColliding(10, 2)
                .SetIsColliding(10, 5)
                .SetIsColliding(11, 2)
                .SetIsColliding(12, 2)
                .SetIsColliding(13, 2)
                .Build();

            Area.ActiveArea = testArea;
        }
    }
}