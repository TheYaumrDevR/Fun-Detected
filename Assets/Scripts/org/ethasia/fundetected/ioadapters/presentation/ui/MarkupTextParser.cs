using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI
{    
    public class MarkupTextParser
    {
        public static List<UiTextSegment> Parse(string input)
        {
            var result = new List<UiTextSegment>();
            var scanner = new MarkupTextScanner(input);

            var isCurrentSegmentBold = false;

            while (scanner.ScanNext())
            {
                var token = scanner.CurrentToken;

                if (token.Type == TokenType.BoldStart)
                {
                    isCurrentSegmentBold = true;
                }
                else if (token.Type == TokenType.BoldEnd)
                {
                    isCurrentSegmentBold = false;
                }
                else if (token.Type == TokenType.Text)
                {
                    result.Add(new UiTextSegment(token.Content.ToString(), isCurrentSegmentBold));
                }
            }

            return result;
        }
    }
}