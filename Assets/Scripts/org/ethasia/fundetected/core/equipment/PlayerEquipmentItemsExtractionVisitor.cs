using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class PlayerEquipmentItemsExtractionVisitor : ItemVisitor
    {
        private PlayerEquipmentSlots equipmentSlots;

        public Weapon ExtractedWeapon
        {
            get;
            private set;
        }

        public Armor ExtractedArmor
        {
            get;
            private set;
        }

        public Jewelry ExtractedJewelry
        {
            get;
            private set;
        }

        public RecoveryPotion ExtractedRecoveryPotion
        {
            get;
            private set;
        }

        public PlayerEquipmentItemsExtractionVisitor(PlayerEquipmentSlots equipmentSlots)
        {
            this.equipmentSlots = equipmentSlots;
        }

        public void ExtractMainHandEquipment()
        {
            equipmentSlots.AcceptMainHandVisitor(this);
        }

        public void ExtractOffHandEquipment()
        {
            equipmentSlots.AcceptOffHandVisitor(this);
        }

        public void ExtractLeftRingEquipment()
        {
            equipmentSlots.AcceptLeftRingVisitor(this);
        }

        public void ExtractRightRingEquipment()
        {
            equipmentSlots.AcceptRightRingVisitor(this);
        }

        public void ExtractBeltEquipment()
        {
            equipmentSlots.AcceptBeltVisitor(this);
        }

        public override void Visit(Weapon item)
        {
            ExtractedWeapon = item;
        }

        public override void Visit(Armor item)
        {
            ExtractedArmor = item;
        }

        public override void Visit(Jewelry item)
        {
            ExtractedJewelry = item;
        }

        public override void Visit(RecoveryPotion item)
        {
            ExtractedRecoveryPotion = item;
        }

        public void Reset()
        {
            ExtractedWeapon = null;
            ExtractedArmor = null;
            ExtractedJewelry = null;
        }
    }
}