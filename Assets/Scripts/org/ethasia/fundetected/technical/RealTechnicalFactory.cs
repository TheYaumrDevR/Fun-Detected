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
    }
}