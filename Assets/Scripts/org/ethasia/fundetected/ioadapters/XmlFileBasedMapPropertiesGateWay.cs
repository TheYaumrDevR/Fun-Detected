using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFileBasedMapPropertiesGateWay : IMapPropertiesGateway
    {
        public MapProperties LoadMapProperties(string mapName)
        {
            MapProperties result = new MapProperties(0, 0);

            if (File.Exists(Application.dataPath + "/Scenes/Maps/" + mapName + ".xml"))
            {
                XmlDocument mapPropertiesXml = new XmlDocument();
                mapPropertiesXml.Load(Application.dataPath + "/Scenes/Maps/" + mapName + ".xml");

                XmlElement mapTileProperties = mapPropertiesXml.DocumentElement;

                if (null != mapTileProperties)
                {
                    result = ConvertXmlToMapProperties(mapTileProperties);
                    FillCollisionPropertiesFromXml(mapTileProperties, result);
                }
                else
                {
                    throw new AssetLoadFailureException();
                }
            }
            else
            {
                throw new AssetLoadFailureException();
            }

            return result;
        }

        private MapProperties ConvertXmlToMapProperties(XmlElement mapTileProperties)
        {
            string widthText = mapTileProperties.GetAttribute("width");
            string heightText = mapTileProperties.GetAttribute("height");

            if (int.TryParse(widthText, out int width))
            {
                if (int.TryParse(heightText, out int height))
                {
                    if (width > 0 && height > 0)
                    {
                        return new MapProperties(width, height);
                    }
                }
            }

            throw new AssetLoadFailureException();
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
    }
}