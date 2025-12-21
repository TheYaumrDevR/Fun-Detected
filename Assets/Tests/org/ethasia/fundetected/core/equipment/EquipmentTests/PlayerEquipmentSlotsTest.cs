using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class PlayerEquipmentSlotsTest
    {

        [Test]
        public void TestCanEquipInMainHandCanEquipTwoHandedWeaponWhenOffhandFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.WIZARD_STAFF);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanNotEquipTwoHandedWeaponWhenOffhandUsed()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.BOW);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);
            offHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_SWORD);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandSame()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.DAGGER);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.DAGGER);
            offHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanNotEquipOneHandedWeaponWhenOffhandDifferent()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.WAND);
            offHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInOffHandCanNotEquipTwoHandedWeapon()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.TWO_HANDED_MACE);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInOffHand(twoHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeapon()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.SPELL_DAGGER);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeaponWhenSameTypeIsInMainHand()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder mainHandWeaponBuilder = new Weapon.Builder();
            mainHandWeaponBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);
            mainHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon mainHandWeapon = mainHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInOffHandCanNotEquipOneHandedWeaponWhenDifferentTypeIsInMainHand()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder mainHandWeaponBuilder = new Weapon.Builder();
            mainHandWeaponBuilder.SetItemClass(ItemClass.ONE_HANDED_MACE);
            mainHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon mainHandWeapon = mainHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestEquipInMainHandReturnsNullIfNothingIsEquipped()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.MARTIAL_STAFF);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestEquipInMainHandReturnsOldEquippedItem()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Bronze Twohander")
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon firstWeapon = weaponBuilder.Build();

            testCandidate.EquipInMainHand(firstWeapon);

            weaponBuilder.SetName("Bronze Warhammer")
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            Weapon secondWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInMainHand(firstWeapon);

            Assert.That(result.Name, Is.EqualTo("Bronze Twohander"));
        }

        [Test]
        public void TestEquipInMainHandReturnsCurrentItemIfItCannotEquip()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Warstaff")
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);
            offHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result.Name, Is.EqualTo("Warstaff"));
        }

        [Test]
        public void TestEquipInOffHandReturnsNullIfNothingIsEquipped()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_MACE);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon weapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInOffHand(weapon);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestEquipInOffHandReturnsOldEquippedItem()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Spellblade")
                .SetItemClass(ItemClass.SPELL_DAGGER);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon firstWeapon = weaponBuilder.Build();

            testCandidate.EquipInOffHand(firstWeapon);

            weaponBuilder.SetName("Hatchet")
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon secondWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInOffHand(firstWeapon);

            Assert.That(result.Name, Is.EqualTo("Spellblade"));
        }

        [Test]
        public void TestEquipInOffHandReturnsCurrentItemIfItCannotEquip()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Gladius")
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);
            weaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon secondWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);
            offHandWeaponBuilder.SetMinToMaxPhysicalDamage(new DamageRange(1, 1));

            Weapon firstWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(firstWeapon);
            Equipment result = testCandidate.EquipInOffHand(secondWeapon);

            Assert.That(result.Name, Is.EqualTo("Gladius"));
        }

        [Test]
        public void TestEquipInLeftRingEquipsRingIfSlotIsEmpty()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Gold Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry goldRing = jewelryBuilder.Build();

            Equipment oldEquipment = testCandidate.EquipInLeftRing(goldRing);
            Equipment currentEquipment = testCandidate.EquipInLeftRing(goldRing);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("Gold Ring"));
        }

        [Test]
        public void TestEquipInLeftRingSwapsOutOldEquipment()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Iron Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry ironRing = jewelryBuilder.Build();

            jewelryBuilder.SetName("Sapphire Ring");
            Jewelry sapphireRing = jewelryBuilder.Build();

            testCandidate.EquipInLeftRing(ironRing);
            Equipment oldEquipment = testCandidate.EquipInLeftRing(sapphireRing);

            Assert.That(oldEquipment.Name, Is.EqualTo("Iron Ring"));
        }

        [Test]
        public void TestEquipInLeftRingCannotEquipWrongItemClass()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Armor.Builder armorBuilder = new Armor.Builder();

            armorBuilder.SetName("Leather Sandals")
                .SetItemClass(ItemClass.SHOES);

            Armor leatherSandals = armorBuilder.Build();

            Equipment result = testCandidate.EquipInLeftRing(leatherSandals);

            Assert.That(result.Name, Is.EqualTo("Leather Sandals"));
        }

        [Test]
        public void TestEquipInRightRingEquipsRingIfSlotIsEmpty()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Gold Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry goldRing = jewelryBuilder.Build();

            Equipment oldEquipment = testCandidate.EquipInRightRing(goldRing);
            Equipment currentEquipment = testCandidate.EquipInRightRing(goldRing);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("Gold Ring"));
        }

        [Test]
        public void TestEquipInRightRingSwapsOutOldEquipment()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Iron Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry ironRing = jewelryBuilder.Build();

            jewelryBuilder.SetName("Sapphire Ring");
            Jewelry sapphireRing = jewelryBuilder.Build();

            testCandidate.EquipInRightRing(ironRing);
            Equipment oldEquipment = testCandidate.EquipInRightRing(sapphireRing);

            Assert.That(oldEquipment.Name, Is.EqualTo("Iron Ring"));
        }

        [Test]
        public void TestEquipInRightRingCannotEquipWrongItemClass()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Hunting Bow")
                .SetItemClass(ItemClass.BOW);

            Weapon huntingBow = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInLeftRing(huntingBow);

            Assert.That(result.Name, Is.EqualTo("Hunting Bow"));
        }

        [Test]
        public void TestEquipInBeltEquipsBeltIfSlotIsEmpty()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("War Belt")
                .SetItemClass(ItemClass.BELT);

            Jewelry warBelt = jewelryBuilder.Build();

            Equipment oldEquipment = testCandidate.EquipInBelt(warBelt);
            Equipment currentEquipment = testCandidate.EquipInBelt(warBelt);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("War Belt"));
        }

        [Test]
        public void TestEquipInBeltSwapsOutOldEquipment()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Crystal Belt")
                .SetItemClass(ItemClass.BELT);

            Jewelry crystalBelt = jewelryBuilder.Build();

            jewelryBuilder.SetName("Plated Belt");
            Jewelry platedBelt = jewelryBuilder.Build();

            testCandidate.EquipInBelt(crystalBelt);
            Equipment oldEquipment = testCandidate.EquipInBelt(platedBelt);

            Assert.That(oldEquipment.Name, Is.EqualTo("Crystal Belt"));
        }

        [Test]
        public void TestEquipInBeltCannotEquipWrongItemClass()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Emerald Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry emeraldRing = jewelryBuilder.Build();

            Equipment result = testCandidate.EquipInBelt(emeraldRing);

            Assert.That(result.Name, Is.EqualTo("Emerald Ring"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInLeftRingIfFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder testItemBuilder = new Jewelry.Builder();

            testItemBuilder.SetName("Ruby Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry rubyRing = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(rubyRing);
            resultExtractor.ExtractLeftRingEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Ruby Ring"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInRightRingIfLeftIsOccupied()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder testItemBuilder = new Jewelry.Builder();

            testItemBuilder.SetName("Gold Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry goldRing = testItemBuilder.Build();

            testItemBuilder.SetName("Chrysocolla Band");

            Jewelry chrysocollaBand = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(goldRing);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(chrysocollaBand);

            resultExtractor.ExtractRightRingEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Chrysocolla Band"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInBeltIfFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder testItemBuilder = new Jewelry.Builder();

            testItemBuilder.SetName("Flask Belt")
                .SetItemClass(ItemClass.BELT);

            Jewelry flaskBelt = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(flaskBelt);
            resultExtractor.ExtractBeltEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Flask Belt"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassDoesNotEquipRingIfBothSlotsOccupied()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder testItemBuilder = new Jewelry.Builder();

            testItemBuilder.SetName("Gold Ring")
                .SetItemClass(ItemClass.RING);

            Jewelry goldRing = testItemBuilder.Build();

            testItemBuilder.SetName("Chrysocolla Band");

            Jewelry chrysocollaBand = testItemBuilder.Build();

            testItemBuilder.SetName("Neodymium Ring");

            Jewelry neodymiumRing = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(goldRing);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(chrysocollaBand);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(neodymiumRing);

            resultExtractor.ExtractRightRingEquipment();
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Chrysocolla Band"));

            resultExtractor.ExtractLeftRingEquipment();
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Gold Ring"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassDoesNotEquipBeltIfSlotOccupied()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Jewelry.Builder testItemBuilder = new Jewelry.Builder();

            testItemBuilder.SetName("Flask Belt")
                .SetItemClass(ItemClass.BELT);

            Jewelry flaskBelt = testItemBuilder.Build();

            testItemBuilder.SetName("Condensing Belt");

            Jewelry condensingBelt = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(flaskBelt);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(condensingBelt);

            resultExtractor.ExtractBeltEquipment();
            Assert.That(resultExtractor.ExtractedJewelry.Name, Is.EqualTo("Flask Belt"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_EquipsWeaponIfMainHandFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Weapon.Builder testItemBuilder = new Weapon.Builder();

            testItemBuilder.SetName("Short Sword")
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);
            testItemBuilder.SetMinToMaxPhysicalDamage(new DamageRange(3, 7));

            Weapon shortSword = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(shortSword);
            resultExtractor.ExtractMainHandEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("Short Sword"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_EquipsWeaponIfOffHandFree_AndMainHandIsOccupied()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Weapon.Builder testItemBuilder = new Weapon.Builder();

            testItemBuilder.SetName("Assassin's Dagger")
                .SetItemClass(ItemClass.DAGGER);
            testItemBuilder.SetMinToMaxPhysicalDamage(new DamageRange(2, 5));

            Weapon mainHandWeapon = testItemBuilder.Build();

            testItemBuilder.SetName("Shadow Dagger");
            Weapon offHandWeapon = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(mainHandWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(offHandWeapon);

            resultExtractor.ExtractOffHandEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("Shadow Dagger"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_DoesNotEquipWeaponIfBothHandsOccupied()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Weapon.Builder testItemBuilder = new Weapon.Builder();

            testItemBuilder.SetName("Battle Axe")
                .SetItemClass(ItemClass.ONE_HANDED_AXE);
            testItemBuilder.SetMinToMaxPhysicalDamage(new DamageRange(5, 10));

            Weapon firstWeapon = testItemBuilder.Build();

            testItemBuilder.SetName("Hatchet");
            Weapon secondWeapon = testItemBuilder.Build();

            testItemBuilder.SetName("Long Axe");
            Weapon thirdWeapon = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(firstWeapon);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(secondWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(thirdWeapon);

            resultExtractor.ExtractOffHandEquipment();

            Assert.That(result.Name, Is.EqualTo("Long Axe"));
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("Hatchet"));

            resultExtractor.ExtractMainHandEquipment();
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("Battle Axe"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_DoesNotEquipOffHandWeaponOfDifferentTypeFromMainHand()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Weapon.Builder testItemBuilder = new Weapon.Builder();

            testItemBuilder.SetName("War Hammer")
                .SetItemClass(ItemClass.ONE_HANDED_MACE);
            testItemBuilder.SetMinToMaxPhysicalDamage(new DamageRange(6, 12));

            Weapon mainHandWeapon = testItemBuilder.Build();

            testItemBuilder.SetName("Magic Wand")
                .SetItemClass(ItemClass.WAND);
            Weapon offHandWeapon = testItemBuilder.Build();

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(mainHandWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(offHandWeapon);

            resultExtractor.ExtractOffHandEquipment();

            Assert.That(result.Name, Is.EqualTo("Magic Wand"));
            Assert.That(resultExtractor.ExtractedWeapon, Is.Null);

            resultExtractor.ExtractMainHandEquipment();
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("War Hammer"));
        }
    }
}