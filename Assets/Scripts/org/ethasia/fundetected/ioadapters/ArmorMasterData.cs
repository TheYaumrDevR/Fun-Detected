using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ArmorMasterData
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

        public class Builder
        {
            private ItemClass itemClass;
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private int armorValue;
            private int movementSpeedAddend;

            public Builder SetItemClass(ItemClass value)
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

            public ArmorMasterData Build()
            {
                ArmorMasterData result = new ArmorMasterData();

                result.ItemClass = itemClass;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.ArmorValue = armorValue;
                result.MovementSpeedAddend = movementSpeedAddend;

                return result;
            }
        }  
    }
}