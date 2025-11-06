using Org.Ethasia.Fundetected.Core.Map;

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
        public abstract IMeleeHitArcMasterDataProvider GetMeleeHitArcMasterDataProviderInstance();
        public abstract IPlayerBoundingBoxMasterDataProvider GetPlayerBoundingBoxMasterDataProviderInstance();
        public abstract IEnemyMasterDataProvider GetEnemyMasterDataProviderInstance();
        public abstract IBattleLogPrinter GetBattleLogPrinterInstance();
        public abstract IPlayerMovementController GetPlayerMovementControllerInstance();
        public abstract IEnemyPresenter GetEnemyPresenterInstance();
        public abstract IPlayerCharacterPresenter GetPlayerCharacterPresenterInstance();
        public abstract IResourceBarPresenter GetResourceBarPresenterInstance();
        public abstract IMapChunkGateway GetMapChunkGatewayInstance();
        public abstract IMapDefinitionGateway GetMapDefinitionGatewayInstance();
        public abstract IMapPresenter GetMapPresenterInstance();
        public abstract IPlayerInputOnOffSwitch GetPlayerInputOnOffSwitchInstance();
        public abstract IGuiWindowsPresenter GetGuiWindowsPresenterInstance();
        public abstract IDroppedItemPresenter GetDroppedItemPresenterInstance();
    }
}