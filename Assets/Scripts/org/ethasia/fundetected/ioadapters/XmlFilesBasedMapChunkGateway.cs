using System.Collections.Generic;
using System.Xml;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFilesBasedMapChunkGateway : IMapChunkGateway
    {
        private XmlFiles xmlFiles;

        public XmlFilesBasedMapChunkGateway()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
        }

        public MapChunkProperties LoadChunkProperties(string chunkName)
        {
            MapChunkProperties result = new MapChunkProperties(chunkName);

            XmlElement mapChunkProperties = xmlFiles.TryToLoadXmlRoot("/Scenes/Tilemaps/" + chunkName + ".xml");

            if (null != mapChunkProperties)
            {
                SetupTiles(mapChunkProperties, result);
                SetupTileProperties(mapChunkProperties, result);
            }
            else
            {
                throw new AssetLoadFailureException("XML root node for map chunk properties " + chunkName + " does not exist");
            }

            return result;
        }

        private void SetupTiles(XmlElement mapChunkProperties, MapChunkProperties result)
        {
            XmlElement tilesParent = mapChunkProperties["tileMaps"];

            if (null != tilesParent)
            {
                XmlElement groundTiles = tilesParent["ground"];
                XmlElement terrainTiles = tilesParent["terrain"];

                SetupGroundTiles(groundTiles, result);
                SetupTerrainTiles(terrainTiles, result);
            }
        }

        private void SetupGroundTiles(XmlElement groundTiles, MapChunkProperties result)
        {
            ConvertTiles(groundTiles, result.GroundTiles);
        }

        private void SetupTerrainTiles(XmlElement terrainTiles, MapChunkProperties result)
        {
            ConvertTiles(terrainTiles, result.TerrainTiles);
        }   

        private void ConvertTiles(XmlElement tilesRoot, List<Tile> target)
        {
            if (null != tilesRoot)
            {
                XmlNodeList tilesList = tilesRoot.GetElementsByTagName("tile");

                foreach (XmlElement tileDefinition in tilesList)
                {
                    string id = tileDefinition.GetAttribute("id");
                    string startXText = tileDefinition.GetAttribute("startX");
                    string startYText = tileDefinition.GetAttribute("startY");
                    string widthText = tileDefinition.GetAttribute("width");
                    string heightText = tileDefinition.GetAttribute("height");      

                    if (int.TryParse(startXText, out int startX))
                    {
                        if (int.TryParse(startYText, out int startY))
                        {
                            if (int.TryParse(widthText, out int width))
                            {
                                if (int.TryParse(heightText, out int height))
                                {
                                    if (width > 0 && height > 0)
                                    {
                                        Tile convertedTile = new Tile.Builder()
                                            .SetId(id)
                                            .SetStartX(startX)
                                            .SetStartY(startY)
                                            .SetWidth(width)
                                            .SetHeight(height)
                                            .Build();

                                        target.Add(convertedTile);
                                    }
                                }
                            }
                        }
                    }                                  
                }
            }
        }

        private void SetupTileProperties(XmlElement mapChunkProperties, MapChunkProperties result)
        {
            XmlElement tilePropertiesParent = mapChunkProperties["mapTileProperties"];

            if (null != tilePropertiesParent)
            {
                FillCollisionPropertiesFromXml(tilePropertiesParent, result);
                FillSpawnerPropertiesFromXml(tilePropertiesParent, result);   
            }         
        }

        private void FillCollisionPropertiesFromXml(XmlElement tilePropertiesParent, MapChunkProperties result)
        {
            XmlElement collisionsParent = tilePropertiesParent["collisions"];

            if (collisionsParent != null)
            {
                XmlNodeList collisions = collisionsParent.GetElementsByTagName("collision");

                foreach (XmlElement collision in collisions)
                {
                    string startXText = collision.GetAttribute("startX");
                    string startYText = collision.GetAttribute("startY");
                    string widthText = collision.GetAttribute("width");
                    string heightText = collision.GetAttribute("height");

                    if (int.TryParse(startXText, out int startX))
                    {
                        if (int.TryParse(startYText, out int startY))
                        {
                            if (int.TryParse(widthText, out int width))
                            {
                                if (int.TryParse(heightText, out int height))
                                {
                                    if (width > 0 && height > 0)
                                    {
                                        result.CollisionProperties.Add(new Collision.Builder()
                                            .SetStartX(startX)
                                            .SetStartY(startY)
                                            .SetWidth(width)
                                            .SetHeight(height)
                                            .Build());
                                    }
                                }
                            }
                        }
                    }                    
                }                
            }
        } 

        private void FillSpawnerPropertiesFromXml(XmlElement tilePropertiesParent, MapChunkProperties result)
        {
            XmlElement spawnersParent = tilePropertiesParent["spawners"];

            if (spawnersParent != null)
            {
                XmlNodeList spawnerElements = spawnersParent.GetElementsByTagName("spawner");

                foreach (XmlElement spawnerElement in spawnerElements)
                {
                    string xText = spawnerElement.GetAttribute("x");
                    string yText = spawnerElement.GetAttribute("y");

                    if (int.TryParse(xText, out int x))
                    {
                        if (int.TryParse(yText, out int y))
                        {
                            Spawner spawner = new Spawner(x, y);
                            result.Spawners.Add(spawner);
                        }
                    }                    
                }
            }
        }        
    }
}