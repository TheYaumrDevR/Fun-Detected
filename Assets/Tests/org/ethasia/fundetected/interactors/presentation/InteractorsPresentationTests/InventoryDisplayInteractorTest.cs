using NUnit.Framework;
using System.Collections;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
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
            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.MainHand.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.MainHand.IsLegallyEquipped, Is.True);

            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatBeltIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatChestIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsOffHandCorrectly()
        {
            string itemName = "Exceptional Mace";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Weapon mainHandWeapon = CreateTestWeapon("Fine Mace", ItemClass.ONE_HANDED_MACE);
            Weapon offHandWeapon = CreateTestWeapon(itemName, ItemClass.ONE_HANDED_MACE);

            playerCharacter.PickupEquipment(mainHandWeapon);
            playerCharacter.PickupEquipment(offHandWeapon);

            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.OffHand.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.OffHand.IsLegallyEquipped, Is.True);

            AssertThatLeftRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatBeltIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatChestIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsLeftRingCorrectly()
        {
            string itemName = "Ruby Ring";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Jewelry leftRing = CreateTestJewelry(itemName, ItemClass.RING);

            playerCharacter.PickupEquipment(leftRing);

            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.LeftRing.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.LeftRing.IsLegallyEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatBeltIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatChestIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsRightRingCorrectly()
        {
            string itemName = "Gold Ring";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Jewelry leftRing = CreateTestJewelry("Ruby Ring", ItemClass.RING);
            Jewelry rightRing = CreateTestJewelry(itemName, ItemClass.RING);

            playerCharacter.PickupEquipment(leftRing);
            playerCharacter.PickupEquipment(rightRing);

            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.RightRing.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.RightRing.IsLegallyEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatBeltIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatChestIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsBeltCorrectly()
        {
            string itemName = "Plated Belt";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Jewelry belt = CreateTestJewelry(itemName, ItemClass.BELT);

            playerCharacter.PickupEquipment(belt);

            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext, Is.Not.Null);
            Assert.That(equipmentSlotsPresentationContext.Belt.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.Belt.IsLegallyEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftRingIsEmpty(equipmentSlotsPresentationContext);
            AssertThatNeckIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHeadIsEmpty(equipmentSlotsPresentationContext);
            AssertThatChestIsEmpty(equipmentSlotsPresentationContext);
            AssertThatHandsAreEmpty(equipmentSlotsPresentationContext);
            AssertThatFeetAreEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMostPotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatLeftMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMiddlePotionIsEmpty(equipmentSlotsPresentationContext);
            AssertThatRightMostPotionIsEmpty(equipmentSlotsPresentationContext);
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsInventoryGridCorrectly()
        {
            PlayerCharacter playerCharacter = CreateTestPlayer();

            RecoveryPotion potion1 = CreateTestRecoveryPotion("Life Potion");
            RecoveryPotion potion2 = CreateTestRecoveryPotion("Mana Potion");

            Jewelry ring1 = CreateTestJewelry("Ruby Ring", ItemClass.RING);
            Jewelry ring2 = CreateTestJewelry("Emerald Ring", ItemClass.RING);
            Jewelry ring3 = CreateTestJewelry("Sapphire Ring", ItemClass.RING);

            Weapon weapon1 = CreateTestWeapon("Sharp Axe", ItemClass.ONE_HANDED_AXE);
            Weapon weapon2 = CreateTestWeapon("Steel Axe", ItemClass.ONE_HANDED_AXE);
            Weapon weapon3 = CreateTestWeapon("Cutlass", ItemClass.ONE_HANDED_SWORD);
            Weapon weapon4 = CreateTestWeapon("The Mirage", ItemClass.ONE_HANDED_SWORD);

            playerCharacter.PickupPotion(potion1);
            playerCharacter.PickupPotion(potion2);
            playerCharacter.PickupEquipment(ring1);
            playerCharacter.PickupEquipment(ring2);
            playerCharacter.PickupEquipment(ring3);
            playerCharacter.PickupEquipment(weapon1);
            playerCharacter.PickupEquipment(weapon2);
            playerCharacter.PickupEquipment(weapon3);
            playerCharacter.PickupEquipment(weapon4);

            InventoryGridPresentationContext inventoryGridPresentationContext = CallInventoryGridExtraction(playerCharacter);

            Assert.That(inventoryGridPresentationContext.WeaponsPresentationContexts.Count, Is.EqualTo(2));
            Assert.That(inventoryGridPresentationContext.ArmorsPresentationContexts, Is.Null);
            Assert.That(inventoryGridPresentationContext.JewelriesPresentationContexts.Count, Is.EqualTo(1));
            Assert.That(inventoryGridPresentationContext.RecoveryPotionsPresentationContexts.Count, Is.EqualTo(2));

            InventoryItemPresentationContext firstResult = inventoryGridPresentationContext.WeaponsPresentationContexts[0].ItemContext;
            InventoryItemPresentationContext secondResult = inventoryGridPresentationContext.WeaponsPresentationContexts[1].ItemContext;
            InventoryItemPresentationContext thirdResult = inventoryGridPresentationContext.JewelriesPresentationContexts[0];
            InventoryItemPresentationContext fourthResult = inventoryGridPresentationContext.RecoveryPotionsPresentationContexts[0].ItemContext;
            InventoryItemPresentationContext fifthResult = inventoryGridPresentationContext.RecoveryPotionsPresentationContexts[1].ItemContext;

            Assert.That(firstResult.ItemId, Is.EqualTo("Cutlass"));
            Assert.That(firstResult.TopLeftCornerX, Is.EqualTo(1));
            Assert.That(firstResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(firstResult.DimensionX, Is.EqualTo(2));
            Assert.That(firstResult.DimensionY, Is.EqualTo(3));

            Assert.That(secondResult.ItemId, Is.EqualTo("The Mirage"));
            Assert.That(secondResult.TopLeftCornerX, Is.EqualTo(3));
            Assert.That(secondResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(secondResult.DimensionX, Is.EqualTo(2));
            Assert.That(secondResult.DimensionY, Is.EqualTo(3));

            Assert.That(thirdResult.ItemId, Is.EqualTo("Sapphire Ring"));
            Assert.That(thirdResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(thirdResult.TopLeftCornerY, Is.EqualTo(4));
            Assert.That(thirdResult.DimensionX, Is.EqualTo(1));
            Assert.That(thirdResult.DimensionY, Is.EqualTo(1));

            Assert.That(fourthResult.ItemId, Is.EqualTo("Life Potion"));
            Assert.That(fourthResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(fourthResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(fourthResult.DimensionX, Is.EqualTo(1));
            Assert.That(fourthResult.DimensionY, Is.EqualTo(2));

            Assert.That(fifthResult.ItemId, Is.EqualTo("Mana Potion"));
            Assert.That(fifthResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(fifthResult.TopLeftCornerY, Is.EqualTo(2));
            Assert.That(fifthResult.DimensionX, Is.EqualTo(1));
            Assert.That(fifthResult.DimensionY, Is.EqualTo(2));
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

        private Jewelry CreateTestJewelry(string itemId, ItemClass jewelryClass)
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetName(itemId);
            jewelryBuilder.SetItemClass(jewelryClass);

            return jewelryBuilder.Build();
        }

        private RecoveryPotion CreateTestRecoveryPotion(string itemId)
        {
            RecoveryPotion.Builder potionBuilder = new RecoveryPotion.Builder();
            potionBuilder.SetName(itemId);
            potionBuilder.SetItemClass(ItemClass.LIFE_POTION);

            return potionBuilder.Build();
        }

        private EquipmentSlotsPresentationContext CallEquipmentExtraction(PlayerCharacter playerCharacter)
        {
            InventoryPresentationContext createdContext = CallInventoryExtraction(playerCharacter);
            return createdContext.EquipmentSlotsPresentationContext;
        }

        private InventoryGridPresentationContext CallInventoryGridExtraction(PlayerCharacter playerCharacter)
        {
            InventoryPresentationContext createdContext = CallInventoryExtraction(playerCharacter);
            return createdContext.InventoryGridPresentationContext;
        }

        private InventoryPresentationContext CallInventoryExtraction(PlayerCharacter playerCharacter)
        {
            PlayerEquipmentItemsExtractionVisitor itemExtractionVisitor = playerCharacter.CreateItemExtractionVisitor();
            ItemInventoryExtractionVisitor inventoryExtractionVisitor = playerCharacter.CreateInventoryItemExtractionVisitor();

            InventoryDisplayInteractorWithCreatedPresentationContext testCandidate = new InventoryDisplayInteractorWithCreatedPresentationContext(itemExtractionVisitor, inventoryExtractionVisitor);
            testCandidate.ExtractAndShowInventory();

            return testCandidate.LastCreatedContext;
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

        private void AssertThatChestIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.Chest.ItemId, Is.Null.Or.Empty);
            Assert.That(equipmentSlotsPresentationContext.Chest.IsLegallyEquipped, Is.False);
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
            private ItemInventoryExtractionVisitor inventoryExtractionVisitor;

            public InventoryPresentationContext LastCreatedContext
            {
                get;
                private set;
            }

            public InventoryDisplayInteractorWithCreatedPresentationContext(PlayerEquipmentItemsExtractionVisitor itemsExtractionVisitor, ItemInventoryExtractionVisitor inventoryExtractionVisitor)
            {
                this.itemsExtractionVisitor = itemsExtractionVisitor;
                this.inventoryExtractionVisitor = inventoryExtractionVisitor;
            }

            public override void ExtractAndShowInventory()
            {
                LastCreatedContext = CreateInventoryPresentationContext(itemsExtractionVisitor, inventoryExtractionVisitor);
            }
        }
    }
}