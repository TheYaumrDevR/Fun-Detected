using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class WeaponMasterData
    {
        public ItemClass ItemClass
        {
            get;
            private set;
        }

        public int ItemLevel
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

        public DamageRange MinToMaxPhysicalDamage
        {
            get;
            private set;
        }

        public DamageRange MinToMaxSpellDamage
        {
            get;
            private set;
        }

        public double SkillsPerSecond
        {
            get;
            private set;
        }         

        public int CriticalStrikeChance
        {
            get;
            private set;
        } 

        public int WeaponRange
        {
            get;
            private set;
        }    

        public class Builder
        {
            private ItemClass itemClass;
            private int itemLevel;
            private string name;
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private DamageRange minToMaxPhysicalDamage;
            private DamageRange minToMaxSpellDamage;
            private double skillsPerSecond;
            private int criticalStrikeChance;
            private int weaponRange;

            public Builder SetItemClass(ItemClass value)
            {
                itemClass = value;
                return this;
            }

            public Builder SetItemLevel(int value)
            {
                itemLevel = value;
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

            public Builder SetMinToMaxPhysicalDamage(DamageRange value)
            {
                minToMaxPhysicalDamage = value;
                return this;
            }    

            public Builder SetMinToMaxSpellDamage(DamageRange value)
            {
                minToMaxSpellDamage = value;
                return this;
            }      

            public Builder SetSkillsPerSecond(double value)
            {
                skillsPerSecond = value;
                return this;
            }        

            public Builder SetCriticalStrikeChance(int value)
            {
                criticalStrikeChance = value;
                return this;
            }   

            public Builder SetWeaponRange(int value)
            {
                weaponRange = value;
                return this;
            }                                                  

            public WeaponMasterData Build()
            {
                WeaponMasterData result = new WeaponMasterData();

                result.ItemClass = itemClass;
                result.ItemLevel = itemLevel;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.MinToMaxPhysicalDamage = minToMaxPhysicalDamage;
                result.MinToMaxSpellDamage = minToMaxSpellDamage;
                result.SkillsPerSecond = skillsPerSecond;
                result.CriticalStrikeChance = criticalStrikeChance;
                result.WeaponRange = weaponRange;

                return result;
            }               
        }                    
    }
}