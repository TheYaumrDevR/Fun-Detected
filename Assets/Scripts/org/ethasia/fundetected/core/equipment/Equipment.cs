namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Equipment : Item
    {
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

        public class Builder : Item.Builder
        {
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;

            public Builder SetName(string value)
            {
                this.name = value;
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

            protected void FillEquipmentFields(Equipment statlessEquipment)
            {
                statlessEquipment.Name = name;
                statlessEquipment.StrengthRequirement = strengthRequirement;
                statlessEquipment.AgilityRequirement = agilityRequirement;
                statlessEquipment.IntelligenceRequirement = intelligenceRequirement;

                FillItemFields(statlessEquipment);
            }                         
        }             
    }
}