using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Technical
{
    public class TechnicalUtils
    {
        public static string ReplacePlaceHoldersInText(string text, params string[] insertedTexts)
        {
            string result = text;

            for (int i = 0; i < insertedTexts.Length; i++)
            {
                result = result.Replace("{" + i + "}", insertedTexts[i]);
            }

            return result;
        }

        public static string ReplacePlaceHoldersInText(string text, List<string> insertedTexts)
        {
            string result = text;

            int i = 0;
            foreach (string insertedText in insertedTexts)
            {
                result = result.Replace("{" + i + "}", insertedText);
                i++;
            }

            return result;
        }
    }
}