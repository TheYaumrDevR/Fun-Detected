namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct ExperienceBarPresentationContext
    {
        public int CurrentExperience;
        public int RequiredExperience;
        public int CurrentLevel;
    }

    public interface IExperienceBarPresenter
    {
        void PresentExperienceBar(ExperienceBarPresentationContext context);
    }
}