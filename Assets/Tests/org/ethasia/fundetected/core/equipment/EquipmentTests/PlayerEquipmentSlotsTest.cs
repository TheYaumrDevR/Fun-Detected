using NUnit.Framework;

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
            Weapon huntingBow = CreateWeapon("Hunting Bow", ItemClass.BOW);

            Equipment result = testCandidate.EquipInLeftRing(huntingBow);

            Assert.That(result.Name, Is.EqualTo("Hunting Bow"));
        }

        [Test]
        public void TestEquipInBeltEquipsBeltIfSlotIsEmpty()
        {
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
            Weapon shortSword = CreateWeapon("Short Sword", ItemClass.ONE_HANDED_SWORD, new DamageRange(3, 7));

            PlayerEquipmentItemsExtractionVisitor resultExtractor = new PlayerEquipmentItemsExtractionVisitor(testCandidate);

            Equipment result = testCandidate.EquipIntoFreeSlotBasedOnItemClass(shortSword);
            resultExtractor.ExtractMainHandEquipment();

            Assert.That(result, Is.Null);
            Assert.That(resultExtractor.ExtractedWeapon.Name, Is.EqualTo("Short Sword"));
        }

        [Test]
        public void TestEquipIntoFreeSlotBasedOnItemClass_EquipsWeaponIfOffHandFree_AndMainHandIsOccupied()
        {
            Weapon mainHandWeapon = CreateWeapon("Assassin's Dagger", ItemClass.DAGGER, new DamageRange(2, 5));
            Weapon offHandWeapon = CreateWeapon("Shadow Dagger", ItemClass.DAGGER, new DamageRange(2, 5));

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
            Weapon firstWeapon = CreateWeapon("Battle Axe", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));
            Weapon secondWeapon = CreateWeapon("Hatchet", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));
            Weapon thirdWeapon = CreateWeapon("Long Axe", ItemClass.ONE_HANDED_AXE, new DamageRange(5, 10));

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
    }
}