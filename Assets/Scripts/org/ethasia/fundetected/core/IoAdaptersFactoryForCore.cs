namespace Org.Ethasia.Fundetected.Core
{

    public abstract class IoAdaptersFactoryForCore
    {
        private static IoAdaptersFactoryForCore instance;

        public static void SetInstance(IoAdaptersFactoryForCore value)
        {
            instance = value;
        }

        public static IoAdaptersFactoryForCore GetInstance()
        {
            return instance;
        } 

        public abstract IRandomNumberGenerator GetRandomNumberGeneratorInstance();
    }
}
