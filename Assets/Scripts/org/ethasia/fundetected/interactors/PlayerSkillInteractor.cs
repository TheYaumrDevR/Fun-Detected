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

                PlayerCharacter playerCharacter = activeArea.Player;

                IBattleActionResult battleLogAction = playerCharacter.AutoAttack(enemyHit);
                battleLogPrinter.PrintBattleLogEntry(battleLogAction);

                if (battleLogAction.AttackWasExecuted())
                {
                    if (playerCharacter.FacingDirection == FacingDirection.RIGHT)
                    {
                        PlayerAnimationPresenter.StartRightArmSwingAnimation();
                    } else {
                        PlayerAnimationPresenter.StartLeftArmSwingAnimation();
                    }
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