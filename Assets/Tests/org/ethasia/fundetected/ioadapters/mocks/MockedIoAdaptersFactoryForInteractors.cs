using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MockedIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        public override ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance()
        {
            return new CharacterClassMasterDataProviderMock();       
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

        public override PlayerAnimationPresenter GetPlayerAnimationPresenterInstance()
        {
            return new PlayerAnimationPresenterMock();
        }             

        public override IMapPropertiesGateway GetMapPropertiesGatewayInstance()
        {
            return new MapPropertiesGatewayMock();
        }    

        public override IEnemyPresenter GetEnemyPresenterInstance()
        {
            return new EnemiesPresenterMock();
        }    
    }
}