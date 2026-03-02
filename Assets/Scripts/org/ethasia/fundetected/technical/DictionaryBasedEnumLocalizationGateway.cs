using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical
{
    public class DictionaryBasedEnumLocalizationGateway : IEnumLocalizationGateway
    {
        private Dictionary<string, string> localizedStrings = new Dictionary<string, string>
        {
            { "ONE_HANDED_SWORD", "One Handed Sword" },
            { "ONE_HANDED_STABBING_SWORD", "One Handed Stabbing Sword" },
            { "TWO_HANDED_SWORD", "Two Handed Sword" },
            { "DAGGER", "Dagger" },
            { "ONE_HANDED_AXE", "One Handed Axe" },
            { "TWO_HANDED_AXE", "Two Handed Axe" },
            { "FIST_WEAPON", "Fist Weapon" },
            { "WIZARD_STAFF", "Wizard Staff" },
            { "MARTIAL_STAFF", "Martial Staff" },
            { "ONE_HANDED_MACE", "One Handed Mace" },
            { "TWO_HANDED_MACE", "Two Handed Mace" },
            { "BOW", "Bow" },
            { "WAND", "Wand" },
            { "SHIELD", "Shield" },
            { "QUIVER", "Quiver" },
            { "MAGIC_SOURCE", "Magic Source" },
            { "BODY_ARMOR", "Body Armor" },
            { "HEAD_GEAR", "Head Armor" },
            { "SHOES", "Shoes" },
            { "GLOVES", "Gloves" },
            { "RING", "Ring" },
            { "AMULET", "Amulet" },
            { "BELT", "Belt" },
            { "GLYPH", "Glyph" },
            { "LIFE_POTION", "Life Potion" },
            { "MANA_POTION", "Mana Potion" },
            { "ENHANCING_POTION", "Enhancing Potion" }
        };

        public string GetLocalizedEnumString<T>(T enumValue) where T : Enum
        {
            var key = enumValue.ToString();
            return localizedStrings.TryGetValue(key, out var value) ? value : key;
        }
    }
}