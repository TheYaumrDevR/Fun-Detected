using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public class AffixToPresentationContextConversionVisitor : IAffixVisitor
    {
        private int currentImplicitIndex = -1;
        private int currentExplicitIndex = -1;

        public IAffixPresentationContext[] Implicits 
        { 
            get; 
            private set; 
        }

        public IAffixPresentationContext[] Explicits
        {
            get;
            private set;
        }

        public void ConvertAffixesToPresentationContexts(RollableEquipmentAffix firstImplicit, IReadOnlyList<EquipmentAffix> prefixes, IReadOnlyList<EquipmentAffix> suffixes)
        {
            Explicits = new IAffixPresentationContext[prefixes.Count + suffixes.Count];

            if (firstImplicit != null)
            {
                Implicits = new IAffixPresentationContext[1];

                currentImplicitIndex = 0;
                firstImplicit.RerolledAffix.Accept(this);
            }
            else
            {
                Implicits = new IAffixPresentationContext[0];
            }

            currentImplicitIndex = -1;
            currentExplicitIndex = 0;

            foreach (var prefix in prefixes)
            {
                prefix.Accept(this);
                currentExplicitIndex++;
            }

            foreach (var suffix in suffixes)
            {
                suffix.Accept(this);
                currentExplicitIndex++;
            }
        }

        public void Visit(IAffixWithOneFloat affix)
        {
            
        }

        public void Visit(IAffixWithOneInteger affix)
        {
            IAffixPresentationContext converted = new OneIntegerAffixPresentationContext(affix.GetType().Name, affix.Value);
            AssignConvertedPresentationContextToCorrectArray(converted);
        }

        public void Visit(IAffixWithTwoIntegers affix)
        {
            IAffixPresentationContext converted = new TwoIntegerAffixPresentationContext(affix.GetType().Name, affix.ValueOne, affix.ValueTwo);
            AssignConvertedPresentationContextToCorrectArray(converted);
        }

        private void AssignConvertedPresentationContextToCorrectArray(IAffixPresentationContext converted)
        {
            if (currentImplicitIndex != -1)
            {
                Implicits[currentImplicitIndex] = converted;
            }
            else if (currentExplicitIndex != -1)
            {
                Explicits[currentExplicitIndex] = converted;
            }
        }
    }
}