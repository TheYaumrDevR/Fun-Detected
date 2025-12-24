using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Combat;
using Org.Ethasia.Fundetected.Interactors.Initialization;
using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

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

        public override IMapDefinitionGateway GetMapDefinitionGatewayInstance()
        {
            return new MapDefinitionGatewayMock();
        }

        public override IMapPresenter GetMapPresenterInstance()
        {
            return new MapPresenterMock();
        }  

        public override IPlayerInputOnOffSwitch GetPlayerInputOnOffSwitchInstance()
        {
            return new PlayerInputOnOffSwitchMock();
        }

        public override IGuiWindowsPresenter GetGuiWindowsPresenterInstance()
        {
            return new GuiWindowsPresenterMock();
        }
        
        public override IDroppedItemPresenter GetDroppedItemPresenterInstance()
        {
            return new DroppedItemPresenterMock();
        }
    }
}