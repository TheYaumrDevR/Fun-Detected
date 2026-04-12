using System;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class InventorySlotPresentationItemVisitor : ItemVisitor
    {
        private ItemInventory itemInventory;
        private Action<InventorySlotPresentationItemVisitor, Weapon> weaponPresentationMethod;
        private Action<InventorySlotPresentationItemVisitor, Armor> armorPresentationMethod;
        private Action<InventorySlotPresentationItemVisitor, Jewelry> jewelryPresentationMethod;
        private Action<InventorySlotPresentationItemVisitor, RecoveryPotion> recoveryPotionPresentationMethod;

        public string ItemIdOnCursor
        {
            get;
            private set;
        }

        public EquipmentSlotPositions SlotPosition
        {
            get;
            private set;
        }

        public void PresentMainHand(string itemIdOnCursor)
        {
            ItemIdOnCursor = itemIdOnCursor;
            SlotPosition = EquipmentSlotPositions.MAIN_HAND;
            itemInventory.EquippedItems.AcceptMainHandVisitor(this);
        }

        public void PresentOffHand(string itemIdOnCursor)
        {
            ItemIdOnCursor = itemIdOnCursor;
            SlotPosition = EquipmentSlotPositions.OFF_HAND;
            itemInventory.EquippedItems.AcceptOffHandVisitor(this);
        }

        public void PresentLeftRing(string itemIdOnCursor)
        {
            ItemIdOnCursor = itemIdOnCursor;
            SlotPosition = EquipmentSlotPositions.LEFT_RING;
            itemInventory.EquippedItems.AcceptLeftRingVisitor(this);
        }

        public void PresentRightRing(string itemIdOnCursor)
        {
            ItemIdOnCursor = itemIdOnCursor;
            SlotPosition = EquipmentSlotPositions.RIGHT_RING;
            itemInventory.EquippedItems.AcceptRightRingVisitor(this);
        }

        public void PresentBelt(string itemIdOnCursor)
        {
            ItemIdOnCursor = itemIdOnCursor;
            SlotPosition = EquipmentSlotPositions.BELT;
            itemInventory.EquippedItems.AcceptBeltVisitor(this);
        }

        public override void Visit(Weapon weapon)
        {
            weaponPresentationMethod(this, weapon);
        }

        public override void Visit(Armor armor)
        {
            armorPresentationMethod(this, armor);
        }

        public override void Visit(Jewelry jewelry)
        {
            jewelryPresentationMethod(this, jewelry);
        }

        public override void Visit(RecoveryPotion recoveryPotion)
        {
            recoveryPotionPresentationMethod(this, recoveryPotion);
        }

        public class Builder
        {
            private ItemInventory itemInventory;
            private Action<InventorySlotPresentationItemVisitor, Weapon> weaponPresentationMethod;
            private Action<InventorySlotPresentationItemVisitor, Armor> armorPresentationMethod;
            private Action<InventorySlotPresentationItemVisitor, Jewelry> jewelryPresentationMethod;
            private Action<InventorySlotPresentationItemVisitor, RecoveryPotion> recoveryPotionPresentationMethod;

            public Builder SetItemInventory(ItemInventory value)
            {
                itemInventory = value;
                return this;
            }

            public Builder SetWeaponPresentationMethod(Action<InventorySlotPresentationItemVisitor, Weapon> value)
            {
                weaponPresentationMethod = value;
                return this;
            }

            public Builder SetArmorPresentationMethod(Action<InventorySlotPresentationItemVisitor, Armor> value)
            {
                armorPresentationMethod = value;
                return this;
            }

            public Builder SetJewelryPresentationMethod(Action<InventorySlotPresentationItemVisitor, Jewelry> value)
            {
                jewelryPresentationMethod = value;
                return this;
            }

            public Builder SetRecoveryPotionPresentationMethod(Action<InventorySlotPresentationItemVisitor, RecoveryPotion> value)
            {
                recoveryPotionPresentationMethod = value;
                return this;
            }

            public InventorySlotPresentationItemVisitor Build()
            {
                return new InventorySlotPresentationItemVisitor()
                {
                    itemInventory = this.itemInventory,
                    weaponPresentationMethod = this.weaponPresentationMethod,
                    armorPresentationMethod = this.armorPresentationMethod,
                    jewelryPresentationMethod = this.jewelryPresentationMethod,
                    recoveryPotionPresentationMethod = this.recoveryPotionPresentationMethod
                };
            }
        }
    }
}