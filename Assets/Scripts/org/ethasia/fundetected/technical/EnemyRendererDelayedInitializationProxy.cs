using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemyRendererDelayedInitializationProxy : IAnimatedCharactersRenderer
    {
        private EnemyRendererImpl proxiedRenderer;

        public EnemyRendererDelayedInitializationProxy(EnemyRendererImpl proxiedRenderer)
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
                EnemyRendererImpl.AddGameObjectToStartupRenderQueue(animatedCharacter);
            }
        }
    }
}