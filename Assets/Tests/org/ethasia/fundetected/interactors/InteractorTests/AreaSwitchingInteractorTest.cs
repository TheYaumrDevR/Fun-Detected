using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
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
            AreaSwitchingInteractor testCandidate = InitiateBasicTestSetupAndRunTest();

            List<EnemyRenderData> result = EnemiesPresenterMock.GetPresentedEnemiesRenderData();

            Assert.That(Area.ActiveArea.Enemies.Count, Is.EqualTo(11));  
            Assert.That(result[0].PositionX, Is.EqualTo(-65));
            Assert.That(result[1].PositionX, Is.EqualTo(-45));
            Assert.That(result[2].PositionX, Is.EqualTo(-25));
            Assert.That(result[3].PositionX, Is.EqualTo(-5));
            Assert.That(result[4].PositionX, Is.EqualTo(25));
            Assert.That(result[5].PositionX, Is.EqualTo(45));
            Assert.That(result[6].PositionX, Is.EqualTo(65));
            Assert.That(result[7].PositionX, Is.EqualTo(85));
            Assert.That(result[8].PositionX, Is.EqualTo(105));
            Assert.That(result[9].PositionX, Is.EqualTo(125));
            Assert.That(result[10].PositionX, Is.EqualTo(145));
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

            testCandidate.SwitchActiveMap("hillWithChunks", testPlayer);         

            List<EnemyRenderData> result = EnemiesPresenterMock.GetPresentedEnemiesRenderData();     

            Assert.That(result[0].TypeId, Is.EqualTo("Fire Mage"));  
            Assert.That(result[1].TypeId, Is.EqualTo("Wolf"));
            Assert.That(result[2].TypeId, Is.EqualTo("Wolf"));  
            Assert.That(result[3].TypeId, Is.EqualTo("Fire Mage"));                      
        }

        [Test]
        public void TestSwitchActiveMapSetsCollisionTiles()
        {
            AreaSwitchingInteractor testCandidate = InitiateBasicTestSetupAndRunTest();

            Area map = Area.ActiveArea;          

            Assert.That(map.TileAtIsCollision(-80, 26), Is.True);   
            Assert.That(map.TileAtIsCollision(-78, 27), Is.True);   
            Assert.That(map.TileAtIsCollision(-81, 26), Is.True);   
            Assert.That(map.TileAtIsCollision(-77, 26), Is.False);  
            Assert.That(map.TileAtIsCollision(-78, 28), Is.False);   
            Assert.That(map.TileAtIsCollision(-78, 25), Is.False); 

            Assert.That(map.TileAtIsCollision(-40, 16), Is.True);   
            Assert.That(map.TileAtIsCollision(-39, 16), Is.True);  
            Assert.That(map.TileAtIsCollision(-40, 18), Is.True); 
            Assert.That(map.TileAtIsCollision(-41, 16), Is.False); 
            Assert.That(map.TileAtIsCollision(-38, 16), Is.False); 
            Assert.That(map.TileAtIsCollision(-39, 19), Is.False);
            Assert.That(map.TileAtIsCollision(-39, 15), Is.False);  

            Assert.That(map.TileAtIsCollision(0, 36), Is.True);
            Assert.That(map.TileAtIsCollision(0, 37), Is.True); 
            Assert.That(map.TileAtIsCollision(-1, 36), Is.False); 
            Assert.That(map.TileAtIsCollision(1, 36), Is.False); 
            Assert.That(map.TileAtIsCollision(0, 38), Is.False);
            Assert.That(map.TileAtIsCollision(0, 35), Is.False);   

            Assert.That(map.TileAtIsCollision(10, 46), Is.True);
            Assert.That(map.TileAtIsCollision(11, 46), Is.True);    
            Assert.That(map.TileAtIsCollision(9, 46), Is.False);
            Assert.That(map.TileAtIsCollision(12, 46), Is.False);   
            Assert.That(map.TileAtIsCollision(11, 47), Is.False);  
            Assert.That(map.TileAtIsCollision(10, 45), Is.False);                  
        }       

        private AreaSwitchingInteractor InitiateBasicTestSetupAndRunTest()
        {
            int[] randomNumbersToGenerate = {};
            float[] randomFloatsToGenerate = {0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f, 0.1f, 0.03f};       

            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);

            PlayerCharacter testPlayer = CreateTestPlayerCharacter();
            AreaSwitchingInteractor testCandidate = new AreaSwitchingInteractor();

            testCandidate.SwitchActiveMap("hillWithChunks", testPlayer);  

            return testCandidate;          
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
                .SetCharacterClass(CharacterClasses.JOCK)
                .SetPlayerCharacterBaseStats(startingStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build(); 
        }

        private MeleeHitArcProperties CreateMeleeHitArcProperties()
        {
            MeleeHitArcProperties result = new MeleeHitArcProperties();

            result.HitArcStartAngle = -0.3829252379;
            result.HitArcEndAngle = 0.9971066017;
            result.HitArcRadius = 22;
            result.HitArcCenterXOffset = -3;
            result.HitArcCenterYOffset = 4;

            return result;
        }         
    }
}