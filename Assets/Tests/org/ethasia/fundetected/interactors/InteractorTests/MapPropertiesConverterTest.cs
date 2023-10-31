using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class MapPropertiesConverterTest
    {

        [Test]
        public void TestConvertMapPropertiesToAreaConvertsCollisions()
        {
            MapProperties mapProperties = new MapProperties(320, 61);

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

            Assert.That(result.TileAtIsCollision(39, 10), Is.True);  
            Assert.That(result.TileAtIsCollision(39, 11), Is.False);
            Assert.That(result.TileAtIsCollision(55, 0), Is.True);
            Assert.That(result.TileAtIsCollision(39, 0), Is.False);
            Assert.That(result.TileAtIsCollision(270, 55), Is.True);
            Assert.That(result.TileAtIsCollision(270, 50), Is.False);
        }
    }
}