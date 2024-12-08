using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs;

namespace Org.Ethasia.Fundetected.Core.Items.Equipments
{
    public class GlyphSockets
    {
        public Glyph PrefixOneGlyph
        {
            get;
            private set;
        }

        public Glyph PrefixTwoGlyph
        {
            get;
            private set;
        }

        public Glyph PrefixThreeGlyph
        {
            get;
            private set;
        }

        public Glyph SuffixOneGlyph
        {
            get;
            private set;
        }

        public Glyph SuffixTwoGlyph
        {
            get;
            private set;
        }

        public Glyph SuffixThreeGlyph
        {
            get;
            private set;
        }

        public bool CanCarveGlyphOnPrefixSlot(Glyph glyph)
        {
            return glyph.AffixType == AffixTypes.PREFIX;
        }

        public bool CanCarveGlyphOnSuffixSlot(Glyph glyph)
        {
            return glyph.AffixType == AffixTypes.SUFFIX;
        }

        public void CarvePrefixOneGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.PREFIX)
            {
                PrefixOneGlyph = glyph;
            }
        }

        public void CarvePrefixTwoGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.PREFIX)
            {
                PrefixTwoGlyph = glyph;
            }
        }

        public void CarvePrefixThreeGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.PREFIX)
            {
                PrefixThreeGlyph = glyph;
            }
        }

        public void CarveSuffixOneGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.SUFFIX)
            {
                SuffixOneGlyph = glyph;
            }
        }

        public void CarveSuffixTwoGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.SUFFIX)
            {
                SuffixTwoGlyph = glyph;
            }
        }

        public void CarveSuffixThreeGlyph(Glyph glyph)
        {
            if (glyph.AffixType == AffixTypes.SUFFIX)
            {
                SuffixThreeGlyph = glyph;
            }
        }

        public void DeletePrefixOneGlyph()
        {
            PrefixOneGlyph = null;
        }

        public void DeletePrefixTwoGlyph()
        {
            PrefixTwoGlyph = null;
        }

        public void DeletePrefixThreeGlyph()
        {
            PrefixThreeGlyph = null;
        }

        public void DeleteSuffixOneGlyph()
        {
            SuffixOneGlyph = null;
        }

        public void DeleteSuffixTwoGlyph()
        {
            SuffixTwoGlyph = null;
        }

        public void DeleteSuffixThreeGlyph()
        {
            SuffixThreeGlyph = null;
        }
    }
}