using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class PlayerLevelInformationInteractor : IPlayerLevelUpInteractor
    {
        public void NotifyPlayerLevelInformationChanged(IPlayerLevelUpInteractor.PlayerLevelContext context)
        {
            UpdateExperienceBar(context);

            if (context.HasLeveledUp)
            {
                PlayLevelUpSound();
            }
        }

        private void UpdateExperienceBar(IPlayerLevelUpInteractor.PlayerLevelContext context)
        {
            IExperienceBarPresenter experienceBarPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetExperienceBarPresenterInstance();

            experienceBarPresenter.PresentExperienceBar(new ExperienceBarPresentationContext
            {
                CurrentExperience = context.CurrentExperience,
                RequiredExperience = Formulas.GetExperiencePointsForNextLevel(context.CurrentLevel + 1),
                CurrentLevel = context.CurrentLevel
            });
        }

        private void PlayLevelUpSound()
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            soundPresenter.PlayLevelUpSound();
        }
    }
}