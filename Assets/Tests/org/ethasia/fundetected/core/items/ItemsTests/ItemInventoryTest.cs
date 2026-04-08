using NUnit.Framework;
using System;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Map;

using EquipmentItem = Org.Ethasia.Fundetected.Core.Equipment.Equipment;

namespace Org.Ethasia.Fundetected.Core.Items.Tests
{
    public class ItemInventoryTest
    {
        private static readonly object[] EquipmentSlotTestedMethods = new object[]
        {
            new object[] { "MainHand", (Action<ItemInventory>)(inv => inv.SwapCursorItemWithMainHandEquipment()) },
            new object[] { "OffHand", (Action<ItemInventory>)(inv => inv.SwapCursorItemWithOffHandEquipment()) },
            new object[] { "LeftRing", (Action<ItemInventory>)(inv => inv.SwapCursorItemWithLeftRingEquipment()) },
            new object[] { "RightRing", (Action<ItemInventory>)(inv => inv.SwapCursorItemWithRightRingEquipment()) },
            new object[] { "Belt", (Action<ItemInventory>)(inv => inv.SwapCursorItemWithBeltEquipment()) }
        };

        [TestCaseSource(nameof(EquipmentSlotTestedMethods))]
        public void TestSwapCursorItemPicksUpItemInSlot(string slotName, Action<ItemInventory> swapAction)
        {
            ItemInventory testCandidate = new ItemInventory();
            var equipment = CreateEquipmentForSlot(slotName);
            
            testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(equipment);
            if (slotName == "OffHand" || slotName == "RightRing") // Must equip another item to fill offhand or right ring
            {
                testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(equipment);
            }

            swapAction(testCandidate);

            Assert.That(testCandidate.ItemOnCursor == equipment);
        }

        [TestCaseSource(nameof(EquipmentSlotTestedMethods))]
        public void TestSwapCursorItemSwapsEquipment(string slotName, Action<ItemInventory> swapAction)
        {
            ItemInventory testCandidate = new ItemInventory();
            var originalEquipment = CreateEquipmentForSlot(slotName);
            var newEquipment = CreateSecondEquipmentForSlot(slotName);

            testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(originalEquipment);
            if (slotName == "OffHand" || slotName == "RightRing") 
            {
                testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(originalEquipment);
            }

            swapAction(testCandidate);
            Assert.That(testCandidate.ItemOnCursor == originalEquipment);

            testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(newEquipment);

            swapAction(testCandidate);
            Assert.That(testCandidate.ItemOnCursor == newEquipment);
        }

        [Test]
        public void TestSwapCursorItemWithMainHandEquipmentDoesNotSwapIncompatibleItemClass()
        {
            TestIncompatibleEquipmentSwap("MainHand", 
                inv => inv.SwapCursorItemWithMainHandEquipment(),
                inv => inv.SwapCursorItemWithLeftRingEquipment());
        }

        [Test]
        public void TestSwapCursorItemWithOffHandEquipmentDoesNotSwapIncompatibleItemClass()
        {
            TestIncompatibleEquipmentSwap("OffHand",
                inv => inv.SwapCursorItemWithOffHandEquipment(),
                inv => inv.SwapCursorItemWithLeftRingEquipment());
        }

        [Test]
        public void TestSwapCursorItemWithLeftRingEquipmentDoesNotSwapIncompatibleItemClass()
        {
            TestIncompatibleEquipmentSwap("LeftRing",
                inv => inv.SwapCursorItemWithLeftRingEquipment(),
                inv => inv.SwapCursorItemWithBeltEquipment());
        }

        [Test]
        public void TestSwapCursorItemWithRightRingEquipmentDoesNotSwapIncompatibleItemClass()
        {
            TestIncompatibleEquipmentSwap("RightRing",
                inv => inv.SwapCursorItemWithRightRingEquipment(),
                inv => inv.SwapCursorItemWithBeltEquipment());
        }

        [Test]
        public void TestSwapCursorItemWithBeltEquipmentDoesNotSwapIncompatibleItemClass()
        {
            TestIncompatibleEquipmentSwap("Belt",
                inv => inv.SwapCursorItemWithBeltEquipment(),
                inv => inv.SwapCursorItemWithMainHandEquipment());
        }

        private void TestIncompatibleEquipmentSwap(string compatibleSlot, 
            Action<ItemInventory> targetSlotAction,
            Action<ItemInventory> incompatibleSlotAction)
        {
            ItemInventory testCandidate = new ItemInventory();

            var compatibleEquipment = CreateEquipmentForSlot(compatibleSlot);
            var incompatibleEquipment = CreateIncompatibleEquipmentForSlot(compatibleSlot);

            testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(compatibleEquipment);
            if (compatibleSlot == "OffHand" || compatibleSlot == "RightRing")
            {
                testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(compatibleEquipment);
            }

            testCandidate.EquippedItems.EquipIntoFreeSlotBasedOnItemClass(incompatibleEquipment);
            incompatibleSlotAction(testCandidate);

            Assert.That(testCandidate.ItemOnCursor == incompatibleEquipment);

            targetSlotAction(testCandidate);

            Assert.That(testCandidate.ItemOnCursor == incompatibleEquipment);
        }

        private EquipmentItem CreateEquipmentForSlot(string slotName)
        {
            return slotName switch
            {
                "MainHand" or "OffHand" => CreateWeapon("Five Finger Claw", ItemClass.FIST_WEAPON, new DamageRange(7, 54)),
                "LeftRing" or "RightRing" => CreateRingWithImplicit("Testing Ring"),
                "Belt" => CreateBeltWithStrImplicit("Leather Belt"),
                _ => throw new ArgumentException($"Unknown slot: {slotName}")
            };
        }

        private EquipmentItem CreateSecondEquipmentForSlot(string slotName)
        {
            return slotName switch
            {
                "MainHand" => CreateWeapon("Hunter Bow", ItemClass.BOW, new DamageRange(3, 9)),
                "OffHand" => CreateWeapon("Punching Iron", ItemClass.FIST_WEAPON, new DamageRange(2, 7)),
                "LeftRing" or "RightRing" => CreateRingWithImplicit("Incompatible Ring"),
                "Belt" => CreateBeltWithStrImplicit("Leather Belt"),
                _ => throw new ArgumentException($"Unknown slot: {slotName}")
            };
        }

        private EquipmentItem CreateIncompatibleEquipmentForSlot(string slotName)
        {
            return slotName switch
            {
                "MainHand" or "OffHand" => CreateRingWithImplicit("Incompatibility Ring"),
                "LeftRing" or "RightRing" => CreateBeltWithStrImplicit("Leather Belt"),
                "Belt" => CreateWeapon("Five Finger Claw", ItemClass.FIST_WEAPON, new DamageRange(7, 54)),
                _ => CreateRingWithImplicit("Default Incompatible")
            };
        }

        private Weapon CreateWeapon(string name, ItemClass itemClass, DamageRange damage = null)
        {
            var builder = new Weapon.Builder();

            builder.SetName(name)
                .SetItemClass(itemClass);
            
            if (damage != null)
                builder.SetMinToMaxPhysicalDamage(damage);
                
            return builder.Build();
        }

        private Jewelry CreateRingWithImplicit(string name)
        {
            var builder = new Jewelry.Builder();

            PlusMinMaxGlobalPhysicalDamageWithAttacksAffix actualAffix = new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(2, 16);
            IntegerIntervalMinMaxIncrementRollableEquipmentAffix implicitAffix = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(actualAffix)
                .SetLowerBoundMinValue(1)
                .SetUpperBoundMaxValue(5)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(10)
                .SetUpperBoundMaxValue(150)
                .SetUpperBoundIncrement(1)
                .Build();

            builder.SetName(name)
                .SetItemClass(ItemClass.RING);

            builder.SetFirstImplicit(implicitAffix);

            return builder.Build();
        }

        private Jewelry CreateBeltWithStrImplicit(string name)
        {
            var builder = new Jewelry.Builder();

            PlusStrengthAffix actualAffix = new PlusStrengthAffix(41);
            IntegerMinMaxIncrementRollableEquipmentAffix implicitAffix = new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(actualAffix)
                .SetMinValue(1)
                .SetMaxValue(60)
                .SetIncrement(1)
                .Build();

            builder.SetName(name)
                .SetItemClass(ItemClass.BELT);

            builder.SetFirstImplicit(implicitAffix);

            return builder.Build();
        }
    }
}