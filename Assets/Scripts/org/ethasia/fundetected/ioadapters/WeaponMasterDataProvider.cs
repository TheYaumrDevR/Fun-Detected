using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class WeaponMasterDataProvider
    {
        public WeaponMasterData GetCorrodedCutlassMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 9))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Cutlass")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }

        public WeaponMasterData GetBronzeCutlassMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 22))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Cutlass")
                .SetMinimumItemLevel(10)
                .SetStrengthRequirement(18)
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }    

        public WeaponMasterData GetSteelCutlassMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 53))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Cutlass")
                .SetMinimumItemLevel(38)
                .SetStrengthRequirement(55)
                .SetAgilityRequirement(79)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }      

        public WeaponMasterData GetExceptionalSteelCutlassMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 80))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Cutlass")
                .SetMinimumItemLevel(58)
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(117)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }     

        public WeaponMasterData GetCorrodedSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 14))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Sword")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(14)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }  

        public WeaponMasterData GetBronzeSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 33))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Sword")
                .SetMinimumItemLevel(28)
                .SetStrengthRequirement(46)
                .SetAgilityRequirement(55)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }  

        public WeaponMasterData GetSteelSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(34, 55))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Sword")
                .SetMinimumItemLevel(50)
                .SetStrengthRequirement(78)
                .SetAgilityRequirement(94)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }  

        public WeaponMasterData GetExceptionalSteelSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(41, 68))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Sword")
                .SetMinimumItemLevel(66)
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();
        }         

        public WeaponMasterData GetCorrodedRapierMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 11))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Corroded Rapier")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(20)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }     

        public WeaponMasterData GetBronzeRapierMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 25))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Bronze Rapier")
                .SetMinimumItemLevel(17)
                .SetAgilityRequirement(62)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }   

        public WeaponMasterData GetCorrodedFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Corroded Foil")
                .SetMinimumItemLevel(7)
                .SetAgilityRequirement(32)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }               

        public WeaponMasterData GetBronzeFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 29))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Bronze Foil")
                .SetMinimumItemLevel(22)
                .SetAgilityRequirement(77)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }   

        public WeaponMasterData GetExceptionalBronzeFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(18, 33))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Exceptional Bronze Foil")
                .SetMinimumItemLevel(30)
                .SetAgilityRequirement(101)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }  

        public WeaponMasterData GetRustedSteelFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(21, 49))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Rusted Steel Foil")
                .SetMinimumItemLevel(46)
                .SetAgilityRequirement(149)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }    

        public WeaponMasterData GetSteelFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(28, 51))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Steel Foil")
                .SetMinimumItemLevel(52)
                .SetAgilityRequirement(167)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }    

        public WeaponMasterData GetFlexibleSteelFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(27, 64))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Flexible Steel Foil")
                .SetMinimumItemLevel(64)
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }

        public WeaponMasterData GetExceptionalSteelFoilMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(32, 60))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18)
                .SetName("Exceptional Steel Foil")
                .SetMinimumItemLevel(68)
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD)
                .Build();
        }                                                                         

        public WeaponMasterData GetCorrodedBastardSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Corroded Bastard Sword")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(11)
                .SetAgilityRequirement(11)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD)
                .Build();
        }      

        public WeaponMasterData GetBronzeBastardSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 29))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Bronze Bastard Sword")
                .SetMinimumItemLevel(12)
                .SetStrengthRequirement(21)
                .SetAgilityRequirement(30)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD)
                .Build();
        } 

        public WeaponMasterData GetSteelBastardSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(39, 65))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Steel Bastard Sword")
                .SetMinimumItemLevel(40)
                .SetStrengthRequirement(57)
                .SetAgilityRequirement(83)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD)
                .Build();
        }    

        public WeaponMasterData GetExceptionalSteelBastardSwordMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(69, 115))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Exceptional Steel Bastard Sword")
                .SetMinimumItemLevel(65)
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD)
                .Build();
        }  

        public WeaponMasterData GetCorrodedDaggerMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 10))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Corroded Dagger")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(9)
                .SetIntelligenceRequirement(6)
                .SetItemClass(ItemClass.DAGGER)
                .Build();
        }  

        public WeaponMasterData GetCorrodedArtisansKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Corroded Artisan's Knife")
                .SetMinimumItemLevel(5)
                .SetAgilityRequirement(16)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.DAGGER)
                .Build();
        }

        public WeaponMasterData GetBronzeArtisansKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 45))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10)
                .SetName("Bronze Artisan's Knife")
                .SetMinimumItemLevel(30)
                .SetAgilityRequirement(64)
                .SetIntelligenceRequirement(44)
                .SetItemClass(ItemClass.DAGGER)
                .Build();
        }  

        public WeaponMasterData GetSteelArtisansKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 76))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(650)
                .SetWeaponRange(10)
                .SetName("Steel Artisan's Knife")
                .SetMinimumItemLevel(56)
                .SetAgilityRequirement(113)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.DAGGER)
                .Build();
        }    

        public WeaponMasterData GetCorrodedAlchemistsKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(3, 26))
                .SetMinToMaxSpellDamage(new DamageRange(3, 26))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Corroded Alchemist's Knife")
                .SetMinimumItemLevel(10)
                .SetAgilityRequirement(18)
                .SetIntelligenceRequirement(26)
                .SetItemClass(ItemClass.SPELL_DAGGER)
                .Build();
        }   

        public WeaponMasterData GetBronzeAlchemistsKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(7, 62))
                .SetMinToMaxSpellDamage(new DamageRange(7, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Bronze Alchemist's Knife")
                .SetMinimumItemLevel(38)
                .SetAgilityRequirement(55)
                .SetIntelligenceRequirement(79)
                .SetItemClass(ItemClass.SPELL_DAGGER)
                .Build();
        }                                                               

        public WeaponMasterData GetSteelAlchemistsKnifeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 86))
                .SetMinToMaxSpellDamage(new DamageRange(10, 86))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10)
                .SetName("Steel Alchemist's Knife")
                .SetMinimumItemLevel(58)
                .SetAgilityRequirement(81)
                .SetIntelligenceRequirement(117)
                .SetItemClass(ItemClass.SPELL_DAGGER)
                .Build();
        }

        public WeaponMasterData GetCorrodedHatchetMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 11))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Hatchet")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetAgilityRequirement(6)
                .SetItemClass(ItemClass.ONE_HANDED_AXE)
                .Build();
        }   

        public WeaponMasterData GetBronzeHatchetMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 21))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Hatchet")
                .SetMinimumItemLevel(11)
                .SetStrengthRequirement(28)
                .SetAgilityRequirement(19)
                .SetItemClass(ItemClass.ONE_HANDED_AXE)
                .Build();
        }         

        public WeaponMasterData GetSteelHatchetMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(25, 46))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Hatchet")
                .SetMinimumItemLevel(39)
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(56)
                .SetItemClass(ItemClass.ONE_HANDED_AXE)
                .Build();
        } 

        public WeaponMasterData GetExceptionalSteelHatchetMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 70))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Hatchet")
                .SetMinimumItemLevel(59)
                .SetStrengthRequirement(119)
                .SetAgilityRequirement(82)
                .SetItemClass(ItemClass.ONE_HANDED_AXE)
                .Build();
        }    

        public WeaponMasterData GetCorrodedLumberjackAxeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 20))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Corroded Lumberjack Axe")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(17)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.TWO_HANDED_AXE)
                .Build();
        }  

        public WeaponMasterData GetBronzeLumberjackAxeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 39))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Bronze Lumberjack Axe")
                .SetMinimumItemLevel(13)
                .SetStrengthRequirement(36)
                .SetAgilityRequirement(17)
                .SetItemClass(ItemClass.TWO_HANDED_AXE)
                .Build();
        }    

        public WeaponMasterData GetSteelLumberjackAxeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 99))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Steel Lumberjack Axe")
                .SetMinimumItemLevel(41)
                .SetStrengthRequirement(97)
                .SetAgilityRequirement(45)
                .SetItemClass(ItemClass.TWO_HANDED_AXE)
                .Build();
        }    

        public WeaponMasterData GetExceptionalSteelLumberjackAxeMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(74, 155))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Exceptional Steel Lumberjack Axe")
                .SetMinimumItemLevel(60)
                .SetStrengthRequirement(149)
                .SetAgilityRequirement(76)
                .SetItemClass(ItemClass.TWO_HANDED_AXE)
                .Build();
        }    

        public WeaponMasterData GetCorrodedSlashingClawMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 11))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(620)
                .SetWeaponRange(12)
                .SetName("Corroded Slashing Claw")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(11)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.FIST_WEAPON)
                .Build();
        }    

        public WeaponMasterData GetBronzeSlashingClawMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 22))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Bronze Slashing Claw")
                .SetMinimumItemLevel(17)
                .SetAgilityRequirement(39)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.FIST_WEAPON)
                .Build();
        }      

        public WeaponMasterData GetSteelSlashingClawMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(23, 43))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Steel Slashing Claw")
                .SetMinimumItemLevel(43)
                .SetAgilityRequirement(88)
                .SetIntelligenceRequirement(61)
                .SetItemClass(ItemClass.FIST_WEAPON)
                .Build();
        }        

        public WeaponMasterData GetExceptionalSteelSlashingClawMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(29, 55))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Slashing Claw")
                .SetMinimumItemLevel(62)
                .SetAgilityRequirement(131)
                .SetIntelligenceRequirement(95)
                .SetItemClass(ItemClass.FIST_WEAPON)
                .Build();
        }    

        public WeaponMasterData GetRottenQuarterstaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(9, 19))
                .SetMinToMaxSpellDamage(new DamageRange(9, 19))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Rotten Quarterstaff")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetIntelligenceRequirement(12)
                .SetItemClass(ItemClass.WIZARD_STAFF)
                .Build();
        }  

        public WeaponMasterData GetCrackedQuarterstaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(24, 41))
                .SetMinToMaxSpellDamage(new DamageRange(24, 41))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Cracked Quarterstaff")
                .SetMinimumItemLevel(18)
                .SetStrengthRequirement(35)
                .SetIntelligenceRequirement(35)
                .SetItemClass(ItemClass.WIZARD_STAFF)
                .Build();
        }     

        public WeaponMasterData GetQuarterstaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(51, 86))
                .SetMinToMaxSpellDamage(new DamageRange(51, 86))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Quarterstaff")
                .SetMinimumItemLevel(45)
                .SetStrengthRequirement(78)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.WIZARD_STAFF)
                .Build();
        }    

        public WeaponMasterData GetReinforcedQuarterstaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(72, 120))
                .SetMinToMaxSpellDamage(new DamageRange(72, 120))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16)
                .SetName("Reinforced Quarterstaff")
                .SetMinimumItemLevel(62)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.WIZARD_STAFF)
                .Build();
        }  

        public WeaponMasterData GetErodedStaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(14, 42))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(640)
                .SetWeaponRange(16)
                .SetName("Eroded Staff")
                .SetMinimumItemLevel(13)
                .SetStrengthRequirement(27)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.MARTIAL_STAFF)
                .Build();
        }   

        public WeaponMasterData GetBronzeStaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 114))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(660)
                .SetWeaponRange(16)
                .SetName("Bronze Staff")
                .SetMinimumItemLevel(41)
                .SetStrengthRequirement(72)
                .SetIntelligenceRequirement(72)
                .SetItemClass(ItemClass.MARTIAL_STAFF)
                .Build();
        }  

        public WeaponMasterData GetSteelStaffMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(53, 160))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(730)
                .SetWeaponRange(16)
                .SetName("Steel Staff")
                .SetMinimumItemLevel(60)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.MARTIAL_STAFF)
                .Build();
        } 

        public WeaponMasterData GetRottenBarbedClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 8))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Rotten Barbed Club")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }      

        public WeaponMasterData GetBronzeBarbedClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Bronze Barbed Club")
                .SetMinimumItemLevel(10)
                .SetStrengthRequirement(41)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        } 

        public WeaponMasterData GetSteelBarbedClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(33, 42))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Steel Barbed Club")
                .SetMinimumItemLevel(38)
                .SetStrengthRequirement(125)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }        

        public WeaponMasterData GetExceptionalSteelBarbedClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(49, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Exceptional Steel Barbed Club")
                .SetMinimumItemLevel(58)
                .SetStrengthRequirement(185)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }    

        public WeaponMasterData GetRottenWoodenClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Rotten Wooden Club")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }  

        public WeaponMasterData GetRawWoodenClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(31, 51))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Raw Wooden Club")
                .SetMinimumItemLevel(35)
                .SetStrengthRequirement(116)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }  

        public WeaponMasterData GetWoodenClubMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 80))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Wooden Club")
                .SetMinimumItemLevel(56)
                .SetStrengthRequirement(179)
                .SetItemClass(ItemClass.ONE_HANDED_MACE)
                .Build();
        }            

        public WeaponMasterData GetRottenWoodenMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 16))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Rotten Wooden Maul")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(20)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        }  

        public WeaponMasterData GetRawWoodenMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(16, 33))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Raw Wooden Maul")
                .SetMinimumItemLevel(12)
                .SetStrengthRequirement(47)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        }     

        public WeaponMasterData GetWoodenMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(43, 88))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Wooden Maul")
                .SetMinimumItemLevel(40)
                .SetStrengthRequirement(131)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        }    

        public WeaponMasterData GetReinforcedWoodenMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(65, 135))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(16)
                .SetName("Reinforced Wooden Maul")
                .SetMinimumItemLevel(59)
                .SetStrengthRequirement(188)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        }   

        public WeaponMasterData GetRottenCarvedMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 25))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Rotten Carved Maul")
                .SetMinimumItemLevel(8)
                .SetStrengthRequirement(35)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        }   

        public WeaponMasterData GetCarvedMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(57, 85))
                .SetSkillsPerSecond(1.1)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Carved Maul")
                .SetMinimumItemLevel(36)
                .SetStrengthRequirement(119)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        } 

        public WeaponMasterData GetReinforcedCarvedMaulMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(112, 168))
                .SetSkillsPerSecond(1.0)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16)
                .SetName("Reinforced Carved Maul")
                .SetMinimumItemLevel(36)
                .SetStrengthRequirement(182)
                .SetItemClass(ItemClass.TWO_HANDED_MACE)
                .Build();
        } 

        public WeaponMasterData GetCorrodedRoyalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 11))
                .SetMinToMaxSpellDamage(new DamageRange(8, 11))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Corroded Royal Sceptre")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetIntelligenceRequirement(8)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        } 

        public WeaponMasterData GetBronzeRoyalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(21, 50))
                .SetMinToMaxSpellDamage(new DamageRange(21, 50))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Bronze Royal Sceptre")
                .SetMinimumItemLevel(28)
                .SetStrengthRequirement(51)
                .SetIntelligenceRequirement(51)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        }    

        public WeaponMasterData GetSilverRoyalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(34, 80))
                .SetMinToMaxSpellDamage(new DamageRange(34, 80))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Silver Royal Sceptre")
                .SetMinimumItemLevel(50)
                .SetStrengthRequirement(86)
                .SetIntelligenceRequirement(86)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        } 

        public WeaponMasterData GetGoldenRoyalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(41, 95))
                .SetMinToMaxSpellDamage(new DamageRange(41, 95))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Golden Royal Sceptre")
                .SetMinimumItemLevel(66)
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        } 

        public WeaponMasterData GetRottenTribalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 17))
                .SetMinToMaxSpellDamage(new DamageRange(11, 17))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Rotten Tribal Sceptre")
                .SetMinimumItemLevel(5)
                .SetStrengthRequirement(14)
                .SetIntelligenceRequirement(14)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        }      

        public WeaponMasterData GetTribalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(24, 36))
                .SetMinToMaxSpellDamage(new DamageRange(24, 36))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Tribal Sceptre")
                .SetMinimumItemLevel(35)
                .SetStrengthRequirement(62)
                .SetIntelligenceRequirement(62)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        } 

        public WeaponMasterData GetReinforcedTribalSceptreMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(37, 55))
                .SetMinToMaxSpellDamage(new DamageRange(37, 55))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12)
                .SetName("Reinforced Tribal Sceptre")
                .SetMinimumItemLevel(56)
                .SetStrengthRequirement(96)
                .SetIntelligenceRequirement(96)
                .SetItemClass(ItemClass.MAGIC_MACE)
                .Build();
        } 

        public WeaponMasterData GetPrimitiveBowMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Primitive Bow")
                .SetMinimumItemLevel(1)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.BOW)
                .Build();
        }  

        public WeaponMasterData GetShortBowMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 16))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Short Bow")
                .SetMinimumItemLevel(5)
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.BOW)
                .Build();
        }    

        public WeaponMasterData GetCompositeShortBowMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 61))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Composite Short Bow")
                .SetMinimumItemLevel(35)
                .SetAgilityRequirement(116)
                .SetItemClass(ItemClass.BOW)
                .Build();
        }     


        public WeaponMasterData GetExceptionalCompositeShortBowMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(32, 96))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(80)
                .SetName("Exceptional Composite Short Bow")
                .SetMinimumItemLevel(56)
                .SetAgilityRequirement(179)
                .SetItemClass(ItemClass.BOW)
                .Build();
        } 

        public WeaponMasterData GetRottenWandMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(5, 9))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Rotten Wand")
                .SetMinimumItemLevel(1)
                .SetIntelligenceRequirement(14)
                .SetItemClass(ItemClass.WAND)
                .Build();
        }     

        public WeaponMasterData GetRottenPyromancersWandMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(9, 16))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Rotten Pyromancer's Wand")
                .SetMinimumItemLevel(6)
                .SetIntelligenceRequirement(29)
                .SetItemClass(ItemClass.WAND)
                .Build();
        }  

        public WeaponMasterData GetPyromancersWandMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(26, 48))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Pyromancer's Wand")
                .SetMinimumItemLevel(35)
                .SetIntelligenceRequirement(116)
                .SetItemClass(ItemClass.WAND)
                .Build();
        }   

        public WeaponMasterData GetExceptionalPyromancersWandMasterData()
        {
            return new WeaponMasterData.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(38, 71))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(60)
                .SetName("Exceptional Pyromancer's Wand")
                .SetMinimumItemLevel(56)
                .SetIntelligenceRequirement(179)
                .SetItemClass(ItemClass.WAND)
                .Build();
        }                                                                                                                                                                                                                                                                                                                                                       
    }
}