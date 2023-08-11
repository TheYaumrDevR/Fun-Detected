namespace Org.Ethasia.Fundetected.Core
{
    public interface IRandomNumberGenerator
    {
        int GenerateIntegerBetweenAnd(int min, int max);
        int GenerateRandomPositiveInteger(int max);
    }
}