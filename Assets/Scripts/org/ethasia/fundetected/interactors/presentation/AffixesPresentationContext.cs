namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct AffixesPresentationContext
    {
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

        public AffixesPresentationContext(IAffixPresentationContext[] implicits, IAffixPresentationContext[] explicits)
        {
            Implicits = implicits;
            Explicits = explicits;
        }
    }
}