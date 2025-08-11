using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IntegerMinMaxIncrementRollableEquipmentAffix : RollableEquipmentAffix
    {
        private int minValue;
        private int maxValue;
        private int increment;

        public IntegerMinMaxIncrementRollableEquipmentAffix(EquipmentAffix rerolledAffix)
            : base(rerolledAffix)
        {
        }

        public override void RerollAffix()
        {
            RerolledAffix.RerollValue(this);
        }

        public int RerollValue()
        {
            IRandomNumberGenerator randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            return randomNumberGenerator.GenerateIntegerBetweenAndWithStep(minValue, maxValue, increment);
        }

        public class Builder
        {
            private EquipmentAffix rerolledAffix;
            private int minValue;
            private int maxValue;
            private int increment;

            public Builder SetRerolledAffix(EquipmentAffix value)
            {
                rerolledAffix = value;
                return this;
            }

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

            public IntegerMinMaxIncrementRollableEquipmentAffix Build()
            {
                return new IntegerMinMaxIncrementRollableEquipmentAffix(rerolledAffix)
                {
                    minValue = this.minValue,
                    maxValue = this.maxValue,
                    increment = this.increment
                };
            }
        }
    }
}
