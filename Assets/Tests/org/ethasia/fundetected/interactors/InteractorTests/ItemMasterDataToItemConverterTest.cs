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
            AffixMasterDataBaseForIntegerMinMaxAndIncrement rollableImplicit = new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(1)
                .SetMaxValue(2)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusAllElementalResistances)
                .Build();

            ArmorMasterData armorMasterData = new ArmorMasterData.Builder()
                .SetName("Tattered Cloth Hood")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(3)
                .SetArmorValue(4)
                .SetFirstImplicit(rollableImplicit)
                .Build();

            Armor result = ItemMasterDataToItemConverter.ConvertArmorMasterDataToArmor(armorMasterData);

            Assert.That(result.Name, Is.EqualTo("Tattered Cloth Hood"));
            Assert.That(result.ItemClass, Is.EqualTo(ItemClass.HEAD_GEAR));
            Assert.That(result.MinimumItemLevel, Is.EqualTo(1));
            Assert.That(result.StrengthRequirement, Is.EqualTo(3));
            Assert.That(result.AgilityRequirement, Is.EqualTo(0));
            Assert.That(result.IntelligenceRequirement, Is.EqualTo(0));
            Assert.That(result.ArmorValue, Is.EqualTo(4));
            Assert.That(result.FirstImplicit.RerolledAffix, Is.InstanceOf<PlusAllElementalResistancesAffix>());
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
                .SetFirstImplicit(CreateImplicitMasterDataForTest())
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
        
        [Test]
        public void TestConvertJewelryMasterDataToJewelryConvertsImplicit()
        {
            AffixMasterDataBaseForIntegerMinMaxAndIncrement implicitMasterData = new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(5)
                .SetMaxValue(6)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusAllElementalResistances)
                .Build();

            JewelryMasterData masterData = new JewelryMasterData.Builder()
                .SetItemClass(ItemClass.RING)
                .SetMinimumItemLevel(1)
                .SetName("Copper Ring")
                .SetStrengthRequirement(0)
                .SetAgilityRequirement(0)
                .SetIntelligenceRequirement(0)
                .SetFirstImplicit(implicitMasterData)
                .Build();
                
            Jewelry result = ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(masterData);

            Assert.That(result.FirstImplicit.RerolledAffix, Is.InstanceOf<PlusAllElementalResistancesAffix>());
        }

        [Test]
        public void TestConvertWeaponMasterDataToWeaponConvertsCollisionDimensions()
        {
            WeaponMasterData.Builder weaponMasterDataBuilder = new WeaponMasterData.Builder();

            weaponMasterDataBuilder.SetCollisionShapeDistanceToLeftEdgeFromCenter(1);
            weaponMasterDataBuilder.SetCollisionShapeDistanceToRightEdgeFromCenter(2);
            weaponMasterDataBuilder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            weaponMasterDataBuilder.SetCollisionShapeDistanceToBottomEdgeFromCenter(4);

            WeaponMasterData testWeaponMasterData = weaponMasterDataBuilder.Build();

            Weapon result = ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(testWeaponMasterData);

            Assert.That(result.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(1));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(2));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(3));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(4));
        }

        [Test]
        public void TestConvertArmorMasterDataToArmorConvertsCollisionDimensions()
        {
            ArmorMasterData.Builder armorMasterDataBuilder = new ArmorMasterData.Builder();

            armorMasterDataBuilder.SetCollisionShapeDistanceToLeftEdgeFromCenter(4);
            armorMasterDataBuilder.SetCollisionShapeDistanceToRightEdgeFromCenter(5);
            armorMasterDataBuilder.SetCollisionShapeDistanceToTopEdgeFromCenter(6);
            armorMasterDataBuilder.SetCollisionShapeDistanceToBottomEdgeFromCenter(7);

            ArmorMasterData testArmorMasterData = armorMasterDataBuilder.Build();

            Armor result = ItemMasterDataToItemConverter.ConvertArmorMasterDataToArmor(testArmorMasterData);

            Assert.That(result.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(4));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(5));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(6));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(7));
        }

        [Test]
        public void TestConvertRecoveryPotionMasterDataToPotionConvertsCollisionDimensions()
        {
            RecoveryPotionMasterData.Builder potionMasterDataBuilder = new RecoveryPotionMasterData.Builder();

            potionMasterDataBuilder.SetCollisionShapeDistanceToLeftEdgeFromCenter(7);
            potionMasterDataBuilder.SetCollisionShapeDistanceToRightEdgeFromCenter(8);
            potionMasterDataBuilder.SetCollisionShapeDistanceToTopEdgeFromCenter(9);
            potionMasterDataBuilder.SetCollisionShapeDistanceToBottomEdgeFromCenter(10);

            RecoveryPotionMasterData testPotionMasterData = potionMasterDataBuilder.Build();

            RecoveryPotion result = ItemMasterDataToItemConverter.ConvertRecoveryPotionMasterDataToPotion(testPotionMasterData);

            Assert.That(result.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(7));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(8));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(9));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(10));
        }

        [Test]
        public void TestConvertJewelryMasterDataToJewelryConvertsCollisionDimensions()
        {
            JewelryMasterData.Builder jewelryMasterDataBuilder = new JewelryMasterData.Builder();

            jewelryMasterDataBuilder.SetCollisionShapeDistanceToLeftEdgeFromCenter(10);
            jewelryMasterDataBuilder.SetCollisionShapeDistanceToRightEdgeFromCenter(11);
            jewelryMasterDataBuilder.SetCollisionShapeDistanceToTopEdgeFromCenter(12);
            jewelryMasterDataBuilder.SetCollisionShapeDistanceToBottomEdgeFromCenter(13);

            JewelryMasterData testJewelryMasterData = jewelryMasterDataBuilder.Build();

            Jewelry result = ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(testJewelryMasterData);

            Assert.That(result.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(10));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(11));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(12));
            Assert.That(result.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(13));
        }
        
        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateImplicitMasterDataForTest()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(5)
                .SetMaxValue(6)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusGlobalArmorIncrease)
                .Build();
        }
    }
}