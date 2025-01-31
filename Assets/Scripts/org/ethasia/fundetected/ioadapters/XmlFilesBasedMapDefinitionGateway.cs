using System.Xml;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFilesBasedMapDefinitionGateway : IMapDefinitionGateway
    {
        private XmlFiles xmlFiles;

        public XmlFilesBasedMapDefinitionGateway()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
        }

        public MapDefinition LoadMapDefinition(string mapName)
        {
            XmlElement mapDefinitionProperties = xmlFiles.TryToLoadXmlRoot("/Scenes/Maps/" + mapName + ".xml");

            if (null != mapDefinitionProperties)
            {
                MapDefinition result = SetupMapProperties(mapDefinitionProperties, mapName);
                SetupChunks(mapDefinitionProperties, result);
                SetupSpawnableMonsters(mapDefinitionProperties, result);

                return result;
            }
            else
            {
                throw new AssetLoadFailureException("XML root node for map properties " + mapName + " does not exist");
            }          
        }

        private MapDefinition SetupMapProperties(XmlElement mapDefinitionProperties, string mapName)
        {
            string maximumMonstersText = mapDefinitionProperties.GetAttribute("maximumMonsters");

            if (int.TryParse(maximumMonstersText, out int maximumMonsters))
            {
                return new MapDefinition(maximumMonsters, mapName);
            }

            return new MapDefinition(0, mapName);
        }

        private void SetupChunks(XmlElement mapDefinitionProperties, MapDefinition result)
        {
            XmlElement chunksParent = mapDefinitionProperties["chunks"];

            if (null != chunksParent)
            {
                XmlNodeList chunkList = chunksParent.GetElementsByTagName("chunk");

                foreach (XmlElement chunkDefinition in chunkList)
                {
                    string xText = chunkDefinition.GetAttribute("x");
                    string yText = chunkDefinition.GetAttribute("y");
                    string spawnText = "false";                 

                    Chunk chunk;
                    Chunk.Builder chunkBuilder = new Chunk.Builder();

                    if (int.TryParse(xText, out int x))
                    {
                        if (int.TryParse(yText, out int y))
                        {
                            chunkBuilder.SetX(x).SetY(y);
                        }
                        else
                        {
                            chunkBuilder.SetX(x).SetY(0);
                        }
                    }         
                    else
                    {
                        chunkBuilder.SetX(0).SetY(0);
                    }       

                    if (chunkDefinition.HasAttribute("spawn"))
                    {
                        spawnText = chunkDefinition.GetAttribute("spawn");

                        if (bool.TryParse(spawnText, out bool spawnValue))
                        {
                            chunkBuilder.SetSpawn(spawnValue);
                        }
                    }   

                    SetupPortalToProperties(chunkDefinition, chunkBuilder);

                    chunk = chunkBuilder.Build();
                    SetupChunkProperties(chunkDefinition, chunk);

                    result.Chunks.Add(chunk);
                }                
            }            
        }

        private void SetupPortalToProperties(XmlElement chunkDefinition, Chunk.Builder chunkBuilder)
        {
            XmlElement portalToElement = chunkDefinition["portalTo"];

            if (null != portalToElement)
            {
                XmlElement portalToMapElement = portalToElement["map"];
                XmlElement portalToPortalElement = portalToElement["portal"];

                if (null != portalToMapElement && null != portalToPortalElement)
                {
                    string portalToMapName = portalToMapElement.GetAttribute("id");
                    string portalToPortalId = portalToPortalElement.GetAttribute("id");

                    chunkBuilder.SetPortalTo(new PortalTo(portalToMapName, portalToPortalId));
                }
            }
        }

        private void SetupChunkProperties(XmlElement chunkDefinition, Chunk chunk)
        {
            XmlElement chunkReferencesRoot = chunkDefinition["definitions"];

            if (null != chunkReferencesRoot)
            {
                XmlNodeList chunkReferences = chunkReferencesRoot.GetElementsByTagName("definition");
                IMapChunkGateway mapChunkGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapChunkGatewayInstance();

                foreach (XmlElement chunkReference in chunkReferences)
                {
                    string chunkFileName = chunkReference.GetAttribute("file");
                    MapChunkProperties mapChunkProperties = mapChunkGateway.LoadChunkProperties(chunkFileName);

                    chunk.PropertiesOfPossibleChunks.Add(mapChunkProperties);
                }
            }
        }        

        private void SetupSpawnableMonsters(XmlElement mapDefinitionProperties, MapDefinition result)
        {
            XmlElement spawnableMonstersParent = mapDefinitionProperties["spawnedMonsters"];

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
                        result.SpawnableMonsters.Add(spawnableMonster);
                    }                    
                }
            }
        }
    }
}