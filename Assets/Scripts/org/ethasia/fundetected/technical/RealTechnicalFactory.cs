using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class RealTechnicalFactory : TechnicalFactory
    {
        private PortalRendererDelayedInitializationProxy portalRenderer;
        private InteractablesRendererDelayedInitializationProxy interactablesRenderer;

        public override XmlFiles CreateXmlFiles()
        {
            return new XmlFilesImpl();
        }

        public override IAnimatedCharactersInitializer GetEnemyInitializerInstance()
        {
            return new EnemyRendererDelayedInitializationProxy(EnemyInitializerImpl.GetInstance());
        }

        public override IAnimatedCharactersInitializer GetPlayerCharacterInitializerInstance()
        {
            return new PlayerCharacterRendererDelayedInitializationProxy(PlayerCharacterInitializerImpl.GetInstance());
        }      

        public override IFloatingDamageTextRenderer GetFloatingDamageTextRendererInstance()
        {
            return FloatingDamageTextRendererImpl.GetInstance();
        }  

        public override IHitboxDebugShapeRenderer GetHitboxDebugShapeRendererInstance()
        {
            return HitboxDebugShapeRendererImpl.GetInstance();
        }

        public override ISoundPlayer GetSoundPlayerInstance()
        {
            return SoundPlayer.GetInstance();
        }

        public override IResourceBarRenderer GetResourceBarRendererInstance()
        {
            return ResourceBarRenderer.GetInstance();
        }

        public override ITileMapRenderer GetTileMapRendererInstance()
        {
            TileMapRenderer result = TileMapRenderer.GetInstance();

            if (null == result)
            {
                return TileMapRendererDelayedInitializationProxy.GetInstance();
            }

            return result;
        }

        public override IPortalRenderer GetPortalRendererInstance()
        {
            if (null == portalRenderer)
            {
                portalRenderer = new PortalRendererDelayedInitializationProxy();
            }

            return portalRenderer;
        }

        public override IInteractablesRenderer GetInteractablesRendererInstance()
        {
            if (null == interactablesRenderer)
            {
                interactablesRenderer = new InteractablesRendererDelayedInitializationProxy();
            }

            return interactablesRenderer;
        }

        public override IGuiWindowsController GetGuiWindowsControllerInstance()
        {
            return GuiWindowsController.GetInstance();
        }
    }
}