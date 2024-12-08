using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JewelryMasterData
    {
        public ItemClass ItemClass
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int StrengthRequirement
        {
            get;
            private set;
        }    

        public int AgilityRequirement
        {
            get;
            private set;
        }       

        public int IntelligenceRequirement
        {
            get;
            private set;
        }  

        public EquipmentAffix FirstImplicit
        {
            get;
            private set;
        }

        public class Builder
        {
            private ItemClass itemClass;
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private EquipmentAffix firstImplicit;

            public Builder SteItemClass(ItemClass value)
            {
                itemClass = value;
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

            public Builder SetFirstImplicit(EquipmentAffix value)
            {
                firstImplicit = value;
                return this;
            }

            public JewelryMasterData Build()
            {
                JewelryMasterData result = new JewelryMasterData();
                
                result.ItemClass = itemClass;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.FirstImplicit = firstImplicit;

                return result;
            }
        }        
    }
}