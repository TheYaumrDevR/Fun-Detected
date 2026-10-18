namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI
{  
    public struct UiTextSegment
    {
        public string Text { get; }
        public bool IsBold { get; }
        public UiDefaultColors Color { get; }

        public UiTextSegment(string text, bool isBold, UiDefaultColors color)
        {
            Text = text;
            IsBold = isBold;
            Color = color;
        }
    }
}