using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class FastMathTest
    {
        [Test]
        public void TestFloorRandomNumberGetsFloored()
        {
            int result = FastMath.Floor(63.542f);

            Assert.That(result, Is.EqualTo(63)); 
        }

        [Test]
        public void TestFloorFullNumberStaysTheSame()
        {
            int result = FastMath.Floor(564);

            Assert.That(result, Is.EqualTo(564)); 
        }

        [Test]
        public void TestFloorNegativeNumberGetsFloored()
        {
            int result = FastMath.Floor(-4743.3546f);

            Assert.That(result, Is.EqualTo(-4744)); 
        }

        [Test]
        public void TestFloorNumberWithSmallDecimalsGetsFloored()
        {
            int result = FastMath.Floor(23456.0000001f);

            Assert.That(result, Is.EqualTo(23456));             
        }

        [Test]
        public void TestCeilRandomNumberGetsUpped()
        {
            int result = FastMath.Ceil(63.542f);

            Assert.That(result, Is.EqualTo(64)); 
        }

        [Test]
        public void TestCeilFullNumberStaysTheSame()
        {
            int result = FastMath.Ceil(564);

            Assert.That(result, Is.EqualTo(564)); 
        }

        [Test]
        public void TestCeilNegativeNumberGetsUpped()
        {
            int result = FastMath.Ceil(-4743.3546f);

            Assert.That(result, Is.EqualTo(-4743)); 
        }

        [Test]
        public void TestCeilNumberWithSmallDecimalsGetsUpped()
        {
            int result = FastMath.Ceil(23456.001f);

            Assert.That(result, Is.EqualTo(23457));             
        }

        [Test]
        public void TestNearlyEqualNumbersWithinThresholdReturnsTrue()
        {
            float number1 = 53.433f;
            float number2 = 53.434f;

            bool result = FastMath.NearlyEqual(number1, number2, 0.001f);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestNearlyEqualNumbersOutsideThresholdReturnsFalse()
        {
            float number1 = 124.433f;
            float number2 = 124.434f;

            bool result = FastMath.NearlyEqual(number1, number2, 0.0005f);

            Assert.That(result, Is.False);
        }        

        [Test]
        public void TestRoundRoundsToTheNearestIntegerUp()
        {
            double toRound = 9534.567;

            double result = FastMath.Round(toRound);

            Assert.That(result, Is.EqualTo(9535));
        }

        [Test]
        public void TestRoundRoundsToTheNearestIntegerDown()
        {
            double toRound = 9534.499;

            double result = FastMath.Round(toRound);

            Assert.That(result, Is.EqualTo(9534));
        }

        [Test]
        public void TestRoundRoundsToFirstDecimalPlaceUp()
        {
            double toRound = 9534.759;

            double result = FastMath.Round(toRound, 1);

            Assert.That(result, Is.EqualTo(9534.8));
        }    

        [Test]
        public void TestRoundRoundsToSecondDecimalPlaceUp()
        {
            double toRound = 9534.749;

            double result = FastMath.Round(toRound, 2);

            Assert.That(result, Is.EqualTo(9534.75));
        } 

        [Test]
        public void TestRoundRoundsToThirdDecimalPlaceUp()
        {
            double toRound = 9534.1527;

            double result = FastMath.Round(toRound, 3);

            Assert.That(result, Is.EqualTo(9534.153));
        }    

        [Test]
        public void TestRoundRoundsToFirstDecimalPlaceDown()
        {
            double toRound = 9534.749;

            double result = FastMath.Round(toRound, 1);

            Assert.That(result, Is.EqualTo(9534.7));
        }    

        [Test]
        public void TestRoundRoundsToSecondDecimalPlaceDown()
        {
            double toRound = 9534.741;

            double result = FastMath.Round(toRound, 2);

            Assert.That(result, Is.EqualTo(9534.74));
        } 

        [Test]
        public void TestRoundRoundsToThirdDecimalPlaceDown()
        {
            double toRound = 9534.1523;

            double result = FastMath.Round(toRound, 3);

            Assert.That(result, Is.EqualTo(9534.152));
        }                             
    }
}