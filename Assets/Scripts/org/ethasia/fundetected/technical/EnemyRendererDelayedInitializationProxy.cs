using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemyRendererDelayedInitializationProxy : IAnimatedCharactersInitializer
    {
        private EnemyInitializerImpl proxiedRenderer;

        public EnemyRendererDelayedInitializationProxy(EnemyInitializerImpl proxiedRenderer)
        {
            this.proxiedRenderer = proxiedRenderer;
        }

        public void InitializeAnimatedCharacter(GameObjectProxy animatedCharacter)
        {
            if (null != proxiedRenderer)
            {
                proxiedRenderer.InitializeAnimatedCharacter(animatedCharacter);
            }
            else
            {
                EnemyInitializerImpl.AddGameObjectToStartupRenderQueue(animatedCharacter);
            }
        }
    }
}