using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerSkillInteractor
    {
        public void ExecutePrimaryPlayerAction(double actionTime)
        {
            Area activeArea = Area.ActiveArea;
            Enemy enemyHit = activeArea.GetEnemyHit();

            if (null != enemyHit)
            {
                IBattleLogPrinter battleLogPrinter = IoAdaptersFactoryForInteractors.GetInstance().GetBattleLogPrinterInstance();  

                PlayerAbilityActionResult battleLogAction = activeArea.Player.AutoAttack(actionTime, enemyHit);
                battleLogPrinter.PrintBattleLogEntry(battleLogAction);
            }
        }
    }
}