using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Animation
{
    public class Animation2dGraphPropertiesGatewayCacheProxy : Animation2dGraphPropertiesGateway
    {
        private Animation2dGraphPropertiesGateway realGateway;
        private Dictionary<string, Animation2dGraphNodeProperties> cache;

        public Animation2dGraphPropertiesGatewayCacheProxy()
        {
            realGateway = new Animation2dGraphPropertiesGatewayImpl();
            cache = new Dictionary<string, Animation2dGraphNodeProperties>();
        }

        public Animation2dGraphNodeProperties LoadAnimation2dGraph(string animationGraphName)
        {
            if (cache.ContainsKey(animationGraphName))
            {
                return cache[animationGraphName];
            }

            cache[animationGraphName] = realGateway.LoadAnimation2dGraph(animationGraphName);
            return cache[animationGraphName];
        }        
    }
}