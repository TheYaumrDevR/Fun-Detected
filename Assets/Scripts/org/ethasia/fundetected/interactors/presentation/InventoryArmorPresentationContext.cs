namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryArmorPresentationContext
    {
        public int ArmorValue
        {
            get;
            private set;
        }

        public int MovementSpeedAddend
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

            public Builder WithArmorValue(int value)
            {
                result.ArmorValue = value;
                return this;
            }

            public Builder WithMovementSpeedAddend(int value)
            {
                result.MovementSpeedAddend = value;
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