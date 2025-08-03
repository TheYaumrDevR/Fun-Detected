using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Interactors
{

    public class ItemMasterDataToItemConverter
    {
        public static Weapon ConvertWeaponMasterDataToWeapon(WeaponMasterData weaponMasterData)
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(weaponMasterData.MinToMaxPhysicalDamage)
                .SetMinToMaxSpellDamage(weaponMasterData.MinToMaxSpellDamage)
                .SetSkillsPerSecond(weaponMasterData.SkillsPerSecond)
                .SetCriticalStrikeChance(weaponMasterData.CriticalStrikeChance)
                .SetWeaponRange(weaponMasterData.WeaponRange);

            weaponBuilder.SetName(weaponMasterData.Name);
            weaponBuilder.SetStrengthRequirement(weaponMasterData.StrengthRequirement);
            weaponBuilder.SetAgilityRequirement(weaponMasterData.AgilityRequirement);
            weaponBuilder.SetIntelligenceRequirement(weaponMasterData.IntelligenceRequirement);
            weaponBuilder.SetItemClass(weaponMasterData.ItemClass);
            weaponBuilder.SetMinimumItemLevel(weaponMasterData.MinimumItemLevel);

            return weaponBuilder.Build();
        }

        public static Armor ConvertArmorMasterDataToArmor(ArmorMasterData armorMasterData)
        {
            Armor.Builder armorBuilder = new Armor.Builder()
                .SetArmorValue(armorMasterData.ArmorValue)
                .SetMovementSpeedAddend(armorMasterData.MovementSpeedAddend);

            armorBuilder.SetName(armorMasterData.Name);
            armorBuilder.SetStrengthRequirement(armorMasterData.StrengthRequirement);
            armorBuilder.SetAgilityRequirement(armorMasterData.AgilityRequirement);
            armorBuilder.SetIntelligenceRequirement(armorMasterData.IntelligenceRequirement);
            armorBuilder.SetItemClass(armorMasterData.ItemClass);
            armorBuilder.SetMinimumItemLevel(armorMasterData.MinimumItemLevel);
            armorBuilder.SetFirstImplicit(armorMasterData.FirstImplicit);

            return armorBuilder.Build();
        }

        public static RecoveryPotion ConvertRecoveryPotionMasterDataToPotion(RecoveryPotionMasterData potionMasterData)
        {
            RecoveryPotion.Builder potionBuilder = new RecoveryPotion.Builder()
                .SetRecoveryAmount(potionMasterData.RecoveryAmount);

            potionBuilder.SetName(potionMasterData.Name);
            potionBuilder.SetUses(potionMasterData.Uses);
            potionBuilder.SetItemClass(potionMasterData.ItemClass);
            potionBuilder.SetMinimumItemLevel(potionMasterData.MinimumItemLevel);

            return potionBuilder.Build();
        }
    }
}