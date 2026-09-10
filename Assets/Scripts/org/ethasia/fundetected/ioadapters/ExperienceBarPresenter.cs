using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ExperienceBarPresenter : IExperienceBarPresenter
    {
        public void PresentExperienceBar(ExperienceBarPresentationContext context)
        {
            IExperienceBarRenderer experienceBarRenderer = TechnicalFactory.GetInstance().GetExperienceBarRendererInstance();

            if (null != experienceBarRenderer)
            {
                float experiencePercentage = (float)context.CurrentExperience / (float)context.RequiredExperience;
                experienceBarRenderer.FillExperienceBarBasedOnExperiencePercentage(experiencePercentage);
                experienceBarRenderer.UpdateLevelText(context.CurrentLevel);
            }
        }
    }
}