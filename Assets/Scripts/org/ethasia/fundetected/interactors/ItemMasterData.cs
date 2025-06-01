using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors
{
    public abstract class ItemMasterData
    {
        public ItemClass ItemClass { get; protected set; }
        public int MinimumItemLevel { get; protected set; }
        public string Name { get; protected set; }
        public int StrengthRequirement { get; protected set; }
        public int AgilityRequirement { get; protected set; }
        public int IntelligenceRequirement { get; protected set; }
    }
}