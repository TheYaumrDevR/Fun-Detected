using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class MapPropertiesConverterTest
    {

        [Test]
        public void TestConvertMapPropertiesToAreaConvertsCollisions()
        {
            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .Build();

            Collision collision1 = new Collision.Builder()
                .SetStartX(-100)
                .SetStartY(-11)
                .SetWidth(40)
                .SetHeight(1)
                .Build();

            Collision collision2 = new Collision.Builder()
                .SetStartX(-60)
                .SetStartY(-21)
                .SetWidth(30)
                .SetHeight(1)
                .Build();  

            Collision collision3 = new Collision.Builder()
                .SetStartX(170)
                .SetStartY(30)
                .SetWidth(1)
                .SetHeight(9)
                .Build();                                

            mapProperties.AddCollision(collision1);
            mapProperties.AddCollision(collision2);
            mapProperties.AddCollision(collision3);

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);

            Assert.That(result.TileAtIsCollision(-80, -11), Is.True);  
            Assert.That(result.TileAtIsCollision(-77, -12), Is.False);
            Assert.That(result.TileAtIsCollision(-55, -21), Is.True);
            Assert.That(result.TileAtIsCollision(-55, -20), Is.False);
            Assert.That(result.TileAtIsCollision(170, 38), Is.True);
            Assert.That(result.TileAtIsCollision(170, 40), Is.False);
        }

        [Test]
        public void TestConvertMapPropertiesToAreaConvertsPortals()
        {
            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .Build();        

            Position portalPosition1 = new Position(10, 10);
            Position portalPosition2 = new Position(-120, -300);

            MapPortalProperties portal1 = new MapPortalProperties.Builder()
                .SetPosition(portalPosition1)
                .SetWidth(100)
                .SetHeight(150)
                .SetDestinationMapId("map1")
                .SetDestinationPortalId("portal1")
                .Build();

            MapPortalProperties portal2 = new MapPortalProperties.Builder()
                .SetPosition(portalPosition2)
                .SetWidth(50)
                .SetHeight(50)
                .SetDestinationMapId("map2")
                .SetDestinationPortalId("portal2")
                .Build();

            mapProperties.Portals.Add(portal1);    
            mapProperties.Portals.Add(portal2);

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);

            Assert.That(result.Portals.Count, Is.EqualTo(2));  

            Assert.That(result.Portals[0].Position.X, Is.EqualTo(10));  
            Assert.That(result.Portals[0].Position.Y, Is.EqualTo(10)); 
            Assert.That(result.Portals[0].Width, Is.EqualTo(100));  
            Assert.That(result.Portals[0].Height, Is.EqualTo(150));   
            Assert.That(result.Portals[0].DestinationMapId, Is.EqualTo("map1"));
            Assert.That(result.Portals[0].DestinationPortalId, Is.EqualTo("portal1"));

            Assert.That(result.Portals[1].Position.X, Is.EqualTo(-120));  
            Assert.That(result.Portals[1].Position.Y, Is.EqualTo(-300)); 
            Assert.That(result.Portals[1].Width, Is.EqualTo(50));  
            Assert.That(result.Portals[1].Height, Is.EqualTo(50));         
            Assert.That(result.Portals[1].DestinationMapId, Is.EqualTo("map2"));
            Assert.That(result.Portals[1].DestinationPortalId, Is.EqualTo("portal2"));      
        }

        [Test]
        public void TestConvertMapPropertiesToAreaConvertsSpawnPositionsByChunkId()
        {
            Dictionary<string, Position> spawnPositionsByChunkId = new Dictionary<string, Position>();
            spawnPositionsByChunkId.Add("westPortal", new Position(32, 36));
            spawnPositionsByChunkId.Add("eastPortal", new Position(77, 43));

            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .SetSpawnPositionsByChunkId(spawnPositionsByChunkId)
                .Build();    

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);  

            Assert.That(result.GetSpawnPositionForChunkId("westPortal").X, Is.EqualTo(32));
            Assert.That(result.GetSpawnPositionForChunkId("westPortal").Y, Is.EqualTo(36));
            Assert.That(result.GetSpawnPositionForChunkId("eastPortal").X, Is.EqualTo(77));
            Assert.That(result.GetSpawnPositionForChunkId("eastPortal").Y, Is.EqualTo(43));      
        }

        [Test]
        public void TestConvertMapPropertiesToAreaConvertsReloadableTileMap()
        {
            ReloadableTileMap reloadableTileMap = new ReloadableTileMap();

            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .SetReloadableTileMap(reloadableTileMap)
                .Build();    

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);  

            Assert.That(result.ReloadableTileMap, Is.EqualTo(reloadableTileMap));      
        }

        [Test]
        public void TestConvertMapPropertiesConvertsAreaLevel()
        {
            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .SetAreaLevel(5)
                .Build();    

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);  

            Assert.That(result.AreaLevel, Is.EqualTo(5));
        }

        [Test]
        public void TestConvertMapPropertiesConvertsIsSingleton()
        {
            MapProperties mapProperties = new MapProperties.Builder()
                .SetWidth(320)
                .SetHeight(70)
                .SetLowestScreenX(-100)
                .SetLowestScreenY(-25)
                .SetIsSingleton(true)
                .Build();    

            Area result = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);  

            Assert.That(result.IsSingleton, Is.True);  
        }
    }
}