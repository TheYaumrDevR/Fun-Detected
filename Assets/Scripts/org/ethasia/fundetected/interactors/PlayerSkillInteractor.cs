using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerSkillInteractor
    {
        public void ExecutePrimaryPlayerAction()
        {
            Area activeArea = Area.ActiveArea;
            Enemy enemyHit = activeArea.GetEnemyHit();

            if (null != enemyHit)
            {
                IBattleLogPrinter battleLogPrinter = IoAdaptersFactoryForInteractors.GetInstance().GetBattleLogPrinterInstance();  

                IBattleActionResult battleLogAction = activeArea.Player.AutoAttack(enemyHit);
                battleLogPrinter.PrintBattleLogEntry(battleLogAction);

                if (battleLogAction.AttackWasExecuted())
                {
                    PlayerAnimationPresenter.StartRightArmSwingAnimation();
                }
            }
        }

        public bool PlayerCharacterIsExecutingAction()
        {
            Area activeArea = Area.ActiveArea;
            return activeArea.Player.IsAttacking();
        }
    }
}