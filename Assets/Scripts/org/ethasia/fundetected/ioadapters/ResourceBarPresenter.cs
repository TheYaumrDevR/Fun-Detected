using Org.Ethasia.Fundetected.Interactors;
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
            }
        }
    }
}