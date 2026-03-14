using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedWeaponPresentationContext
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

        public WeaponPresentationContext WeaponPresentationContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquippedWeaponPresentationContext result;

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

            public Builder WithWeaponPresentationContext(WeaponPresentationContext value)
            {
                result.WeaponPresentationContext = value;
                return this;
            }

            public EquippedWeaponPresentationContext Build()
            {
                return result;
            }
        }
    }
}