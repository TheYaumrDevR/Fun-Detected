using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Presentation;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class LocalizationGatewayMock : ILocalizationGateway
    {
        private Dictionary<string, string> valuesByKeys = new Dictionary<string, string>
        {
            { "inventory-window-title", "Inventory" },
            { "weapon-tooltip-phys-dam", "weapon-tooltip-phys-dam {0}-{1}" },
            { "weapon-tooltip-spell-dam", "weapon-tooltip-spell-dam {0}-{1}" },
            { "weapon-tooltip-crit-chance", "weapon-tooltip-crit-chance {0}%" },
            { "weapon-tooltip-skills-per-second", "weapon-tooltip-skills-per-second {0}" },
            { "armor-tooltip-armor", "armor-tooltip-armor {0}" },
            { "armor-tooltip-movement-speed", "armor-tooltip-movement-speed {0}%" },
            { "life-potion-tooltip-heal-value", "life-potion-tooltip-heal-value {0}" },
            { "life-potion-tooltip-usages", "life-potion-tooltip-usages {0}" },
            { "PlusStrengthAffix", "PlusStrengthAffix {0}" },
            { "PlusMaximumLifeAffix", "PlusMaximumLifeAffix {0}" },
            { "PlusMinMaxLightningDamageAffix", "PlusMinMaxLightningDamageAffix {0}, {1}" },
            { "IncMaxResAffix", "IncMaxResAffix {0}" }
        };

        public string GetLocalizedString(string key)
        {
            return valuesByKeys.TryGetValue(key, out var value) ? value : key;
        }
    }
}