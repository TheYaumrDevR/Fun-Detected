using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EquipmentMasterDataProvider
    {
        public Weapon GetCorrodedSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 9))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(22);

            weaponBuilder.SetName("Corroded Sword")
                .SetLevelRequirement(1)
                .SetStrengthRequirement(8)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }

        public Weapon GetBronzeSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 14))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(22);

            weaponBuilder.SetName("Bronze Sword")
                .SetLevelRequirement(5)
                .SetStrengthRequirement(14)
                .SetAgilityRequirement(14)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetCorrodedLongSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(8, 16))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(26);

            weaponBuilder.SetName("Corroded Long Sword")
                .SetLevelRequirement(1)
                .SetStrengthRequirement(11)
                .SetAgilityRequirement(11)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        }   

        public Weapon GetLongSwordMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(11, 26))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(26);

            weaponBuilder.SetName("Long Sword")
                .SetLevelRequirement(8)
                .SetStrengthRequirement(20)
                .SetAgilityRequirement(17)
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            return weaponBuilder.Build();
        }    

        public Weapon GetCrudeBowMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(5, 13))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(240);

            weaponBuilder.SetName("Crude Bow")
                .SetLevelRequirement(1)
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
                .SetWeaponRange(240);

            weaponBuilder.SetName("Short Bow")
                .SetLevelRequirement(5)
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
                .SetWeaponRange(240);

            weaponBuilder.SetName("Oldwood Wand")
                .SetLevelRequirement(1)
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
                .SetWeaponRange(240);

            weaponBuilder.SetName("Cut Wand")
                .SetLevelRequirement(6)
                .SetIntelligenceRequirement(29)
                .SetItemClass(ItemClass.WAND);

            return weaponBuilder.Build();
        }  

        public Weapon GetObsidianDaggerMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(6, 10))
                .SetSkillsPerSecond(1.5)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(20);

            weaponBuilder.SetName("Obsidian Dagger")
                .SetLevelRequirement(1)
                .SetAgilityRequirement(9)
                .SetIntelligenceRequirement(6)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }     

        public Weapon GetButchersKnifeMasterData()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 17))
                .SetSkillsPerSecond(1.45)
                .SetCriticalStrikeChance(600)
                .SetWeaponRange(20);

            weaponBuilder.SetName("Butcher's Knife")
                .SetLevelRequirement(5)
                .SetAgilityRequirement(16)
                .SetIntelligenceRequirement(11)
                .SetItemClass(ItemClass.DAGGER);

            return weaponBuilder.Build();
        }                                                      
    }
}