using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{

    public class RandomNumberGeneratorMock : IRandomNumberGenerator
    {

        private int[] toBeGeneratedRandomNumbers;
        private float[] toBeGeneratedRandomFloats;
        private double[] toBeGeneratedRandomDoubles;
        private int randomNumberIndex;
        private int nextFloatNumberIndex;
        private int nextDoubleNumberIndex;

        public RandomNumberGeneratorMock(int[] randomNumbersToGenerate, float[] randomFloatsToGenerate, double[] randomDoublesToGenerate)
        {
            toBeGeneratedRandomNumbers = randomNumbersToGenerate;
            toBeGeneratedRandomFloats = randomFloatsToGenerate;
            toBeGeneratedRandomDoubles = randomDoublesToGenerate;
        }

        public int GenerateIntegerBetweenAnd(int min, int max)
        {
            return GetNextGeneratedRandomNumber();
        }

        public int GenerateIntegerBetweenAndWithStep(int min, int max, int step)
        {
            return GetNextGeneratedRandomNumber();
        }

        public int GenerateRandomPositiveInteger(int max)
        {
            return GetNextGeneratedRandomNumber();
        }

        public bool CheckProbabilityIsHit(float probability)
        {
            float randomNumber = GetNextGeneratedRandomFloat();
            return randomNumber <= probability;
        }

        public bool CheckProbabilityIsHit(double probability)
        {
            double randomNumber = GetNextGeneratedRandomDouble();
            return randomNumber <= probability;
        }

        public void Reset()
        {
            randomNumberIndex = 0;
            nextFloatNumberIndex = 0;
            nextDoubleNumberIndex = 0;
        }

        private int GetNextGeneratedRandomNumber()
        {
            if (randomNumberIndex < toBeGeneratedRandomNumbers.Length)
            {
                int result = toBeGeneratedRandomNumbers[randomNumberIndex];
                randomNumberIndex++;

                return result;
            }

            return -1;
        }

        private float GetNextGeneratedRandomFloat()
        {
            if (nextFloatNumberIndex < toBeGeneratedRandomFloats.Length)
            {
                float result = toBeGeneratedRandomFloats[nextFloatNumberIndex];
                nextFloatNumberIndex++;

                return result;
            }

            return -1.0f;
        }

        private double GetNextGeneratedRandomDouble()
        {
            if (nextDoubleNumberIndex < toBeGeneratedRandomDoubles.Length)
            {
                double result = toBeGeneratedRandomDoubles[nextDoubleNumberIndex];
                nextDoubleNumberIndex++;

                return result;
            }

            return -1.0;
        }
    }
}