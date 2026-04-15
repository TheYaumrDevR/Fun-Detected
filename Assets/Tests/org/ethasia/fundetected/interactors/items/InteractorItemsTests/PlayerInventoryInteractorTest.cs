using NUnit.Framework;
using System;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
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