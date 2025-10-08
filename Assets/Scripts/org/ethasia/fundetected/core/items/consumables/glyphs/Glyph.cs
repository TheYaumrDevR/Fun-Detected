using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs
{
    public abstract class Glyph : Consumable
    {
        public AffixTypes AffixType
        {
            get;
            protected set;
        }

        public Glyph()
        {
            MaximumStackSize = 10;
        }

        public abstract EquipmentAffix OnApplyToEquipment();   

        protected void Clone(Glyph target)
        {
            target.AffixType = AffixType;
        }    
    }
}