using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class ItemMasterDataToItemConverterTest
    {
        [Test]
        public void TestConvertWeaponMasterDataToWeaponConvertsAllProperties()
        {
            WeaponMasterData testWeaponMasterData = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 25))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Bronze Rapier")
                .SetMinimumItemLevel(17)
                .SetAgilityRequirement(62)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();

            Weapon result = ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(testWeaponMasterData);

            Assert.That(result.MinToMaxPhysicalDamage.MinDamage, Is.EqualTo(11));
            Assert.That(result.MinToMaxPhysicalDamage.MaxDamage, Is.EqualTo(25));
            Assert.That(result.MinToMaxSpellDamage, Is.Null);
            Assert.That(result.SkillsPerSecond, Is.EqualTo(1.55));
            Assert.That(result.CriticalStrikeChance, Is.EqualTo(550));
            Assert.That(result.WeaponRange, Is.EqualTo(18));
            Assert.That(result.Name, Is.EqualTo("Bronze Rapier"));
            Assert.That(result.StrengthRequirement, Is.EqualTo(0));
            Assert.That(result.AgilityRequirement, Is.EqualTo(62));
            Assert.That(result.IntelligenceRequirement, Is.EqualTo(0));
            Assert.That(result.ItemClass, Is.EqualTo(ItemClass.ONE_HANDED_STABBING_SWORD));
            Assert.That(result.MinimumItemLevel, Is.EqualTo(17));
        }

        [Test]
        public void TestConvertArmorMasterDataToArmorConvertsAllProperties()
        {
            ArmorMasterData armorMasterData = new ArmorMasterData.Builder()
                .SetName("Tattered Cloth Hood")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(3)
                .SetArmorValue(4)
                .SetFirstImplicit(new PlusAllElementalResistancesAffix(1))
                .Build();

            Armor result = ItemMasterDataToItemConverter.ConvertArmorMasterDataToArmor(armorMasterData);

            Assert.That(result.Name, Is.EqualTo("Tattered Cloth Hood"));
            Assert.That(result.ItemClass, Is.EqualTo(ItemClass.HEAD_GEAR));
            Assert.That(result.MinimumItemLevel, Is.EqualTo(1));
            Assert.That(result.StrengthRequirement, Is.EqualTo(3));
            Assert.That(result.AgilityRequirement, Is.EqualTo(0));
            Assert.That(result.IntelligenceRequirement, Is.EqualTo(0));
            Assert.That(result.ArmorValue, Is.EqualTo(4));
            Assert.That(result.FirstImplicit, Is.InstanceOf<PlusAllElementalResistancesAffix>());
        }

        [Test]
        public void TestConvertRecoveryPotionMasterDataToPotionConvertsAllProperties()
        {
            RecoveryPotionMasterData masterData = new RecoveryPotionMasterData.Builder()
                .SetItemClass(ItemClass.LIFE_POTION)
                .SetMinimumItemLevel(1)
                .SetName("Tiny Life Potion")
                .SetRecoveryAmount(70)
                .SetUses(3)
                .Build();

            RecoveryPotion result = ItemMasterDataToItemConverter.ConvertRecoveryPotionMasterDataToPotion(masterData);

            Assert.That(result.Name, Is.EqualTo("Tiny Life Potion"));
            Assert.That(result.ItemClass, Is.EqualTo(ItemClass.LIFE_POTION));
            Assert.That(result.MinimumItemLevel, Is.EqualTo(1));
            Assert.That(result.RecoveryAmount, Is.EqualTo(70));
            Assert.That(result.Uses, Is.EqualTo(3));
        }

        [Test]
        public void TestConvertJewelryMasterDataToJewelryConvertsAllProperties()
        {
            JewelryMasterData masterData = new JewelryMasterData.Builder()
                .SetItemClass(ItemClass.AMULET)
                .SetMinimumItemLevel(13)
                .SetName("Iron Amulet")
                .SetStrengthRequirement(0)
                .SetAgilityRequirement(0)
                .SetIntelligenceRequirement(0)
                .Build();

            Jewelry result = ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(masterData);

            Assert.That(result.Name, Is.EqualTo("Iron Amulet"));
            Assert.That(result.ItemClass, Is.EqualTo(ItemClass.AMULET));
            Assert.That(result.MinimumItemLevel, Is.EqualTo(13));
            Assert.That(result.StrengthRequirement, Is.EqualTo(0));
            Assert.That(result.AgilityRequirement, Is.EqualTo(0));
            Assert.That(result.IntelligenceRequirement, Is.EqualTo(0));
        }
    }
}