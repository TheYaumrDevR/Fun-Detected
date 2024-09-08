using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerSkillInteractor
    {
        private static InternalInteractorsFactory internalInteractorsFactory;

        public PlayerSkillInteractor()
        {
            internalInteractorsFactory = InternalInteractorsFactory.GetInstance();
        }

        public void ExecutePrimaryPlayerAction()
        {
            Area activeArea = Area.ActiveArea;
            IBattleLogPrinter battleLogPrinter = IoAdaptersFactoryForInteractors.GetInstance().GetBattleLogPrinterInstance();  
            PlayerCharacter playerCharacter = activeArea.Player;

            if (playerCharacter.CanAutoAttack())
            {
                IPlayerAnimationPresenter playerAnimationPresenter = internalInteractorsFactory.GetPlayerAnimationPresenterInstance();

                if (playerCharacter.FacingDirection == FacingDirection.RIGHT)
                {
                    playerAnimationPresenter.StartRightArmSwingAnimation();
                } else {
                    playerAnimationPresenter.StartLeftArmSwingAnimation();
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