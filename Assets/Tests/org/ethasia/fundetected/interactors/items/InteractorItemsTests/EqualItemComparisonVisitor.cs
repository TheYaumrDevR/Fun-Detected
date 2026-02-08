using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class EqualItemComparisonVisitor : ItemVisitor
    {
        private Weapon extractedWeapon;
        private Armor extractedArmor;
        private Jewelry extractedJewelry;
        private RecoveryPotion extractedRecoveryPotion;

        public override void Visit(Weapon weapon)
        {
            extractedWeapon = weapon;
        }

        public override void Visit(Armor armor)
        {
            extractedArmor = armor;
        }

        public override void Visit(Jewelry jewelry)
        {
            extractedJewelry = jewelry;
        }

        public override void Visit(RecoveryPotion recoveryPotion)
        {
            extractedRecoveryPotion = recoveryPotion;
        }

        public void AssertExtractedWeaponIsEqualTo(Weapon expectedWeapon)
        {
            Assert.That(extractedWeapon, Is.Not.Null);
            Assert.That(extractedWeapon.ItemClass, Is.EqualTo(expectedWeapon.ItemClass));
            Assert.That(extractedWeapon.MinimumItemLevel, Is.EqualTo(expectedWeapon.MinimumItemLevel));
            Assert.That(extractedWeapon.Name, Is.EqualTo(expectedWeapon.Name));
            Assert.That(extractedWeapon.StrengthRequirement, Is.EqualTo(expectedWeapon.StrengthRequirement));
            Assert.That(extractedWeapon.SkillsPerSecond, Is.EqualTo(expectedWeapon.SkillsPerSecond));
            Assert.That(extractedWeapon.FirstImplicit.Equals(expectedWeapon.FirstImplicit), Is.True);
        }

        public void AssertExtractedArmorIsEqualTo(Armor expectedArmor)
        {
            Assert.That(extractedArmor, Is.Not.Null);
            Assert.That(extractedArmor.ItemClass, Is.EqualTo(expectedArmor.ItemClass));
            Assert.That(extractedArmor.MinimumItemLevel, Is.EqualTo(expectedArmor.MinimumItemLevel));
            Assert.That(extractedArmor.Name, Is.EqualTo(expectedArmor.Name));
            Assert.That(extractedArmor.StrengthRequirement, Is.EqualTo(expectedArmor.StrengthRequirement));
            Assert.That(extractedArmor.ArmorValue, Is.EqualTo(expectedArmor.ArmorValue));
            Assert.That(extractedArmor.FirstImplicit.Equals(expectedArmor.FirstImplicit), Is.True);
        }

        public void AssertExtractedJewelryIsEqualTo(Jewelry expectedJewelry)
        {
            Assert.That(extractedJewelry, Is.Not.Null);
            Assert.That(extractedJewelry.ItemClass, Is.EqualTo(expectedJewelry.ItemClass));
            Assert.That(extractedJewelry.MinimumItemLevel, Is.EqualTo(expectedJewelry.MinimumItemLevel));
            Assert.That(extractedJewelry.Name, Is.EqualTo(expectedJewelry.Name));
            Assert.That(extractedJewelry.StrengthRequirement, Is.EqualTo(expectedJewelry.StrengthRequirement));
            Assert.That(extractedJewelry.FirstImplicit.Equals(expectedJewelry.FirstImplicit), Is.True);
        }   
    }
}