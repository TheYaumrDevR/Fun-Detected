using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public abstract class ItemVisitor
    {
        public abstract void Visit(Weapon weapon);
        public abstract void Visit(Armor armour);
        public abstract void Visit(Jewelry jewelry);
    }
}