namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI
{  
    public struct UiTextSegment
    {
        public string Text { get; }
        public bool IsBold { get; }

        public UiTextSegment(string text, bool isBold)
        {
            Text = text;
            IsBold = isBold;
        }
    }
}