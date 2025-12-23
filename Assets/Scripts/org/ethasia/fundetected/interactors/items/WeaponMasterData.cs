using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public class WeaponMasterData : ItemMasterData
    {
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
        
        public override Item ToItem()
        {
            return ItemMasterDataToItemConverter.ConvertWeaponMasterDataToWeapon(this);
        }          

        new public class Builder : ItemMasterData.Builder
        {
            private ItemClass itemClass;
            private int minimumItemLevel;
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
                result.MinimumItemLevel = minimumItemLevel;
                result.Name = name;
                result.StrengthRequirement = strengthRequirement;
                result.AgilityRequirement = agilityRequirement;
                result.IntelligenceRequirement = intelligenceRequirement;
                result.MinToMaxPhysicalDamage = minToMaxPhysicalDamage;
                result.MinToMaxSpellDamage = minToMaxSpellDamage;
                result.SkillsPerSecond = skillsPerSecond;
                result.CriticalStrikeChance = criticalStrikeChance;
                result.WeaponRange = weaponRange;

                FillItemMasterDataFields(result);

                return result;
            }
        }                    
    }
}