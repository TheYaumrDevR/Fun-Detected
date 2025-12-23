using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors.Items
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

        public AffixClasses AffixClass
        {
            get;
            private set;
        }

        public RollableEquipmentAffix ToRollableEquipmentAffix()
        {
            EquipmentAffix affix = AffixClass.ToRollableEquipmentAffix();

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
            private AffixClasses affixClass;

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
                affixClass = value;
                return this;
            }

            public AffixMasterDataBaseForIntegerMinMaxAndIncrement Build()
            {
                return new AffixMasterDataBaseForIntegerMinMaxAndIncrement
                {
                    MinValue = minValue,
                    MaxValue = maxValue,
                    Increment = increment,
                    AffixClass = affixClass
                };
            }
        }
    }
}
