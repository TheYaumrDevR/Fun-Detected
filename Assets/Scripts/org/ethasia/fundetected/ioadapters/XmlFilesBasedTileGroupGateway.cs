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

        public void ConvertTileGroupRefs(XmlElement tilesRoot, List<ITile> target)
        {
            XmlNodeList tileGroupRefList = tilesRoot.GetElementsByTagName("tileGroupRef");

            foreach (XmlElement tileGroupRefDefinition in tileGroupRefList)
            {
                string groupId = tileGroupRefDefinition.GetAttribute("groupId");
                string startXText = tileGroupRefDefinition.GetAttribute("startX");
                string startYText = tileGroupRefDefinition.GetAttribute("startY");

                if (int.TryParse(startXText, out int startX))
                {
                    if (int.TryParse(startYText, out int startY))
                    {
                        target.AddRange(ResolveTileGroup(groupId, startX, startY));
                    }
                }
            }
        }

        private List<ITile> ResolveTileGroup(string groupId, int startX, int startY)
        {
            List<ITile> result = new List<ITile>();
            List<TileGroupTileDefinition> tileGroupDefinition = LoadTileGroup(groupId);

            foreach (TileGroupTileDefinition tileDefinition in tileGroupDefinition)
            {
                Tile convertedTile = new Tile.Builder()
                    .SetId(tileDefinition.Id)
                    .SetStartX(startX + tileDefinition.OffsetX)
                    .SetStartY(startY + tileDefinition.OffsetY)
                    .SetWidth(tileDefinition.Width)
                    .SetHeight(tileDefinition.Height)
                    .Build();

                result.Add(convertedTile);
            }

            return result;
        }        

        private List<TileGroupTileDefinition> LoadTileGroup(string groupId)
        {
            if (loadedTileGroupsByGroupId.ContainsKey(groupId))
            {
                return loadedTileGroupsByGroupId[groupId];
            }

            List<TileGroupTileDefinition> result = new List<TileGroupTileDefinition>();
            XmlElement tileGroupRoot = xmlFiles.TryToLoadXmlRoot("/Scenes/Tilemaps/TileGroups/" + groupId + ".xml");

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

            loadedTileGroupsByGroupId[groupId] = result;

            return result;
        }
    }
}
