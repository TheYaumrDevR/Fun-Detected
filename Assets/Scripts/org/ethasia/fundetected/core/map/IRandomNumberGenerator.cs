namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IRandomNumberGenerator
    {
        int GenerateIntegerBetweenAnd(int min, int max);
        int GenerateRandomPositiveInteger(int max);
        bool CheckProbabilityIsHit(float probability);
    }
}