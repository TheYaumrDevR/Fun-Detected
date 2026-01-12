using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Technical
{
    // Can be used if no proper localization is implemented
    public class DictionaryBasedLocalizationGateway
    {
        // TODO: add interface LocalizationGateway in interactors namespace
        // TODO: Make FunDetectedWindow use the interface

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