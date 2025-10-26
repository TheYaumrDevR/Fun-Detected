using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class TestablePhysicsCalculator : PhysicsCalculator
    {
        public static int CallCalculateDistanceForConstantAcceleration(double timeInSeconds, int acceleration)
        {
            return CalculateDistanceForConstantAcceleration(timeInSeconds, acceleration);
        }

        public static int CallCalculateDistanceForConstantAccelerationWithInitialVelocity(double timeInSeconds, int initialVelocityUnitsPerSecond, int acceleration)
        {
            return CalculateDistanceForConstantAccelerationWithInitialVelocity(timeInSeconds, initialVelocityUnitsPerSecond, acceleration);
        }
    }
}