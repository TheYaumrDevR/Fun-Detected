namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InventoryRenderContext
    {
        public EquipmentSlotsRenderContext EquipmentSlotsRenderContext
        {
            get;
            private set;
        }

        public InventoryGridRenderContext InventoryGridRenderContext
        {
            get;
            private set;
        }

        public InventoryRenderContext(EquipmentSlotsRenderContext equipmentSlotsRenderContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            EquipmentSlotsRenderContext = equipmentSlotsRenderContext;
            InventoryGridRenderContext = inventoryGridRenderContext;
        }
    }
}