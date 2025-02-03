using NUnit.Framework;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Mocks;

namespace Org.Ethasia.Fundetected.Ioadapters.Tests
{
    public class XmlFilesBasedMapDefinitionGatewayTest
    {
        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new RealIoAdaptersFactoryForInteractors());
            TechnicalFactory.SetInstance(new TechnicalMockFactory());
        }

        [Test]
        public void TestLoadMapDefinitionHasCorrectAmountOfChildren()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");

            Assert.That(result.MaximumMonsters, Is.EqualTo(10));
            Assert.That(result.Chunks.Count, Is.EqualTo(8));
            Assert.That(result.SpawnableMonsters.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestLoadMapDefinitionLoadsChunksCorrectly()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");

            Assert.That(result.Chunks[0].X, Is.EqualTo(-2));
            Assert.That(result.Chunks[0].Y, Is.EqualTo(-1));

            Assert.That(result.Chunks[1].X, Is.EqualTo(-1));
            Assert.That(result.Chunks[1].Y, Is.EqualTo(-1));

            Assert.That(result.Chunks[2].X, Is.EqualTo(0));
            Assert.That(result.Chunks[2].Y, Is.EqualTo(-1));

            Assert.That(result.Chunks[3].X, Is.EqualTo(1));
            Assert.That(result.Chunks[3].Y, Is.EqualTo(-1));

            Assert.That(result.Chunks[4].X, Is.EqualTo(-2));
            Assert.That(result.Chunks[4].Y, Is.EqualTo(0));

            Assert.That(result.Chunks[5].X, Is.EqualTo(-1));
            Assert.That(result.Chunks[5].Y, Is.EqualTo(0));

            Assert.That(result.Chunks[6].X, Is.EqualTo(0));
            Assert.That(result.Chunks[6].Y, Is.EqualTo(0));

            Assert.That(result.Chunks[7].X, Is.EqualTo(1));
            Assert.That(result.Chunks[7].Y, Is.EqualTo(0));       

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks.Count, Is.EqualTo(1));
            Assert.That(result.Chunks[1].PropertiesOfPossibleChunks.Count, Is.EqualTo(1));
            Assert.That(result.Chunks[2].PropertiesOfPossibleChunks.Count, Is.EqualTo(3));
            Assert.That(result.Chunks[3].PropertiesOfPossibleChunks.Count, Is.EqualTo(2));
            Assert.That(result.Chunks[4].PropertiesOfPossibleChunks.Count, Is.EqualTo(0));
            Assert.That(result.Chunks[5].PropertiesOfPossibleChunks.Count, Is.EqualTo(0));
            Assert.That(result.Chunks[6].PropertiesOfPossibleChunks.Count, Is.EqualTo(0));
            Assert.That(result.Chunks[7].PropertiesOfPossibleChunks.Count, Is.EqualTo(0));                                                                             
        }   

        [Test]
        public void TestLoadMapDefinitionLoadsSpawnableMonstersCorrectly()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");

            Assert.That(result.SpawnableMonsters[0].Name, Is.EqualTo("Animated Thornbush"));
            Assert.That(result.SpawnableMonsters[0].SpawnChanceMillis, Is.EqualTo(1000));                                                                            
        }  

        [Test]
        public void TestLoadMapDefinitionLoadsCorrectTilesForChunk()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");     
        
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[0].Id, Is.EqualTo("PlainsAndHillsTileset_Earth")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[0].StartX, Is.EqualTo(0));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[0].StartY, Is.EqualTo(0)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[0].Width, Is.EqualTo(4));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[0].Height, Is.EqualTo(4)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[1].Id, Is.EqualTo("PlainsAndHillsTileset_Earth")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[1].StartX, Is.EqualTo(4));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[1].StartY, Is.EqualTo(0)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[1].Width, Is.EqualTo(3));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[1].Height, Is.EqualTo(1));  

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[2].Id, Is.EqualTo("PlainsAndHillsTileset_Earth")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[2].StartX, Is.EqualTo(7));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[2].StartY, Is.EqualTo(0)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[2].Width, Is.EqualTo(1));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].TerrainTiles[2].Height, Is.EqualTo(2));   

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[0].Id, Is.EqualTo("PlainsAndHillsTileset_Grass")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[0].StartX, Is.EqualTo(0));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[0].StartY, Is.EqualTo(2)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[0].Width, Is.EqualTo(4));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[0].Height, Is.EqualTo(1)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[1].Id, Is.EqualTo("PlainsAndHillsTileset_Grass")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[1].StartX, Is.EqualTo(4));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[1].StartY, Is.EqualTo(1)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[1].Width, Is.EqualTo(3));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[1].Height, Is.EqualTo(1));  

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[2].Id, Is.EqualTo("PlainsAndHillsTileset_Grass")); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[2].StartX, Is.EqualTo(7));
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[2].StartY, Is.EqualTo(2)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[2].Width, Is.EqualTo(1));      
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].GroundTiles[2].Height, Is.EqualTo(1));                                        
        }  

        [Test]
        public void TestLoadMapDefinitionLoadsCollisionInformation()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");  

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[0].StartX, Is.EqualTo(0)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[0].StartY, Is.EqualTo(26)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[0].Width, Is.EqualTo(40)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[0].Height, Is.EqualTo(1)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[1].StartX, Is.EqualTo(40)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[1].StartY, Is.EqualTo(16)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[1].Width, Is.EqualTo(30)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[1].Height, Is.EqualTo(1)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[2].StartX, Is.EqualTo(70)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[2].StartY, Is.EqualTo(26)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[2].Width, Is.EqualTo(10)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[2].Height, Is.EqualTo(1)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[3].StartX, Is.EqualTo(39)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[3].StartY, Is.EqualTo(17)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[3].Width, Is.EqualTo(1)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[3].Height, Is.EqualTo(9)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[4].StartX, Is.EqualTo(70)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[4].StartY, Is.EqualTo(17)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[4].Width, Is.EqualTo(1)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].CollisionProperties[4].Height, Is.EqualTo(9));                                                 
        }  

        [Test]
        public void TestLoadMapDefinitionLoadsSpawners()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");  

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[0].X, Is.EqualTo(5)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[0].Y, Is.EqualTo(28)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[1].X, Is.EqualTo(15)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[1].Y, Is.EqualTo(28)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[2].X, Is.EqualTo(25)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[2].Y, Is.EqualTo(28)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[3].X, Is.EqualTo(35)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[3].Y, Is.EqualTo(28)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[4].X, Is.EqualTo(45)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[4].Y, Is.EqualTo(18)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[5].X, Is.EqualTo(55)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[5].Y, Is.EqualTo(18)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[6].X, Is.EqualTo(65)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[6].Y, Is.EqualTo(18)); 

            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[7].X, Is.EqualTo(75)); 
            Assert.That(result.Chunks[0].PropertiesOfPossibleChunks[0].Spawners[7].Y, Is.EqualTo(28));                                                                             
        }  

        [Test]
        public void TestLoadMapDefinitionLoadsSpawnAttributeOnChunk()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");     

            Assert.That(result.Chunks[0].Spawn, Is.True);         
        }      

        [Test]
        public void TestLoadMapDefinitionLoadsPortalToProperly()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");     

            Assert.That(result.Chunks[3].PortalTo.Value.MapId, Is.EqualTo("Town"));             
            Assert.That(result.Chunks[3].PortalTo.Value.PortalId, Is.EqualTo("westPortal"));                                                               
        }  

        [Test]
        public void TestLoadMapDefinitionLoadsIdAttributeOnChunk()
        {
            XmlFilesBasedMapDefinitionGateway testCandidate = new XmlFilesBasedMapDefinitionGateway();

            MapDefinition result = testCandidate.LoadMapDefinition("Hill");     

            Assert.That(result.Chunks[3].Id, Is.EqualTo("eastPortal"));         
        }                 
    }
}