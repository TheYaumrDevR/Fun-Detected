using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
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

            int oldPlayerLevel = playerCharacter.BaseStats.LevelingSystem.Level;

            AsyncResponse<List<IBattleActionResult>> battleLogActions = playerCharacter.AutoAttack();
            battleLogActions.OnResponseReceived((battleLogActions) => 
            {
                int newPlayerLevel = playerCharacter.BaseStats.LevelingSystem.Level;
                
                foreach (IBattleActionResult battleLogAction in battleLogActions)
                {
                    battleLogPrinter.PrintBattleLogEntry(battleLogAction);  
                    battleLogAction.PresentToPlayer();             
                }

                if (newPlayerLevel > oldPlayerLevel)
                {
                    PlayLevelUpSound();
                    UpdateResourceBars(playerCharacter);
                }
            });
        }

        public bool PlayerCharacterIsExecutingAction()
        {
            Area activeArea = Area.ActiveArea;
            return activeArea.Player.IsAttacking();
        }

        private void PlayLevelUpSound()
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            soundPresenter.PlayLevelUpSound();
        }

        private void UpdateResourceBars(PlayerCharacter playerCharacter)
        {
            IResourceBarPresenter resourceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetResourceBarPresenterInstance();
            resourceBarPresenter.PresentHealthBarBasedOnCurrentAndMaximumHealth(playerCharacter.TotalStats.CurrentLife, playerCharacter.TotalStats.MaximumLife);
            resourceBarPresenter.PresentManaBarBasedOnCurrentAndMaximumMana(playerCharacter.TotalStats.CurrentMana, playerCharacter.TotalStats.MaximumMana);
        }
    }
}