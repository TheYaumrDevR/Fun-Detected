using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EquipmentMasterDataProvider
    {
        public Weapon GetCorrodedCutlassMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 9))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Corroded Cutlass")
                .SetStrengthRequirement(8)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }

        public Weapon GetBronzeCutlassMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 22))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Bronze Cutlass")
                .SetStrengthRequirement(18)
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetSteelCutlassMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 53))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Steel Cutlass")
                .SetStrengthRequirement(55)
                .SetAgilityRequirement(79)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }      

        public Weapon GetExceptionalSteelCutlassMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 80))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Exceptional Steel Cutlass")
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(117)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }     

        public Weapon GetCorrodedSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 14))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Corroded Sword")
                .SetStrengthRequirement(14)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }  

        public Weapon GetBronzeSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(20, 33))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Bronze Sword")
                .SetStrengthRequirement(46)
                .SetAgilityRequirement(55)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }  

        public Weapon GetSteelSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(34, 55))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Steel Sword")
                .SetStrengthRequirement(78)
                .SetAgilityRequirement(94)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }  

        public Weapon GetExceptionalSteelSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(41, 68))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Exceptional Steel Sword")
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }         

        public Weapon GetCorrodedRapierMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 11))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Corroded Rapier")
                .SetAgilityRequirement(20)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }     

        public Weapon GetBronzeRapierMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 25))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Bronze Rapier")
                .SetAgilityRequirement(62)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }   

        public Weapon GetCorrodedFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Corroded Foil")
                .SetAgilityRequirement(32)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }               

        public Weapon GetBronzeFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 29))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Bronze Foil")
                .SetAgilityRequirement(77)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }   

        public Weapon GetExceptionalBronzeFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(18, 33))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Exceptional Bronze Foil")
                .SetAgilityRequirement(101)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }  

        public Weapon GetRustedSteelFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(21, 49))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Rusted Steel Foil")
                .SetAgilityRequirement(149)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetSteelFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(28, 51))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Steel Foil")
                .SetAgilityRequirement(167)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetFlexibleSteelFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(27, 64))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Flexible Steel Foil")
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }

        public Weapon GetExceptionalSteelFoilMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(32, 60))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(18);

            weaponBuilder.SetName("Exceptional Steel Foil")
                .SetAgilityRequirement(212)
                .SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            return weaponBuilder.Build();
        }                                                                         

        public Weapon GetCorrodedBastardSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Corroded Bastard Sword")
                .SetStrengthRequirement(11)
                .SetAgilityRequirement(11)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        }      

        public Weapon GetBronzeBastardSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 29))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Bronze Bastard Sword")
                .SetStrengthRequirement(21)
                .SetAgilityRequirement(30)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        } 

        public Weapon GetSteelBastardSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(39, 65))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Steel Bastard Sword")
                .SetStrengthRequirement(57)
                .SetAgilityRequirement(83)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetExceptionalSteelBastardSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(69, 115))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Exceptional Steel Bastard Sword")
                .SetStrengthRequirement(104)
                .SetAgilityRequirement(122)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        }  

        public Weapon GetCorrodedDaggerMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 10))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Corroded Dagger")
                .SetAgilityRequirement(9)
                .SetIntelligenceRequirement(6)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }  

        public Weapon GetCorrodedArtisansKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Corroded Artisan's Knife")
                .SetAgilityRequirement(16)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }

        public Weapon GetBronzeArtisansKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 45))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Bronze Artisan's Knife")
                .SetAgilityRequirement(64)
                .SetIntelligenceRequirement(44)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }  

        public Weapon GetSteelArtisansKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 76))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(650)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Steel Artisan's Knife")
                .SetAgilityRequirement(113)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }    

        public Weapon GetCorrodedAlchemistsKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(3, 26))
                .SetMinToMaxSpellDamage(new DamageRange(3, 26))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Corroded Alchemist's Knife")
                .SetAgilityRequirement(18)
                .SetIntelligenceRequirement(26)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            return weaponBuilder.Build();
        }   

        public Weapon GetBronzeAlchemistsKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(7, 62))
                .SetMinToMaxSpellDamage(new DamageRange(7, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Bronze Alchemist's Knife")
                .SetAgilityRequirement(55)
                .SetIntelligenceRequirement(79)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            return weaponBuilder.Build();
        }                                                               

        public Weapon GetSteelAlchemistsKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 86))
                .SetMinToMaxSpellDamage(new DamageRange(10, 86))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(630)
                .SetWeaponRange(10);

            weaponBuilder.SetName("Steel Alchemist's Knife")
                .SetAgilityRequirement(81)
                .SetIntelligenceRequirement(117)
                .SetItemClass(ItemClass.SPELL_DAGGER);

            return weaponBuilder.Build();
        }

        public Weapon GetCorrodedHatchetMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 11))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Corroded Hatchet")
                .SetStrengthRequirement(12)
                .SetAgilityRequirement(6)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            return weaponBuilder.Build();
        }   

        public Weapon GetBronzeHatchetMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 21))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Bronze Hatchet")
                .SetStrengthRequirement(28)
                .SetAgilityRequirement(19)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            return weaponBuilder.Build();
        }         

        public Weapon GetSteelHatchetMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(25, 46))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Steel Hatchet")
                .SetStrengthRequirement(81)
                .SetAgilityRequirement(56)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            return weaponBuilder.Build();
        } 

        public Weapon GetExceptionalSteelHatchetMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 70))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Exceptional Steel Hatchet")
                .SetStrengthRequirement(119)
                .SetAgilityRequirement(82)
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            return weaponBuilder.Build();
        }    

        public Weapon GetCorrodedLumberjackAxeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 20))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Corroded Lumberjack Axe")
                .SetStrengthRequirement(17)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            return weaponBuilder.Build();
        }  

        public Weapon GetBronzeLumberjackAxeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 39))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Bronze Lumberjack Axe")
                .SetStrengthRequirement(36)
                .SetAgilityRequirement(17)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            return weaponBuilder.Build();
        }    

        public Weapon GetSteelLumberjackAxeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 99))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Steel Lumberjack Axe")
                .SetStrengthRequirement(97)
                .SetAgilityRequirement(45)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            return weaponBuilder.Build();
        }    

        public Weapon GetExceptionalSteelLumberjackAxeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(74, 155))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Exceptional Steel Lumberjack Axe")
                .SetStrengthRequirement(149)
                .SetAgilityRequirement(76)
                .SetItemClass(ItemClass.TWO_HANDED_AXE);

            return weaponBuilder.Build();
        }    

        public Weapon GetCorrodedSlashingClawMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 11))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(620)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Corroded Slashing Claw")
                .SetAgilityRequirement(11)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.FIST_WEAPON);

            return weaponBuilder.Build();
        }    

        public Weapon GetBronzeSlashingClawMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(12, 22))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Bronze Slashing Claw")
                .SetAgilityRequirement(39)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.FIST_WEAPON);

            return weaponBuilder.Build();
        }      

        public Weapon GetSteelSlashingClawMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(23, 43))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Steel Slashing Claw")
                .SetAgilityRequirement(88)
                .SetIntelligenceRequirement(61)
                .SetItemClass(ItemClass.FIST_WEAPON);

            return weaponBuilder.Build();
        }        

        public Weapon GetExceptionalSteelSlashingClawMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(29, 55))
                .SetSkillsPerSecond(1.6)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Exceptional Steel Slashing Claw")
                .SetAgilityRequirement(131)
                .SetIntelligenceRequirement(95)
                .SetItemClass(ItemClass.FIST_WEAPON);

            return weaponBuilder.Build();
        }    

        public Weapon GetRottenQuarterstaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(9, 19))
                .SetMinToMaxSpellDamage(new DamageRange(9, 19))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Rotten Quarterstaff")
                .SetStrengthRequirement(12)
                .SetIntelligenceRequirement(12)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            return weaponBuilder.Build();
        }  

        public Weapon GetCrackedQuarterstaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(24, 41))
                .SetMinToMaxSpellDamage(new DamageRange(24, 41))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Cracked Quarterstaff")
                .SetStrengthRequirement(35)
                .SetIntelligenceRequirement(35)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            return weaponBuilder.Build();
        }     

        public Weapon GetQuarterstaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(51, 86))
                .SetMinToMaxSpellDamage(new DamageRange(51, 86))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Quarterstaff")
                .SetStrengthRequirement(78)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            return weaponBuilder.Build();
        }    

        public Weapon GetReinforcedQuarterstaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(72, 120))
                .SetMinToMaxSpellDamage(new DamageRange(72, 120))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Reinforced Quarterstaff")
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.WIZARD_STAFF);

            return weaponBuilder.Build();
        }  

        public Weapon GetErodedStaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(14, 42))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(640)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Eroded Staff")
                .SetStrengthRequirement(27)
                .SetIntelligenceRequirement(27)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            return weaponBuilder.Build();
        }   

        public Weapon GetBronzeStaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(38, 114))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(660)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Bronze Staff")
                .SetStrengthRequirement(72)
                .SetIntelligenceRequirement(72)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            return weaponBuilder.Build();
        }  

        public Weapon GetSteelStaffMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(53, 160))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(730)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Steel Staff")
                .SetStrengthRequirement(113)
                .SetIntelligenceRequirement(113)
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            return weaponBuilder.Build();
        } 

        public Weapon GetRottenBarbedClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 8))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Rotten Barbed Club")
                .SetStrengthRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }      

        public Weapon GetBronzeBarbedClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(13, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Bronze Barbed Club")
                .SetStrengthRequirement(41)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        } 

        public Weapon GetSteelBarbedClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(33, 42))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Steel Barbed Club")
                .SetStrengthRequirement(125)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }        

        public Weapon GetExceptionalSteelBarbedClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(49, 62))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Exceptional Steel Barbed Club")
                .SetStrengthRequirement(185)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }    

        public Weapon GetRottenWoodenClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Rotten Wooden Club")
                .SetStrengthRequirement(26)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }  

        public Weapon GetRawWoodenClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(31, 51))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Raw Wooden Club")
                .SetStrengthRequirement(116)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }  

        public Weapon GetWoodenClubMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(48, 80))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12);

            weaponBuilder.SetName("Wooden Club")
                .SetStrengthRequirement(179)
                .SetItemClass(ItemClass.ONE_HANDED_MACE);

            return weaponBuilder.Build();
        }            

        public Weapon GetRottenWoodenMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 16))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Rotten Wooden Maul")
                .SetStrengthRequirement(20)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }  

        public Weapon GetRottenWoodenMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(16, 33))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Raw Wooden Maul")
                .SetStrengthRequirement(47)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }     

        public Weapon GetRottenWoodenMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(16, 33))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Raw Wooden Maul")
                .SetStrengthRequirement(47)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        } 

        public Weapon GetRottenWoodenMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(43, 88))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Wooden Maul")
                .SetStrengthRequirement(131)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }    

        public Weapon GetReinforcedWoodenMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(65, 135))
                .SetSkillsPerSecond(1.3)
                .SetCriticalStrikeChance(550)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Reinforced Wooden Maul")
                .SetStrengthRequirement(188)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }   

        public Weapon GetRottenCarvedMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(17, 25))
                .SetSkillsPerSecond(1.25)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Rotten Carved Maul")
                .SetStrengthRequirement(35)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }   

        public Weapon GetCarvedMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(57, 85))
                .SetSkillsPerSecond(1.1)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Carved Maul")
                .SetStrengthRequirement(119)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        } 

        public Weapon GetReinforcedCarvedMaulMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(112, 168))
                .SetSkillsPerSecond(1.0)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(16);

            weaponBuilder.SetName("Reinforced Carved Maul")
                .SetStrengthRequirement(182)
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            return weaponBuilder.Build();
        }                                                                                                                                                                                 

        public Weapon GetCrudeBowMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(0);

            weaponBuilder.SetName("Crude Bow")
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.BOW);

            return weaponBuilder.Build();
        }     

        public Weapon GetShortBowMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 16))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(0);

            weaponBuilder.SetName("Short Bow")
                .SetAgilityRequirement(26)
                .SetItemClass(ItemClass.BOW);

            return weaponBuilder.Build();
        }      

        public Weapon GetOldWoodWandMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(5, 9))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(0);

            weaponBuilder.SetName("Oldwood Wand")
                .SetIntelligenceRequirement(14)
                .SetItemClass(ItemClass.WAND);

            return weaponBuilder.Build();
        }  

        public Weapon GetCutWandMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxSpellDamage(new DamageRange(9, 16))
                .SetSkillsPerSecond(1.2)
                .SetCriticalStrikeChance(700)
                .SetWeaponRange(0);

            weaponBuilder.SetName("Cut Wand")
                .SetIntelligenceRequirement(29)
                .SetItemClass(ItemClass.WAND);

            return weaponBuilder.Build();
        }                                                       
    }
}