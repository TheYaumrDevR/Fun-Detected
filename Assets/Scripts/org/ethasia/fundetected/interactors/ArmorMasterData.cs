using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class ArmorMasterData : ItemMasterData
    { 
        public int ArmorValue
        {
            get;
            private set;
        }

        public int MovementSpeedAddend
        {
            get;
            private set;
        }      

        public override Item ToItem()
        {
            return ItemMasterDataToItemConverter.ConvertArmorMasterDataToArmor(this);
        }

        new public class Builder : ItemMasterData.Builder
        {
            private ItemClass itemClass;
            private int minimumItemLevel;
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private int armorValue;
            private int movementSpeedAddend;
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

            public Builder SetArmorValue(int value)
            {
                armorValue = value;
                return this;
            }

            public Builder SetMovementSpeedAddend(int value)
            {
                movementSpeedAddend = value;
                return this;
            }

            public Builder SetFirstImplicit(EquipmentAffixMasterData value)
            {
                firstImplicit = value;
                return this;
            }

            public ArmorMasterData Build()
            {
                ArmorMasterData result = new ArmorMasterData();

                result.ItemClass = itemClass;
                result.MinimumItemLevel = minimumItemLevel;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.ArmorValue = armorValue;
                result.MovementSpeedAddend = movementSpeedAddend;
                result.FirstImplicit = firstImplicit;

                FillItemMasterDataFields(result);

                return result;
            }
        }  
    }
}