namespace Org.Ethasia.Fundetected.Interactors
{

    public abstract class IoAdaptersFactoryForInteractors
    {
        private static IoAdaptersFactoryForInteractors instance;

        public static void SetInstance(IoAdaptersFactoryForInteractors value)
        {
            instance = value;
        }

        public static IoAdaptersFactoryForInteractors GetInstance()
        {
            return instance;
        }        

        public abstract ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance();
        public abstract IEnemyMasterDataProvider GetEnemyMasterDataProviderInstance();
    }
}