using Org.Ethasia.Fundetected.Core.Items;

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

        public override void Visit(Weapon equipment)
        {
            ExtractedWeapon = equipment;
        }

        public override void Visit(Armor equipment)
        {
            ExtractedArmor = equipment;
        }

        public override void Visit(Jewelry equipment)
        {
            ExtractedJewelry = equipment;
        }

        public void Reset()
        {
            ExtractedWeapon = null;
            ExtractedArmor = null;
            ExtractedJewelry = null;
        }
    }
}