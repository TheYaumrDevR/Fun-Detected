using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class RealTechnicalFactory : TechnicalFactory
    {
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
    }
}