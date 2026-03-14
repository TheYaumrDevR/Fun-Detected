using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquipmentSlotsPresentationContext
    {
        public List<EquippedWeaponPresentationContext> EquippedWeapons
        {
            get;
            private set;
        }

        public List<EquippedArmorPresentationContext> EquippedArmors
        {
            get;
            private set;
        }

        public List<EquippedJewelryPresentationContext> EquippedJewelry
        {
            get;
            private set;
        }

        public List<EquippedRecoveryPotionPresentationContext> EquippedRecoveryPotions
        {
            get;
            private set;
        }

        public class Builder
        {
            private List<EquippedWeaponPresentationContext> equippedWeapons = new List<EquippedWeaponPresentationContext>();
            private List<EquippedArmorPresentationContext> equippedArmors = new List<EquippedArmorPresentationContext>();
            private List<EquippedJewelryPresentationContext> equippedJewelry = new List<EquippedJewelryPresentationContext>();
            private List<EquippedRecoveryPotionPresentationContext> equippedRecoveryPotions = new List<EquippedRecoveryPotionPresentationContext>();

            public Builder AddEquippedWeapon(EquippedWeaponPresentationContext value)
            {
                equippedWeapons.Add(value);
                return this;
            }

            public Builder AddEquippedArmor(EquippedArmorPresentationContext value)
            {
                equippedArmors.Add(value);
                return this;
            }

            public Builder AddEquippedJewelry(EquippedJewelryPresentationContext value)
            {
                equippedJewelry.Add(value);
                return this;
            }

            public Builder AddEquippedRecoveryPotion(EquippedRecoveryPotionPresentationContext value)
            {
                equippedRecoveryPotions.Add(value);
                return this;
            }

            public EquipmentSlotsPresentationContext Build()
            {
                return new EquipmentSlotsPresentationContext
                {
                    EquippedWeapons = equippedWeapons,
                    EquippedArmors = equippedArmors,
                    EquippedJewelry = equippedJewelry,
                    EquippedRecoveryPotions = equippedRecoveryPotions
                };
            }
        }
    }
}