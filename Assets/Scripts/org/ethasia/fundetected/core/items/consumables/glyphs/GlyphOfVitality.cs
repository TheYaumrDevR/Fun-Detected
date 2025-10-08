using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs
{
    public class GlyphOfVitality : Glyph
    {
        public GlyphOfVitality()
        {
            AffixType = AffixTypes.PREFIX;
        }

        public override EquipmentAffix OnApplyToEquipment()
        {   
            return null;
        }     

        public override void Accept(ItemVisitor visitor)
        {

        }

        public override Item Clone()
        {
            GlyphOfVitality result = new GlyphOfVitality();
            Clone(result);
            
            return result;
        }

        new public class Builder : Consumable.Builder
        {
            public GlyphOfVitality Build()
            {
                GlyphOfVitality result = new GlyphOfVitality();
                FillConsumableFields(result);

                return result;
            }
        }           
    }
}