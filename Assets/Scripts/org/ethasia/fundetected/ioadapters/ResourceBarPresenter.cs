using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ResourceBarPresenter : IResourceBarPresenter
    {
        public void PresentHealthBarBasedOnCurrentAndMaximumHealth(int currentHealth, int maximumHealth)
        {
            IResourceBarRenderer resourceBarRenderer = TechnicalFactory.GetInstance().GetResourceBarRendererInstance();

            if (null != resourceBarRenderer)
            {
                float healthPercentage = (float)currentHealth / (float)maximumHealth;
                resourceBarRenderer.FillHealthBarBasedOnHealthPercentage(healthPercentage);
                resourceBarRenderer.UpdateHealthText(currentHealth, maximumHealth);
            }
        }

        public void PresentManaBarBasedOnCurrentAndMaximumMana(int currentMana, int maximumMana)
        {
            IResourceBarRenderer resourceBarRenderer = TechnicalFactory.GetInstance().GetResourceBarRendererInstance();

            if (null != resourceBarRenderer)
            {
                float manaPercentage = (float)currentMana / (float)maximumMana;
                resourceBarRenderer.FillManaBarBasedOnManaPercentage(manaPercentage);
                resourceBarRenderer.UpdateManaText(currentMana, maximumMana);
            }
        }
    }
}