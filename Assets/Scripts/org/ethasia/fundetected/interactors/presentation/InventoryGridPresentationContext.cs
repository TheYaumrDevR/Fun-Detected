using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryGridPresentationContext
    {
        public List<InventoryItemPresentationContext> ItemsPresentationContexts
        {
            get;
            private set;
        }

        public void AddItemPresentationContext(InventoryItemPresentationContext inventoryItemPresentationContext)
        {
            if (ItemsPresentationContexts == null)
            {
                ItemsPresentationContexts = new List<InventoryItemPresentationContext>();
            }

            ItemsPresentationContexts.Add(inventoryItemPresentationContext);
        }
    }
}