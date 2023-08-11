using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealIoAdaptersFactoryForCore : IoAdaptersFactoryForCore
    {
        private RandomNumberGenerator randomNumberGenerator;

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            if (null == randomNumberGenerator)
            {
                randomNumberGenerator = new RandomNumberGenerator();
            }

            return randomNumberGenerator;
        }        
    }
}