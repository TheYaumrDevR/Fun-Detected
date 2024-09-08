using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{

    public class PlayerCharacterTest
    {
        private PlayerCharacter testCandidate;
        private PlayerCharacterBaseStats testBaseStats;

        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());

            testBaseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder().SetMovementSpeed(150).Build();
            testBaseStats.DeriveStats();            
        }

        [Test]
        public void TestMoveLeftDistanceUnitsAreCalculatedCorrectly()
        {
            testCandidate = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();    

            int unitsMoved = testCandidate.MoveLeft(0.2);
            Assert.That(unitsMoved, Is.EqualTo(3));  
        }

        [Test]
        public void TestMoveLeftMoveTimeIsBelowThreshold()
        {
            testCandidate = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            int unitsMoved = testCandidate.MoveLeft(0.065);
            Assert.That(unitsMoved, Is.EqualTo(0));  
        }        

        [Test]
        public void TestMoveRightDistanceUnitsAreCalculatedCorrectly()
        {
            testCandidate = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            int unitsMoved = testCandidate.MoveRight(0.54);
            Assert.That(unitsMoved, Is.EqualTo(8)); 
        }        

        [Test]
        public void TestMoveRightMoveTimeIsBelowThreshold()
        {
            testCandidate = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            int unitsMoved = testCandidate.MoveRight(0.065);
            Assert.That(unitsMoved, Is.EqualTo(0)); 
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