using System;
using System.Collections.Generic;
using System.Xml;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class XmlFilesMock : XmlFiles
    {
        private Dictionary<string, Func<string>> xmlFileContentProvidersByFileName;

        public XmlFilesMock()
        {
            xmlFileContentProvidersByFileName = new Dictionary<string, Func<string>>();
            xmlFileContentProvidersByFileName.Add("/Scenes/Maps/Hill.xml", GetXmlFileContentForHill);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassLoweringPlateau.xml", GetXmlFileContentForEarthGrassLoweringPlateau);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassPlateau.xml", GetXmlFileContentForEarthGrassPlateau);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassRisingHill.xml", GetXmlFileContentForEarthGrassRisingHill);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassRisingPlateau.xml", GetXmlFileContentForEarthGrassRisingPlateau);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassValley.xml", GetXmlFileContentForEarthGrassValley);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/CorruptPlayerSpawnPortal.xml", GetXmlFileContentForCorruptPlayerSpawnPortal);
            xmlFileContentProvidersByFileName.Add("/Scenes/Tilemaps/EarthGrassLoweringHill.xml", GetXmlFileContentForEarthGrassLoweringHill);
        }

        public XmlElement TryToLoadXmlRoot(string fileNameWithDirectory)
        {
            if (xmlFileContentProvidersByFileName.ContainsKey(fileNameWithDirectory))
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlFileContentProvidersByFileName[fileNameWithDirectory]());
                return document.DocumentElement;
            }

            return null;
        }

        private string GetXmlFileContentForHill()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <mapDefinition maximumMonsters=""10"">
                        <chunks>
                            <chunk x=""-2"" y=""-1"" spawn=""true"">
                                <definitions>   
                                    <definition file=""EarthGrassValley""/>
                                </definitions>
                            </chunk>
                            <chunk x=""-1"" y=""-1"">
                                <definitions>
                                    <definition file=""EarthGrassRisingPlateau""/>
                                </definitions>
                            </chunk>
                            <chunk x=""0"" y=""-1"">
                                <definitions>
                                    <definition file=""EarthGrassPlateau""/>
                                    <definition file=""EarthGrassLoweringPlateau""/>
                                    <definition file=""EarthGrassRisingPlateau""/>
                                </definitions>
                            </chunk>    
                            <chunk x=""1"" y=""-1"" id=""eastPortal"">
                                <portalTo>
                                    <map id=""Town""/>
                                    <portal id=""westPortal""/>
                                </portalTo>
                                <definitions>
                                    <definition file=""EarthGrassRisingHill""/>
                                    <definition file=""EarthGrassLoweringHill""/>
                                </definitions>        
                            </chunk>   
                            <chunk x=""-2"" y=""0""/>
                            <chunk x=""-1"" y=""0""/>
                            <chunk x=""0"" y=""0""/>   
                            <chunk x=""1"" y=""0""/>              
                        </chunks>
                        <spawnedMonsters>
                            <monster name=""Animated Thornbush"" spawnChance=""1000""/>
                        </spawnedMonsters>    
                    </mapDefinition>";
        }

        private string GetXmlFileContentForEarthGrassLoweringPlateau()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""2"" height=""4""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""2"" startY=""0"" width=""5"" height=""3""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""7"" startY=""0"" width=""1"" height=""4""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""4"" width=""2"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""2"" startY=""3"" width=""5"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""7"" startY=""4"" width=""1"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <collisions>
                                <collision startX=""0"" startY=""46"" width=""20"" height=""1""/>   
                                <collision startX=""20"" startY=""36"" width=""50"" height=""1""/> 
                                <collision startX=""70"" startY=""46"" width=""10"" height=""1""/> 

                                <collision startX=""19"" startY=""37"" width=""1"" height=""9""/>  
                                <collision startX=""70"" startY=""37"" width=""1"" height=""9""/>    
                            </collisions>

                            <spawners>
                                <spawner x=""5"" y=""48""/>
                                <spawner x=""15"" y=""48""/>
                                <spawner x=""25"" y=""38""/>
                                <spawner x=""35"" y=""38""/>
                                <spawner x=""45"" y=""38""/>
                                <spawner x=""55"" y=""38""/>
                                <spawner x=""65"" y=""38""/>
                                <spawner x=""75"" y=""48""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }

        private string GetXmlFileContentForEarthGrassPlateau()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""8"" height=""4""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""4"" width=""8"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <collisions>
                                <collision startX=""0"" startY=""46"" width=""80"" height=""1""/>     
                            </collisions>

                            <spawners>
                                <spawner x=""5"" y=""48""/>
                                <spawner x=""15"" y=""48""/>
                                <spawner x=""25"" y=""48""/>
                                <spawner x=""35"" y=""48""/>
                                <spawner x=""45"" y=""48""/>
                                <spawner x=""55"" y=""48""/>
                                <spawner x=""65"" y=""48""/>
                                <spawner x=""75"" y=""48""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }

        private string GetXmlFileContentForEarthGrassRisingHill()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""2"" height=""5""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""2"" startY=""0"" width=""1"" height=""6""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""3"" startY=""0"" width=""5"" height=""7""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""5"" width=""2"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""2"" startY=""6"" width=""1"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""3"" startY=""7"" width=""5"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <portal x=""74"" y=""77"" width=""100"" height=""150""/>

                            <collisions>
                                <collision startX=""0"" startY=""56"" width=""20"" height=""1""/>
                                <collision startX=""20"" startY=""66"" width=""10"" height=""1""/>
                                <collision startX=""30"" startY=""76"" width=""50"" height=""1""/>

                                <collision startX=""0"" startY=""47"" width=""1"" height=""9""/>
                                <collision startX=""20"" startY=""57"" width=""1"" height=""9""/>
                                <collision startX=""30"" startY=""67"" width=""1"" height=""9""/>
                            </collisions>

                            <spawners>
                                <spawner x=""5"" y=""58""/>
                                <spawner x=""15"" y=""58""/>

                                <spawner x=""25"" y=""68""/>

                                <spawner x=""35"" y=""78""/>
                                <spawner x=""45"" y=""78""/>
                                <spawner x=""55"" y=""78""/>
                                <spawner x=""65"" y=""78""/>
                                <spawner x=""75"" y=""78""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }

        private string GetXmlFileContentForEarthGrassRisingPlateau()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""1"" height=""3""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""1"" startY=""0"" width=""7"" height=""4""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""3"" width=""1"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""1"" startY=""4"" width=""7"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <collisions>
                                <collision startX=""0"" startY=""36"" width=""10"" height=""1""/>
                                <collision startX=""10"" startY=""46"" width=""70"" height=""1""/>

                                <collision startX=""0"" startY=""27"" width=""1"" height=""9""/>
                                <collision startX=""10"" startY=""37"" width=""1"" height=""9""/>            
                            </collisions>

                            <spawners>
                                <spawner x=""15"" y=""48""/>
                                <spawner x=""25"" y=""48""/>
                                <spawner x=""35"" y=""48""/>
                                <spawner x=""45"" y=""48""/>
                                <spawner x=""55"" y=""48""/>
                                <spawner x=""65"" y=""48""/>
                                <spawner x=""75"" y=""48""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }

        private string GetXmlFileContentForEarthGrassValley()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""4"" height=""4""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""4"" startY=""0"" width=""3"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""7"" startY=""0"" width=""1"" height=""2""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""2"" width=""4"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""4"" startY=""1"" width=""3"" height=""1""/>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""7"" startY=""2"" width=""1"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <playerSpawn x=""15"" y=""27""/>

                            <collisions>
                                <collision startX=""0"" startY=""26"" width=""40"" height=""1""/>
                                <collision startX=""40"" startY=""16"" width=""30"" height=""1""/>
                                <collision startX=""70"" startY=""26"" width=""10"" height=""1""/>

                                <collision startX=""39"" startY=""17"" width=""1"" height=""9""/>
                                <collision startX=""70"" startY=""17"" width=""1"" height=""9""/>
                            </collisions>

                            <spawners>
                                <spawner x=""5"" y=""28""/>
                                <spawner x=""15"" y=""28""/>
                                <spawner x=""25"" y=""28""/>
                                <spawner x=""35"" y=""28""/>

                                <spawner x=""45"" y=""18""/>
                                <spawner x=""55"" y=""18""/>
                                <spawner x=""65"" y=""18""/>

                                <spawner x=""75"" y=""28""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }

        private string GetXmlFileContentForCorruptPlayerSpawnPortal()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <tileChunk>
                        <tileMaps>
                            <terrain>
                                <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""4"" height=""4""/>
                            </terrain>
                            <ground>
                                <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""2"" width=""4"" height=""1""/>
                            </ground>
                        </tileMaps>

                        <mapTileProperties>
                            <playerSpawn y=""27""/>
                            <portal x=""15""/>

                            <collisions>
                                <collision startX=""0"" startY=""26"" width=""40"" height=""1""/>
                            </collisions>

                            <spawners>
                                <spawner x=""5"" y=""28""/>
                            </spawners>
                        </mapTileProperties>
                    </tileChunk>";
        }    

        private string GetXmlFileContentForEarthGrassLoweringHill()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <tileChunk>
                <tileMaps>
                    <terrain>
                        <tile id=""PlainsAndHillsTileset_Earth"" startX=""0"" startY=""0"" width=""2"" height=""5""/>
                        <tile id=""PlainsAndHillsTileset_Earth"" startX=""2"" startY=""0"" width=""3"" height=""4""/>
                        <tile id=""PlainsAndHillsTileset_Earth"" startX=""5"" startY=""0"" width=""3"" height=""3""/>
                    </terrain>
                    <ground>
                        <tile id=""PlainsAndHillsTileset_Grass"" startX=""0"" startY=""5"" width=""2"" height=""1""/>
                        <tile id=""PlainsAndHillsTileset_Grass"" startX=""2"" startY=""4"" width=""3"" height=""1""/>
                        <tile id=""PlainsAndHillsTileset_Grass"" startX=""5"" startY=""3"" width=""2"" height=""1""/>
                        <tile id=""PlainsAndHillsTileset_Pavement"" startX=""7"" startY=""3"" width=""1"" height=""1""/>
                    </ground>
                </tileMaps>

                <mapTileProperties>
                    <playerSpawn x=""64"" y=""37""/>
                    <portal x=""74"" y=""37""/>

                    <collisions>
                        <collision startX=""0"" startY=""56"" width=""20"" height=""1""/>
                        <collision startX=""20"" startY=""46"" width=""30"" height=""1""/>
                        <collision startX=""50"" startY=""36"" width=""30"" height=""1""/>

                        <collision startX=""19"" startY=""47"" width=""1"" height=""9""/>
                        <collision startX=""49"" startY=""37"" width=""1"" height=""9""/>
                    </collisions>

                    <spawners>
                        <spawner x=""5"" y=""66""/>
                        <spawner x=""15"" y=""66""/>

                        <spawner x=""25"" y=""56""/>
                        <spawner x=""35"" y=""56""/>
                        <spawner x=""45"" y=""56""/>

                        <spawner x=""55"" y=""46""/>
                        <spawner x=""65"" y=""46""/>
                    </spawners>
                </mapTileProperties>
            </tileChunk>";
        }    
    }
}