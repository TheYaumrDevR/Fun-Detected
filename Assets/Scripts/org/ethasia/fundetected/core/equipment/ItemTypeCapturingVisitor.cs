using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class ItemTypeCapturingVisitor : ItemVisitor
    {
        public Weapon CapturedWeapon
        {
            get;
            private set;
        }

        public Armor CapturedArmor
        {
            get;
            private set;
        }

        public Jewelry CapturedJewelry
        {
            get;
            private set;
        }

        public RecoveryPotion CapturedRecoveryPotion
        {
            get;
            private set;
        }

        public override void Visit(Weapon item)
        {
            Reset();
            CapturedWeapon = item;
        }

        public override void Visit(Armor item)
        {
            Reset();
            CapturedArmor = item;
        }

        public override void Visit(Jewelry item)
        {
            Reset();
            CapturedJewelry = item;
        }

        public override void Visit(RecoveryPotion item)
        {
            Reset();
            CapturedRecoveryPotion = item;
        }

        public override void Visit()
        {
            Reset();
        }

        public void Reset()
        {
            CapturedWeapon = null;
            CapturedArmor = null;
            CapturedJewelry = null;
            CapturedRecoveryPotion = null;
        }
    }
}