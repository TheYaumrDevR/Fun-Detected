using NUnit.Framework;

using Org.Ethasia.Fundetected.Ioadapters.Mocks;
using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class AreaTest
    {
        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());
        }

        [Test]
        public void TestCalculateFallDepthFallsDownInAir()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(9, 4)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 11, 30);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(10)); 
        }

        [Test]
        public void TestCalculateFallDepthFallsDownToZero()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(3, 10)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 8, 30);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(14)); 
        }

        [Test]
        public void TestCalculateFallDepthDoesNotFallWhileOnGround()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(37, 24)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 41, 40);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(0)); 
        }

        [Test]
        public void TestTryToMovePlayerRightStepUpMovesWhenNoObstacleExists()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(18, 10)
                .SetIsColliding(19, 10)
                .SetIsColliding(20, 10)
                .SetIsColliding(21, 10)
                .SetIsColliding(22, 10)
                .SetIsColliding(23, 11)
                .SetIsColliding(23, 12)
                .SetIsColliding(23, 13)
                .SetIsColliding(23, 14)
                .SetIsColliding(23, 15)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(5)); 
        }    

        [Test]
        public void TestTryToMovePlayerLeftStepUpMovesWhenNoObstacleExists()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(13, 10)
                .SetIsColliding(14, 10)
                .SetIsColliding(15, 10)
                .SetIsColliding(16, 10)
                .SetIsColliding(17, 10)
                .SetIsColliding(12, 11)
                .SetIsColliding(12, 12)
                .SetIsColliding(12, 13)
                .SetIsColliding(12, 14)
                .SetIsColliding(12, 15)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(5)); 
        }  

        [Test]
        public void TestTryToMovePlayerRightStepUpDoesNotMoveWhenStepTooHigh()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(18, 10)
                .SetIsColliding(19, 10)
                .SetIsColliding(20, 10)
                .SetIsColliding(21, 10)
                .SetIsColliding(22, 10)
                .SetIsColliding(23, 11)
                .SetIsColliding(23, 12)
                .SetIsColliding(23, 13)
                .SetIsColliding(23, 14)
                .SetIsColliding(23, 15)
                .SetIsColliding(23, 16)
                .SetIsColliding(23, 17)
                .SetIsColliding(23, 18)
                .SetIsColliding(23, 19)
                .SetIsColliding(23, 20)
                .SetIsColliding(23, 21)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }    

        [Test]
        public void TestTryToMovePlayerLeftStepUpDoesNotMoveWhenStepTooHigh()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(13, 10)
                .SetIsColliding(14, 10)
                .SetIsColliding(15, 10)
                .SetIsColliding(16, 10)
                .SetIsColliding(17, 10)
                .SetIsColliding(12, 11)
                .SetIsColliding(12, 12)
                .SetIsColliding(12, 13)
                .SetIsColliding(12, 14)
                .SetIsColliding(12, 15)
                .SetIsColliding(12, 16)
                .SetIsColliding(12, 17)
                .SetIsColliding(12, 18)
                .SetIsColliding(12, 19)
                .SetIsColliding(12, 20)
                .SetIsColliding(12, 21)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }          

        [Test]
        public void TestTryToMovePlayerRightStepUpBumpsIntoRightWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(18, 10)
                .SetIsColliding(19, 10)
                .SetIsColliding(20, 10)
                .SetIsColliding(21, 10)
                .SetIsColliding(22, 10)
                .SetIsColliding(23, 11)
                .SetIsColliding(23, 12)
                .SetIsColliding(23, 13)
                .SetIsColliding(23, 14)
                .SetIsColliding(23, 15)
                .SetIsColliding(23, 23)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }  

        [Test]
        public void TestTryToMovePlayerLeftStepUpBumpsIntoRightWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(13, 10)
                .SetIsColliding(14, 10)
                .SetIsColliding(15, 10)
                .SetIsColliding(16, 10)
                .SetIsColliding(17, 10)
                .SetIsColliding(12, 11)
                .SetIsColliding(12, 12)
                .SetIsColliding(12, 13)
                .SetIsColliding(12, 14)
                .SetIsColliding(12, 15)
                .SetIsColliding(12, 23)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }            

        [Test]
        public void TestTryToMovePlayerRightStepUpBumpsIntoTopWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(18, 10)
                .SetIsColliding(19, 10)
                .SetIsColliding(20, 10)
                .SetIsColliding(21, 10)
                .SetIsColliding(22, 10)
                .SetIsColliding(23, 11)
                .SetIsColliding(23, 12)
                .SetIsColliding(23, 13)
                .SetIsColliding(23, 14)
                .SetIsColliding(23, 15)
                .SetIsColliding(19, 45)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }   

        [Test]
        public void TestTryToMovePlayerLeftStepUpBumpsIntoTopWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(13, 10)
                .SetIsColliding(14, 10)
                .SetIsColliding(15, 10)
                .SetIsColliding(16, 10)
                .SetIsColliding(17, 10)
                .SetIsColliding(12, 11)
                .SetIsColliding(12, 12)
                .SetIsColliding(12, 13)
                .SetIsColliding(12, 14)
                .SetIsColliding(12, 15)
                .SetIsColliding(16, 45)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 17, 26);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
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