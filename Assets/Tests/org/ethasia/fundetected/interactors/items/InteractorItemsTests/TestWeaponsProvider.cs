using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class TestWeaponsProvider
    {
        public static Weapon CreateOneHandedSword()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetBronzeCutlassMasterData());
        }

        public static Weapon CreateOneHandedStabbingSword()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetBronzeFoilMasterData());
        }

        public static Weapon CreateTwoHandedSword()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetExceptionalSteelBastardSwordMasterData());
        }

        public static Weapon CreateDagger()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetCorrodedDaggerMasterData());
        }

        public static Weapon CreateSpellDagger()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetBronzeAlchemistsKnifeMasterData());
        }

        public static Weapon CreateOneHandedAxe()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetCorrodedHatchetMasterData());
        }

        public static Weapon CreateTwoHandedAxe()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetSteelLumberjackAxeMasterData());
        }

        public static Weapon CreateFistWeapon()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetBronzeSlashingClawMasterData());
        }

        public static Weapon CreateWizardStaff()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetRottenQuarterstaffMasterData());
        }

        public static Weapon CreateMartialStaff()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetSteelStaffMasterData());
        }

        public static Weapon CreateOneHandedMace()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetRottenBarbedClubMasterData());
        }

        public static Weapon CreateTwoHandedMace()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetWoodenMaulMasterData());
        }

        public static Weapon CreateMagicMace()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetGoldenRoyalSceptreMasterData());
        }

        public static Weapon CreateBow()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetShortBowMasterData());
        }

        public static Weapon CreateWand()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(GetRottenPyromancersWandMasterData());
        }

        private static WeaponMasterData GetBronzeCutlassMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 22))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Cutlass")
                .SetMinimumItemLevel(10)
                .SetStrengthRequirement(18)
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        private static WeaponMasterData GetBronzeFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 29))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Bronze Foil")
                .SetMinimumItemLevel(22)
                .SetAgilityRequirement(77)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetExceptionalSteelBastardSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(69, 115))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Exceptional Steel Bastard Sword")
                .SetMinimumItemLevel(65)
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        private static WeaponMasterData GetCorrodedDaggerMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 10))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Corroded Dagger")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(9)
                .SetIntelligenceRequirement(6)
                .SetItemClass(ItemClass.DAGGER);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetBronzeAlchemistsKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(7, 62))
                .SetMinToMaxSpellDamage(new DamageRange(7, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Bronze Alchemist's Knife")
                .SetMinimumItemLevel(38)
                .SetAgilityRequirement(55)
                .SetIntelligenceRequirement(79)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        private static WeaponMasterData GetCorrodedHatchetMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 11))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Hatchet")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetAgilityRequirement(6)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetSteelLumberjackAxeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 99))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Steel Lumberjack Axe")
                .SetMinimumItemLevel(41)
                .SetStrengthRequirement(97)
                .SetAgilityRequirement(45)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetBronzeSlashingClawMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 22))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Bronze Slashing Claw")
                .SetMinimumItemLevel(17)
                .SetAgilityRequirement(39)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.FIST_WEAPON);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetRottenQuarterstaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(9, 19))
                .SetMinToMaxSpellDamage(new DamageRange(9, 19))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Rotten Quarterstaff")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetIntelligenceRequirement(12)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetSteelStaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(53, 160))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(730)
                .SetWeaponRange(16)
                .SetName("Steel Staff")
                .SetMinimumItemLevel(60)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetRottenBarbedClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 8))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Rotten Barbed Club")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetWoodenMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(43, 88))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Wooden Maul")
                .SetMinimumItemLevel(40)
                .SetStrengthRequirement(131)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetGoldenRoyalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(41, 95))
                .SetMinToMaxSpellDamage(new DamageRange(41, 95))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Golden Royal Sceptre")
                .SetMinimumItemLevel(66)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        private static WeaponMasterData GetShortBowMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 16))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Short Bow")
                .SetMinimumItemLevel(5)
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.BOW);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        private static WeaponMasterData GetRottenPyromancersWandMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(9, 16))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Rotten Pyromancer's Wand")
                .SetMinimumItemLevel(6)
                .SetIntelligenceRequirement(29)
                .SetItemClass(ItemClass.WAND);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  
    }
}