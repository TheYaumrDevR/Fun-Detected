using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
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
                .SetPlayerSpawnPosition(new Position(11, 30))
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(10)); 
        }

        [Test]
        public void TestCalculateFallDepthFallsDownToZero()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(3, 10)
                .SetPlayerSpawnPosition(new Position(8, 30))
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(14)); 
        }

        [Test]
        public void TestCalculateFallDepthDoesNotFallWhileOnGround()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(37, 24)
                .SetPlayerSpawnPosition(new Position(41, 40))
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();  

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(0)); 
        }

        [Test]
        public void TestTryToMovePlayerRightStepUpMovesWhenNoObstacleExists()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(5)); 
        }    

        [Test]
        public void TestTryToMovePlayerLeftStepUpMovesWhenNoObstacleExists()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(5)); 
        }  

        [Test]
        public void TestTryToMovePlayerRightStepUpDoesNotMoveWhenStepTooHigh()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }    

        [Test]
        public void TestTryToMovePlayerLeftStepUpDoesNotMoveWhenStepTooHigh()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }          

        [Test]
        public void TestTryToMovePlayerRightStepUpBumpsIntoRightWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }  

        [Test]
        public void TestTryToMovePlayerLeftStepUpBumpsIntoRightWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }            

        [Test]
        public void TestTryToMovePlayerRightStepUpBumpsIntoTopWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerRightStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }   

        [Test]
        public void TestTryToMovePlayerLeftStepUpBumpsIntoTopWall()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(17, 26))
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

            testArea.SpawnPlayer(playerCharacter);

            int result = testArea.TryToMovePlayerLeftStepUp();
            Assert.That(result, Is.EqualTo(0)); 
        }

        [Test]
        public void TestPortPlayerToPortsToCoordinatesWithDestinationId()
        {
            Dictionary<string, Position> playerSpawnPositionBySpawnerId = new Dictionary<string, Position>();
            playerSpawnPositionBySpawnerId.Add("upperWestPortal", new Position(5, 70));

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 90)
                .SetPlayerSpawnPositionBySpawnerId(playerSpawnPositionBySpawnerId)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();

            testArea.PortPlayerTo(playerCharacter, "upperWestPortal");

            Assert.That(testArea.GetPlayerPositionX(), Is.EqualTo(5));
            Assert.That(testArea.GetPlayerPositionY(), Is.EqualTo(70));
        }

        [Test]
        public void TestPortPlayerTo_DoesNotModifyPortalTargetPositionWhenPlayerMoves()
        {
            string portalTargetId = "upperWestPortal";

            Dictionary<string, Position> playerSpawnPositionBySpawnerId = new Dictionary<string, Position>();
            playerSpawnPositionBySpawnerId.Add(portalTargetId, new Position(5, 70));

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 90)
                .SetPlayerSpawnPositionBySpawnerId(playerSpawnPositionBySpawnerId)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(CreateMeleeHitArcProperties())
                .Build();

            testArea.PortPlayerTo(playerCharacter, portalTargetId);
            testArea.CalculateUnitsPlayerCanMoveRight(4);

            Assert.That(testArea.GetPlayerPositionX(), Is.EqualTo(9));
            Assert.That(testArea.GetPlayerPositionY(), Is.EqualTo(70));
            Assert.That(testArea.GetSpawnPositionForChunkId(portalTargetId).X, Is.EqualTo(5));
            Assert.That(testArea.GetSpawnPositionForChunkId(portalTargetId).Y, Is.EqualTo(70));
        }

        [Test]
        public void TestPickupItemRemovesItemFromDroppedItemsAndEquipsItToPlayer()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(10, 10))
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .Build();  

            testArea.SpawnPlayer(playerCharacter);

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetItemClass(ItemClass.BELT);

            Jewelry testItem1 = jewelryBuilder.Build();

            jewelryBuilder.SetItemClass(ItemClass.RING);

            Jewelry testItem2 = jewelryBuilder.Build();
            Jewelry testItem3 = jewelryBuilder.Build();

            testArea.AddItem(testItem2);
            testArea.AddItem(testItem1);
            testArea.AddItem(testItem3);

            testArea.PickupItem(1);

            PlayerEquipmentItemsExtractionVisitor equipmentExtractionVisitor = playerCharacter.CreateItemExtractionVisitor();
            equipmentExtractionVisitor.ExtractBeltEquipment();

            Assert.That(testArea.DroppedItems.Count, Is.EqualTo(2));
            Assert.That(equipmentExtractionVisitor.ExtractedJewelry, Is.EqualTo(testItem1));
        }

        [Test]
        public void TestPickupItemDoesNotPickUpItemWhenNoSpaceInInventory()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(10, 10))
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .Build();  

            testArea.SpawnPlayer(playerCharacter);

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetItemClass(ItemClass.BELT);

            Jewelry testItem1 = jewelryBuilder.Build();

            jewelryBuilder.SetItemClass(ItemClass.RING);

            Jewelry testItem2 = jewelryBuilder.Build();
            Jewelry testItem3 = jewelryBuilder.Build();
            Jewelry testItem4 = jewelryBuilder.Build();

            testArea.AddItem(testItem2);
            testArea.AddItem(testItem1);
            testArea.AddItem(testItem3);
            testArea.AddItem(testItem4);

            bool pickedRingOne = testArea.PickupItem(0);
            bool pickedRingTwo = testArea.PickupItem(1);
            bool pickedBelt = testArea.PickupItem(0);
            bool pickedRingThree = testArea.PickupItem(0);

            Assert.That(testArea.DroppedItems.Count, Is.EqualTo(1));
            Assert.That(pickedRingOne, Is.True);
            Assert.That(pickedRingTwo, Is.True);
            Assert.That(pickedBelt, Is.True);
            Assert.That(pickedRingThree, Is.False);
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