using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class RealTechnicalFactory : TechnicalFactory
    {
        public override XmlFiles CreateXmlFiles()
        {
            return new XmlFilesImpl();
        }

        public override IAnimatedCharactersRenderer GetAnimatedCharactersRendererInstance()
        {
            return new AnimatedCharactersRendererDelayedInitializationProxy(AnimatedCharactersRendererImpl.GetInstance());
        }
    }
}