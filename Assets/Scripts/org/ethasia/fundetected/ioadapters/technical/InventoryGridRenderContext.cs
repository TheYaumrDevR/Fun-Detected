namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InventoryGridRenderContext
    {
        private InventorySlotRenderContext[,] slotRenderContexts;

        public InventorySlotRenderContext[,] SlotRenderContexts 
        { 
            get 
            { 
                if (slotRenderContexts == null)
                {
                    slotRenderContexts = new InventorySlotRenderContext[12, 5];
                }

                return slotRenderContexts; 
            }
            
            private set 
            { 
                slotRenderContexts = value; 
            }
        }

        public void AddSlotRenderContext(int x, int y, InventorySlotRenderContext context)
        {
            SlotRenderContexts[x, y] = context;
        }
    }
}