using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Mocks;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Map.Tests
{
    public class PlayerRespawnInteractorTest
    {
        private Area previousActiveArea;

        [OneTimeSetUp]
        public void SetupMockFactories()
        {
            InteractorsFactoryForCore.SetInstance(new MockInteractorsFactoryForCore());
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());
        }

        [SetUp]
        public void SetUp()
        {
            previousActiveArea = Area.ActiveArea;
        }

        [TearDown]
        public void TearDown()
        {
            Area.ActiveArea = previousActiveArea;
        }

        [Test]
        public void TestRespawnInNearestTownFullyHealsPlayer()
        {
            PlayerCharacter player = CreatePlayerCharacter();
            Area area = new Area.Builder()
                .SetName("Hills West of Sventara")
                .SetWidthAndHeight(100, 100)
                .SetPlayerSpawnPosition(new Position(15, 20))
                .Build();

            area.SpawnPlayer(player);
            Area.ActiveArea = area;

            player.TakePhysicalDamage(int.MaxValue / 2);
            Assert.That(player.IsDead, Is.True);

            PlayerRespawnInteractor testCandidate = new PlayerRespawnInteractor();

            testCandidate.RespawnInNearestTown();

            Assert.That(player.IsDead, Is.False);
            Assert.That(player.TotalStats.CurrentLife, Is.EqualTo(player.TotalStats.MaximumLife));
            Assert.That(player.TotalStats.CurrentMana, Is.EqualTo(player.TotalStats.MaximumMana));
        }

        private PlayerCharacter CreatePlayerCharacter()
        {
            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetMaxLife(1)
                .SetLevel(1)
                .Build();          

            PlayerCharacter result = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .Build(); 

            result.FullyHealHp();
            return result;
        }
    }
}