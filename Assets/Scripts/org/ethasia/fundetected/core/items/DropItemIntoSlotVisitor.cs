using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class DropItemIntoSlotVisitor : ItemVisitor
    {
        private readonly PlayerEquipmentSlots equipmentSlots;
        private readonly EquipmentSlotPositions slotPosition;

        public Item SwappedItem
        {
            get;
            private set;
        }

        public override void Visit(Weapon equipment)
        {
            switch (slotPosition)
            {
                case EquipmentSlotPositions.MAIN_HAND:
                    break;
                case EquipmentSlotPositions.OFF_HAND:
                    break;
                case EquipmentSlotPositions.LEFT_RING:
                    break;
                case EquipmentSlotPositions.RIGHT_RING:
                    break;
                case EquipmentSlotPositions.BELT:
                    break;
            }
        }

        public override void Visit(Armor equipment)
        {
        }

        public override void Visit(Jewelry equipment)
        {
        }

        public override void Visit(RecoveryPotion recoveryPotion)
        {
        }
    }
}