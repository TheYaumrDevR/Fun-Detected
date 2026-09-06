using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Mocks;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{

    public class PlayerCharacterTest
    {
        private RandomNumberGeneratorMock rngMock;
        private PlayerCharacter testCandidate;
        private PlayerCharacterBaseStats testBaseStats;

        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());

            testBaseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder().SetMovementSpeed(150).Build();           
        }

        [SetUp]
        public void ResetStates()
        {
            int[] randomNumbersToGenerate = {1};
            float[] randomFloatsToGenerate = {};   
            double[] randomDoublesToGenerate = {};    

            rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            InternalInteractorsFactory.SetInstance(new InternalInteractorsFactoryMock());
            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
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

        [Test]
        public void TestTotalStatsIncreaseWhenPlayerCharacterLevelsUp()
        {
            PlayerCharacterBaseStats playerCharacterBaseStats = new PlayerCharacterBaseStats
                .PlayerCharacterBaseStatsBuilder()
                .SetLevel(1)
                .SetMaxLife(66)
                .SetMaxMana(33)
                .SetAccuracyRating(1000)
                .SetAttacksPerSecond(1.0)
                .Build();

            testCandidate = CreateStandardTestCandidate(playerCharacterBaseStats);
            testCandidate.TotalStats.FullHeal();

            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToLeftEdge(5)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(5)
                .Build();

            Enemy testEnemy = new Enemy
                .Builder()
                .SetPosition(new Position(16, 20))
                .SetBoundingBox(enemyBoundingBox)
                .SetLife(1)
                .SetExperiencePointsGivenOnDeath(500)
                .Build();

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(15, 20))
                .Build();

            Area.ActiveArea = testArea; 
            testArea.SpawnPlayer(testCandidate);
            testArea.AddEnemy(testEnemy);

            testCandidate.AutoAttack();
            Area.ActiveArea.Player.Tick(1.5);

            int maximumLifeAfterLevelUp = testCandidate.TotalStats.MaximumLife;
            int maximumManaAfterLevelUp = testCandidate.TotalStats.MaximumMana;
            int accuracyRatingAfterLevelUp = testCandidate.TotalStats.AccuracyRating;

            Assert.That(playerCharacterBaseStats.LevelingSystem.Level, Is.EqualTo(2));
            Assert.That(maximumLifeAfterLevelUp, Is.EqualTo(78));
            Assert.That(maximumManaAfterLevelUp, Is.EqualTo(39));
            Assert.That(accuracyRatingAfterLevelUp, Is.EqualTo(1002));
        }

        [Test]
        public void TestTotalStatsIncreaseWhenPlayerCharacterLevelsUpThreeTimes()
        {
            PlayerCharacterBaseStats playerCharacterBaseStats = new PlayerCharacterBaseStats
                .PlayerCharacterBaseStatsBuilder()
                .SetLevel(1)
                .SetMaxLife(66)
                .SetMaxMana(33)
                .SetAccuracyRating(1000)
                .SetAttacksPerSecond(1.0)
                .Build();

            testCandidate = CreateStandardTestCandidate(playerCharacterBaseStats);
            testCandidate.TotalStats.FullHeal();

            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToLeftEdge(5)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(5)
                .Build();

            Enemy testEnemy = new Enemy
                .Builder()
                .SetPosition(new Position(16, 20))
                .SetBoundingBox(enemyBoundingBox)
                .SetLife(1)
                .SetExperiencePointsGivenOnDeath(4000)
                .Build();

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(15, 20))
                .Build();

            Area.ActiveArea = testArea;
            testArea.SpawnPlayer(testCandidate);
            testArea.AddEnemy(testEnemy);

            testCandidate.AutoAttack();
            Area.ActiveArea.Player.Tick(1.5);

            int maximumLifeAfterLevelUps = testCandidate.TotalStats.MaximumLife;
            int maximumManaAfterLevelUps = testCandidate.TotalStats.MaximumMana;
            int accuracyRatingAfterLevelUps = testCandidate.TotalStats.AccuracyRating;

            Assert.That(playerCharacterBaseStats.LevelingSystem.Level, Is.EqualTo(4));
            Assert.That(maximumLifeAfterLevelUps, Is.EqualTo(102));   // 66 + 3*12
            Assert.That(maximumManaAfterLevelUps, Is.EqualTo(51));    // 33 + 3*6
            Assert.That(accuracyRatingAfterLevelUps, Is.EqualTo(1006)); // 1000 + 3*2
        }

        private PlayerCharacter CreateStandardTestCandidate()
        {
            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(testBaseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  
        }

        private PlayerCharacter CreateStandardTestCandidate(PlayerCharacterBaseStats playerCharacterBaseStats)
        {
            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(playerCharacterBaseStats)
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