using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedJewelryPresentationContext
    {
        public EquipmentSlotTypes SlotType
        {
            get;
            private set;
        }

        public InventoryItemPresentationContext ItemPresentationContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquippedJewelryPresentationContext result;

            public Builder WithSlotType(EquipmentSlotTypes value)
            {
                result.SlotType = value;
                return this;
            }

            public Builder WithItemPresentationContext(InventoryItemPresentationContext value)
            {
                result.ItemPresentationContext = value;
                return this;
            }

            public EquippedJewelryPresentationContext Build()
            {
                return result;
            }
        }
    }
}