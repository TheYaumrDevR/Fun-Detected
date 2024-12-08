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

        public abstract EquipmentAffix OnApplyToEquipment();       
    }
}