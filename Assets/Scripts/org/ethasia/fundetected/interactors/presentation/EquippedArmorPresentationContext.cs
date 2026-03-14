using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedArmorPresentationContext
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

        public ArmorPresentationContext ArmorPresentationContext
        {
            get;
            private set;
        }

        public static EquippedArmorPresentationContext CreateEmpty()
        {
            return new Builder().Build();
        }

        public class Builder
        {
            private EquippedArmorPresentationContext result;

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

            public Builder WithArmorPresentationContext(ArmorPresentationContext value)
            {
                result.ArmorPresentationContext = value;
                return this;
            }

            public EquippedArmorPresentationContext Build()
            {
                return result;
            }
        }
    }
}