using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class MapDefinitionToMapPropertiesConverterTest
    {
        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsMaximumNumberOfMonsters()
        {
            MapDefinition mapDefinition = new MapDefinition(5);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.MaximumMonsters, Is.EqualTo(5));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesCalculatesLowestScreenValues()
        {
            MapDefinition mapDefinition = new MapDefinition(6);
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.LowestScreenX, Is.EqualTo(-160));
            Assert.That(result.LowestScreenY, Is.EqualTo(-160));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesCalculatesWidthAndHeight()
        {
            MapDefinition mapDefinition = new MapDefinition(7);
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);   

            Assert.That(result.Width, Is.EqualTo(320));
            Assert.That(result.Height, Is.EqualTo(240));                     
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPlayerSpawnToPosition()
        {
            MapDefinition mapDefinition = new MapDefinition(8);
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);   

            Assert.That(result.PlayerSpawnPosition.X, Is.EqualTo(-65));
            Assert.That(result.PlayerSpawnPosition.Y, Is.EqualTo(-114));                     
        }

        private void CreateTestChunks(MapDefinition mapDefinition)
        {
            Chunk chunk1 = new Chunk(-2, -2);
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

            MapChunkProperties chunkProperties2 = new MapChunkProperties("EarthGrassValley", new PlayerSpawn(15, 46));

            chunk2.Spawn = true;
            chunk2.PropertiesOfPossibleChunks.Add(chunkProperties2);

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