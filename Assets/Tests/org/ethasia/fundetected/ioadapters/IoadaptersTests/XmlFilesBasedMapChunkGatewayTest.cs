using NUnit.Framework;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Mocks;

namespace Org.Ethasia.Fundetected.Ioadapters.Tests
{
    public class XmlFilesBasedMapChunkGatewayTest
    {
        [OneTimeSetUp] 
        public void Init()
        {
            TechnicalFactory.SetInstance(new TechnicalMockFactory());
        }

        [Test]
        public void TestLoadChunkPropertiesPlayerSpawnIsLoaded()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("EarthGrassValley");

            Assert.That(result.PlayerSpawnPoint.IsSet, Is.True);
            Assert.That(result.PlayerSpawnPoint.X, Is.EqualTo(15));
            Assert.That(result.PlayerSpawnPoint.Y, Is.EqualTo(27));
        }  

        [Test]
        public void TestLoadChunkPropertiesPlayerSpawnIsNotSetIfNotDefined()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("EarthGrassRisingHill");

            Assert.That(result.PlayerSpawnPoint.IsSet, Is.False);
        }            

        [Test]
        public void TestLoadChunkPropertiesCorruptPlayerSpawnIsIgnored()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("CorruptPlayerSpawnPortal");

            Assert.That(result.PlayerSpawnPoint.IsSet, Is.False);
        }  

        [Test]
        public void TestLoadChunkPropertiesPortalIsLoaded()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("EarthGrassRisingHill");

            Assert.That(result.PortalProperties.AreSet, Is.True);
            Assert.That(result.PortalProperties.X, Is.EqualTo(74));
            Assert.That(result.PortalProperties.Y, Is.EqualTo(77));
            Assert.That(result.PortalProperties.Width, Is.EqualTo(100));
            Assert.That(result.PortalProperties.Height, Is.EqualTo(150));
        }

        [Test]
        public void TestLoadChunkPropertiesPortalIsNotSetIfNotDefined()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("EarthGrassValley");

            Assert.That(result.PortalProperties.AreSet, Is.False);
            Assert.That(result.PortalProperties.X, Is.EqualTo(0));
            Assert.That(result.PortalProperties.Y, Is.EqualTo(0));
        }  

        [Test]
        public void TestLoadChunkPropertiesCorruptPortalIsIgnored()
        {
            XmlFilesBasedMapChunkGateway testCandidate = new XmlFilesBasedMapChunkGateway();

            MapChunkProperties result = testCandidate.LoadChunkProperties("CorruptPlayerSpawnPortal");

            Assert.That(result.PortalProperties.AreSet, Is.False);
            Assert.That(result.PortalProperties.X, Is.EqualTo(0));
            Assert.That(result.PortalProperties.Y, Is.EqualTo(0));
        }                 
    }
}