using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical
{
    // Can be used if no proper localization is implemented
    public class DictionaryBasedLocalizationGateway : ILocalizationGateway
    {
        private Dictionary<string, string> localizedStrings = new Dictionary<string, string>
        {
            { "inventory-window-title", "Inventory" }
        };

        public string GetLocalizedString(string key)
        {
            return localizedStrings.TryGetValue(key, out var value) ? value : key;
        }
    }
}