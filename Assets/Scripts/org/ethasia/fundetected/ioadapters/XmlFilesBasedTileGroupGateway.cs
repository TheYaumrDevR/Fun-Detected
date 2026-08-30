using System.Collections.Generic;
using System.Xml;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFilesBasedTileGroupGateway : ITileGroupGateway
    {
        private XmlFiles xmlFiles;

        private Dictionary<string, List<TileGroupTileDefinition>> loadedTileGroupsByGroupId;

        public XmlFilesBasedTileGroupGateway()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
            loadedTileGroupsByGroupId = new Dictionary<string, List<TileGroupTileDefinition>>();
        }       

        public List<TileGroupTileDefinition> LoadTileGroup(string groupName)
        {
            if (loadedTileGroupsByGroupId.ContainsKey(groupName))
            {
                return loadedTileGroupsByGroupId[groupName];
            }

            List<TileGroupTileDefinition> result = new List<TileGroupTileDefinition>();
            XmlElement tileGroupRoot = xmlFiles.TryToLoadXmlRoot("/Scenes/Tilemaps/TileGroups/" + groupName + ".xml");

            if (null != tileGroupRoot)
            {
                XmlNodeList tileDefinitions = tileGroupRoot.GetElementsByTagName("tile");

                foreach (XmlElement tileDefinition in tileDefinitions)
                {
                    string id = tileDefinition.GetAttribute("id");
                    string offsetXText = tileDefinition.GetAttribute("offsetX");
                    string offsetYText = tileDefinition.GetAttribute("offsetY");
                    string widthText = tileDefinition.GetAttribute("width");
                    string heightText = tileDefinition.GetAttribute("height");

                    if (int.TryParse(offsetXText, out int offsetX))
                    {
                        if (int.TryParse(offsetYText, out int offsetY))
                        {
                            if (int.TryParse(widthText, out int width))
                            {
                                if (int.TryParse(heightText, out int height))
                                {
                                    if (width > 0 && height > 0)
                                    {
                                        result.Add(new TileGroupTileDefinition
                                        {
                                            Id = id,
                                            OffsetX = offsetX,
                                            OffsetY = offsetY,
                                            Width = width,
                                            Height = height
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            loadedTileGroupsByGroupId[groupName] = result;

            return result;
        }
    }
}
