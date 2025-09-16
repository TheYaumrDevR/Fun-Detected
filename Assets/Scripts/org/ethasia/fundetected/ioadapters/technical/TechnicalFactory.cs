namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public abstract class TechnicalFactory
    {
        private static TechnicalFactory instance;

        public static void SetInstance(TechnicalFactory value)
        {
            instance = value;
        }

        public static TechnicalFactory GetInstance()
        {
            return instance;
        }

        public abstract XmlFiles CreateXmlFiles();
        public abstract IAnimatedCharactersInitializer GetEnemyInitializerInstance();
        public abstract IAnimatedCharactersInitializer GetPlayerCharacterInitializerInstance();
        public abstract IFloatingDamageTextRenderer GetFloatingDamageTextRendererInstance();
        public abstract IHitboxDebugShapeRenderer GetHitboxDebugShapeRendererInstance();
        public abstract ISoundPlayer GetSoundPlayerInstance();
        public abstract IResourceBarRenderer GetResourceBarRendererInstance();
        public abstract ITileMapRenderer GetTileMapRendererInstance();
        public abstract IPortalRenderer GetPortalRendererInstance();
        public abstract IInteractablesRenderer GetInteractablesRendererInstance();
        public abstract IGuiWindowsController GetGuiWindowsControllerInstance();
        public abstract IDroppableItemRenderer GetDroppableItemRendererInstance();
    }
}