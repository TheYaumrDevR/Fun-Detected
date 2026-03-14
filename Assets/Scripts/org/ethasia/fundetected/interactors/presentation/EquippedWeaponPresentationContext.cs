using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedWeaponPresentationContext
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

        public WeaponPresentationContext WeaponPresentationContext
        {
            get;
            private set;
        }

        public static EquippedWeaponPresentationContext CreateEmpty()
        {
            return new Builder().Build();
        }

        public class Builder
        {
            private EquippedWeaponPresentationContext result;

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