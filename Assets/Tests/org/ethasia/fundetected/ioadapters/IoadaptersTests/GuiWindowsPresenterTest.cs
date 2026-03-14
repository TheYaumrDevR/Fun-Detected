using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Mocks;

namespace Org.Ethasia.Fundetected.Ioadapters.Tests
{
    public class GuiWindowsPresenterTest
    {
        [OneTimeSetUp] 
        public void Init()
        {
            TechnicalFactory.SetInstance(new TechnicalMockFactory());
        }

        [Test]
        public void TestOpenInventoryWindowCreatesProperRenderContext()
        {
            InventoryRenderContext result = ExecuteTest();

            EquipmentSlotsRenderContext equipmentSlotsContext = result.EquipmentSlotsRenderContext;

            Assert.That(equipmentSlotsContext.MainHand.ItemImagePath, Is.EqualTo("sword_icon"));
            Assert.That(equipmentSlotsContext.MainHand.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.OffHand.ItemImagePath, Is.Null);
            Assert.That(equipmentSlotsContext.OffHand.IsEquipped, Is.False);
            Assert.That(equipmentSlotsContext.Head.ItemImagePath, Is.EqualTo("helmet_icon"));
            Assert.That(equipmentSlotsContext.Head.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.Chest.ItemImagePath, Is.Null);
            Assert.That(equipmentSlotsContext.Chest.IsEquipped, Is.False);
            Assert.That(equipmentSlotsContext.Hands.ItemImagePath, Is.EqualTo("gloves_icon"));
            Assert.That(equipmentSlotsContext.Hands.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.Feet.ItemImagePath, Is.Null);
            Assert.That(equipmentSlotsContext.Feet.IsEquipped, Is.False);
            Assert.That(equipmentSlotsContext.Belt.ItemImagePath, Is.EqualTo("belt_icon"));
            Assert.That(equipmentSlotsContext.Belt.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.LeftRing.ItemImagePath, Is.EqualTo("left_ring_icon"));
            Assert.That(equipmentSlotsContext.LeftRing.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.RightRing.ItemImagePath, Is.EqualTo("right_ring_icon"));
            Assert.That(equipmentSlotsContext.RightRing.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.Neck.ItemImagePath, Is.EqualTo("necklace_icon"));
            Assert.That(equipmentSlotsContext.Neck.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.LeftMostPotion.ItemImagePath, Is.EqualTo("left_most_potion_icon"));
            Assert.That(equipmentSlotsContext.LeftMostPotion.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.LeftMiddlePotion.ItemImagePath, Is.EqualTo("left_middle_potion_icon"));
            Assert.That(equipmentSlotsContext.LeftMiddlePotion.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.MiddlePotion.ItemImagePath, Is.EqualTo("middle_potion_icon"));
            Assert.That(equipmentSlotsContext.MiddlePotion.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.RightMiddlePotion.ItemImagePath, Is.EqualTo("right_middle_potion_icon"));
            Assert.That(equipmentSlotsContext.RightMiddlePotion.IsEquipped, Is.True);
            Assert.That(equipmentSlotsContext.RightMostPotion.ItemImagePath, Is.EqualTo("right_most_potion_icon"));
            Assert.That(equipmentSlotsContext.RightMostPotion.IsEquipped, Is.True);
        }

        [Test]
        public void TestOpenInventoryWindowConvertsInventoryGridRenderContext()
        {
            InventoryRenderContext result = ExecuteTest();

            InventoryGridRenderContext inventoryGridRenderContext = result.InventoryGridRenderContext;      

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 0].CanBeEquipped, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 0].ItemImageName, Is.EqualTo("first_item_icon"));
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 1].CanBeEquipped, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 1].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 2].CanBeEquipped, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 2].ItemImageName, Is.EqualTo("second_item_icon"));
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 3].CanBeEquipped, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 3].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 4].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[0, 4].ItemImageName, Is.EqualTo("third_item_icon"));

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 0].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 0].ItemImageName, Is.EqualTo("fourth_item_icon"));
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 1].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 1].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 2].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 2].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 3].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 3].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 4].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[1, 4].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 0].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 0].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 1].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 1].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 2].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 2].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 3].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 3].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 4].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[2, 4].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 0].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 0].ItemImageName, Is.EqualTo("fifth_item_icon"));
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 1].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 1].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 2].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 2].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 3].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 3].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 4].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[3, 4].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 0].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 0].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 1].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 1].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 2].CanBeEquipped, Is.True);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 2].ItemImageName, Is.Null);

            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 3].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 3].ItemImageName, Is.Null);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 4].ShouldRenderSomething, Is.False);
            Assert.That(inventoryGridRenderContext.SlotRenderContexts[4, 4].ItemImageName, Is.Null);
        }

        private InventoryRenderContext ExecuteTest()
        {
            GuiWindowsPresenter testCandidate = new GuiWindowsPresenter();

            testCandidate.OpenInventoryWindow(CreateSampleInventoryPresentationContext());

            GuiWindowsControllerMock guiWindowsControllerMock = TechnicalMockFactory.GetGuiWindowsControllerMockInstance();
            return guiWindowsControllerMock.LastOpenedInventoryContext;            
        }

        private InventoryPresentationContext CreateSampleInventoryPresentationContext()
        {
            InventoryItemPresentationContext mainHandItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("sword_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedWeaponPresentationContext mainHandContext = new EquippedWeaponPresentationContext.Builder()
                .WithItemPresentationContext(mainHandItemContext)
                .WithSlotPosition(EquipmentSlotPositions.MAIN_HAND)
                .Build();

            InventoryItemPresentationContext offHandItemContext = new InventoryItemPresentationContext.Builder()
                .WithCanBeEquipped(false)
                .Build();

            EquippedWeaponPresentationContext offHandContext = new EquippedWeaponPresentationContext.Builder()
                .WithItemPresentationContext(offHandItemContext)
                .WithSlotPosition(EquipmentSlotPositions.OFF_HAND)
                .Build();

            InventoryItemPresentationContext headItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("helmet_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedArmorPresentationContext headContext = new EquippedArmorPresentationContext.Builder()
                .WithItemPresentationContext(headItemContext)
                .WithSlotPosition(EquipmentSlotPositions.HEAD)
                .Build();

            InventoryItemPresentationContext chestItemContext = new InventoryItemPresentationContext.Builder()
                .WithCanBeEquipped(false)
                .Build();

            EquippedArmorPresentationContext chestContext = new EquippedArmorPresentationContext.Builder()
                .WithItemPresentationContext(chestItemContext)
                .WithSlotPosition(EquipmentSlotPositions.CHEST)
                .Build();

            InventoryItemPresentationContext handsItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("gloves_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedArmorPresentationContext handsContext = new EquippedArmorPresentationContext.Builder()
                .WithItemPresentationContext(handsItemContext)
                .WithSlotPosition(EquipmentSlotPositions.HANDS)
                .Build();

            InventoryItemPresentationContext feetItemContext = new InventoryItemPresentationContext.Builder()
                .WithCanBeEquipped(false)
                .Build();

            EquippedArmorPresentationContext feetContext = new EquippedArmorPresentationContext.Builder()
                .WithItemPresentationContext(feetItemContext)
                .WithSlotPosition(EquipmentSlotPositions.FEET)
                .Build();

            InventoryItemPresentationContext beltItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("belt_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedJewelryPresentationContext beltContext = new EquippedJewelryPresentationContext.Builder()
                .WithItemPresentationContext(beltItemContext)
                .WithSlotPosition(EquipmentSlotPositions.BELT)
                .Build();

            InventoryItemPresentationContext leftRingItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("left_ring_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedJewelryPresentationContext leftRingContext = new EquippedJewelryPresentationContext.Builder()
                .WithItemPresentationContext(leftRingItemContext)
                .WithSlotPosition(EquipmentSlotPositions.LEFT_RING)
                .Build();

            InventoryItemPresentationContext rightRingItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("right_ring_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedJewelryPresentationContext rightRingContext = new EquippedJewelryPresentationContext.Builder()
                .WithItemPresentationContext(rightRingItemContext)
                .WithSlotPosition(EquipmentSlotPositions.RIGHT_RING)
                .Build();

            InventoryItemPresentationContext necklaceItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("necklace_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedJewelryPresentationContext necklaceContext = new EquippedJewelryPresentationContext.Builder()
                .WithItemPresentationContext(necklaceItemContext)
                .WithSlotPosition(EquipmentSlotPositions.AMULET)
                .Build();

            InventoryItemPresentationContext leftMostPotionItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("left_most_potion_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedRecoveryPotionPresentationContext leftMostPotionContext = new EquippedRecoveryPotionPresentationContext.Builder()
                .WithItemPresentationContext(leftMostPotionItemContext)
                .WithSlotPosition(EquipmentSlotPositions.OUTER_LEFT_POTION)
                .Build();

            InventoryItemPresentationContext leftMiddlePotionItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("left_middle_potion_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedRecoveryPotionPresentationContext leftMiddlePotionContext = new EquippedRecoveryPotionPresentationContext.Builder()
                .WithItemPresentationContext(leftMiddlePotionItemContext)
                .WithSlotPosition(EquipmentSlotPositions.MIDDLE_LEFT_POTION)
                .Build();

            InventoryItemPresentationContext middlePotionItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("middle_potion_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedRecoveryPotionPresentationContext middlePotionContext = new EquippedRecoveryPotionPresentationContext.Builder()
                .WithItemPresentationContext(middlePotionItemContext)
                .WithSlotPosition(EquipmentSlotPositions.MIDDLE_POTION)
                .Build();

            InventoryItemPresentationContext rightMiddlePotionItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("right_middle_potion_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedRecoveryPotionPresentationContext rightMiddlePotionContext = new EquippedRecoveryPotionPresentationContext.Builder()
                .WithItemPresentationContext(rightMiddlePotionItemContext)
                .WithSlotPosition(EquipmentSlotPositions.MIDDLE_RIGHT_POTION)
                .Build();

            InventoryItemPresentationContext rightMostPotionItemContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("right_most_potion_icon")
                .WithCanBeEquipped(true)
                .Build();

            EquippedRecoveryPotionPresentationContext rightMostPotionContext = new EquippedRecoveryPotionPresentationContext.Builder()
                .WithItemPresentationContext(rightMostPotionItemContext)
                .WithSlotPosition(EquipmentSlotPositions.OUTER_RIGHT_POTION)
                .Build();

            EquipmentSlotsPresentationContext equipmentSlotsContext = new EquipmentSlotsPresentationContext.Builder()
                .AddEquippedWeapon(mainHandContext)
                .AddEquippedWeapon(offHandContext)
                .AddEquippedArmor(headContext)
                .AddEquippedArmor(chestContext)
                .AddEquippedArmor(handsContext)
                .AddEquippedArmor(feetContext)
                .AddEquippedJewelry(beltContext)
                .AddEquippedJewelry(leftRingContext)
                .AddEquippedJewelry(rightRingContext)
                .AddEquippedJewelry(necklaceContext)
                .AddEquippedRecoveryPotion(leftMostPotionContext)
                .AddEquippedRecoveryPotion(leftMiddlePotionContext)
                .AddEquippedRecoveryPotion(middlePotionContext)
                .AddEquippedRecoveryPotion(rightMiddlePotionContext)
                .AddEquippedRecoveryPotion(rightMostPotionContext)
                .Build();

            return new InventoryPresentationContext(equipmentSlotsContext, CreateInventoryGridPresentationContextForTesting());
        }

        private InventoryGridPresentationContext CreateInventoryGridPresentationContextForTesting()
        {
            InventoryItemPresentationContext firstItemPresentationContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("first_item_icon")
                .WithCanBeEquipped(false)
                .WithTopLeftCornerX(0)
                .WithTopLeftCornerY(0)
                .WithDimensionX(1)
                .WithDimensionY(2)
                .Build();

            WeaponPresentationContext weaponPresentationContext = new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .WithMinToMaxSpellDamage(new DamageRange(0, 0))
                .WithSkillsPerSecond(1.4f)
                .WithCriticalStrikeChance(500)
                .Build();

            InventoryWeaponPresentationContext weaponContext1 = new InventoryWeaponPresentationContext.Builder()
                .WithWeaponContext(weaponPresentationContext)
                .WithItemContext(firstItemPresentationContext)
                .Build();

            InventoryItemPresentationContext secondItemPresentationContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("second_item_icon")
                .WithCanBeEquipped(false)
                .WithTopLeftCornerX(0)
                .WithTopLeftCornerY(2)
                .WithDimensionX(1)
                .WithDimensionY(2)
                .Build();

            WeaponPresentationContext weaponPresentationContext2 = new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(new DamageRange(0, 0))
                .WithMinToMaxSpellDamage(new DamageRange(6, 14))
                .WithSkillsPerSecond(1.5f)
                .WithCriticalStrikeChance(400)
                .Build();

            InventoryWeaponPresentationContext weaponContext2 = new InventoryWeaponPresentationContext.Builder()
                .WithWeaponContext(weaponPresentationContext2)
                .WithItemContext(secondItemPresentationContext)
                .Build();

            InventoryItemPresentationContext thirdItemPresentationContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("third_item_icon")
                .WithCanBeEquipped(true)
                .WithTopLeftCornerX(0)
                .WithTopLeftCornerY(4)
                .WithDimensionX(1)
                .WithDimensionY(1)
                .Build();

            ArmorPresentationContext armorPresentationContext = new ArmorPresentationContext.Builder()
                .WithArmorValue(5)
                .WithMovementSpeedAddend(3)
                .Build();

            InventoryArmorPresentationContext armorContext1 = new InventoryArmorPresentationContext.Builder()
                .WithArmorContext(armorPresentationContext)
                .WithItemContext(thirdItemPresentationContext)
                .Build();

            InventoryItemPresentationContext fourthItemPresentationContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("fourth_item_icon")
                .WithCanBeEquipped(true)
                .WithTopLeftCornerX(1)
                .WithTopLeftCornerY(0)
                .WithDimensionX(2)
                .WithDimensionY(3)
                .Build();

            RecoveryPotionPresentationContext recoveryPotionContext = new RecoveryPotionPresentationContext.Builder()
                .WithRecoveryAmount(20)
                .WithUses(2)
                .Build();

            InventoryRecoveryPotionPresentationContext recoveryPotionContext1 = new InventoryRecoveryPotionPresentationContext.Builder()
                .WithRecoveryPotionContext(recoveryPotionContext)
                .WithItemContext(fourthItemPresentationContext)
                .Build();

            InventoryItemPresentationContext fifthItemPresentationContext = new InventoryItemPresentationContext.Builder()
                .WithItemId("fifth_item_icon")
                .WithCanBeEquipped(true)
                .WithTopLeftCornerX(3)
                .WithTopLeftCornerY(0)
                .WithDimensionX(2)
                .WithDimensionY(3)
                .Build();

            InventoryGridPresentationContext result = new InventoryGridPresentationContext();

            result.AddWeaponPresentationContext(weaponContext1);
            result.AddWeaponPresentationContext(weaponContext2);
            result.AddArmorPresentationContext(armorContext1);
            result.AddRecoveryPotionPresentationContext(recoveryPotionContext1);
            result.AddJewelryPresentationContext(fifthItemPresentationContext);

            return result;
        }
    }
}