namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryPresentationContext
    {
        public EquipmentSlotsPresentationContext EquipmentSlotsPresentationContext
        {
            get;
            private set;
        }

        public InventoryGridPresentationContext InventoryGridPresentationContext
        {
            get;
            private set;
        }

        public InventoryPresentationContext(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext, InventoryGridPresentationContext inventoryGridPresentationContext)
        {
            EquipmentSlotsPresentationContext = equipmentSlotsPresentationContext;
            InventoryGridPresentationContext = inventoryGridPresentationContext;
        }
    }
}