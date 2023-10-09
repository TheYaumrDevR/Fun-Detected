using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{

    public class MockedIoAdaptersFactoryForCore : IoAdaptersFactoryForCore
    {
        private IRandomNumberGenerator rngInstance;

        public void SetRngInstance(IRandomNumberGenerator value)
        {
            rngInstance = value;
        }

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            if (null == rngInstance)
            {
                int[] randomNumbersToGenerate = {};
                float[] randomFloatsToGenerate = {};

                rngInstance = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            }

            return rngInstance;
        }
    }
}