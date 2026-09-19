using NUnit.Framework;
using System;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class PlayerInventoryInteractorTest
    {
        private static readonly object[] UntwinnedEquipmentSlotTestCases = new object[]
        {
            new object[] { (Action<PlayerInventoryInteractor>)(interactor => interactor.SwapCursorItemWithMainHandEquipment()), (Func<Equipment>)(() => TestWeaponsProvider.CreateOneHandedSword()) },
            new object[] { (Action<PlayerInventoryInteractor>)(interactor => interactor.SwapCursorItemWithLeftRingEquipment()), (Func<Equipment>)(() => TestJewelryProvider.CreateRing()) },
            new object[] { (Action<PlayerInventoryInteractor>)(interactor => interactor.SwapCursorItemWithBeltEquipment()), (Func<Equipment>)(() => TestJewelryProvider.CreateBelt()) }
        };

        private PlayerInventoryInteractor testCandidate;

        [OneTimeSetUp]
        public void SetupTestCandidate()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new MockedIoAdaptersFactoryForInteractors());
            testCandidate = new PlayerInventoryInteractor();
        }

        [SetUp]
        public void SetupTestEnvironment()
        {
            SetupMapAndPlayer();
        }

        [TestCaseSource(nameof(UntwinnedEquipmentSlotTestCases))]
        public void TestSwapCursorItemWithUntwinnedEquipmentSlot(Action<PlayerInventoryInteractor> swapAction, Func<Equipment> equipmentFactory)
        {
            Equipment equipment = equipmentFactory();
            Area.ActiveArea.Player.PickupEquipment(equipment);

            swapAction(testCandidate);
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(equipment));

            swapAction(testCandidate);
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);
        }

        [Test]
        public void TestSwapCursorItemWithOffHandEquipment()
        {
            Weapon equippedWeaponOne = TestWeaponsProvider.CreateDagger();
            Weapon equippedWeaponTwo = TestWeaponsProvider.CreateDagger();
            Area.ActiveArea.Player.PickupEquipment(equippedWeaponOne);
            Area.ActiveArea.Player.PickupEquipment(equippedWeaponTwo);

            testCandidate.SwapCursorItemWithOffHandEquipment();
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(equippedWeaponTwo));

            testCandidate.SwapCursorItemWithOffHandEquipment();
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);
        }

        [Test]
        public void TestSwapCursorItemWithRightRingEquipment()
        {
            Equipment equippedRingOne = TestJewelryProvider.CreateRing();
            Equipment equippedRingTwo = TestJewelryProvider.CreateRing();
            Area.ActiveArea.Player.PickupEquipment(equippedRingOne);
            Area.ActiveArea.Player.PickupEquipment(equippedRingTwo);

            testCandidate.SwapCursorItemWithRightRingEquipment();
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(equippedRingTwo));

            testCandidate.SwapCursorItemWithRightRingEquipment();
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);
        }

        [Test]
        public void TestPickItemFromGridAtPositionAddsItemToCursor()
        {
            Weapon lootedWeaponFour = FillMainHandAndThreeGridSlotsWithStabbingSwords();

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);

            testCandidate.PickItemFromGridAtPosition(1, 1);

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(lootedWeaponFour));
        }

        [Test]
        public void TestPickItemFromGridAtPositionDoesNotExist()
        {
            FillMainHandAndThreeGridSlotsWithStabbingSwords();

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);

            testCandidate.PickItemFromGridAtPosition(2, 0);

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);
        }

        [Test]
        public void TestTryDropItemOnCursorIntoGridAtPlacesItemAtTargetPosition()
        {
            Weapon lootedWeapon = TestWeaponsProvider.CreateOneHandedStabbingSword();

            PutWeaponOnCursorViaMainHand(lootedWeapon);

            testCandidate.TryDropItemOnCursorIntoGridAt(3, 0);

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.Null);

            ItemInInventoryShape placedShape = Area.ActiveArea.Player.ItemInventory.InventoryGrid.GetItemAt(new PositionImmutable(3, 0));
            Assert.That(placedShape, Is.Not.Null);
            Assert.That(placedShape.Item, Is.EqualTo(lootedWeapon));
        }

        [Test]
        public void TestTryDropItemOnCursorIntoGridAtSwapsWithExistingItemInGrid()
        {
            Weapon initiallyPlacedWeapon = TestWeaponsProvider.CreateOneHandedSword();
            ItemInInventoryShape initiallyPlacedWeaponShape = initiallyPlacedWeapon.CreateInventoryShape();
            Area.ActiveArea.Player.ItemInventory.InventoryGrid.ReplaceItemAt(initiallyPlacedWeaponShape, new PositionImmutable(3, 2));

            Weapon secondWeapon = TestWeaponsProvider.CreateOneHandedStabbingSword();

            PutWeaponOnCursorViaMainHand(secondWeapon);

            testCandidate.TryDropItemOnCursorIntoGridAt(3, 0);

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(initiallyPlacedWeapon));

            ItemInInventoryShape placedShape = Area.ActiveArea.Player.ItemInventory.InventoryGrid.GetItemAt(new PositionImmutable(3, 0));
            Assert.That(placedShape, Is.Not.Null);
            Assert.That(placedShape.Item, Is.EqualTo(secondWeapon));
        }

        [Test]
        public void TestTryDropItemOnCursorIntoGridAtDoesNotPlaceItemWhenTargetOverlapsTwoDifferentItems()
        {
            Jewelry firstOverlappedItem = TestJewelryProvider.CreateRing();
            Jewelry secondOverlappedItem = TestJewelryProvider.CreateBelt();

            Area.ActiveArea.Player.ItemInventory.InventoryGrid.ReplaceItemAt(firstOverlappedItem.CreateInventoryShape(), new PositionImmutable(3, 2));
            Area.ActiveArea.Player.ItemInventory.InventoryGrid.ReplaceItemAt(secondOverlappedItem.CreateInventoryShape(), new PositionImmutable(4, 2));

            Weapon itemToBePlaced = TestWeaponsProvider.CreateTwoHandedSword();

            PutWeaponOnCursorViaMainHand(itemToBePlaced);

            testCandidate.TryDropItemOnCursorIntoGridAt(3, 2);

            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(itemToBePlaced));

            ItemInInventoryShape firstItemShape = Area.ActiveArea.Player.ItemInventory.InventoryGrid.GetItemAt(new PositionImmutable(3, 2));
            Assert.That(firstItemShape, Is.Not.Null);
            Assert.That(firstItemShape.Item, Is.EqualTo(firstOverlappedItem));

            ItemInInventoryShape secondItemShape = Area.ActiveArea.Player.ItemInventory.InventoryGrid.GetItemAt(new PositionImmutable(4, 2));
            Assert.That(secondItemShape, Is.Not.Null);
            Assert.That(secondItemShape.Item, Is.EqualTo(secondOverlappedItem));
        }

        private Weapon FillMainHandAndThreeGridSlotsWithStabbingSwords()
        {
            Weapon lootedWeaponOne = TestWeaponsProvider.CreateOneHandedStabbingSword();
            Weapon lootedWeaponTwo = TestWeaponsProvider.CreateOneHandedStabbingSword();
            Weapon lootedWeaponThree = TestWeaponsProvider.CreateOneHandedStabbingSword();
            Weapon lootedWeaponFour = TestWeaponsProvider.CreateOneHandedStabbingSword();

            Area.ActiveArea.Player.PickupEquipment(lootedWeaponOne);
            Area.ActiveArea.Player.PickupEquipment(lootedWeaponTwo);
            Area.ActiveArea.Player.PickupEquipment(lootedWeaponThree);

            Area.ActiveArea.Player.PickupEquipment(lootedWeaponFour);
            return lootedWeaponFour;
        }

        private Weapon PutWeaponOnCursorViaMainHand(Weapon weapon)
        {
            Area.ActiveArea.Player.PickupEquipment(weapon);
            testCandidate.SwapCursorItemWithMainHandEquipment();
            Assert.That(Area.ActiveArea.Player.ItemInventory.ItemOnCursor, Is.EqualTo(weapon));

            return weapon;
        }

        private void SetupMapAndPlayer()
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