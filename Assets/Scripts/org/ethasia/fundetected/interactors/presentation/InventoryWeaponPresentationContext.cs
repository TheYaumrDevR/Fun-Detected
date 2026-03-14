using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryWeaponPresentationContext
    {
        public WeaponPresentationContext WeaponContext
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
            private InventoryWeaponPresentationContext result;

            public Builder WithWeaponContext(WeaponPresentationContext value)
            {
                result.WeaponContext = value;
                return this;
            }

            public Builder WithItemContext(InventoryItemPresentationContext value)
            {
                result.ItemContext = value;
                return this;
            }

            public InventoryWeaponPresentationContext Build()
            {
                return result;
            }
        }
    }
}