using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class WeaponMasterDataProvider
    {
        private const string ID_PREFIX = "Masterdata/Item/Equipment/Weapon/";

        // OneHandedSword
        private const string ID_CORRODED_CUTLASS = ID_PREFIX + "OneHandedSword/CorrodedCutlass";
        private const string ID_BRONZE_CUTLASS = ID_PREFIX + "OneHandedSword/BronzeCutlass";
        private const string ID_STEEL_CUTLASS = ID_PREFIX + "OneHandedSword/SteelCutlass";
        private const string ID_EXCEPTIONAL_STEEL_CUTLASS = ID_PREFIX + "OneHandedSword/ExceptionalSteelCutlass";
        private const string ID_CORRODED_SWORD = ID_PREFIX + "OneHandedSword/CorrodedSword";
        private const string ID_BRONZE_SWORD = ID_PREFIX + "OneHandedSword/BronzeSword";
        private const string ID_STEEL_SWORD = ID_PREFIX + "OneHandedSword/SteelSword";
        private const string ID_EXCEPTIONAL_STEEL_SWORD = ID_PREFIX + "OneHandedSword/ExceptionalSteelSword";

        // OneHandedStabbingSword
        private const string ID_CORRODED_RAPIER = ID_PREFIX + "OneHandedStabbingSword/CorrodedRapier";
        private const string ID_BRONZE_RAPIER = ID_PREFIX + "OneHandedStabbingSword/BronzeRapier";
        private const string ID_CORRODED_FOIL = ID_PREFIX + "OneHandedStabbingSword/CorrodedFoil";
        private const string ID_BRONZE_FOIL = ID_PREFIX + "OneHandedStabbingSword/BronzeFoil";
        private const string ID_EXCEPTIONAL_BRONZE_FOIL = ID_PREFIX + "OneHandedStabbingSword/ExceptionalBronzeFoil";
        private const string ID_RUSTED_STEEL_FOIL = ID_PREFIX + "OneHandedStabbingSword/RustedSteelFoil";
        private const string ID_STEEL_FOIL = ID_PREFIX + "OneHandedStabbingSword/SteelFoil";
        private const string ID_FLEXIBLE_STEEL_FOIL = ID_PREFIX + "OneHandedStabbingSword/FlexibleSteelFoil";
        private const string ID_EXCEPTIONAL_STEEL_FOIL = ID_PREFIX + "OneHandedStabbingSword/ExceptionalSteelFoil";

        // TwoHandedSword
        private const string ID_CORRODED_BASTARD_SWORD = ID_PREFIX + "TwoHandedSword/CorrodedBastardSword";
        private const string ID_BRONZE_BASTARD_SWORD = ID_PREFIX + "TwoHandedSword/BronzeBastardSword";
        private const string ID_STEEL_BASTARD_SWORD = ID_PREFIX + "TwoHandedSword/SteelBastardSword";
        private const string ID_EXCEPTIONAL_STEEL_BASTARD_SWORD = ID_PREFIX + "TwoHandedSword/ExceptionalSteelBastardSword";

        // Dagger
        private const string ID_CORRODED_DAGGER = ID_PREFIX + "Dagger/CorrodedDagger";
        private const string ID_CORRODED_ARTISANS_KNIFE = ID_PREFIX + "Dagger/CorrodedArtisansKnife";
        private const string ID_BRONZE_ARTISANS_KNIFE = ID_PREFIX + "Dagger/BronzeArtisansKnife";
        private const string ID_STEEL_ARTISANS_KNIFE = ID_PREFIX + "Dagger/SteelArtisansKnife";

        // SpellDagger
        private const string ID_CORRODED_ALCHEMISTS_KNIFE = ID_PREFIX + "SpellDagger/CorrodedAlchemistsKnife";
        private const string ID_BRONZE_ALCHEMISTS_KNIFE = ID_PREFIX + "SpellDagger/BronzeAlchemistsKnife";
        private const string ID_STEEL_ALCHEMISTS_KNIFE = ID_PREFIX + "SpellDagger/SteelAlchemistsKnife";

        // OneHandedAxe
        private const string ID_CORRODED_HATCHET = ID_PREFIX + "OneHandedAxe/CorrodedHatchet";
        private const string ID_BRONZE_HATCHET = ID_PREFIX + "OneHandedAxe/BronzeHatchet";
        private const string ID_STEEL_HATCHET = ID_PREFIX + "OneHandedAxe/SteelHatchet";
        private const string ID_EXCEPTIONAL_STEEL_HATCHET = ID_PREFIX + "OneHandedAxe/ExceptionalSteelHatchet";

        // TwoHandedAxe
        private const string ID_CORRODED_LUMBERJACK_AXE = ID_PREFIX + "TwoHandedAxe/CorrodedLumberjackAxe";
        private const string ID_BRONZE_LUMBERJACK_AXE = ID_PREFIX + "TwoHandedAxe/BronzeLumberjackAxe";
        private const string ID_STEEL_LUMBERJACK_AXE = ID_PREFIX + "TwoHandedAxe/SteelLumberjackAxe";
        private const string ID_EXCEPTIONAL_STEEL_LUMBERJACK_AXE = ID_PREFIX + "TwoHandedAxe/ExceptionalSteelLumberjackAxe";

        // FistWeapon
        private const string ID_CORRODED_SLASHING_CLAW = ID_PREFIX + "FistWeapon/CorrodedSlashingClaw";
        private const string ID_BRONZE_SLASHING_CLAW = ID_PREFIX + "FistWeapon/BronzeSlashingClaw";
        private const string ID_STEEL_SLASHING_CLAW = ID_PREFIX + "FistWeapon/SteelSlashingClaw";
        private const string ID_EXCEPTIONAL_STEEL_SLASHING_CLAW = ID_PREFIX + "FistWeapon/ExceptionalSteelSlashingClaw";

        // WizardStaff
        private const string ID_ROTTEN_QUARTERSTAFF = ID_PREFIX + "WizardStaff/RottenQuarterstaff";
        private const string ID_CRACKED_QUARTERSTAFF = ID_PREFIX + "WizardStaff/CrackedQuarterstaff";
        private const string ID_QUARTERSTAFF = ID_PREFIX + "WizardStaff/Quarterstaff";
        private const string ID_REINFORCED_QUARTERSTAFF = ID_PREFIX + "WizardStaff/ReinforcedQuarterstaff";

        // MartialStaff
        private const string ID_ERODED_STAFF = ID_PREFIX + "MartialStaff/ErodedStaff";
        private const string ID_BRONZE_STAFF = ID_PREFIX + "MartialStaff/BronzeStaff";
        private const string ID_STEEL_STAFF = ID_PREFIX + "MartialStaff/SteelStaff";

        // OneHandedMace
        private const string ID_ROTTEN_BARBED_CLUB = ID_PREFIX + "OneHandedMace/RottenBarbedClub";
        private const string ID_BRONZE_BARBED_CLUB = ID_PREFIX + "OneHandedMace/BronzeBarbedClub";
        private const string ID_STEEL_BARBED_CLUB = ID_PREFIX + "OneHandedMace/SteelBarbedClub";
        private const string ID_EXCEPTIONAL_STEEL_BARBED_CLUB = ID_PREFIX + "OneHandedMace/ExceptionalSteelBarbedClub";
        private const string ID_ROTTEN_WOODEN_CLUB = ID_PREFIX + "OneHandedMace/RottenWoodenClub";
        private const string ID_RAW_WOODEN_CLUB = ID_PREFIX + "OneHandedMace/RawWoodenClub";
        private const string ID_WOODEN_CLUB = ID_PREFIX + "OneHandedMace/WoodenClub";

        // TwoHandedMace
        private const string ID_ROTTEN_WOODEN_MAUL = ID_PREFIX + "TwoHandedMace/RottenWoodenMaul";
        private const string ID_RAW_WOODEN_MAUL = ID_PREFIX + "TwoHandedMace/RawWoodenMaul";
        private const string ID_WOODEN_MAUL = ID_PREFIX + "TwoHandedMace/WoodenMaul";
        private const string ID_REINFORCED_WOODEN_MAUL = ID_PREFIX + "TwoHandedMace/ReinforcedWoodenMaul";
        private const string ID_ROTTEN_CARVED_MAUL = ID_PREFIX + "TwoHandedMace/RottenCarvedMaul";
        private const string ID_CARVED_MAUL = ID_PREFIX + "TwoHandedMace/CarvedMaul";
        private const string ID_REINFORCED_CARVED_MAUL = ID_PREFIX + "TwoHandedMace/ReinforcedCarvedMaul";

        // MagicMace
        private const string ID_CORRODED_ROYAL_SCEPTRE = ID_PREFIX + "MagicMace/CorrodedRoyalSceptre";
        private const string ID_BRONZE_ROYAL_SCEPTRE = ID_PREFIX + "MagicMace/BronzeRoyalSceptre";
        private const string ID_SILVER_ROYAL_SCEPTRE = ID_PREFIX + "MagicMace/SilverRoyalSceptre";
        private const string ID_GOLDEN_ROYAL_SCEPTRE = ID_PREFIX + "MagicMace/GoldenRoyalSceptre";
        private const string ID_ROTTEN_TRIBAL_SCEPTRE = ID_PREFIX + "MagicMace/RottenTribalSceptre";
        private const string ID_TRIBAL_SCEPTRE = ID_PREFIX + "MagicMace/TribalSceptre";
        private const string ID_REINFORCED_TRIBAL_SCEPTRE = ID_PREFIX + "MagicMace/ReinforcedTribalSceptre";

        // Bow
        private const string ID_PRIMITIVE_BOW = ID_PREFIX + "Bow/PrimitiveBow";
        private const string ID_SHORT_BOW = ID_PREFIX + "Bow/ShortBow";
        private const string ID_COMPOSITE_SHORT_BOW = ID_PREFIX + "Bow/CompositeShortBow";
        private const string ID_EXCEPTIONAL_COMPOSITE_SHORT_BOW = ID_PREFIX + "Bow/ExceptionalCompositeShortBow";

        // Wand
        private const string ID_ROTTEN_WAND = ID_PREFIX + "Wand/RottenWand";
        private const string ID_ROTTEN_PYROMANCERS_WAND = ID_PREFIX + "Wand/RottenPyromancersWand";
        private const string ID_PYROMANCERS_WAND = ID_PREFIX + "Wand/PyromancersWand";
        private const string ID_EXCEPTIONAL_PYROMANCERS_WAND = ID_PREFIX + "Wand/ExceptionalPyromancersWand";

        private Dictionary<string, Func<WeaponMasterData>> factoriesByUniqueId;

        public WeaponMasterDataProvider()
        {
            factoriesByUniqueId = new Dictionary<string, Func<WeaponMasterData>>
            {
                { ID_CORRODED_CUTLASS, GetCorrodedCutlassMasterData },
                { ID_BRONZE_CUTLASS, GetBronzeCutlassMasterData },
                { ID_STEEL_CUTLASS, GetSteelCutlassMasterData },
                { ID_EXCEPTIONAL_STEEL_CUTLASS, GetExceptionalSteelCutlassMasterData },
                { ID_CORRODED_SWORD, GetCorrodedSwordMasterData },
                { ID_BRONZE_SWORD, GetBronzeSwordMasterData },
                { ID_STEEL_SWORD, GetSteelSwordMasterData },
                { ID_EXCEPTIONAL_STEEL_SWORD, GetExceptionalSteelSwordMasterData },

                { ID_CORRODED_RAPIER, GetCorrodedRapierMasterData },
                { ID_BRONZE_RAPIER, GetBronzeRapierMasterData },
                { ID_CORRODED_FOIL, GetCorrodedFoilMasterData },
                { ID_BRONZE_FOIL, GetBronzeFoilMasterData },
                { ID_EXCEPTIONAL_BRONZE_FOIL, GetExceptionalBronzeFoilMasterData },
                { ID_RUSTED_STEEL_FOIL, GetRustedSteelFoilMasterData },
                { ID_STEEL_FOIL, GetSteelFoilMasterData },
                { ID_FLEXIBLE_STEEL_FOIL, GetFlexibleSteelFoilMasterData },
                { ID_EXCEPTIONAL_STEEL_FOIL, GetExceptionalSteelFoilMasterData },

                { ID_CORRODED_BASTARD_SWORD, GetCorrodedBastardSwordMasterData },
                { ID_BRONZE_BASTARD_SWORD, GetBronzeBastardSwordMasterData },
                { ID_STEEL_BASTARD_SWORD, GetSteelBastardSwordMasterData },
                { ID_EXCEPTIONAL_STEEL_BASTARD_SWORD, GetExceptionalSteelBastardSwordMasterData },

                { ID_CORRODED_DAGGER, GetCorrodedDaggerMasterData },
                { ID_CORRODED_ARTISANS_KNIFE, GetCorrodedArtisansKnifeMasterData },
                { ID_BRONZE_ARTISANS_KNIFE, GetBronzeArtisansKnifeMasterData },
                { ID_STEEL_ARTISANS_KNIFE, GetSteelArtisansKnifeMasterData },

                { ID_CORRODED_ALCHEMISTS_KNIFE, GetCorrodedAlchemistsKnifeMasterData },
                { ID_BRONZE_ALCHEMISTS_KNIFE, GetBronzeAlchemistsKnifeMasterData },
                { ID_STEEL_ALCHEMISTS_KNIFE, GetSteelAlchemistsKnifeMasterData },

                { ID_CORRODED_HATCHET, GetCorrodedHatchetMasterData },
                { ID_BRONZE_HATCHET, GetBronzeHatchetMasterData },
                { ID_STEEL_HATCHET, GetSteelHatchetMasterData },
                { ID_EXCEPTIONAL_STEEL_HATCHET, GetExceptionalSteelHatchetMasterData },

                { ID_CORRODED_LUMBERJACK_AXE, GetCorrodedLumberjackAxeMasterData },
                { ID_BRONZE_LUMBERJACK_AXE, GetBronzeLumberjackAxeMasterData },
                { ID_STEEL_LUMBERJACK_AXE, GetSteelLumberjackAxeMasterData },
                { ID_EXCEPTIONAL_STEEL_LUMBERJACK_AXE, GetExceptionalSteelLumberjackAxeMasterData },

                { ID_CORRODED_SLASHING_CLAW, GetCorrodedSlashingClawMasterData },
                { ID_BRONZE_SLASHING_CLAW, GetBronzeSlashingClawMasterData },
                { ID_STEEL_SLASHING_CLAW, GetSteelSlashingClawMasterData },
                { ID_EXCEPTIONAL_STEEL_SLASHING_CLAW, GetExceptionalSteelSlashingClawMasterData },

                { ID_ROTTEN_QUARTERSTAFF, GetRottenQuarterstaffMasterData },
                { ID_CRACKED_QUARTERSTAFF, GetCrackedQuarterstaffMasterData },
                { ID_QUARTERSTAFF, GetQuarterstaffMasterData },
                { ID_REINFORCED_QUARTERSTAFF, GetReinforcedQuarterstaffMasterData },

                { ID_ERODED_STAFF, GetErodedStaffMasterData },
                { ID_BRONZE_STAFF, GetBronzeStaffMasterData },
                { ID_STEEL_STAFF, GetSteelStaffMasterData },

                { ID_ROTTEN_BARBED_CLUB, GetRottenBarbedClubMasterData },
                { ID_BRONZE_BARBED_CLUB, GetBronzeBarbedClubMasterData },
                { ID_STEEL_BARBED_CLUB, GetSteelBarbedClubMasterData },
                { ID_EXCEPTIONAL_STEEL_BARBED_CLUB, GetExceptionalSteelBarbedClubMasterData },
                { ID_ROTTEN_WOODEN_CLUB, GetRottenWoodenClubMasterData },
                { ID_RAW_WOODEN_CLUB, GetRawWoodenClubMasterData },
                { ID_WOODEN_CLUB, GetWoodenClubMasterData },

                { ID_ROTTEN_WOODEN_MAUL, GetRottenWoodenMaulMasterData },
                { ID_RAW_WOODEN_MAUL, GetRawWoodenMaulMasterData },
                { ID_WOODEN_MAUL, GetWoodenMaulMasterData },
                { ID_REINFORCED_WOODEN_MAUL, GetReinforcedWoodenMaulMasterData },
                { ID_ROTTEN_CARVED_MAUL, GetRottenCarvedMaulMasterData },
                { ID_CARVED_MAUL, GetCarvedMaulMasterData },
                { ID_REINFORCED_CARVED_MAUL, GetReinforcedCarvedMaulMasterData },

                { ID_CORRODED_ROYAL_SCEPTRE, GetCorrodedRoyalSceptreMasterData },
                { ID_BRONZE_ROYAL_SCEPTRE, GetBronzeRoyalSceptreMasterData },
                { ID_SILVER_ROYAL_SCEPTRE, GetSilverRoyalSceptreMasterData },
                { ID_GOLDEN_ROYAL_SCEPTRE, GetGoldenRoyalSceptreMasterData },
                { ID_ROTTEN_TRIBAL_SCEPTRE, GetRottenTribalSceptreMasterData },
                { ID_TRIBAL_SCEPTRE, GetTribalSceptreMasterData },
                { ID_REINFORCED_TRIBAL_SCEPTRE, GetReinforcedTribalSceptreMasterData },

                { ID_PRIMITIVE_BOW, GetPrimitiveBowMasterData },
                { ID_SHORT_BOW, GetShortBowMasterData },
                { ID_COMPOSITE_SHORT_BOW, GetCompositeShortBowMasterData },
                { ID_EXCEPTIONAL_COMPOSITE_SHORT_BOW, GetExceptionalCompositeShortBowMasterData },

                { ID_ROTTEN_WAND, GetRottenWandMasterData },
                { ID_ROTTEN_PYROMANCERS_WAND, GetRottenPyromancersWandMasterData },
                { ID_PYROMANCERS_WAND, GetPyromancersWandMasterData },
                { ID_EXCEPTIONAL_PYROMANCERS_WAND, GetExceptionalPyromancersWandMasterData }
            };
        }

        public WeaponMasterData GetMasterDataByUniqueId(string uniqueId)
        {
            return factoriesByUniqueId.TryGetValue(uniqueId, out Func<WeaponMasterData> factory) ? factory() : null;
        }

        public WeaponMasterData GetCorrodedCutlassMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 9))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Cutlass")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .SetMaterial(ItemMaterials.METAL_WEAPON);

            builder.SetUniqueId(ID_CORRODED_CUTLASS);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(2);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(7);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(7);

            return builder.Build();
        }

        public WeaponMasterData GetBronzeCutlassMasterData()
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
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .SetMaterial(ItemMaterials.METAL_WEAPON);

            builder.SetUniqueId(ID_BRONZE_CUTLASS);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetSteelCutlassMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 53))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Cutlass")
                .SetMinimumItemLevel(38)
                .SetStrengthRequirement(55)
                .SetAgilityRequirement(79)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_STEEL_CUTLASS);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }      

        public WeaponMasterData GetExceptionalSteelCutlassMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 80))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Cutlass")
                .SetMinimumItemLevel(58)
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(117)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_CUTLASS);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     

        public WeaponMasterData GetCorrodedSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 14))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Sword")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(14)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_CORRODED_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetBronzeSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 33))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Sword")
                .SetMinimumItemLevel(28)
                .SetStrengthRequirement(46)
                .SetAgilityRequirement(55)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_BRONZE_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetSteelSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(34, 55))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Sword")
                .SetMinimumItemLevel(50)
                .SetStrengthRequirement(78)
                .SetAgilityRequirement(94)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_STEEL_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetExceptionalSteelSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(41, 68))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Sword")
                .SetMinimumItemLevel(66)
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }         

        public WeaponMasterData GetCorrodedRapierMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 11))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Corroded Rapier")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(20)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_CORRODED_RAPIER);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     

        public WeaponMasterData GetBronzeRapierMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 25))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Bronze Rapier")
                .SetMinimumItemLevel(17)
                .SetAgilityRequirement(62)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_BRONZE_RAPIER);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetCorrodedFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Corroded Foil")
                .SetMinimumItemLevel(7)
                .SetAgilityRequirement(32)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_CORRODED_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }               

        public WeaponMasterData GetBronzeFoilMasterData()
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

            builder.SetUniqueId(ID_BRONZE_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetExceptionalBronzeFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(18, 33))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Exceptional Bronze Foil")
                .SetMinimumItemLevel(30)
                .SetAgilityRequirement(101)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_EXCEPTIONAL_BRONZE_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetRustedSteelFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(21, 49))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Rusted Steel Foil")
                .SetMinimumItemLevel(46)
                .SetAgilityRequirement(149)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_RUSTED_STEEL_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetSteelFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(28, 51))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Steel Foil")
                .SetMinimumItemLevel(52)
                .SetAgilityRequirement(167)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_STEEL_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetFlexibleSteelFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(27, 64))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Flexible Steel Foil")
                .SetMinimumItemLevel(64)
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_FLEXIBLE_STEEL_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public WeaponMasterData GetExceptionalSteelFoilMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(32, 60))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Exceptional Steel Foil")
                .SetMinimumItemLevel(68)
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_FOIL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }                                                                         

        public WeaponMasterData GetCorrodedBastardSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Corroded Bastard Sword")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(11)
                .SetAgilityRequirement(11)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            builder.SetUniqueId(ID_CORRODED_BASTARD_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }      

        public WeaponMasterData GetBronzeBastardSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 29))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Bronze Bastard Sword")
                .SetMinimumItemLevel(12)
                .SetStrengthRequirement(21)
                .SetAgilityRequirement(30)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            builder.SetUniqueId(ID_BRONZE_BASTARD_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetSteelBastardSwordMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(39, 65))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Steel Bastard Sword")
                .SetMinimumItemLevel(40)
                .SetStrengthRequirement(57)
                .SetAgilityRequirement(83)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            builder.SetUniqueId(ID_STEEL_BASTARD_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetExceptionalSteelBastardSwordMasterData()
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

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_BASTARD_SWORD);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetCorrodedDaggerMasterData()
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

            builder.SetUniqueId(ID_CORRODED_DAGGER);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetCorrodedArtisansKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Corroded Artisan's Knife")
                .SetMinimumItemLevel(5)
                .SetAgilityRequirement(16)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.DAGGER);

            builder.SetUniqueId(ID_CORRODED_ARTISANS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public WeaponMasterData GetBronzeArtisansKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 45))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Bronze Artisan's Knife")
                .SetMinimumItemLevel(30)
                .SetAgilityRequirement(64)
                .SetIntelligenceRequirement(44)
                .SetItemClass(ItemClass.DAGGER);

            builder.SetUniqueId(ID_BRONZE_ARTISANS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetSteelArtisansKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 76))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(650)
                .SetWeaponRange(10)
                .SetName("Steel Artisan's Knife")
                .SetMinimumItemLevel(56)
                .SetAgilityRequirement(113)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.DAGGER);

            builder.SetUniqueId(ID_STEEL_ARTISANS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetCorrodedAlchemistsKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(3, 26))
                .SetMinToMaxSpellDamage(new DamageRange(3, 26))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Corroded Alchemist's Knife")
                .SetMinimumItemLevel(10)
                .SetAgilityRequirement(18)
                .SetIntelligenceRequirement(26)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            builder.SetUniqueId(ID_CORRODED_ALCHEMISTS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetBronzeAlchemistsKnifeMasterData()
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

            builder.SetUniqueId(ID_BRONZE_ALCHEMISTS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }                                                               

        public WeaponMasterData GetSteelAlchemistsKnifeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 86))
                .SetMinToMaxSpellDamage(new DamageRange(10, 86))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Steel Alchemist's Knife")
                .SetMinimumItemLevel(58)
                .SetAgilityRequirement(81)
                .SetIntelligenceRequirement(117)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            builder.SetUniqueId(ID_STEEL_ALCHEMISTS_KNIFE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public WeaponMasterData GetCorrodedHatchetMasterData()
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

            builder.SetUniqueId(ID_CORRODED_HATCHET);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetBronzeHatchetMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 21))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Hatchet")
                .SetMinimumItemLevel(11)
                .SetStrengthRequirement(28)
                .SetAgilityRequirement(19)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            builder.SetUniqueId(ID_BRONZE_HATCHET);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }         

        public WeaponMasterData GetSteelHatchetMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(25, 46))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Hatchet")
                .SetMinimumItemLevel(39)
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(56)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            builder.SetUniqueId(ID_STEEL_HATCHET);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetExceptionalSteelHatchetMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 70))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Hatchet")
                .SetMinimumItemLevel(59)
                .SetStrengthRequirement(119)
                .SetAgilityRequirement(82)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_HATCHET);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetCorrodedLumberjackAxeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 20))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Corroded Lumberjack Axe")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(17)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            builder.SetUniqueId(ID_CORRODED_LUMBERJACK_AXE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetBronzeLumberjackAxeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 39))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Bronze Lumberjack Axe")
                .SetMinimumItemLevel(13)
                .SetStrengthRequirement(36)
                .SetAgilityRequirement(17)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            builder.SetUniqueId(ID_BRONZE_LUMBERJACK_AXE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetSteelLumberjackAxeMasterData()
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

            builder.SetUniqueId(ID_STEEL_LUMBERJACK_AXE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetExceptionalSteelLumberjackAxeMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(74, 155))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Exceptional Steel Lumberjack Axe")
                .SetMinimumItemLevel(60)
                .SetStrengthRequirement(149)
                .SetAgilityRequirement(76)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_LUMBERJACK_AXE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetCorrodedSlashingClawMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 11))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(620)
                .SetWeaponRange(12)
                .SetName("Corroded Slashing Claw")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(11)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.FIST_WEAPON);

            builder.SetUniqueId(ID_CORRODED_SLASHING_CLAW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetBronzeSlashingClawMasterData()
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

            builder.SetUniqueId(ID_BRONZE_SLASHING_CLAW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }      

        public WeaponMasterData GetSteelSlashingClawMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(23, 43))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Steel Slashing Claw")
                .SetMinimumItemLevel(43)
                .SetAgilityRequirement(88)
                .SetIntelligenceRequirement(61)
                .SetItemClass(ItemClass.FIST_WEAPON);

            builder.SetUniqueId(ID_STEEL_SLASHING_CLAW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }        

        public WeaponMasterData GetExceptionalSteelSlashingClawMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(29, 55))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Slashing Claw")
                .SetMinimumItemLevel(62)
                .SetAgilityRequirement(131)
                .SetIntelligenceRequirement(95)
                .SetItemClass(ItemClass.FIST_WEAPON);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_SLASHING_CLAW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetRottenQuarterstaffMasterData()
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

            builder.SetUniqueId(ID_ROTTEN_QUARTERSTAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetCrackedQuarterstaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(24, 41))
                .SetMinToMaxSpellDamage(new DamageRange(24, 41))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Cracked Quarterstaff")
                .SetMinimumItemLevel(18)
                .SetStrengthRequirement(35)
                .SetIntelligenceRequirement(35)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            builder.SetUniqueId(ID_CRACKED_QUARTERSTAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     

        public WeaponMasterData GetQuarterstaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(51, 86))
                .SetMinToMaxSpellDamage(new DamageRange(51, 86))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Quarterstaff")
                .SetMinimumItemLevel(45)
                .SetStrengthRequirement(78)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            builder.SetUniqueId(ID_QUARTERSTAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetReinforcedQuarterstaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(72, 120))
                .SetMinToMaxSpellDamage(new DamageRange(72, 120))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Reinforced Quarterstaff")
                .SetMinimumItemLevel(62)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            builder.SetUniqueId(ID_REINFORCED_QUARTERSTAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetErodedStaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(14, 42))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(640)
                .SetWeaponRange(16)
                .SetName("Eroded Staff")
                .SetMinimumItemLevel(13)
                .SetStrengthRequirement(27)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            builder.SetUniqueId(ID_ERODED_STAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetBronzeStaffMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 114))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(660)
                .SetWeaponRange(16)
                .SetName("Bronze Staff")
                .SetMinimumItemLevel(41)
                .SetStrengthRequirement(72)
                .SetIntelligenceRequirement(72)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            builder.SetUniqueId(ID_BRONZE_STAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetSteelStaffMasterData()
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

            builder.SetUniqueId(ID_STEEL_STAFF);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetRottenBarbedClubMasterData()
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

            builder.SetUniqueId(ID_ROTTEN_BARBED_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }      

        public WeaponMasterData GetBronzeBarbedClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Barbed Club")
                .SetMinimumItemLevel(10)
                .SetStrengthRequirement(41)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_BRONZE_BARBED_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetSteelBarbedClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(33, 42))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Barbed Club")
                .SetMinimumItemLevel(38)
                .SetStrengthRequirement(125)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_STEEL_BARBED_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }        

        public WeaponMasterData GetExceptionalSteelBarbedClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(49, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Barbed Club")
                .SetMinimumItemLevel(58)
                .SetStrengthRequirement(185)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_EXCEPTIONAL_STEEL_BARBED_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetRottenWoodenClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Rotten Wooden Club")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_ROTTEN_WOODEN_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetRawWoodenClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(31, 51))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Raw Wooden Club")
                .SetMinimumItemLevel(35)
                .SetStrengthRequirement(116)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_RAW_WOODEN_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetWoodenClubMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 80))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Wooden Club")
                .SetMinimumItemLevel(56)
                .SetStrengthRequirement(179)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            builder.SetUniqueId(ID_WOODEN_CLUB);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }            

        public WeaponMasterData GetRottenWoodenMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 16))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Rotten Wooden Maul")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(20)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_ROTTEN_WOODEN_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetRawWoodenMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(16, 33))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Raw Wooden Maul")
                .SetMinimumItemLevel(12)
                .SetStrengthRequirement(47)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_RAW_WOODEN_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     

        public WeaponMasterData GetWoodenMaulMasterData()
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

            builder.SetUniqueId(ID_WOODEN_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetReinforcedWoodenMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(65, 135))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(16)
                .SetName("Reinforced Wooden Maul")
                .SetMinimumItemLevel(59)
                .SetStrengthRequirement(188)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_REINFORCED_WOODEN_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetRottenCarvedMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 25))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Rotten Carved Maul")
                .SetMinimumItemLevel(8)
                .SetStrengthRequirement(35)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_ROTTEN_CARVED_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetCarvedMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(57, 85))
                .SetSkillsPerSecond(1.1)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Carved Maul")
                .SetMinimumItemLevel(36)
                .SetStrengthRequirement(119)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_CARVED_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetReinforcedCarvedMaulMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(112, 168))
                .SetSkillsPerSecond(1.0)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Reinforced Carved Maul")
                .SetMinimumItemLevel(57)
                .SetStrengthRequirement(182)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            builder.SetUniqueId(ID_REINFORCED_CARVED_MAUL);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetCorrodedRoyalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 11))
                .SetMinToMaxSpellDamage(new DamageRange(8, 11))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Corroded Royal Sceptre")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetIntelligenceRequirement(8)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_CORRODED_ROYAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetBronzeRoyalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(21, 50))
                .SetMinToMaxSpellDamage(new DamageRange(21, 50))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Bronze Royal Sceptre")
                .SetMinimumItemLevel(28)
                .SetStrengthRequirement(51)
                .SetIntelligenceRequirement(51)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_BRONZE_ROYAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetSilverRoyalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(34, 80))
                .SetMinToMaxSpellDamage(new DamageRange(34, 80))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Silver Royal Sceptre")
                .SetMinimumItemLevel(50)
                .SetStrengthRequirement(86)
                .SetIntelligenceRequirement(86)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_SILVER_ROYAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetGoldenRoyalSceptreMasterData()
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

            builder.SetUniqueId(ID_GOLDEN_ROYAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetRottenTribalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 17))
                .SetMinToMaxSpellDamage(new DamageRange(11, 17))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Rotten Tribal Sceptre")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(14)
                .SetIntelligenceRequirement(14)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_ROTTEN_TRIBAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }      

        public WeaponMasterData GetTribalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(24, 36))
                .SetMinToMaxSpellDamage(new DamageRange(24, 36))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Tribal Sceptre")
                .SetMinimumItemLevel(35)
                .SetStrengthRequirement(62)
                .SetIntelligenceRequirement(62)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_TRIBAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetReinforcedTribalSceptreMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(37, 55))
                .SetMinToMaxSpellDamage(new DamageRange(37, 55))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Reinforced Tribal Sceptre")
                .SetMinimumItemLevel(56)
                .SetStrengthRequirement(96)
                .SetIntelligenceRequirement(96)
                .SetItemClass(ItemClass.MAGIC_MACE);

            builder.SetUniqueId(ID_REINFORCED_TRIBAL_SCEPTRE);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetPrimitiveBowMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Primitive Bow")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.BOW);

            builder.SetUniqueId(ID_PRIMITIVE_BOW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetShortBowMasterData()
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

            builder.SetUniqueId(ID_SHORT_BOW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }    

        public WeaponMasterData GetCompositeShortBowMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 61))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Composite Short Bow")
                .SetMinimumItemLevel(35)
                .SetAgilityRequirement(116)
                .SetItemClass(ItemClass.BOW);

            builder.SetUniqueId(ID_COMPOSITE_SHORT_BOW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     


        public WeaponMasterData GetExceptionalCompositeShortBowMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(32, 96))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Exceptional Composite Short Bow")
                .SetMinimumItemLevel(56)
                .SetAgilityRequirement(179)
                .SetItemClass(ItemClass.BOW);

            builder.SetUniqueId(ID_EXCEPTIONAL_COMPOSITE_SHORT_BOW);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        } 

        public WeaponMasterData GetRottenWandMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(5, 9))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Rotten Wand")
                .SetMinimumItemLevel(1)
                .SetIntelligenceRequirement(14)
                .SetItemClass(ItemClass.WAND);

            builder.SetUniqueId(ID_ROTTEN_WAND);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }     

        public WeaponMasterData GetRottenPyromancersWandMasterData()
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

            builder.SetUniqueId(ID_ROTTEN_PYROMANCERS_WAND);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }  

        public WeaponMasterData GetPyromancersWandMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(26, 48))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Pyromancer's Wand")
                .SetMinimumItemLevel(35)
                .SetIntelligenceRequirement(116)
                .SetItemClass(ItemClass.WAND);

            builder.SetUniqueId(ID_PYROMANCERS_WAND);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }   

        public WeaponMasterData GetExceptionalPyromancersWandMasterData()
        {
            WeaponMasterData.Builder builder = new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(38, 71))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Exceptional Pyromancer's Wand")
                .SetMinimumItemLevel(56)
                .SetIntelligenceRequirement(179)
                .SetItemClass(ItemClass.WAND);

            builder.SetUniqueId(ID_EXCEPTIONAL_PYROMANCERS_WAND);
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }                                                                                                                                                                                                                                                                                                                                                       
    }
}