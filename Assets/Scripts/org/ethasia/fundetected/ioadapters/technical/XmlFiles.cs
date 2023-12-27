using System.Xml;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface XmlFiles
    {
        XmlElement TryToLoadXmlRoot(string fileNameWithDirectory);
    }
}