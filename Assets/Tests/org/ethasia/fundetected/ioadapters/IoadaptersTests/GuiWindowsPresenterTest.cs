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
            EquipmentSlotPresentationContext mainHandContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("sword_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext offHandContext = new EquipmentSlotPresentationContext.Builder()
                .SetIsLegallyEquipped(false)
                .Build();

            EquipmentSlotPresentationContext headContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("helmet_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext chestContext = new EquipmentSlotPresentationContext.Builder()
                .SetIsLegallyEquipped(false)
                .Build();

            EquipmentSlotPresentationContext handsContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("gloves_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext feetContext = new EquipmentSlotPresentationContext.Builder()
                .SetIsLegallyEquipped(false)
                .Build();

            EquipmentSlotPresentationContext beltContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("belt_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext leftRingContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("left_ring_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext rightRingContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("right_ring_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext necklaceContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("necklace_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext leftMostPotionContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("left_most_potion_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext leftMiddlePotionContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("left_middle_potion_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext middlePotionContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("middle_potion_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext rightMiddlePotionContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("right_middle_potion_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotPresentationContext rightMostPotionContext = new EquipmentSlotPresentationContext.Builder()
                .SetItemId("right_most_potion_icon")
                .SetIsLegallyEquipped(true)
                .Build();

            EquipmentSlotsPresentationContext equipmentSlotsContext = new EquipmentSlotsPresentationContext.Builder()
                .SetMainHand(mainHandContext)
                .SetOffHand(offHandContext)
                .SetHead(headContext)
                .SetChest(chestContext)
                .SetHands(handsContext)
                .SetFeet(feetContext)
                .SetBelt(beltContext)
                .SetLeftRing(leftRingContext)
                .SetRightRing(rightRingContext)
                .SetNeck(necklaceContext)
                .SetLeftMostPotion(leftMostPotionContext)
                .SetLeftMiddlePotion(leftMiddlePotionContext)
                .SetMiddlePotion(middlePotionContext)
                .SetRightMiddlePotion(rightMiddlePotionContext)
                .SetRightMostPotion(rightMostPotionContext)
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

            InventoryWeaponPresentationContext weaponContext1 = new InventoryWeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .WithMinToMaxSpellDamage(new DamageRange(0, 0))
                .WithSkillsPerSecond(1.4f)
                .WithCriticalStrikeChance(500)
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

            InventoryWeaponPresentationContext weaponContext2 = new InventoryWeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(new DamageRange(0, 0))
                .WithMinToMaxSpellDamage(new DamageRange(6, 14))
                .WithSkillsPerSecond(1.5f)
                .WithCriticalStrikeChance(400)
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

            InventoryArmorPresentationContext armorContext1 = new InventoryArmorPresentationContext.Builder()
                .WithArmorValue(5)
                .WithMovementSpeedAddend(3)
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

            InventoryRecoveryPotionPresentationContext recoveryPotionContext1 = new InventoryRecoveryPotionPresentationContext.Builder()
                .WithRecoveryAmount(20)
                .WithUses(2)
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