using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PlayerCharacterRendererDelayedInitializationProxy : IAnimatedCharactersRenderer
    {
        private PlayerCharacterRendererImpl proxiedRenderer;

        public PlayerCharacterRendererDelayedInitializationProxy(PlayerCharacterRendererImpl proxiedRenderer)
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
                PlayerCharacterRendererImpl.AddGameObjectToStartupRenderQueue(animatedCharacter);
            }
        }
    }
}