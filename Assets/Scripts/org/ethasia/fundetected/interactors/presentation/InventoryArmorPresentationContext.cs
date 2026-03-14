namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryArmorPresentationContext
    {
        public ArmorPresentationContext ArmorContext
        {
            get;
            private set;
        }

        public InventoryItemPresentationContext ItemContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private InventoryArmorPresentationContext result;

            public Builder WithArmorContext(ArmorPresentationContext value)
            {
                result.ArmorContext = value;
                return this;
            }

            public Builder WithItemContext(InventoryItemPresentationContext value)
            {
                result.ItemContext = value;
                return this;
            }

            public InventoryArmorPresentationContext Build()
            {
                return result;
            }
        }
    }
}