using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedRecoveryPotionPresentationContext
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

        public RecoveryPotionPresentationContext RecoveryPotionPresentationContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquippedRecoveryPotionPresentationContext result;

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

            public Builder WithRecoveryPotionPresentationContext(RecoveryPotionPresentationContext value)
            {
                result.RecoveryPotionPresentationContext = value;
                return this;
            }

            public EquippedRecoveryPotionPresentationContext Build()
            {
                return result;
            }
        }
    }
}