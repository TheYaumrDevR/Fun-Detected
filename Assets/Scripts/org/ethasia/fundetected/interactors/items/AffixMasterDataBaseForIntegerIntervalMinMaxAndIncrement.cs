using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public struct AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement : EquipmentAffixMasterData
    {
        public int LowerBoundMinValue
        {
            get;
            private set;
        }

        public int LowerBoundMaxValue
        {
            get;
            private set;
        }

        public int LowerBoundIncrement
        {
            get;
            private set;
        }

        public int UpperBoundMinValue
        {
            get;
            private set;
        }

        public int UpperBoundMaxValue
        {
            get;
            private set;
        }

        public int UpperBoundIncrement
        {
            get;
            private set;
        }

        public AffixClasses AffixClass
        {
            get;
            private set;
        }

        public RollableEquipmentAffix ToRollableEquipmentAffix()
        {
            EquipmentAffix affix = AffixClass.ToRollableEquipmentAffix();

            IntegerIntervalMinMaxIncrementRollableEquipmentAffix result = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(affix)
                .SetLowerBoundMinValue(LowerBoundMinValue)
                .SetLowerBoundMaxValue(LowerBoundMaxValue)
                .SetLowerBoundIncrement(LowerBoundIncrement)
                .SetUpperBoundMinValue(UpperBoundMinValue)
                .SetUpperBoundMaxValue(UpperBoundMaxValue)
                .SetUpperBoundIncrement(UpperBoundIncrement)
                .Build();

            result.RerollAffix();

            return result;
        }

        public class Builder
        {
            private int lowerBoundMinValue;
            private int lowerBoundMaxValue;
            private int lowerBoundIncrement;
            private int upperBoundMinValue;
            private int upperBoundMaxValue;
            private int upperBoundIncrement;
            private AffixClasses affixClass;

            public Builder SetLowerBoundMinValue(int value)
            {
                lowerBoundMinValue = value;
                return this;
            }

            public Builder SetLowerBoundMaxValue(int value)
            {
                lowerBoundMaxValue = value;
                return this;
            }

            public Builder SetLowerBoundIncrement(int value)
            {
                lowerBoundIncrement = value;
                return this;
            }

            public Builder SetUpperBoundMinValue(int value)
            {
                upperBoundMinValue = value;
                return this;
            }

            public Builder SetUpperBoundMaxValue(int value)
            {
                upperBoundMaxValue = value;
                return this;
            }

            public Builder SetUpperBoundIncrement(int value)
            {
                upperBoundIncrement = value;
                return this;
            }

            public Builder SetAffixClass(AffixClasses value)
            {
                affixClass = value;
                return this;
            }

            public AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement Build()
            {
                return new AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement
                {
                    LowerBoundMinValue = lowerBoundMinValue,
                    LowerBoundMaxValue = lowerBoundMaxValue,
                    LowerBoundIncrement = lowerBoundIncrement,
                    UpperBoundMinValue = upperBoundMinValue,
                    UpperBoundMaxValue = upperBoundMaxValue,
                    UpperBoundIncrement = upperBoundIncrement,

                    AffixClass = affixClass
                };
            }
        }
    }
}