using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical
{
    // Can be used if no proper localization is implemented
    public class DictionaryBasedLocalizationGateway : ILocalizationGateway
    {
        private Dictionary<string, string> localizedStrings = new Dictionary<string, string>
        {
            { "inventory-window-title", "Inventory" },
            { "weapon-tooltip-phys-dam", "Physical Damage: <b>{0}-{1}</b>" },
            { "weapon-tooltip-spell-dam", "Spell Damage: <b>{0}-{1}</b>" },
            { "weapon-tooltip-crit-chance", "Critical Strike Chance: <b>{0}%</b>" },
            { "weapon-tooltip-skills-per-second", "Usages per Second: <b>{0}</b>" },
            { "armor-tooltip-armor", "Armor: <b>{0}</b>" },
            { "armor-tooltip-movement-speed", "Movement Speed: <b>{0}%</b>" },
            { "life-potion-tooltip-heal-value", "Recovers <b>{0}%</b> Life on Use" },
            { "life-potion-tooltip-usages", "Maximum Usages: <b>{0}</b>" }
        };

        public string GetLocalizedString(string key)
        {
            return localizedStrings.TryGetValue(key, out var value) ? value : key;
        }
    }
}