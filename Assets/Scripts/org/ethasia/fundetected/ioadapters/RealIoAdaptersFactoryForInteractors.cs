using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{

    public class RealIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        private CharacterClassMasterdataProvider characterClassMasterdataProvider;
        private MeleeHitArcMasterDataProvider meleeHitArcMasterDataProvider;
        private PlayerBoundingBoxMasterDataProvider playerBoundingBoxMasterDataProvider;
        private EnemyMasterDataProvider enemyMasterDataProvider;
        private BattleLogPrinter battleLogPrinter;
        private PlayerMovementControllerImpl playerMovementController;
        private IMapPropertiesGateway mapPropertiesGateway;
        private IEnemyPresenter enemyPresenter;
        private IPlayerCharacterPresenter playerCharacterPresenter;
        private IResourceBarPresenter resourceBarPresenter;

        public override ICharacterClassMasterDataProvider GetCharacterClassMasterDataProviderInstance()
        {
            if (null == characterClassMasterdataProvider)
            {
                characterClassMasterdataProvider = new CharacterClassMasterdataProvider();
            }

            return characterClassMasterdataProvider;
        }

        public override IMeleeHitArcMasterDataProvider GetMeleeHitArcMasterDataProviderInstance()
        {
            if (null == meleeHitArcMasterDataProvider)
            {
                meleeHitArcMasterDataProvider = new MeleeHitArcMasterDataProvider();
            }

            return meleeHitArcMasterDataProvider;
        }

        public override IPlayerBoundingBoxMasterDataProvider GetPlayerBoundingBoxMasterDataProviderInstance()
        {
            if (null == playerBoundingBoxMasterDataProvider)
            {
                playerBoundingBoxMasterDataProvider = new PlayerBoundingBoxMasterDataProvider();
            }

            return playerBoundingBoxMasterDataProvider;
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

        public ICharacterTranslator GetCharacterTranslatorInstance()
        {
            if (null == playerMovementController)
            {
                playerMovementController = PlayerMovementControllerImpl.GetInstance();
            }

            return playerMovementController;
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

        public override IPlayerCharacterPresenter GetPlayerCharacterPresenterInstance()
        {
            if (null == playerCharacterPresenter)
            {
                playerCharacterPresenter = new RealPlayerCharacterPresenter();
            }

            return playerCharacterPresenter;
        }

        public override IResourceBarPresenter GetResourceBarPresenterInstance()
        {
            if (null == resourceBarPresenter)
            {
                resourceBarPresenter = new ResourceBarPresenter();
            }

            return resourceBarPresenter;
        }
    }
}