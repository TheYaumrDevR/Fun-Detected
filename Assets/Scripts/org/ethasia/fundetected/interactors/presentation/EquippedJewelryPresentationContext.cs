using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedJewelryPresentationContext
    {
        public EquipmentSlotPositions SlotPosition
        {
            get;
            private set;
        }

        public InventoryItemPresentationContext ItemPresentationContext
        {
            get;
            private set;
        }

        public static EquippedJewelryPresentationContext CreateEmpty()
        {
            return new Builder().Build();
        }

        public class Builder
        {
            private EquippedJewelryPresentationContext result;

            public Builder WithSlotPosition(EquipmentSlotPositions value)
            {
                result.SlotPosition = value;
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