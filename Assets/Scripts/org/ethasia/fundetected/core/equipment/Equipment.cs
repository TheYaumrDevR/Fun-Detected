namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Equipment
    {
        public string Name
        {
            get;
            private set;
        }

        public int LevelRequirement
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

        public ItemClass ItemClass
        {
            get;
            private set;
        }

        public class Builder
        {
            private string name;
            private int levelRequirement;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private ItemClass itemClass;

            public Builder SetName(string value)
            {
                this.name = value;
                return this;
            }

            public Builder SetLevelRequirement(int value)
            {
                this.levelRequirement = value;
                return this;
            }

            public Builder SetStrengthRequirement(int value)
            {
                this.strengthRequirement = value;
                return this;
            }         

            public Builder SetAgilityRequirement(int value)
            {
                this.agilityRequirement = value;
                return this;
            }    

            public Builder SetIntelligenceRequirement(int value)
            {
                this.intelligenceRequirement = value;
                return this;
            }   

            public Builder SetItemClass(ItemClass value)
            {
                this.itemClass = value;
                return this;
            }              

            protected void FillEquipmentFields(Equipment statlessEquipment)
            {
                statlessEquipment.Name = name;
                statlessEquipment.LevelRequirement = levelRequirement;
                statlessEquipment.StrengthRequirement = strengthRequirement;
                statlessEquipment.AgilityRequirement = agilityRequirement;
                statlessEquipment.IntelligenceRequirement = intelligenceRequirement;
                statlessEquipment.ItemClass = itemClass;
            }                         
        }             
    }
}