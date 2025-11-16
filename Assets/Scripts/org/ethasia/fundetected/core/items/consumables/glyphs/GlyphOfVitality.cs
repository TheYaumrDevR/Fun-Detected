using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Map;

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

        public override void RerollEntireItem()
        {
            // TODO: implement later when there is something to reroll
        }
        
        public override void OnPickup(PlayerCharacter player)
        {
            // TODO: Add to inventory grid
        }

        protected override Item CloneActual()
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