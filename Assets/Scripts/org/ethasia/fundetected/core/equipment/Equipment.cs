using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Equipment : Item
    {
        protected List<EquipmentAffix> prefixes = new List<EquipmentAffix>();
        protected List<EquipmentAffix> suffixes = new List<EquipmentAffix>();

        public IReadOnlyList<EquipmentAffix> Prefixes => prefixes.AsReadOnly();
        public IReadOnlyList<EquipmentAffix> Suffixes => suffixes.AsReadOnly();

        public RollableEquipmentAffix FirstImplicit
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

        public void OnEquip(StatsFromEquipment statsFromEquipment)
        {
            foreach (EquipmentAffix prefix in prefixes)
            {
                prefix.ApplyEffects(statsFromEquipment);
            }

            foreach (EquipmentAffix suffix in suffixes)
            {
                suffix.ApplyEffects(statsFromEquipment);
            }

            if (null != FirstImplicit)
            {
                FirstImplicit.RerolledAffix.ApplyEffects(statsFromEquipment);
            }
        }

        public void OnUnequip(StatsFromEquipment statsFromEquipment)
        {
            foreach (EquipmentAffix prefix in prefixes)
            {
                prefix.UnApplyEffects(statsFromEquipment);
            }

            foreach (EquipmentAffix suffix in suffixes)
            {
                suffix.UnApplyEffects(statsFromEquipment);
            }

            if (null != FirstImplicit)
            {
                FirstImplicit.RerolledAffix.UnApplyEffects(statsFromEquipment);
            }
        }

        public override void RerollEntireItem()
        {
            if (null != FirstImplicit)
            {
                FirstImplicit.RerollAffix();
            }
        }

        public override void OnPickup(PlayerCharacter player)
        {
            player.PickupEquipment(this);
        }

        protected void Clone(Equipment clone)
        {
            clone.StrengthRequirement = StrengthRequirement;
            clone.AgilityRequirement = AgilityRequirement;
            clone.IntelligenceRequirement = IntelligenceRequirement;

            ClonePrefixes(clone);
            CloneSuffixes(clone);

            clone.FirstImplicit = null == FirstImplicit ? null : FirstImplicit.Clone();
            
            CloneItemFields(clone);
        }

        protected void ClonePrefixes(Equipment target)
        {
            foreach (EquipmentAffix prefix in prefixes)
            {
                target.prefixes.Add(prefix.Clone());
            }
        }

        protected void CloneSuffixes(Equipment target)
        {
            foreach (EquipmentAffix suffix in suffixes)
            {
                target.suffixes.Add(suffix.Clone());
            }
        }
            
        protected abstract void ApplyLocalAffixes();        

        new public class Builder : Item.Builder
        {
            private int strengthRequirement;
            private int agilityRequirement;
            private int intelligenceRequirement;
            private RollableEquipmentAffix firstImplicit;
            private List<EquipmentAffix> prefixes = new List<EquipmentAffix>();
            private List<EquipmentAffix> suffixes = new List<EquipmentAffix>();            

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

            public Builder SetFirstImplicit(RollableEquipmentAffix value)
            {
                this.firstImplicit = value;
                return this;
            }          

            public Builder AddAffix(EquipmentAffix value)
            {
                if (value.AffixType == AffixTypes.PREFIX)
                {
                    return AddPrefix(value);
                }
                else if (value.AffixType == AffixTypes.SUFFIX)
                {
                    return AddSuffix(value);
                }

                return this;
            }

            private Builder AddPrefix(EquipmentAffix value)
            {
                if (prefixes.Count < 3)
                {
                    prefixes.Add(value);
                }

                return this;
            }

            private Builder AddSuffix(EquipmentAffix value)
            {
                if (suffixes.Count < 3)
                {
                    suffixes.Add(value);
                }

                return this;
            }            

            protected void FillEquipmentFields(Equipment statlessEquipment)
            {
                statlessEquipment.StrengthRequirement = strengthRequirement;
                statlessEquipment.AgilityRequirement = agilityRequirement;
                statlessEquipment.IntelligenceRequirement = intelligenceRequirement;
                statlessEquipment.FirstImplicit = firstImplicit;
                statlessEquipment.prefixes.AddRange(prefixes);
                statlessEquipment.suffixes.AddRange(suffixes);
                statlessEquipment.ApplyLocalAffixes();

                FillItemFields(statlessEquipment);
            }                         
        }             
    }
}