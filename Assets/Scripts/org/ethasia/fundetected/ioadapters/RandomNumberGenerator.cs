using System;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public RandomNumberGenerator()
        {
            UnityEngine.Random.InitState(GenerateRandomSeed());
        }

        public int GenerateIntegerBetweenAnd(int min, int max)
        {
            float lowerBound = min + 0.0f;
            float upperBound = max + 1.0f;

            float randomNumber = UnityEngine.Random.Range(lowerBound, upperBound);

            if (max == randomNumber)
            {
                return GenerateIntegerBetweenAnd(min, max);
            }            

            return FastMath.Floor(randomNumber);
        }

        public int GenerateRandomPositiveInteger(int max)
        {
            float lowerBound = 0.0f;
            float upperBound = max + 1.0f;

            float randomNumber = UnityEngine.Random.Range(lowerBound, upperBound);

            if (max == randomNumber)
            {
                return GenerateRandomPositiveInteger(max);
            }

            return FastMath.Floor(randomNumber);
        }

        public bool CheckProbabilityIsHit(float probability)
        {
            float randomNumber = UnityEngine.Random.Range(0.0f, 1.0f);
    	    return randomNumber <= probability;
        }

        private int GenerateRandomSeed()
        {
            long currentDateTimeTicks = DateTime.Now.Ticks;
            int lowerTicksBits = (int)(currentDateTimeTicks & 0xffffffffL);
            int upperTicksBits = (int)(currentDateTimeTicks >> 32);

            System.Random rng = new System.Random(lowerTicksBits | upperTicksBits);

            return rng.Next();
        }
    }
}