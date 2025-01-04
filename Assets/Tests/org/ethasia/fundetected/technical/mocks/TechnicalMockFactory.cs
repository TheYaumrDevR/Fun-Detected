using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class TechnicalMockFactory : TechnicalFactory
    {
        public override XmlFiles CreateXmlFiles()
        {
            return new XmlFilesMock();
        }

        public override IAnimatedCharactersInitializer GetEnemyInitializerInstance()
        {
            return null;
        }

        public override IAnimatedCharactersInitializer GetPlayerCharacterInitializerInstance()
        {
            return null;
        }      

        public override IFloatingDamageTextRenderer GetFloatingDamageTextRendererInstance()
        {
            return null;
        }  

        public override IHitboxDebugShapeRenderer GetHitboxDebugShapeRendererInstance()
        {
            return null;
        }

        public override ISoundPlayer GetSoundPlayerInstance()
        {
            return null;
        }

        public override IResourceBarRenderer GetResourceBarRendererInstance()
        {
            return null;
        }

        public override ITileMapRenderer GetTileMapRendererInstance()
        {
            return new TileMapRendererMock();
        }

        public override IPortalRenderer GetPortalRendererInstance()
        {
            return null;
        }
    }
}