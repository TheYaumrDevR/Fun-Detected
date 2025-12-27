using NUnit.Framework;
using System;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class PlayerEquipmentSlotsTest
    {
        private PlayerEquipmentSlots testCandidate;

        [SetUp]
        public void Setup()
        {
            testCandidate = new PlayerEquipmentSlots();
        }

        [Test]
        public void TestCanEquipInMainHandCanEquipTwoHandedWeaponWhenOffhandFree()
        {
            Weapon twoHandedWeapon = CreateWeapon("", ItemClass.WIZARD_STAFF);

            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanNotEquipTwoHandedWeaponWhenOffhandUsed()
        {
            Weapon twoHandedWeapon = CreateWeapon("", ItemClass.BOW, new DamageRange(1, 1));
            Weapon offHandWeapon = CreateWeapon("", ItemClass.FIST_WEAPON, new DamageRange(1, 1));

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandFree()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.ONE_HANDED_SWORD);

            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandSame()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.DAGGER);
            Weapon offHandWeapon = CreateWeapon("", ItemClass.DAGGER, new DamageRange(1, 1));

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInMainHandCanNotEquipOneHandedWeaponWhenOffhandDifferent()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.ONE_HANDED_AXE);
            Weapon offHandWeapon = CreateWeapon("", ItemClass.WAND, new DamageRange(1, 1));

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInOffHandCanNotEquipTwoHandedWeapon()
        {
            Weapon twoHandedWeapon = CreateWeapon("", ItemClass.TWO_HANDED_MACE);

            bool result = testCandidate.CanEquipInOffHand(twoHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeapon()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.SPELL_DAGGER);

            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeaponWhenSameTypeIsInMainHand()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.ONE_HANDED_STABBING_SWORD);
            Weapon mainHandWeapon = CreateWeapon("", ItemClass.ONE_HANDED_STABBING_SWORD, new DamageRange(1, 1));

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanEquipInOffHandCanNotEquipOneHandedWeaponWhenDifferentTypeIsInMainHand()
        {
            Weapon oneHandedWeapon = CreateWeapon("", ItemClass.ONE_HANDED_AXE);
            Weapon mainHandWeapon = CreateWeapon("", ItemClass.ONE_HANDED_MACE, new DamageRange(1, 1));

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestEquipInMainHandReturnsNullIfNothingIsEquipped()
        {
            Weapon twoHandedWeapon = CreateWeapon("", ItemClass.MARTIAL_STAFF, new DamageRange(1, 1));

            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestEquipInMainHandReturnsOldEquippedItem()
        {
            Weapon firstWeapon = CreateWeapon("Bronze Twohander", ItemClass.TWO_HANDED_SWORD, new DamageRange(1, 1));
            testCandidate.EquipInMainHand(firstWeapon);

            Weapon secondWeapon = CreateWeapon("Bronze Warhammer", ItemClass.TWO_HANDED_MACE);
            Equipment result = testCandidate.EquipInMainHand(firstWeapon);

            Assert.That(result.Name, Is.EqualTo("Bronze Twohander"));
        }

        [Test]
        public void TestEquipInMainHandReturnsCurrentItemIfItCannotEquip()
        {
            Weapon twoHandedWeapon = CreateWeapon("Warstaff", ItemClass.MARTIAL_STAFF);
            Weapon offHandWeapon = CreateWeapon("", ItemClass.FIST_WEAPON, new DamageRange(1, 1));

            testCandidate.EquipInOffHand(offHandWeapon);
            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result.Name, Is.EqualTo("Warstaff"));
        }

        [Test]
        public void TestEquipInOffHandReturnsNullIfNothingIsEquipped()
        {
            Weapon weapon = CreateWeapon("", ItemClass.ONE_HANDED_MACE, new DamageRange(1, 1));

            Equipment result = testCandidate.EquipInOffHand(weapon);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestEquipInOffHandReturnsOldEquippedItem()
        {
            Weapon firstWeapon = CreateWeapon("Spellblade", ItemClass.SPELL_DAGGER, new DamageRange(1, 1));
            testCandidate.EquipInOffHand(firstWeapon);

            Weapon secondWeapon = CreateWeapon("Hatchet", ItemClass.ONE_HANDED_AXE, new DamageRange(1, 1));
            Equipment result = testCandidate.EquipInOffHand(secondWeapon);

            Assert.That(result.Name, Is.EqualTo("Spellblade"));
        }

        [Test]
        public void TestEquipInOffHandReturnsCurrentItemIfItCannotEquip()
        {
            Weapon secondWeapon = CreateWeapon("Gladius", ItemClass.ONE_HANDED_SWORD, new DamageRange(1, 1));
            Weapon firstWeapon = CreateWeapon("", ItemClass.FIST_WEAPON, new DamageRange(1, 1));

            testCandidate.EquipInMainHand(firstWeapon);
            Equipment result = testCandidate.EquipInOffHand(secondWeapon);

            Assert.That(result.Name, Is.EqualTo("Gladius"));
        }

        [Test]
        public void TestEquipInLeftRingEquipsRingIfSlotIsEmpty()
        {
            Jewelry goldRing = CreateJewelry("Gold Ring", ItemClass.RING);

            Equipment oldEquipment = testCandidate.EquipInLeftRing(goldRing);
            Equipment currentEquipment = testCandidate.EquipInLeftRing(goldRing);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("Gold Ring"));
        }

        [Test]
        public void TestEquipInLeftRingSwapsOutOldEquipment()
        {
            Jewelry ironRing = CreateJewelry("Iron Ring", ItemClass.RING);
            Jewelry sapphireRing = CreateJewelry("Sapphire Ring", ItemClass.RING);

            testCandidate.EquipInLeftRing(ironRing);
            Equipment oldEquipment = testCandidate.EquipInLeftRing(sapphireRing);

            Assert.That(oldEquipment.Name, Is.EqualTo("Iron Ring"));
        }

        [Test]
        public void TestEquipInLeftRingCannotEquipWrongItemClass()
        {
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
            Jewelry goldRing = CreateJewelry("Gold Ring", ItemClass.RING);

            Equipment oldEquipment = testCandidate.EquipInRightRing(goldRing);
            Equipment currentEquipment = testCandidate.EquipInRightRing(goldRing);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("Gold Ring"));
        }

        [Test]
        public void TestEquipInRightRingSwapsOutOldEquipment()
        {
            Jewelry ironRing = CreateJewelry("Iron Ring", ItemClass.RING);
            Jewelry sapphireRing = CreateJewelry("Sapphire Ring", ItemClass.RING);

            testCandidate.EquipInRightRing(ironRing);
            Equipment oldEquipment = testCandidate.EquipInRightRing(sapphireRing);

            Assert.That(oldEquipment.Name, Is.EqualTo("Iron Ring"));
        }

        [Test]
        public void TestEquipInRightRingCannotEquipWrongItemClass()
        {
            Weapon huntingBow = CreateWeapon("Hunting Bow", ItemClass.BOW);

            Equipment result = testCandidate.EquipInLeftRing(huntingBow);

            Assert.That(result.Name, Is.EqualTo("Hunting Bow"));
        }

        [Test]
        public void TestEquipInBeltEquipsBeltIfSlotIsEmpty()
        {
            Jewelry warBelt = CreateJewelry("War Belt", ItemClass.BELT);

            Equipment oldEquipment = testCandidate.EquipInBelt(warBelt);
            Equipment currentEquipment = testCandidate.EquipInBelt(warBelt);

            Assert.That(oldEquipment, Is.Null);
            Assert.That(currentEquipment.Name, Is.EqualTo("War Belt"));
        }

        [Test]
        public void TestEquipInBeltSwapsOutOldEquipment()
        {
            Jewelry crystalBelt = CreateJewelry("Crystal Belt", ItemClass.BELT);
            Jewelry platedBelt = CreateJewelry("Plated Belt", ItemClass.BELT);

            testCandidate.EquipInBelt(crystalBelt);
            Equipment oldEquipment = testCandidate.EquipInBelt(platedBelt);

            Assert.That(oldEquipment.Name, Is.EqualTo("Crystal Belt"));
        }

        [Test]
        public void TestEquipInBeltCannotEquipWrongItemClass()
        {
            Jewelry emeraldRing = CreateJewelry("Emerald Ring", ItemClass.RING);

            Equipment result = testCandidate.EquipInBelt(emeraldRing);

            Assert.That(result.Name, Is.EqualTo("Emerald Ring"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInLeftRingIfFree()
        {
            Jewelry rubyRing = CreateJewelry("Ruby Ring", ItemClass.RING);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(rubyRing);

            Assert.That(result, Is.Null);
            AssertThatJewelryWithNameIsEquipped("Ruby Ring", resultExtractor => resultExtractor.ExtractLeftRingEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInRightRingIfLeftIsOccupied()
        {
            Jewelry goldRing = CreateJewelry("Gold Ring", ItemClass.RING);
            Jewelry chrysocollaBand = CreateJewelry("Chrysocolla Band", ItemClass.RING);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(goldRing);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(chrysocollaBand);

            Assert.That(result, Is.Null);
            AssertThatJewelryWithNameIsEquipped("Chrysocolla Band", resultExtractor => resultExtractor.ExtractRightRingEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassEquipsInBeltIfFree()
        {
            Jewelry flaskBelt = CreateJewelry("Flask Belt", ItemClass.BELT);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(flaskBelt);

            Assert.That(result, Is.Null);
            AssertThatJewelryWithNameIsEquipped("Flask Belt", resultExtractor => resultExtractor.ExtractBeltEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassDoesNotEquipRingIfBothSlotsOccupied()
        {
            Jewelry goldRing = CreateJewelry("Gold Ring", ItemClass.RING);
            Jewelry chrysocollaBand = CreateJewelry("Chrysocolla Band", ItemClass.RING);
            Jewelry neodymiumRing = CreateJewelry("Neodymium Ring", ItemClass.RING);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(goldRing);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(chrysocollaBand);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(neodymiumRing);

            AssertThatJewelryWithNameIsEquipped("Chrysocolla Band", resultExtractor => resultExtractor.ExtractRightRingEquipment());
            AssertThatJewelryWithNameIsEquipped("Gold Ring", resultExtractor => resultExtractor.ExtractLeftRingEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClassDoesNotEquipBeltIfSlotOccupied()
        {
            Jewelry flaskBelt = CreateJewelry("Flask Belt", ItemClass.BELT);
            Jewelry condensingBelt = CreateJewelry("Condensing Belt", ItemClass.BELT);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(flaskBelt);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(condensingBelt);

            AssertThatJewelryWithNameIsEquipped("Flask Belt", resultExtractor => resultExtractor.ExtractBeltEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_EquipsWeaponIfMainHandFree()
        {
            Weapon shortSword = CreateWeapon("Short Sword", ItemClass.ONE_HANDED_SWORD, new DamageRange(3, 7));

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(shortSword);

            Assert.That(result, Is.Null);
            AssertThatWeaponWithNameIsEquipped("Short Sword", resultExtractor => resultExtractor.ExtractMainHandEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_EquipsWeaponIfOffHandFree_AndMainHandIsOccupied()
        {
            Weapon mainHandWeapon = CreateWeapon("Assassin's Dagger", ItemClass.DAGGER, new DamageRange(2, 5));
            Weapon offHandWeapon = CreateWeapon("Shadow Dagger", ItemClass.DAGGER, new DamageRange(2, 5));

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(mainHandWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(offHandWeapon);

            Assert.That(result, Is.Null);
            AssertThatWeaponWithNameIsEquipped("Shadow Dagger", resultExtractor => resultExtractor.ExtractOffHandEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_DoesNotEquipWeaponIfBothHandsOccupied()
        {
            Weapon firstWeapon = CreateWeapon("Battle Axe", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));
            Weapon secondWeapon = CreateWeapon("Hatchet", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));
            Weapon thirdWeapon = CreateWeapon("Long Axe", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(firstWeapon);
            testCandidate.EquipIntoFreeSlotBasedOnItemClass(secondWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(thirdWeapon);

            Assert.That(result.Name, Is.EqualTo("Long Axe"));
            AssertThatWeaponWithNameIsEquipped("Hatchet", resultExtractor => resultExtractor.ExtractOffHandEquipment());
            AssertThatWeaponWithNameIsEquipped("Battle Axe", resultExtractor => resultExtractor.ExtractMainHandEquipment());
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_DoesNotEquipOffHandWeaponOfDifferentTypeFromMainHand()
        {
            Weapon mainHandWeapon = CreateWeapon("War Hammer", ItemClass.ONE_HANDED_MACE, new DamageRange(6, 12));
            Weapon offHandWeapon = CreateWeapon("Magic Wand", ItemClass.WAND, new DamageRange(6, 12));

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            testCandidate.EquipIntoFreeSlotBasedOnItemClass(mainHandWeapon);
            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(offHandWeapon);

            resultExtractor.ExtractOffHandEquipment();

            Assert.That(result.Name, Is.EqualTo("Magic Wand"));
            Assert.That(resultExtractor.ExtractedWeapon, Is.Null);

            resultExtractor.ExtractMainHandEquipment();
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("War Hammer"));
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

        private Jewelry CreateJewelry(string name, ItemClass itemClass)
        {
            var builder = new Jewelry.Builder();

            builder.SetName(name)
                .SetItemClass(itemClass);

            return builder.Build();
        }

        private void AssertThatWeaponWithNameIsEquipped(string expectedEquipmentName, Action<PlayerEquipmentItemsExtractionVisitor> slotsExtractAction)
        {
            var extractor = ExtractEquipment(slotsExtractAction);
            Assert.That(extractor.ExtractedWeapon?.Name, Is.EqualTo(expectedEquipmentName));
        }

        private void AssertThatJewelryWithNameIsEquipped(string expectedEquipmentName, Action<PlayerEquipmentItemsExtractionVisitor> slotsExtractAction)
        {
            var extractor = ExtractEquipment(slotsExtractAction);
            Assert.That(extractor.ExtractedJewelry?.Name, Is.EqualTo(expectedEquipmentName));
        }

        private PlayerEquipmentItemsExtractionVisitor ExtractEquipment(Action<PlayerEquipmentItemsExtractionVisitor> slotsExtractAction)
        {
            var extractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);
            slotsExtractAction(extractor);

            return extractor;
        }
    }
}