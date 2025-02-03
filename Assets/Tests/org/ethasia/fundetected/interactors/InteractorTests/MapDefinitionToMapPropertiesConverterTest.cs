using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class MapDefinitionToMapPropertiesConverterTest
    {
        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsMaximumNumberOfMonsters()
        {
            MapDefinition mapDefinition = new MapDefinition(5, "Hill");

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.MaximumMonsters, Is.EqualTo(5));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesCalculatesLowestScreenValues()
        {
            MapDefinition mapDefinition = new MapDefinition(6, "Forest");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.LowestScreenX, Is.EqualTo(-160));
            Assert.That(result.LowestScreenY, Is.EqualTo(-160));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesCalculatesWidthAndHeight()
        {
            MapDefinition mapDefinition = new MapDefinition(7, "Lake");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);   

            Assert.That(result.Width, Is.EqualTo(320));
            Assert.That(result.Height, Is.EqualTo(240));                     
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPlayerSpawnToPosition()
        {
            MapDefinition mapDefinition = new MapDefinition(8, "Beach");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);   

            Assert.That(result.PlayerSpawnPosition.X, Is.EqualTo(-65));
            Assert.That(result.PlayerSpawnPosition.Y, Is.EqualTo(-114));                     
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPortals()
        {
            MapDefinition mapDefinition = new MapDefinition(9, "Canyon");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);   

            Assert.That(result.Portals.Count, Is.EqualTo(2));
            Assert.That(result.Portals[0].Position.X, Is.EqualTo(-144));
            Assert.That(result.Portals[0].Position.Y, Is.EqualTo(-88));
            Assert.That(result.Portals[0].Width, Is.EqualTo(75));
            Assert.That(result.Portals[0].Height, Is.EqualTo(120));  
            Assert.That(result.Portals[1].Position.X, Is.EqualTo(-35));
            Assert.That(result.Portals[1].Position.Y, Is.EqualTo(-100));
            Assert.That(result.Portals[1].Width, Is.EqualTo(100));
            Assert.That(result.Portals[1].Height, Is.EqualTo(150));                     
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPortalIds()
        {
            MapDefinition mapDefinition = new MapDefinition(9, "Mesa");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);    

            Assert.That(result.Portals[0].DestinationMapId, Is.EqualTo("Town"));
            Assert.That(result.Portals[0].DestinationPortalId, Is.EqualTo("westPortal"));         
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPortalSpawnTargetsForPlayers()
        {
            MapDefinition mapDefinition = new MapDefinition(9, "Caverns");
            CreateTestChunks(mapDefinition);        

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);  

            Assert.That(result.SpawnPositionsByChunkId.Count, Is.EqualTo(1));          
            Assert.That(result.SpawnPositionsByChunkId["westPortal"].X, Is.EqualTo(-100));
            Assert.That(result.SpawnPositionsByChunkId["westPortal"].Y, Is.EqualTo(-90));
        }

        private void CreateTestChunks(MapDefinition mapDefinition)
        {
            Chunk chunk2 = new Chunk(-1, -2);
            Chunk chunk3 = new Chunk(0, -2);
            Chunk chunk4 = new Chunk(1, -2);

            Chunk chunk5 = new Chunk(-2, -1);
            Chunk chunk6 = new Chunk(-1, -1);
            Chunk chunk7 = new Chunk(0, -1);
            Chunk chunk8 = new Chunk(1, -1);  

            Chunk chunk9 = new Chunk(-2, 0);
            Chunk chunk10 = new Chunk(-1, 0);
            Chunk chunk11 = new Chunk(0, 0);
            Chunk chunk12 = new Chunk(1, 0); 

            PortalProperties portalPropertiesChunk1 = new PortalProperties(16, 72);
            portalPropertiesChunk1.Width = 75;
            portalPropertiesChunk1.Height = 120;            

            MapChunkProperties chunkProperties1 = new MapChunkProperties.Builder()
                .SetId("EarthGrassRisingHill")
                .SetPlayerSpawnPoint(new PlayerSpawn(60, 70))
                .SetPortalProperties(portalPropertiesChunk1)
                .Build(); 

            PortalProperties portalPropertiesChunk2 = new PortalProperties(45, 60);
            portalPropertiesChunk2.Width = 100;
            portalPropertiesChunk2.Height = 150;

            MapChunkProperties chunkProperties2 = new MapChunkProperties.Builder()
                .SetId("EarthGrassValley")
                .SetPlayerSpawnPoint(new PlayerSpawn(15, 46))
                .SetPortalProperties(portalPropertiesChunk2)
                .Build(); 

            chunk2.Spawn = true;
            chunk2.PropertiesOfPossibleChunks.Add(chunkProperties2);

            List<MapChunkProperties> propertiesOfPossibleChunks1 = new List<MapChunkProperties>();
            propertiesOfPossibleChunks1.Add(chunkProperties1);

            Chunk chunk1 = new Chunk.Builder()
                .SetId("westPortal")
                .SetX(-2)
                .SetY(-2)
                .SetPropertiesOfPossibleChunks(propertiesOfPossibleChunks1)
                .SetPortalTo(new PortalTo("Town", "westPortal"))
                .Build();

            mapDefinition.Chunks.Add(chunk1);
            mapDefinition.Chunks.Add(chunk2);
            mapDefinition.Chunks.Add(chunk3);       
            mapDefinition.Chunks.Add(chunk4);    

            mapDefinition.Chunks.Add(chunk5);    
            mapDefinition.Chunks.Add(chunk6);    
            mapDefinition.Chunks.Add(chunk7);
            mapDefinition.Chunks.Add(chunk8);        

            mapDefinition.Chunks.Add(chunk9);    
            mapDefinition.Chunks.Add(chunk10);    
            mapDefinition.Chunks.Add(chunk11);
            mapDefinition.Chunks.Add(chunk12);                                    
        }          
    }
}