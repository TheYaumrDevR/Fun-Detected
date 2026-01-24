using NUnit.Framework;
using System.Collections;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation.Tests
{
    public class InventoryDisplayInteractorTest
    {
        [Test]
        public void TestCreateInventoryPresentationContextConvertsMainHandCorrectly()
        {
            string itemName = "Bonking Staff";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Weapon mainHandWeapon = CreateTestWeapon(itemName, ItemClass.MARTIAL_STAFF);

            playerCharacter.PickupEquipment(mainHandWeapon);
            PlayerEquipmentItemsExtractionVisitor itemExtractionVisitor = playerCharacter.CreateItemExtractionVisitor();

            InventoryDisplayInteractorWithCreatedPresentationContext testCandidate = new InventoryDisplayInteractorWithCreatedPresentationContext(itemExtractionVisitor);
            testCandidate.ExtractAndShowInventory();

            InventoryPresentationContext createdContext = testCandidate.LastCreatedContext;
            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = createdContext.EquipmentSlotsPresentationContext;

            Assert.That(createdContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.MainHand.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.MainHand.IsLegallyEquipped, Is.True);

            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatBeltIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        private PlayerCharacter CreateTestPlayer()
        {
            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .Build(); 
        }

        private Weapon CreateTestWeapon(string itemId, ItemClass weaponClass)
        {
            DamageRange weaponDamageRange = new DamageRange(5, 10);

            Weapon.Builder weaponBuilder = new Weapon.Builder();
            weaponBuilder.SetName(itemId);

            weaponBuilder.SetItemClass(weaponClass);
            weaponBuilder.SetMinToMaxPhysicalDamage(weaponDamageRange);

            return weaponBuilder.Build();
        }

        private void AssertThatMainHandIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.MainHand.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.MainHand.IsLegallyEquipped, Is.False);
        }

        private void AssertThatOffHandIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.OffHand.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.OffHand.IsLegallyEquipped, Is.False);
        }

        private void AssertThatLeftRingIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.LeftRing.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.LeftRing.IsLegallyEquipped, Is.False);
        }

        private void AssertThatRightRingIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.RightRing.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.RightRing.IsLegallyEquipped, Is.False);
        }

        private void AssertThatNeckIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Neck.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Neck.IsLegallyEquipped, Is.False);
        }

        private void AssertThatBeltIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Belt.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Belt.IsLegallyEquipped, Is.False);
        }

        private void AssertThatHeadIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Head.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Head.IsLegallyEquipped, Is.False);
        }

        private void AssertThatHandsAreEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Hands.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Hands.IsLegallyEquipped, Is.False);
        }

        private void AssertThatFeetAreEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Feet.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Feet.IsLegallyEquipped, Is.False);
        }

        private void AssertThatLeftMostPotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.LeftMostPotion.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.LeftMostPotion.IsLegallyEquipped, Is.False);
        }

        private void AssertThatLeftMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.LeftMiddlePotion.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.LeftMiddlePotion.IsLegallyEquipped, Is.False);
        }

        private void AssertThatMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.MiddlePotion.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.MiddlePotion.IsLegallyEquipped, Is.False);
        }

        private void AssertThatRightMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.RightMiddlePotion.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.RightMiddlePotion.IsLegallyEquipped, Is.False);
        }

        private void AssertThatRightMostPotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.RightMostPotion.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.RightMostPotion.IsLegallyEquipped, Is.False);
        }

        private class InventoryDisplayInteractorWithCreatedPresentationContext : InventoryDisplayInteractor
        {
            private PlayerEquipmentItemsExtractionVisitor itemsExtractionVisitor;

            public InventoryPresentationContext LastCreatedContext
            {
                get;
                private set;
            }

            public InventoryDisplayInteractorWithCreatedPresentationContext(PlayerEquipmentItemsExtractionVisitor itemsExtractionVisitor)
            {
                this.itemsExtractionVisitor = itemsExtractionVisitor;
            }

            public override void ExtractAndShowInventory()
            {
                LastCreatedContext = CreateInventoryPresentationContext(itemsExtractionVisitor);
            }
        }
    }
}