using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class AreaSwitchingInteractorTest
    {

        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new MockedIoAdaptersFactoryForInteractors());
        }

        [Test]
        public void TestSwitchActiveMapSpawnsEnemies()
        {
            int[] randomNumbersToGenerate = {};
            float[] randomFloatsToGenerate = {0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f};       

            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);

            PlayerCharacter testPlayer = CreateTestPlayerCharacter();
            AreaSwitchingInteractor testCandidate = new AreaSwitchingInteractor();

            testCandidate.SwitchActiveMap("hill", testPlayer);

            List<EnemyRenderData> result = EnemiesPresenterMock.GetPresentedEnemiesRenderData();

            Assert.That(result.Count, Is.EqualTo(11));  
            Assert.That(result[0].PositionX, Is.EqualTo(10));
            Assert.That(result[1].PositionX, Is.EqualTo(20));  
            Assert.That(result[2].PositionX, Is.EqualTo(40));
            Assert.That(result[3].PositionX, Is.EqualTo(60));
            Assert.That(result[4].PositionX, Is.EqualTo(80));
            Assert.That(result[5].PositionX, Is.EqualTo(100));
            Assert.That(result[6].PositionX, Is.EqualTo(120));
            Assert.That(result[7].PositionX, Is.EqualTo(140));
            Assert.That(result[8].PositionX, Is.EqualTo(160));
            Assert.That(result[9].PositionX, Is.EqualTo(180));
            Assert.That(result[10].PositionX, Is.EqualTo(200));
        }

        [Test]
        public void TestSwitchActiveMapSpawnsDifferentEnemyTypes()
        {
            int[] randomNumbersToGenerate = {180, 479, 789, 33};
            float[] randomFloatsToGenerate = {0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f};       

            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);

            PlayerCharacter testPlayer = CreateTestPlayerCharacter();
            AreaSwitchingInteractor testCandidate = new AreaSwitchingInteractor();

            testCandidate.SwitchActiveMap("hill", testPlayer);

            List<EnemyRenderData> result = EnemiesPresenterMock.GetPresentedEnemiesRenderData();     

            Assert.That(result[1].EnemyId, Is.EqualTo("Fire Mage"));  
            Assert.That(result[2].EnemyId, Is.EqualTo("Wolf"));
            Assert.That(result[3].EnemyId, Is.EqualTo("Wolf"));  
            Assert.That(result[4].EnemyId, Is.EqualTo("Fire Mage"));                 
        }        

        private PlayerCharacter CreateTestPlayerCharacter()
        {
            DamageRange basePhysicalDamage = new DamageRange(2, 5);

            PlayerCharacterBaseStats startingStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetLevel(1)
                .SetIntelligence(5)
                .SetAgility(8)
                .SetStrength(5)
                .SetMaxLife(40)
                .SetMaxMana(40)
                .SetEvasionRating(12)
                .SetBasePhysicalDamage(basePhysicalDamage)
                .SetAttacksPerSecond(1.2)
                .SetMovementSpeed(100)
                .Build();   
            
            startingStats.DeriveStats();
            startingStats.FullHeal();

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetFacingDirection(FacingDirection.RIGHT)
                .SetCharacterClass(CharacterClasses.STRONGMAN)
                .SetPlayerCharacterBaseStats(startingStats)
                .Build(); 
        }
    }
}