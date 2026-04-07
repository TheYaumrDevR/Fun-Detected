using EquipmentItem = Org.Ethasia.Fundetected.Core.Equipment.Equipment;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class DropItemIntoSlotVisitor : ItemVisitor
    {
        private readonly PlayerEquipmentSlots equipmentSlots;
        private EquipmentSlotPositions slotPosition;

        public Item SwappedItem
        {
            get;
            private set;
        }

        public DropItemIntoSlotVisitor(PlayerEquipmentSlots equipmentSlots)
        {
            this.equipmentSlots = equipmentSlots;
        }

        public void DropItemIntoSlot(Item item, EquipmentSlotPositions slotPosition)
        {
            this.slotPosition = slotPosition;
            item.Accept(this);
        }

        public override void Visit(Weapon weapon)
        {
            VisitEquipment(weapon);
        }

        public override void Visit(Armor armor)
        {
            // TODO: Implement once needed
        }

        public override void Visit(Jewelry jewelry)
        {
            VisitEquipment(jewelry);
        }

        public override void Visit(RecoveryPotion recoveryPotion)
        {
            // TODO: Implement once needed
        }

        private void VisitEquipment(EquipmentItem equipment)
        {
            SwappedItem = slotPosition switch
            {
                EquipmentSlotPositions.MAIN_HAND => equipmentSlots.PickUpMainHandEquipment(equipment),
                EquipmentSlotPositions.OFF_HAND => equipmentSlots.PickUpOffHandEquipment(equipment),
                EquipmentSlotPositions.LEFT_RING => equipmentSlots.PickUpLeftRingEquipment(equipment),
                EquipmentSlotPositions.RIGHT_RING => equipmentSlots.PickUpRightRingEquipment(equipment),
                EquipmentSlotPositions.BELT => equipmentSlots.PickUpBeltEquipment(equipment),
                _ => equipment
            };
        }
    }
}