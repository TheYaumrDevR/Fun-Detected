using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public abstract class AbstractAnimationPresenter
    {
        private static Animation2dGraphPropertiesGateway animation2dPropertiesGateway;

        protected Animation2dGraphPropertiesGateway GetAnimation2dPropertiesGateway()
        {
            if (null != animation2dPropertiesGateway)
            {
                return animation2dPropertiesGateway;
            }

            animation2dPropertiesGateway = new Animation2dGraphPropertiesGatewayCacheProxy();
            return animation2dPropertiesGateway;
        }
    }
}