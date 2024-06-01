using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerSkillInteractor
    {
        public void ExecutePrimaryPlayerAction()
        {
            Area activeArea = Area.ActiveArea;
            IBattleLogPrinter battleLogPrinter = IoAdaptersFactoryForInteractors.GetInstance().GetBattleLogPrinterInstance();  
            PlayerCharacter playerCharacter = activeArea.Player;

            if (playerCharacter.CanAutoAttack())
            {
                if (playerCharacter.FacingDirection == FacingDirection.RIGHT)
                {
                    PlayerAnimationPresenter.StartRightArmSwingAnimation();
                } else {
                    PlayerAnimationPresenter.StartLeftArmSwingAnimation();
                }
            }

            AsyncResponse<List<IBattleActionResult>> battleLogActions = playerCharacter.AutoAttack();
            battleLogActions.OnResponseReceived((battleLogActions) => 
            {
                foreach (IBattleActionResult battleLogAction in battleLogActions)
                {
                    battleLogPrinter.PrintBattleLogEntry(battleLogAction);  
                    battleLogAction.PresentToPlayer();             
                }
            });
        }

        public bool PlayerCharacterIsExecutingAction()
        {
            Area activeArea = Area.ActiveArea;
            return activeArea.Player.IsAttacking();
        }
    }
}