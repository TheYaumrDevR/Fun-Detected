using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class RealTechnicalFactory : TechnicalFactory
    {
        public override XmlFiles CreateXmlFiles()
        {
            return new XmlFilesImpl();
        }

        public override IAnimatedCharactersRenderer GetEnemyRendererInstance()
        {
            return new EnemyRendererDelayedInitializationProxy(EnemyRendererImpl.GetInstance());
        }

        public override IAnimatedCharactersRenderer GetPlayerCharacterRendererInstance()
        {
            return new PlayerCharacterRendererDelayedInitializationProxy(PlayerCharacterRendererImpl.GetInstance());
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