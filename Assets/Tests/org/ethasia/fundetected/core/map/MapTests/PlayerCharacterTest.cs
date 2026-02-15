using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
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

        [Test]
        public void TestPickupEquipmentPutsEquipmentInInventoryIfCannotBeEquipped()
        {
            testCandidate = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetItemClass(ItemClass.BELT);

            Jewelry belt1 = jewelryBuilder.Build();
            Jewelry belt2 = jewelryBuilder.Build();

            testCandidate.PickupEquipment(belt1);
            testCandidate.PickupEquipment(belt2);

            ItemInventoryExtractionVisitor inventoryExtractor = testCandidate.CreateInventoryItemExtractionVisitor();

            inventoryExtractor.ExtractItems();

            Assert.That(inventoryExtractor.ExtractedWeapons.Count, Is.EqualTo(0));
            Assert.That(inventoryExtractor.ExtractedArmors.Count, Is.EqualTo(0));
            Assert.That(inventoryExtractor.ExtractedJewelry.Count, Is.EqualTo(1));
            Assert.That(inventoryExtractor.ExtractedJewelry[0].Item, Is.EqualTo(belt2));
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