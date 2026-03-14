using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedArmorPresentationContext
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

        public ArmorPresentationContext ArmorPresentationContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquippedArmorPresentationContext result;

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