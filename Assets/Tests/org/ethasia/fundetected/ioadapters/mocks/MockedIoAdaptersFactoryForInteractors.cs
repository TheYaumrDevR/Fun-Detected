using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MockedIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        public override ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance()
        {
            return new CharacterClassMasterDataProviderMock();       
        }

        public override IMeleeHitArcMasterDataProvider GetMeleeHitArcMasterDataProviderInstance()
        {
            return new MeleeHitArcMasterDataProviderMock();
        }

        public override IPlayerBoundingBoxMasterDataProvider GetPlayerBoundingBoxMasterDataProviderInstance()
        {
            return new PlayerBoundingBoxMasterDataProviderMock();
        }

        public override IEnemyMasterDataProvider GetEnemyMasterDataProviderInstance()
        {
            return new EnemyMasterDataProviderMock();
        }

        public override IBattleLogPrinter GetBattleLogPrinterInstance()
        {
            return new BattleLogPrinterMock();
        }

        public override IPlayerMovementController GetPlayerMovementControllerInstance()
        {
            return new PlayerMovementControllerMock();
        }               

        public override IMapPropertiesGateway GetMapPropertiesGatewayInstance()
        {
            return new MapPropertiesGatewayMock();
        }    

        public override IEnemyPresenter GetEnemyPresenterInstance()
        {
            return new EnemiesPresenterMock();
        }    

        public override IPlayerCharacterPresenter GetPlayerCharacterPresenterInstance()
        {
            return new PlayerCharacterPresenterMock();
        }

        public override IResourceBarPresenter GetResourceBarPresenterInstance()
        {
            return new ResourceBarPresenterMock();
        }

        public override IMapChunkGateway GetMapChunkGatewayInstance()
        {
            return new MapChunkGatewayMock();
        }
    }
}