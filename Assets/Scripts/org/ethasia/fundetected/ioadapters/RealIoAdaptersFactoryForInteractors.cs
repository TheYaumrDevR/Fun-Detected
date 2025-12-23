using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Interactors.Initialization;

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
        private IEnemyPresenter enemyPresenter;
        private IPlayerCharacterPresenter playerCharacterPresenter;
        private IResourceBarPresenter resourceBarPresenter;
        private IMapChunkGateway mapChunkGateway;
        private IMapDefinitionGateway mapDefinitionGateway;
        private IMapPresenter mapPresenter;
        private IPlayerInputOnOffSwitch playerInputOnOffSwitch;
        private IGuiWindowsPresenter guiWindowsPresenter;
        private IDroppedItemPresenter droppedItemPresenter;

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

        public override IMapChunkGateway GetMapChunkGatewayInstance()
        {
            if (null == mapChunkGateway)
            {
                mapChunkGateway = new XmlFilesBasedMapChunkGateway();
            }

            return mapChunkGateway;
        }

        public override IMapDefinitionGateway GetMapDefinitionGatewayInstance()
        {
            if (null == mapDefinitionGateway)
            {
                mapDefinitionGateway = new XmlFilesBasedMapDefinitionGateway();
            }

            return mapDefinitionGateway;
        }

        public override IMapPresenter GetMapPresenterInstance()
        {
            if (null == mapPresenter)
            {
                mapPresenter = new MapPresenterImpl();
            }

            return mapPresenter;
        }

        public override IPlayerInputOnOffSwitch GetPlayerInputOnOffSwitchInstance()
        {
            if (null == playerInputOnOffSwitch)
            {
                playerInputOnOffSwitch = PlayerInputHandler.GetInstance();
            }

            return playerInputOnOffSwitch;
        }

        public override IGuiWindowsPresenter GetGuiWindowsPresenterInstance()
        {
            if (null == guiWindowsPresenter)
            {
                guiWindowsPresenter = new GuiWindowsPresenter();
            }

            return guiWindowsPresenter;
        }

        public override IDroppedItemPresenter GetDroppedItemPresenterInstance()
        {
            if (null == droppedItemPresenter)
            {
                droppedItemPresenter = new DroppedItemPresenter();
            }

            return droppedItemPresenter;
        }
    }
}