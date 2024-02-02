using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Equipment : Item
    {
        private List<EquipmentAffix> prefixes = new List<EquipmentAffix>();
        private List<EquipmentAffix> suffixes = new List<EquipmentAffix>();

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

        new public class Builder : Item.Builder
        {
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private EquipmentAffix firstImplicit;
            private List<EquipmentAffix> prefixes;
            private List<EquipmentAffix> suffixes;            

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

            public Builder SetFirstImplicit(EquipmentAffix value)
            {
                this.firstImplicit = value;
                return this;
            }          

            public Builder AddAffix(EquipmentAffix value)
            {
                if (value.IsPrefix)
                {
                    return AddPrefix(value);
                }
                else
                {
                    return AddSuffix(value);
                }
            }

            protected void FillEquipmentFields(Equipment statlessEquipment)
            {
                statlessEquipment.Name = name;
                statlessEquipment.StrengthRequirement = strengthRequirement;
                statlessEquipment.AgilityRequirement = agilityRequirement;
                statlessEquipment.IntelligenceRequirement = intelligenceRequirement;
                statlessEquipment.FirstImplicit = firstImplicit;
                statlessEquipment.prefixes.AddRange(prefixes);
                statlessEquipment.suffixes.AddRange(suffixes);

                FillItemFields(statlessEquipment);
            }           

            private Builder AddPrefix(EquipmentAffix value)
            {
                if (null == prefixes)
                {
                    prefixes = new List<EquipmentAffix>();
                }

                if (prefixes.Count < 3)
                {
                    prefixes.Add(value);
                }

                return this;
            }

            private Builder AddSuffix(EquipmentAffix value)
            {
                if (null == suffixes)
                {
                    suffixes = new List<EquipmentAffix>();
                }

                if (suffixes.Count < 3)
                {
                    suffixes.Add(value);
                }

                return this;
            }              
        }             
    }
}