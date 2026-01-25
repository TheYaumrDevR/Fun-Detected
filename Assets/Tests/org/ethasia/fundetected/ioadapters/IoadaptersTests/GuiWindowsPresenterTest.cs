using NUnit.Framework;

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
            GuiWindowsPresenter testCandidate = new GuiWindowsPresenter();

            testCandidate.OpenInventoryWindow(CreateSampleInventoryPresentationContext());

            GuiWindowsControllerMock guiWindowsControllerMock = TechnicalMockFactory.GetGuiWindowsControllerMockInstance();
            InventoryRenderContext result = guiWindowsControllerMock.LastOpenedInventoryContext;

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

            return new InventoryPresentationContext(equipmentSlotsContext);
        }
    }
}