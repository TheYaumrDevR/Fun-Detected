using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class XmlFilesImpl : XmlFiles
    {
        public XmlElement TryToLoadXmlRoot(string fileNameWithDirectory)
        {
            if (File.Exists(Application.dataPath + fileNameWithDirectory))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Application.dataPath + fileNameWithDirectory);

                return xmlDocument.DocumentElement;
            }
            else
            {
                throw new AssetLoadFailureException();
            }
        }
    }
}