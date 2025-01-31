using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PlayerCharacterRendererDelayedInitializationProxy : IAnimatedCharactersInitializer
    {
        private PlayerCharacterInitializerImpl proxiedRenderer;

        public PlayerCharacterRendererDelayedInitializationProxy(PlayerCharacterInitializerImpl proxiedRenderer)
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
                PlayerCharacterInitializerImpl.AddGameObjectToStartupRenderQueue(animatedCharacter);
            }
        }

        public void ClearAnimatedCharacters()
        {
            if (null != proxiedRenderer)
            {
                proxiedRenderer.ClearAnimatedCharacters();
            }            
        }
    }
}