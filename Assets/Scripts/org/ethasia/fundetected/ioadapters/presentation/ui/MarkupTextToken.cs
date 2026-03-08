using System;

namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI
{       
    public readonly ref struct MarkupTextToken
    {
        public TokenType Type { get; }
        public ReadOnlySpan<char> Content { get; }

        public MarkupTextToken(TokenType type, ReadOnlySpan<char> content)
        {
            Type = type;
            Content = content;
        }
    }

    public enum TokenType
    {
        Text,
        BoldStart,
        BoldEnd
    }
}