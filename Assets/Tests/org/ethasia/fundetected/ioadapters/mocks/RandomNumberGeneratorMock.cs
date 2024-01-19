using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{

    public class RandomNumberGeneratorMock : IRandomNumberGenerator
    {

        private int[] toBeGeneratedRandomNumbers;
        private float[] toBeGeneratedRandomFloats;
        private int randomNumberIndex;
        private int nextFloatNumberIndex;

        public RandomNumberGeneratorMock(int[] randomNumbersToGenerate, float[] randomFloatsToGenerate)
        {
            toBeGeneratedRandomNumbers = randomNumbersToGenerate;
            toBeGeneratedRandomFloats = randomFloatsToGenerate;
        }

        public int GenerateIntegerBetweenAnd(int min, int max)
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

        public void Reset()
        {
            randomNumberIndex = 0;
            nextFloatNumberIndex = 0;
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
    }
}