namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Equipment
    {
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

        public class Builder
        {
            private int levelRequirement;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;

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

            protected void FillEquipmentFields(Equipment statlessEquipment)
            {
                statlessEquipment.LevelRequirement = levelRequirement;
                statlessEquipment.StrengthRequirement = strengthRequirement;
                statlessEquipment.AgilityRequirement = agilityRequirement;
                statlessEquipment.IntelligenceRequirement = intelligenceRequirement;
            }                         
        }             
    }
}