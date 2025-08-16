using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class Jewelry : Equipment
    {
        protected override void ApplyLocalAffixes() { }

        public override void Accept(ItemVisitor visitor)
        {
            visitor.Visit(this);
        }

        new public class Builder : Equipment.Builder
        {
            public Jewelry Build()
            {
                Jewelry result = new Jewelry();
                FillEquipmentFields(result);

                return result;
            }
        }
    }
}