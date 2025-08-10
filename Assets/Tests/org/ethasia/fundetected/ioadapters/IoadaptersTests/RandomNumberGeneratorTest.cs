using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Ioadapters.Tests
{
    public class RandomNumberGeneratorTest
    {
        [Test]
        public void TestGenerateIntegerBetweenAndWithStepGeneratesAllPossibleNumbers()
        {
            RandomNumberGeneratorWithFixedSeed testCandidate = new RandomNumberGeneratorWithFixedSeed();

            int result = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result2 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result3 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result4 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result5 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result6 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result7 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result8 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result9 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result10 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result11 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result12 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result13 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result14 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);
            int result15 = testCandidate.GenerateIntegerBetweenAndWithStep(10, 20, 2);

            Assert.That(result, Is.EqualTo(18));
            Assert.That(result2, Is.EqualTo(18));
            Assert.That(result3, Is.EqualTo(14));
            Assert.That(result4, Is.EqualTo(10));
            Assert.That(result5, Is.EqualTo(14));
            Assert.That(result6, Is.EqualTo(14));
            Assert.That(result7, Is.EqualTo(10));
            Assert.That(result8, Is.EqualTo(14));
            Assert.That(result9, Is.EqualTo(14));
            Assert.That(result10, Is.EqualTo(12));
            Assert.That(result11, Is.EqualTo(12));
            Assert.That(result12, Is.EqualTo(16));
            Assert.That(result13, Is.EqualTo(20));
            Assert.That(result14, Is.EqualTo(16));
            Assert.That(result15, Is.EqualTo(20));
        }

        private class RandomNumberGeneratorWithFixedSeed : RandomNumberGenerator
        {
            protected override int GenerateRandomSeed()
            {
                return 1;
            }
        }
    }
}