using System.Xml;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class XmlFilesBasedMapDefinitionGateway
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
                MapDefinition result = SetupMapProperties(mapDefinitionProperties);
                SetupChunks(mapDefinitionProperties, result);
                SetupSpawnableMonsters(mapDefinitionProperties, result);

                return result;
            }
            else
            {
                throw new AssetLoadFailureException("XML root node for map properties " + mapName + " does not exist");
            }          
        }

        private MapDefinition SetupMapProperties(XmlElement mapDefinitionProperties)
        {
            string maximumMonstersText = mapDefinitionProperties.GetAttribute("maximumMonsters");

            if (int.TryParse(maximumMonstersText, out int maximumMonsters))
            {
                return new MapDefinition(maximumMonsters);
            }

            return new MapDefinition(0);
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

                    Chunk chunk;

                    if (int.TryParse(xText, out int x))
                    {
                        if (int.TryParse(yText, out int y))
                        {
                            chunk = new Chunk(x, y);
                        }
                        else
                        {
                            chunk = new Chunk(x, 0);
                        }
                    }         
                    else
                    {
                        chunk = new Chunk(0, 0);
                    }           

                    XmlElement chunkReferencesRoot = chunkDefinition["definitions"];

                    if (null != chunkReferencesRoot)
                    {
                        XmlNodeList chunkReferences = chunkReferencesRoot.GetElementsByTagName("definition");

                        foreach (XmlElement chunkReference in chunkReferences)
                        {
                            string chunkFileName = chunkReference.GetAttribute("file");
                            chunk.MapChunkIds.Add(chunkFileName);
                        }
                    }

                    result.Chunks.Add(chunk);
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