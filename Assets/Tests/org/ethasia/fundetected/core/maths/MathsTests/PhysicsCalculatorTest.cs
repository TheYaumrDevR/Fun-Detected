using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class PhysicsCalculatorTest
    {
        [Test]
        public void TestCalculateDistanceForConstantAccelerationCalculatesCorrectDistances()
        {
            int result = TestablePhysicsCalculator.CallCalculateDistanceForConstantAcceleration(1.2, -9);
            int result2 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAcceleration(3.7, -9);
            int result3 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAcceleration(0, -9);
            int result4 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAcceleration(5.2, -3);

            Assert.That(result, Is.EqualTo(-6));
            Assert.That(result2, Is.EqualTo(-62));
            Assert.That(result3, Is.EqualTo(0));
            Assert.That(result4, Is.EqualTo(-41));
        }

        [Test]
        public void TestCalculateDistanceForConstantAccelerationWithInitialVelocityCalculatesCorrectDistances()
        {
            int result = TestablePhysicsCalculator.CallCalculateDistanceForConstantAccelerationWithInitialVelocity(1.2, 10, -9);
            int result2 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAccelerationWithInitialVelocity(3.7, 5, -9);
            int result3 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAccelerationWithInitialVelocity(0, 15, -9);
            int result4 = TestablePhysicsCalculator.CallCalculateDistanceForConstantAccelerationWithInitialVelocity(5.2, 0, -3);

            Assert.That(result, Is.EqualTo(6));
            Assert.That(result2, Is.EqualTo(-43));
            Assert.That(result3, Is.EqualTo(0));
            Assert.That(result4, Is.EqualTo(-41));
        }

        [Test]
        public void TestCalculateHorizontalMovementFallsToLowestPointWhenNoObstacles()
        {
            SetupTestAreaWithNoObstacles();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(4, 14);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(14);
            physicsBody.Fall(3);

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultFallingDistance = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultFallingDistance, Is.EqualTo(10));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(4));
        }

        [Test]
        public void TestCalculateHorizontalMovementFallsBasedOnTime()
        {
            SetupTestAreaWithNoObstacles();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(4, 14);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(14);
            physicsBody.Fall(1.3);

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultFallingDistance = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultFallingDistance, Is.EqualTo(8));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(6));
        }

        [Test]
        public void TestCalculateHorizontalMovementStopsAtCollidable()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(10, 18);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(18);
            physicsBody.Fall(1.5);

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultFallingDistance = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultFallingDistance, Is.EqualTo(9));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(9));
        }

        [Test]
        public void TestCalculateHorizontalMovementDoesNotFallOnGround()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(10, 9);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(9);
            physicsBody.Fall(1.5);

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultFallingDistance = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultFallingDistance, Is.EqualTo(0));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(9));
        }

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

        [Test]
        public void TestCalculateHorizontalMovementDownwardsWhenInitialVelocityIsZero()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(4, 14);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(14);
            physicsBody.Fall(0.5);

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultHorizontalMovement = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultHorizontalMovement, Is.EqualTo(3));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(11));
        }

        [Test]
        public void TestCalculateHorizontalMovementUpwardsWhenInitialVelocityIsGreaterThanZero()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(4, 14);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(14);
            physicsBody.Fall(0.5);
            physicsBody.InitialVerticalVelocityUnitsPerSecond = 14;

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultHorizontalMovement = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultHorizontalMovement, Is.EqualTo(4));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(18));
        }

        [Test]
        public void TestCalculateHorizontalMovementUpwardsStopsAtCeiling()
        {
            SetupTestArea();
            AreaDimensions areaDimensions = CreateAreaDimensions();
            RectangleCollisionShape testRectangleCollisionShape = CreateTestRectangleCollisionShape(4, 14);

            PhysicsBody physicsBody = new PhysicsBody();
            physicsBody.StartFalling(14);
            physicsBody.Fall(0.5);
            physicsBody.InitialVerticalVelocityUnitsPerSecond = 28;

            PhysicsCalculator.PhysicsCalculationContext calculationContext = new PhysicsCalculator.PhysicsCalculationContext.Builder()
                .SetPhysicsBody(physicsBody)
                .SetRectangleCollisionShape(testRectangleCollisionShape)
                .SetAreaDimensions(areaDimensions)
                .Build();

            int resultHorizontalMovement = PhysicsCalculator.CalculateHorizontalMovement(calculationContext);

            Assert.That(resultHorizontalMovement, Is.EqualTo(8));
            Assert.That(testRectangleCollisionShape.Position.Y, Is.EqualTo(22));
        }

        private AreaDimensions CreateAreaDimensions()
        {
            return new AreaDimensions.Builder()
                .SetWidth(14)
                .SetHeight(25)
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
                .SetWidthAndHeight(14, 25)
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

        private void SetupTestAreaWithNoObstacles()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(14, 13)
                .Build();

            Area.ActiveArea = testArea;
        }
    }
}