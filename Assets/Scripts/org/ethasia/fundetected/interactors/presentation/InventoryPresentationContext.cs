namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryPresentationContext
    {
        public EquipmentSlotsPresentationContext EquipmentSlotsPresentationContext
        {
            get;
            private set;
        }

        public InventoryPresentationContext(EquipmentSlotsPresentationContext equipmentSlotsPresentationContext)
        {
            EquipmentSlotsPresentationContext = equipmentSlotsPresentationContext;
        }
    }
}