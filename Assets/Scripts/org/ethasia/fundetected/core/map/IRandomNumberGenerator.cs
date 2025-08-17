namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IRandomNumberGenerator
    {
        int GenerateIntegerBetweenAnd(int min, int max);
        int GenerateIntegerBetweenAndWithStep(int min, int max, int step);
        int GenerateRandomPositiveInteger(int max);
        bool CheckProbabilityIsHit(float probability);
        bool CheckProbabilityIsHit(double probability);
    }
}