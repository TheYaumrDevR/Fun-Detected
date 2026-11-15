using System;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Persistence
{
    [Serializable]
    public struct GamePersistenceContext
    {
        public PlayerCharacterPersistenceContext Player;
    }

    [Serializable]
    public struct PlayerCharacterPersistenceContext
    {
        public string Id;
        public string Name;
        public string CharacterClass;
        public string FacingDirection;
        public int Level;
        public int ExperiencePoints;
        public int CurrentLife;
        public int CurrentMana;
        public PlayerBaseStatsPersistenceContext BaseStats;
        public AreaPositionPersistenceContext AreaPosition;
        public List<EquippedItemPersistenceContext> EquippedItems;
        public List<InventoryItemPersistenceContext> InventoryItems;
    }

    [Serializable]
    public struct PlayerBaseStatsPersistenceContext
    {
        public int Intelligence;
        public int Agility;
        public int Strength;
        public int MaximumLife;
        public int MaximumMana;
        public int AccuracyRating;
        public int EvasionRating;
        public double AttacksPerSecond;
        public int MovementSpeed;
        public int RightHandMinDamage;
        public int RightHandMaxDamage;
        public int LeftHandMinDamage;
        public int LeftHandMaxDamage;
    }

    [Serializable]
    public struct AreaPositionPersistenceContext
    {
        public string AreaId;
        public int PosX;
        public int PosY;
    }

    [Serializable]
    public struct EquippedItemPersistenceContext
    {
        public string SlotPosition;
        public ItemPersistenceContext Item;
    }

    [Serializable]
    public struct InventoryItemPersistenceContext
    {
        public int GridX;
        public int GridY;
        public ItemPersistenceContext Item;
    }

    [Serializable]
    public struct ItemPersistenceContext
    {
        public string UniqueId;
        public string Name;
        public string ItemPotential;
        public int ItemLevel;
        public List<AffixPersistenceContext> Affixes;
    }

    [Serializable]
    public struct AffixPersistenceContext
    {
        public string UniqueId;
        public List<int> Values;
    }
}