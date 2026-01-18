namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InventoryRenderContext
    {
        public EquipmentSlotsRenderContext EquipmentSlotsRenderContext
        {
            get;
            private set;
        }

        public InventoryRenderContext(EquipmentSlotsRenderContext equipmentSlotsRenderContext)
        {
            EquipmentSlotsRenderContext = equipmentSlotsRenderContext;
        }
    }
}