using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class AnimatedCharactersRendererDelayedInitializationProxy : IAnimatedCharactersRenderer
    {
        private AnimatedCharactersRendererImpl proxiedRenderer;

        public AnimatedCharactersRendererDelayedInitializationProxy(AnimatedCharactersRendererImpl proxiedRenderer)
        {
            this.proxiedRenderer = proxiedRenderer;
        }

        public void RenderAnimatedCharacter(GameObjectProxy animatedCharacter)
        {
            if (null != proxiedRenderer)
            {
                proxiedRenderer.RenderAnimatedCharacter(animatedCharacter);
            }
            else
            {
                AnimatedCharactersRendererImpl.AddGameObjectToStartupRenderQueue(animatedCharacter);
            }
        }
    }
}