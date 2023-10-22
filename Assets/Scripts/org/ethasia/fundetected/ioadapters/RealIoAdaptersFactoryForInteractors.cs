using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{

    public class RealIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        private CharacterClassMasterdataProvider characterClassMasterdataProvider;
        private EnemyMasterDataProvider enemyMasterDataProvider;
        private BattleLogPrinter battleLogPrinter;
        private IPlayerMovementController playerMovementController;

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
    }
}