using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class PhysicsBodyTest
    {
        [Test]
        public void TestFallSumsUpFallTimeCorrectly()
        {
            // Arrange
            var testCandidate = new PhysicsBody();
            testCandidate.StartFalling();

            // Act
            testCandidate.Fall(1.0f);
            testCandidate.Fall(1.2f);

            // Assert
            Assert.That(testCandidate.TimePassedSinceVerticalMovementStart, Is.EqualTo(2.2f));
        }

        [Test]
        public void TestFallDoesNotSumUpFallTimeAfterStopFalling()
        {
            // Arrange
            var testCandidate = new PhysicsBody();
            testCandidate.StartFalling();
            testCandidate.Fall(1.0f);
            testCandidate.Fall(1.2f);

            // Act
            testCandidate.StopFalling();
            testCandidate.Fall(3.3f);

            // Assert
            Assert.That(testCandidate.TimePassedSinceVerticalMovementStart, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestStopFallingResetsFallTime()
        {
            // Arrange
            var testCandidate = new PhysicsBody();
            testCandidate.StartFalling();
            testCandidate.Fall(1.0f);
            testCandidate.Fall(1.2f);

            // Act
            testCandidate.StopFalling();

            // Assert
            Assert.That(testCandidate.TimePassedSinceVerticalMovementStart, Is.EqualTo(0.0f));
        }

        [Test]
        public void TestStartFallingStartsSummingUpFallTime()
        {
            // Arrange
            var testCandidate = new PhysicsBody();
            testCandidate.StartFalling();
            testCandidate.Fall(1.0f);
            testCandidate.Fall(1.2f);
            testCandidate.StopFalling();

            // Act
            testCandidate.StartFalling();
            testCandidate.Fall(3.3f);

            // Assert
            Assert.That(testCandidate.TimePassedSinceVerticalMovementStart, Is.EqualTo(3.3f));
        }
    }
}