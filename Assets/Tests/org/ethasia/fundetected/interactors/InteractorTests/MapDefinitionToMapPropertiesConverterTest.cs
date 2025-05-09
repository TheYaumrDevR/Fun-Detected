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
            MapDefinition mapDefinition = new MapDefinition(10, "Mesa");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);    

            Assert.That(result.Portals[0].DestinationMapId, Is.EqualTo("Town"));
            Assert.That(result.Portals[0].DestinationPortalId, Is.EqualTo("westPortal"));         
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsPortalSpawnTargetsForPlayers()
        {
            MapDefinition mapDefinition = new MapDefinition(11, "Caverns");
            CreateTestChunks(mapDefinition);        

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);  

            Assert.That(result.SpawnPositionsByChunkId.Count, Is.EqualTo(1));          
            Assert.That(result.SpawnPositionsByChunkId["westPortal"].X, Is.EqualTo(-100));
            Assert.That(result.SpawnPositionsByChunkId["westPortal"].Y, Is.EqualTo(-90));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsTiles()
        {
            MapDefinition mapDefinition = new MapDefinition(12, "Island");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.ReloadableTileMap.TerrainTiles.Count, Is.EqualTo(1));
            Assert.That(result.ReloadableTileMap.TerrainTiles[0].Id, Is.EqualTo("Earth"));
            Assert.That(result.ReloadableTileMap.TerrainTiles[0].StartX, Is.EqualTo(-2));
            Assert.That(result.ReloadableTileMap.TerrainTiles[0].StartY, Is.EqualTo(-10));
            Assert.That(result.ReloadableTileMap.TerrainTiles[0].Width, Is.EqualTo(3));
            Assert.That(result.ReloadableTileMap.TerrainTiles[0].Height, Is.EqualTo(2));

            Assert.That(result.ReloadableTileMap.GroundTiles.Count, Is.EqualTo(1));
            Assert.That(result.ReloadableTileMap.GroundTiles[0].Id, Is.EqualTo("Grass"));
            Assert.That(result.ReloadableTileMap.GroundTiles[0].StartX, Is.EqualTo(-2));
            Assert.That(result.ReloadableTileMap.GroundTiles[0].StartY, Is.EqualTo(-16));
            Assert.That(result.ReloadableTileMap.GroundTiles[0].Width, Is.EqualTo(3));
            Assert.That(result.ReloadableTileMap.GroundTiles[0].Height, Is.EqualTo(1));

            Assert.That(result.ReloadableTileMap.FoliageBackTiles.Count, Is.EqualTo(1));
            Assert.That(result.ReloadableTileMap.FoliageBackTiles[0].Id, Is.EqualTo("Tree"));
            Assert.That(result.ReloadableTileMap.FoliageBackTiles[0].StartX, Is.EqualTo(-3));
            Assert.That(result.ReloadableTileMap.FoliageBackTiles[0].StartY, Is.EqualTo(-11));
            Assert.That(result.ReloadableTileMap.FoliageBackTiles[0].Width, Is.EqualTo(2));
            Assert.That(result.ReloadableTileMap.FoliageBackTiles[0].Height, Is.EqualTo(3));

            Assert.That(result.ReloadableTileMap.FoliageFrontTiles.Count, Is.EqualTo(1));
            Assert.That(result.ReloadableTileMap.FoliageFrontTiles[0].Id, Is.EqualTo("Flower"));
            Assert.That(result.ReloadableTileMap.FoliageFrontTiles[0].StartX, Is.EqualTo(-8));
            Assert.That(result.ReloadableTileMap.FoliageFrontTiles[0].StartY, Is.EqualTo(-13));
            Assert.That(result.ReloadableTileMap.FoliageFrontTiles[0].Width, Is.EqualTo(1));
            Assert.That(result.ReloadableTileMap.FoliageFrontTiles[0].Height, Is.EqualTo(1));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsInfiniteHealingWells()
        {
            MapDefinition mapDefinition = new MapDefinition(13, "Valley");
            CreateTestChunks(mapDefinition);

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition); 

            Assert.That(result.HealingWells.Count, Is.EqualTo(1));          
            Assert.That(result.HealingWells[0].Position.X, Is.EqualTo(-125));
            Assert.That(result.HealingWells[0].Position.Y, Is.EqualTo(-125));
            Assert.That(result.HealingWells[0].Charges, Is.EqualTo(1));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsAreaLevel()
        {
            MapDefinition mapDefinition = new MapDefinition.Builder()
                .SetMapName("Desert")
                .SetAreaLevel(15)
                .SetMaximumMonsters(14)
                .Build();

            CreateTestChunks(mapDefinition);    

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.AreaLevel, Is.EqualTo(15));
        }

        [Test]
        public void TestConvertMapDefinitionToMapPropertiesConvertsIsSingleton()
        {
            MapDefinition mapDefinition = new MapDefinition.Builder()
                .SetMapName("Mountain")
                .SetIsSingleton(true)
                .Build();

            CreateTestChunks(mapDefinition);    

            MapProperties result = MapDefinitionToMapPropertiesConverter.ConvertMapDefinitionToMapProperties(mapDefinition);

            Assert.That(result.IsSingleton, Is.True);
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

            InfiniteHealingWell infiniteHealingWell = new InfiniteHealingWell(35, 35);                    

            MapChunkProperties chunkProperties1 = new MapChunkProperties.Builder()
                .SetId("EarthGrassRisingHill")
                .SetPlayerSpawnPoint(new PlayerSpawn(60, 70))
                .SetPortalProperties(portalPropertiesChunk1)
                .SetInfiniteHealingWell(infiniteHealingWell)                
                .Build(); 

            PortalProperties portalPropertiesChunk2 = new PortalProperties(45, 60);
            portalPropertiesChunk2.Width = 100;
            portalPropertiesChunk2.Height = 150;

            MapChunkProperties chunkProperties2 = new MapChunkProperties.Builder()
                .SetId("EarthGrassValley")
                .SetPlayerSpawnPoint(new PlayerSpawn(15, 46))
                .SetPortalProperties(portalPropertiesChunk2)
                .Build();   

            CreateTiles(chunkProperties2);

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

        private void CreateTiles(MapChunkProperties chunkProperties)
        {
            Tile groundTile = new Tile.Builder()
                .SetId("Grass")
                .SetStartX(6)
                .SetStartY(0)
                .SetWidth(3)
                .SetHeight(1)
                .Build();

            Tile foliageBackTile = new Tile.Builder()
                .SetId("Tree")
                .SetStartX(5)
                .SetStartY(5)
                .SetWidth(2)
                .SetHeight(3)
                .Build();

            Tile foliageFrontTile = new Tile.Builder()
                .SetId("Flower")
                .SetStartX(0)
                .SetStartY(3)
                .SetWidth(1)
                .SetHeight(1)
                .Build();

            Tile terrainTile = new Tile.Builder()
                .SetId("Earth")
                .SetStartX(6)
                .SetStartY(6)
                .SetWidth(3)
                .SetHeight(2)
                .Build(); 

            chunkProperties.GroundTiles.Add(groundTile);
            chunkProperties.FoliageBackTiles.Add(foliageBackTile);
            chunkProperties.FoliageFrontTiles.Add(foliageFrontTile);
            chunkProperties.TerrainTiles.Add(terrainTile); 
        }      
    }
}