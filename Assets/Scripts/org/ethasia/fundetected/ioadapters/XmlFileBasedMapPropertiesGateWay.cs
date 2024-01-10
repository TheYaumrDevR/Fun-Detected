using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFileBasedMapPropertiesGateWay : IMapPropertiesGateway
    {
        private XmlFiles xmlFiles;

        public XmlFileBasedMapPropertiesGateWay()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
        }

        public MapProperties LoadMapProperties(string mapName)
        {
            MapProperties result = new MapProperties.Builder().Build();

            XmlElement mapTileProperties = xmlFiles.TryToLoadXmlRoot("/Scenes/Maps/" + mapName + ".xml");

            if (null != mapTileProperties)
            {
                result = ConvertXmlToMapProperties(mapTileProperties);
                FillCollisionPropertiesFromXml(mapTileProperties, result);
                FillSpawnerPropertiesFromXml(mapTileProperties, result);
                FillSpawnableMonstersPropertiesFromXml(mapTileProperties, result);
            }
            else
            {
                throw new AssetLoadFailureException("XML root node for map properties " + mapName + " does not exist");
            }

            return result;
        }

        private MapProperties ConvertXmlToMapProperties(XmlElement mapTileProperties)
        {
            string widthText = mapTileProperties.GetAttribute("width");
            string heightText = mapTileProperties.GetAttribute("height");
            string lowestScreenXText = mapTileProperties.GetAttribute("lowestScreenX");
            string lowestScreenYText = mapTileProperties.GetAttribute("lowestScreenY");
            string maximumMonstersText = mapTileProperties.GetAttribute("maximumMonsters");

            if (int.TryParse(widthText, out int width))
            {
                if (int.TryParse(heightText, out int height))
                {
                    if (width > 0 && height > 0)
                    {
                        MapProperties.Builder propertiesBuilder = new MapProperties.Builder()
                            .SetWidth(width)
                            .SetHeight(height);
                        
                        if (int.TryParse(maximumMonstersText, out int maximumMonsters))
                        {
                            propertiesBuilder.SetMaximumMonsters(maximumMonsters);
                        }

                        if (int.TryParse(lowestScreenXText, out int lowestScreenX))
                        {
                            propertiesBuilder.SetLowestScreenX(lowestScreenX);
                        }

                        if (int.TryParse(lowestScreenYText, out int lowestScreenY))
                        {
                            propertiesBuilder.SetLowestScreenY(lowestScreenY);
                        }                                                  

                        return propertiesBuilder.Build();
                    }
                }
            }

            throw new AssetLoadFailureException("Map width or height are undefined or incorrectly defined");
        }  

        private void FillCollisionPropertiesFromXml(XmlElement mapTileProperties, MapProperties parent)
        {
            XmlElement collisionsParent = mapTileProperties["collisions"];

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
                                        parent.AddCollision(new Org.Ethasia.Fundetected.Interactors.Collision.Builder()
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

        private void FillSpawnerPropertiesFromXml(XmlElement xmlRoot, MapProperties parent)
        {
            XmlElement spawnersParent = xmlRoot["spawners"];

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
                            parent.Spawners.Add(spawner);
                        }
                    }                    
                }
            }            
        }

        private void FillSpawnableMonstersPropertiesFromXml(XmlElement xmlRoot, MapProperties parent)
        {
            XmlElement spawnableMonstersParent = xmlRoot["spawnedMonsters"];

            if (spawnableMonstersParent != null)
            {
                XmlNodeList spawnableMonsterElements = spawnableMonstersParent.GetElementsByTagName("monster");

                foreach (XmlElement spawnableMonsterElement in spawnableMonsterElements)
                {
                    string name = spawnableMonsterElement.GetAttribute("name");
                    string spawnChanceText = spawnableMonsterElement.GetAttribute("spawnChance");

                    if (int.TryParse(spawnChanceText, out int spawnChance))
                    {
                        SpawnableMonster spawnableMonster = new SpawnableMonster(name, spawnChance);
                        parent.SpawnableMonsters.Add(spawnableMonster);
                    }                    
                }
            }             
        }
    }
}