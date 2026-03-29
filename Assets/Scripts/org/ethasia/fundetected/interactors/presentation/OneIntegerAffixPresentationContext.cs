namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct OneIntegerAffixPresentationContext : IAffixPresentationContext
    {
        public string Name
        {
            get;
            private set;
        }

        public int Value 
        { 
            get; 
            private set; 
        }

        public OneIntegerAffixPresentationContext(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public object[] GetValues()
        {
            return new object[] { Value };
        }
    }
}