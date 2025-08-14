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

            ConvertEquipmentFields(weaponBuilder, weaponMasterData);

            return weaponBuilder.Build();
        }

        public static Armor ConvertArmorMasterDataToArmor(ArmorMasterData armorMasterData)
        {
            Armor.Builder armorBuilder = new Armor.Builder()
                .SetArmorValue(armorMasterData.ArmorValue)
                .SetMovementSpeedAddend(armorMasterData.MovementSpeedAddend);

            ConvertEquipmentFields(armorBuilder, armorMasterData);

            armorBuilder.SetFirstImplicit(armorMasterData.FirstImplicit);

            return armorBuilder.Build();
        }

        public static Jewelry ConvertJewelryMasterDataToJewelry(JewelryMasterData jewelryMasterData)
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            ConvertEquipmentFields(jewelryBuilder, jewelryMasterData);

            jewelryBuilder.SetFirstImplicit(jewelryMasterData.FirstImplicit.ToRollableEquipmentAffix());

            return jewelryBuilder.Build();
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

        private static void ConvertEquipmentFields(Equipment.Builder equipmentBuilder, ItemMasterData itemMasterData)
        {
            equipmentBuilder.SetName(itemMasterData.Name);
            equipmentBuilder.SetStrengthRequirement(itemMasterData.StrengthRequirement);
            equipmentBuilder.SetAgilityRequirement(itemMasterData.AgilityRequirement);
            equipmentBuilder.SetIntelligenceRequirement(itemMasterData.IntelligenceRequirement);
            equipmentBuilder.SetItemClass(itemMasterData.ItemClass);
            equipmentBuilder.SetMinimumItemLevel(itemMasterData.MinimumItemLevel);
        }
    }
}