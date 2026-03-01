using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryGridPresentationContext
    {
        public List<InventoryWeaponPresentationContext> WeaponsPresentationContexts
        {
            get;
            private set;
        }

        public List<InventoryArmorPresentationContext> ArmorsPresentationContexts
        {
            get;
            private set;
        }

        public List<InventoryItemPresentationContext> JewelriesPresentationContexts
        {
            get;
            private set;
        }

        public List<InventoryRecoveryPotionPresentationContext> RecoveryPotionsPresentationContexts
        {
            get;
            private set;
        }

        public void AddWeaponPresentationContext(InventoryWeaponPresentationContext inventoryWeaponPresentationContext)
        {
            if (WeaponsPresentationContexts == null)
            {
                WeaponsPresentationContexts = new List<InventoryWeaponPresentationContext>();
            }

            WeaponsPresentationContexts.Add(inventoryWeaponPresentationContext);
        }

        public void AddArmorPresentationContext(InventoryArmorPresentationContext inventoryArmorPresentationContext)
        {
            if (ArmorsPresentationContexts == null)
            {
                ArmorsPresentationContexts = new List<InventoryArmorPresentationContext>();
            }

            ArmorsPresentationContexts.Add(inventoryArmorPresentationContext);
        }

        public void AddJewelryPresentationContext(InventoryItemPresentationContext inventoryItemPresentationContext)
        {
            if (JewelriesPresentationContexts == null)
            {
                JewelriesPresentationContexts = new List<InventoryItemPresentationContext>();
            }

            JewelriesPresentationContexts.Add(inventoryItemPresentationContext);
        }

        public void AddRecoveryPotionPresentationContext(InventoryRecoveryPotionPresentationContext inventoryRecoveryPotionPresentationContext)
        {
            if (RecoveryPotionsPresentationContexts == null)
            {
                RecoveryPotionsPresentationContexts = new List<InventoryRecoveryPotionPresentationContext>();
            }

            RecoveryPotionsPresentationContexts.Add(inventoryRecoveryPotionPresentationContext);
        }
    }
}