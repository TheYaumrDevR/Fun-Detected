namespace Org.Ethasia.Fundetected.Interactors
{

    public abstract class IoAdaptersFactory
    {
        private static IoAdaptersFactory instance;

        public static void SetInstance(IoAdaptersFactory value)
        {
            instance = value;
        }

        public static IoAdaptersFactory GetInstance()
        {
            return instance;
        }        

        public abstract ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance();
    }
}