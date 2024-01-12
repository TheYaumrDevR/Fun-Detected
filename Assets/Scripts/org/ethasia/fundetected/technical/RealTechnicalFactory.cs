using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class RealTechnicalFactory : TechnicalFactory
    {
        public override XmlFiles CreateXmlFiles()
        {
            return new XmlFilesImpl();
        }

        public override IEnemiesRenderer GetEnemiesRendererInstance()
        {
            return EnemiesRendererImpl.GetInstance();
        }
    }
}