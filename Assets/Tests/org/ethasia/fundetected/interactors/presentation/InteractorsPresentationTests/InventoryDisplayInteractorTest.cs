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
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons.Count, Is.EqualTo(1));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].ItemPresentationContext.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.MARTIAL_STAFF));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].ItemPresentationContext.CanBeEquipped, Is.True);

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
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[1].ItemPresentationContext.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[1].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.ONE_HANDED_MACE));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[1].ItemPresentationContext.CanBeEquipped, Is.True);

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
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(1));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.RING));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.CanBeEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
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
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(2));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemId, Is.EqualTo("Ruby Ring"));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.RING));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.CanBeEquipped, Is.True);
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[1].ItemPresentationContext.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[1].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.RING));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[1].ItemPresentationContext.CanBeEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
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
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(1));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemId, Is.EqualTo(itemName));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.ItemClass, Is.EqualTo(ItemClass.BELT));
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry[0].ItemPresentationContext.CanBeEquipped, Is.True);

            AssertThatMainHandIsEmpty(equipmentSlotsPresentationContext);
            AssertThatOffHandIsEmpty(equipmentSlotsPresentationContext);
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
            Assert.That(firstResult.ItemClass, Is.EqualTo(ItemClass.ONE_HANDED_SWORD));
            Assert.That(firstResult.TopLeftCornerX, Is.EqualTo(1));
            Assert.That(firstResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(firstResult.DimensionX, Is.EqualTo(2));
            Assert.That(firstResult.DimensionY, Is.EqualTo(3));

            Assert.That(secondResult.ItemId, Is.EqualTo("The Mirage"));
            Assert.That(secondResult.ItemClass, Is.EqualTo(ItemClass.ONE_HANDED_SWORD));
            Assert.That(secondResult.TopLeftCornerX, Is.EqualTo(3));
            Assert.That(secondResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(secondResult.DimensionX, Is.EqualTo(2));
            Assert.That(secondResult.DimensionY, Is.EqualTo(3));

            Assert.That(thirdResult.ItemId, Is.EqualTo("Sapphire Ring"));
            Assert.That(thirdResult.ItemClass, Is.EqualTo(ItemClass.RING));
            Assert.That(thirdResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(thirdResult.TopLeftCornerY, Is.EqualTo(4));
            Assert.That(thirdResult.DimensionX, Is.EqualTo(1));
            Assert.That(thirdResult.DimensionY, Is.EqualTo(1));

            Assert.That(fourthResult.ItemId, Is.EqualTo("Life Potion"));
            Assert.That(fourthResult.ItemClass, Is.EqualTo(ItemClass.LIFE_POTION));
            Assert.That(fourthResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(fourthResult.TopLeftCornerY, Is.EqualTo(0));
            Assert.That(fourthResult.DimensionX, Is.EqualTo(1));
            Assert.That(fourthResult.DimensionY, Is.EqualTo(2));

            Assert.That(fifthResult.ItemId, Is.EqualTo("Mana Potion"));
            Assert.That(fifthResult.ItemClass, Is.EqualTo(ItemClass.LIFE_POTION));
            Assert.That(fifthResult.TopLeftCornerX, Is.EqualTo(0));
            Assert.That(fifthResult.TopLeftCornerY, Is.EqualTo(2));
            Assert.That(fifthResult.DimensionX, Is.EqualTo(1));
            Assert.That(fifthResult.DimensionY, Is.EqualTo(2));
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsEquippedWeaponProperties()
        {
            string itemName = "Ancient Axe";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Weapon mainHandWeapon = CreateTestWeapon(itemName, ItemClass.TWO_HANDED_AXE);

            playerCharacter.PickupEquipment(mainHandWeapon);
            EquipmentSlotsPresentationContext equipmentSlotsPresentationContext = CallEquipmentExtraction(playerCharacter);

            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.MinToMaxPhysicalDamage.MinDamage, Is.EqualTo(5));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.MinToMaxPhysicalDamage.MaxDamage, Is.EqualTo(10));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.MinToMaxSpellDamage.MinDamage, Is.EqualTo(3));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.MinToMaxSpellDamage.MaxDamage, Is.EqualTo(8));
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.SkillsPerSecond, Is.EqualTo(1.0));   
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons[0].WeaponPresentationContext.CriticalStrikeChance,Is.EqualTo(1000));           
        }

        [Test]
        public void TestCreateInventoryPresentationContextConvertsInventoryWeaponProperties()
        {
            string itemName = "Ancient Mace";

            PlayerCharacter playerCharacter = CreateTestPlayer();
            Weapon weapon = CreateTestWeapon(itemName, ItemClass.TWO_HANDED_MACE);

            playerCharacter.PickupEquipment(weapon);
            playerCharacter.PickupEquipment(weapon);
            playerCharacter.PickupEquipment(weapon);

            InventoryGridPresentationContext result = CallInventoryGridExtraction(playerCharacter);

            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.MinToMaxPhysicalDamage.MinDamage, Is.EqualTo(5));
            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.MinToMaxPhysicalDamage.MaxDamage, Is.EqualTo(10));
            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.MinToMaxSpellDamage.MinDamage, Is.EqualTo(3));
            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.MinToMaxSpellDamage.MaxDamage, Is.EqualTo(8));
            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.SkillsPerSecond, Is.EqualTo(1.0));   
            Assert.That(result.WeaponsPresentationContexts[0].WeaponContext.CriticalStrikeChance,Is.EqualTo(1000));   
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
            weaponBuilder.SetMinToMaxPhysicalDamage(weaponDamageRange)
                .SetMinToMaxSpellDamage(new DamageRange(3, 8))
                .SetSkillsPerSecond(1.0)
                .SetCriticalStrikeChance(1000);

            return weaponBuilder.Build();
        }

        private Armor CreateTestArmor(string itemId, ItemClass armorClass)
        {
            Armor.Builder armorBuilder = new Armor.Builder();

            armorBuilder.SetName(itemId)
                .SetItemClass(armorClass);
            armorBuilder.SetArmorValue(32)
                .SetMovementSpeedAddend(3);

            return armorBuilder.Build();
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
            potionBuilder.SetUses(3);
            potionBuilder.SetRecoveryAmount(50);

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
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons.Count, Is.EqualTo(0));
        }

        private void AssertThatOffHandIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedWeapons.Count, Is.EqualTo(0));
        }

        private void AssertThatLeftRingIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(0));
        }

        private void AssertThatRightRingIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(0));
        }

        private void AssertThatNeckIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(0));
        }

        private void AssertThatBeltIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedJewelry.Count, Is.EqualTo(0));
        }

        private void AssertThatHeadIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedArmors.Count, Is.EqualTo(0));
        }

        private void AssertThatChestIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedArmors.Count, Is.EqualTo(0));
        }

        private void AssertThatHandsAreEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedArmors.Count, Is.EqualTo(0));
        }

        private void AssertThatFeetAreEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedArmors.Count, Is.EqualTo(0));
        }

        private void AssertThatLeftMostPotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedRecoveryPotions.Count, Is.EqualTo(0));
        }

        private void AssertThatLeftMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedRecoveryPotions.Count, Is.EqualTo(0));
        }

        private void AssertThatMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedRecoveryPotions.Count, Is.EqualTo(0));
        }

        private void AssertThatRightMiddlePotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedRecoveryPotions.Count, Is.EqualTo(0));
        }

        private void AssertThatRightMostPotionIsEmpty(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            Assert.That(equipmentSlotsPresentationContext.EquippedRecoveryPotions.Count, Is.EqualTo(0));
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