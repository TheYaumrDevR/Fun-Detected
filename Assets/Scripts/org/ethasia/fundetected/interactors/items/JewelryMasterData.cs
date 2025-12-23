using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public class JewelryMasterData : ItemMasterData
    {
        public override Item ToItem()
        {
            return ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(this);
        }        

        new public class Builder : ItemMasterData.Builder
        {
            private ItemClass itemClass;
            private int minimumItemLevel;
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private EquipmentAffixMasterData firstImplicit;

            public Builder SetItemClass(ItemClass value)
            {
                itemClass = value;
                return this;
            }

            public Builder SetMinimumItemLevel(int value)
            {
                minimumItemLevel = value;
                return this;
            }

            public Builder SetName(string value)
            {
                name = value;
                return this;
            }

            public Builder SetStrengthRequirement(int value)
            {
                strengthRequirement = value;
                return this;
            }

            public Builder SetAgilityRequirement(int value)
            {
                agilityRequirement = value;
                return this;
            }

            public Builder SetIntelligenceRequirement(int value)
            {
                intelligenceRequirement = value;
                return this;
            }

            public Builder SetFirstImplicit(EquipmentAffixMasterData value)
            {
                firstImplicit = value;
                return this;
            }

            public JewelryMasterData Build()
            {
                JewelryMasterData result = new JewelryMasterData();

                result.ItemClass = itemClass;
                result.MinimumItemLevel = minimumItemLevel;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.FirstImplicit = firstImplicit;

                FillItemMasterDataFields(result);

                return result;
            }
        }        
    }
}