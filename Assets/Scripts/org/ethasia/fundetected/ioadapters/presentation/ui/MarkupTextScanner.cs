using System;

namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI
{    
    public ref struct MarkupTextScanner
    {
        private ReadOnlySpan<char> input;
        private int pos;

        public MarkupTextToken CurrentToken
        {
            get;
            private set;
        }

        public MarkupTextScanner(ReadOnlySpan<char> input)
        {
            this.input = input;
            pos = 0;
            CurrentToken = default;
        }

        public bool ScanNext()
        {
            if (pos >= input.Length)
            {
                return false;
            }

            int start = pos;

            if (Matches("<b>"))
            {
                CurrentToken = new MarkupTextToken(TokenType.BoldStart, input.Slice(pos, 3));
                pos += 3;

                return true;
            }

            if (Matches("</b>"))
            {
                CurrentToken = new MarkupTextToken(TokenType.BoldEnd, input.Slice(pos, 4));
                pos += 4;

                return true;
            }

            while (pos < input.Length && !Matches("<b>") && !Matches("</b>"))
            {
                pos++;
            }

            CurrentToken = new MarkupTextToken(TokenType.Text, input.Slice(start, pos - start));
            return true;
        }

        private bool Matches(ReadOnlySpan<char> tag)
        {
            return input.Slice(pos).StartsWith(tag);
        }
    }
}