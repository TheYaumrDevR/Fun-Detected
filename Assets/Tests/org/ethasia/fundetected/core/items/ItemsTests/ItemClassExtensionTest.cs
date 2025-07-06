using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Items.Tests
{
    public class ItemClassExtensionTest
    {
        [Test]
        public void TestCreateInventoryShapeCreatesCorrectShapesForEachItemClass()
        {
            ItemClass oneHandedSword = ItemClass.ONE_HANDED_SWORD;
            ItemClass oneHandedStabbingSword = ItemClass.ONE_HANDED_STABBING_SWORD;
            ItemClass twoHandedSword = ItemClass.TWO_HANDED_SWORD;
            ItemClass dagger = ItemClass.DAGGER;
            ItemClass spellDagger = ItemClass.SPELL_DAGGER;
            ItemClass oneHandedAxe = ItemClass.ONE_HANDED_AXE;
            ItemClass twoHandedAxe = ItemClass.TWO_HANDED_AXE;
            ItemClass fistWeapon = ItemClass.FIST_WEAPON;
            ItemClass wizardStaff = ItemClass.WIZARD_STAFF;
            ItemClass martialStaff = ItemClass.MARTIAL_STAFF;
            ItemClass oneHandedMace = ItemClass.ONE_HANDED_MACE;
            ItemClass twoHandedMace = ItemClass.TWO_HANDED_MACE;
            ItemClass magicMace = ItemClass.MAGIC_MACE;
            ItemClass bow = ItemClass.BOW;
            ItemClass wand = ItemClass.WAND;
            ItemClass shield = ItemClass.SHIELD;
            ItemClass quiver = ItemClass.QUIVER;
            ItemClass magicSource = ItemClass.MAGIC_SOURCE;
            ItemClass bodyArmor = ItemClass.BODY_ARMOR;
            ItemClass headGear = ItemClass.HEAD_GEAR;
            ItemClass shoes = ItemClass.SHOES;
            ItemClass gloves = ItemClass.GLOVES;
            ItemClass ring = ItemClass.RING;
            ItemClass amulet = ItemClass.AMULET;
            ItemClass belt = ItemClass.BELT;
            ItemClass glyph = ItemClass.GLYPH;
            ItemClass lifePotion = ItemClass.LIFE_POTION;
            ItemClass manaPotion = ItemClass.MANA_POTION;
            ItemClass enhancingPotion = ItemClass.ENHANCING_POTION;

            ItemInInventoryShape oneByOneShape = ItemInInventoryShape.CreateOneByOne(null);
            ItemInInventoryShape twoByOneShape = ItemInInventoryShape.CreateTwoByOne(null);
            ItemInInventoryShape oneByTwoShape = ItemInInventoryShape.CreateOneByTwo(null);
            ItemInInventoryShape oneByThreeShape = ItemInInventoryShape.CreateOneByThree(null);
            ItemInInventoryShape oneByFourShape = ItemInInventoryShape.CreateOneByFour(null);
            ItemInInventoryShape twoByTwoShape = ItemInInventoryShape.CreateTwoByTwo(null);
            ItemInInventoryShape twoByThreeShape = ItemInInventoryShape.CreateTwoByThree(null);
            ItemInInventoryShape twoByFourShape = ItemInInventoryShape.CreateTwoByFour(null);

            ItemInInventoryShape oneHandedSwordShape = oneHandedSword.CreateInventoryShape(null);
            ItemInInventoryShape oneHandedStabbingSwordShape = oneHandedStabbingSword.CreateInventoryShape(null);
            ItemInInventoryShape twoHandedSwordShape = twoHandedSword.CreateInventoryShape(null);
            ItemInInventoryShape daggerShape = dagger.CreateInventoryShape(null);
            ItemInInventoryShape spellDaggerShape = spellDagger.CreateInventoryShape(null);
            ItemInInventoryShape oneHandedAxeShape = oneHandedAxe.CreateInventoryShape(null);
            ItemInInventoryShape twoHandedAxeShape = twoHandedAxe.CreateInventoryShape(null);
            ItemInInventoryShape fistWeaponShape = fistWeapon.CreateInventoryShape(null);
            ItemInInventoryShape wizardStaffShape = wizardStaff.CreateInventoryShape(null);
            ItemInInventoryShape martialStaffShape = martialStaff.CreateInventoryShape(null);
            ItemInInventoryShape oneHandedMaceShape = oneHandedMace.CreateInventoryShape(null);
            ItemInInventoryShape twoHandedMaceShape = twoHandedMace.CreateInventoryShape(null);
            ItemInInventoryShape magicMaceShape = magicMace.CreateInventoryShape(null);
            ItemInInventoryShape bowShape = bow.CreateInventoryShape(null);
            ItemInInventoryShape wandShape = wand.CreateInventoryShape(null);
            ItemInInventoryShape shieldShape = shield.CreateInventoryShape(null);
            ItemInInventoryShape quiverShape = quiver.CreateInventoryShape(null);
            ItemInInventoryShape magicSourceShape = magicSource.CreateInventoryShape(null);
            ItemInInventoryShape bodyArmorShape = bodyArmor.CreateInventoryShape(null);
            ItemInInventoryShape headGearShape = headGear.CreateInventoryShape(null);
            ItemInInventoryShape shoesShape = shoes.CreateInventoryShape(null);
            ItemInInventoryShape glovesShape = gloves.CreateInventoryShape(null);
            ItemInInventoryShape ringShape = ring.CreateInventoryShape(null);
            ItemInInventoryShape amuletShape = amulet.CreateInventoryShape(null);
            ItemInInventoryShape beltShape = belt.CreateInventoryShape(null);
            ItemInInventoryShape glyphShape = glyph.CreateInventoryShape(null);
            ItemInInventoryShape lifePotionShape = lifePotion.CreateInventoryShape(null);
            ItemInInventoryShape manaPotionShape = manaPotion.CreateInventoryShape(null);
            ItemInInventoryShape enhancingPotionShape = enhancingPotion.CreateInventoryShape(null);

            Assert.IsTrue(oneHandedSwordShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(oneHandedStabbingSwordShape.IsShapeEqualTo(oneByFourShape));
            Assert.IsTrue(twoHandedSwordShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(daggerShape.IsShapeEqualTo(oneByThreeShape));
            Assert.IsTrue(spellDaggerShape.IsShapeEqualTo(oneByThreeShape));
            Assert.IsTrue(oneHandedAxeShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(twoHandedAxeShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(fistWeaponShape.IsShapeEqualTo(twoByTwoShape));
            Assert.IsTrue(wizardStaffShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(martialStaffShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(oneHandedMaceShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(twoHandedMaceShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(magicMaceShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(bowShape.IsShapeEqualTo(twoByFourShape));
            Assert.IsTrue(wandShape.IsShapeEqualTo(oneByThreeShape));
            Assert.IsTrue(shieldShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(quiverShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(magicSourceShape.IsShapeEqualTo(twoByTwoShape));
            Assert.IsTrue(bodyArmorShape.IsShapeEqualTo(twoByThreeShape));
            Assert.IsTrue(headGearShape.IsShapeEqualTo(twoByTwoShape));
            Assert.IsTrue(shoesShape.IsShapeEqualTo(twoByTwoShape));
            Assert.IsTrue(glovesShape.IsShapeEqualTo(twoByTwoShape));
            Assert.IsTrue(ringShape.IsShapeEqualTo(oneByOneShape));
            Assert.IsTrue(amuletShape.IsShapeEqualTo(oneByOneShape));
            Assert.IsTrue(beltShape.IsShapeEqualTo(twoByOneShape));
            Assert.IsTrue(glyphShape.IsShapeEqualTo(oneByOneShape));
            Assert.IsTrue(lifePotionShape.IsShapeEqualTo(oneByTwoShape));
            Assert.IsTrue(manaPotionShape.IsShapeEqualTo(oneByTwoShape));
            Assert.IsTrue(enhancingPotionShape.IsShapeEqualTo(oneByTwoShape));
        }
    }
}