namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct TwoIntegerAffixPresentationContext : IAffixPresentationContext
    {
        public string Name
        {
            get;
            private set;
        }

        public int ValueOne
        { 
            get; 
            private set; 
        }

        public int ValueTwo
        {
            get;
            private set;
        }

        public TwoIntegerAffixPresentationContext(string name, int valueOne, int valueTwo)
        {
            Name = name;
            ValueOne = valueOne;
            ValueTwo = valueTwo;
        }
    }
}