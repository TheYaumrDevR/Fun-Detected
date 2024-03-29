using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{

    public class RealIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        private CharacterClassMasterdataProvider characterClassMasterdataProvider;
        private EnemyMasterDataProvider enemyMasterDataProvider;
        private BattleLogPrinter battleLogPrinter;
        private IPlayerMovementController playerMovementController;
        private IMapPropertiesGateway mapPropertiesGateway;
        private IEnemyPresenter enemyPresenter;

        public override ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance()
        {
            if (null == characterClassMasterdataProvider)
            {
                characterClassMasterdataProvider = new CharacterClassMasterdataProvider();
            }

            return characterClassMasterdataProvider;
        }

        public override IEnemyMasterDataProvider GetEnemyMasterDataProviderInstance()
        {
            if (null == enemyMasterDataProvider)
            {
                enemyMasterDataProvider = new EnemyMasterDataProvider();
            }

            return enemyMasterDataProvider;
        }

        public override IBattleLogPrinter GetBattleLogPrinterInstance()
        {
            if (null == battleLogPrinter)
            {
                battleLogPrinter = new BattleLogPrinter();
            }

            return battleLogPrinter;
        }

        public override IPlayerMovementController GetPlayerMovementControllerInstance()
        {
            if (null == playerMovementController)
            {
                playerMovementController = PlayerMovementControllerImpl.GetInstance();
            }

            return playerMovementController;
        }

        public override PlayerAnimationPresenter GetPlayerAnimationPresenterInstance()
        {
            return PlayerAnimationPresenterImpl.GetInstance();
        }   

        public override IMapPropertiesGateway GetMapPropertiesGatewayInstance()
        {
            if (null == mapPropertiesGateway)
            {
                mapPropertiesGateway = new XmlFileBasedMapPropertiesGateWay();
            }

            return mapPropertiesGateway;
        }

        public override IEnemyPresenter GetEnemyPresenterInstance()
        {
            if (null == enemyPresenter)
            {
                enemyPresenter = new RealEnemiesPresenter();
            }

            return enemyPresenter;
        }
    }
}