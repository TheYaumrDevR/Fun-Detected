using NUnit.Framework;

using Org.Ethasia.Fundetected.Interactors.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class HealingWellTest
    {
        [OneTimeSetUp]
        public void SetupMapAndPlayer()
        {
            InteractorsFactoryForCore.SetInstance(new MockInteractorsFactoryForCore());

            Position playerSpawnPosition = new Position(10, 0);

            Area map = new Area.Builder()
                .SetWidthAndHeight(160, 160)
                .SetPlayerSpawnPosition(playerSpawnPosition)
                .Build();

            Area.ActiveArea = map;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetMaxLife(100)
                .SetMaxMana(100)
                .Build();          

            PlayerCharacter player = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .Build();  

            map.SpawnPlayer(player);
        }

        [Test]
        public void TestOnInteractInfiniteHealingWellKeepsHealingWithoutLosingCharges()
        {
            HealingWell testCandidate = new HealingWell.Builder()
                .SetPosition(new Position(0, 0))
                .SetWidth(1)
                .SetHeight(1)
                .MakeInfinite()
                .SetCharges(0)
                .Build();

            testCandidate.OnInteract(new EnvironmentInteractionInteractorMock());

            Assert.That(testCandidate.Charges, Is.EqualTo(1));
        }

        [Test]
        public void TestOnInteractHealingWellLosesChargesWhenHealing()
        {
            HealingWell testCandidate = new HealingWell.Builder()
                .SetPosition(new Position(0, 0))
                .SetWidth(1)
                .SetHeight(1)
                .SetCharges(5)
                .Build();

            testCandidate.OnInteract(new EnvironmentInteractionInteractorMock());

            Assert.That(testCandidate.Charges, Is.EqualTo(4));
        }

        [Test]
        public void TestOnInteractHealingWellWillNotHealWithNoCharges()
        {
            HealingWell testCandidate = new HealingWell.Builder()
                .SetPosition(new Position(0, 0))
                .SetWidth(1)
                .SetHeight(1)
                .SetCharges(0)
                .Build();

            Area.ActiveArea.Player.TakePhysicalDamage(47);

            testCandidate.OnInteract(new EnvironmentInteractionInteractorMock());

            Assert.That(Area.ActiveArea.Player.BaseStats.CurrentLife, Is.EqualTo(53));
        }

        private class EnvironmentInteractionInteractorMock : IEnvironmentInteractionInteractor
        {
            public void PlayHealingWellUseSound(string playerCharacterName)
            {
            }

            public void PresentHealthAndManaBarState()
            {
            }
        }
    }
}
