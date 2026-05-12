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
            testCandidate = CreateStandardTestCandidate();

            int unitsMoved = testCandidate.MoveLeft(0.2);
            Assert.That(unitsMoved, Is.EqualTo(3));  
        }

        [Test]
        public void TestMoveLeftMoveTimeIsBelowThreshold()
        {
            testCandidate = CreateStandardTestCandidate();

            int unitsMoved = testCandidate.MoveLeft(0.065);
            Assert.That(unitsMoved, Is.EqualTo(0));  
        }        

        [Test]
        public void TestMoveRightDistanceUnitsAreCalculatedCorrectly()
        {
            testCandidate = CreateStandardTestCandidate();

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
            testCandidate = CreateStandardTestCandidate();

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

        [Test]
        public void TestDropPickedInventoryItemRemovesItemFromCursorAndSetsItToPlayerPosition()
        {
            testCandidate = CreateStandardTestCandidate();           

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(9, 4)
                .SetPlayerSpawnPosition(new Position(11, 30))
                .Build();

            Area.ActiveArea = testArea;

            testArea.SpawnPlayer(testCandidate);

            Jewelry equippedRing = CreateTestRing();
            testCandidate.PickupEquipment(equippedRing);

            testCandidate.ItemInventory.SwapCursorItemWithLeftRingEquipment();

            Item droppedItem = testCandidate.DropPickedInventoryItem();

            Assert.That(droppedItem, Is.EqualTo(equippedRing));
            Assert.That(droppedItem.CollisionShape.Position.X, Is.EqualTo(testArea.GetPlayerPositionX()));
            Assert.That(droppedItem.CollisionShape.Position.Y, Is.EqualTo(testArea.GetPlayerPositionY()));
        }

        private PlayerCharacter CreateStandardTestCandidate()
        {
            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
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

        private Jewelry CreateTestRing()
        {
            var builder = new Jewelry.Builder();

            builder.SetName("Diamond Ring")
                .SetItemClass(ItemClass.RING);

            return builder.Build();
        }                
    }
}