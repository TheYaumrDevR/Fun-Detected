using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct AffixMasterDataBaseForIntegerMinMaxAndIncrement : EquipmentAffixMasterData
    {
        public int MinValue
        {
            get;
            private set;
        }

        public int MaxValue
        {
            get;
            private set;
        }

        public int Increment
        {
            get;
            private set;
        }

        public AffixClasses AffixClasses
        {
            get;
            private set;
        }

        public RollableEquipmentAffix ToRollableEquipmentAffix()
        {
            EquipmentAffix affix = AffixClasses.ToRollableEquipmentAffix();

            IntegerMinMaxIncrementRollableEquipmentAffix result = new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(affix)
                .SetMinValue(MinValue)
                .SetMaxValue(MaxValue)
                .SetIncrement(Increment)
                .Build();

            result.RerollAffix();

            return result;
        }

        public class Builder
        {
            private int minValue;
            private int maxValue;
            private int increment;
            private AffixClasses affixClasses;

            public Builder SetMinValue(int value)
            {
                minValue = value;
                return this;
            }

            public Builder SetMaxValue(int value)
            {
                maxValue = value;
                return this;
            }

            public Builder SetIncrement(int value)
            {
                increment = value;
                return this;
            }

            public Builder SetAffixClasses(AffixClasses value)
            {
                affixClasses = value;
                return this;
            }

            public AffixMasterDataBaseForIntegerMinMaxAndIncrement Build()
            {
                return new AffixMasterDataBaseForIntegerMinMaxAndIncrement
                {
                    MinValue = minValue,
                    MaxValue = maxValue,
                    Increment = increment,
                    AffixClasses = affixClasses
                };
            }
        }
    }
}
