using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IntegerIntervalMinMaxIncrementRollableEquipmentAffix : RollableEquipmentAffix
    {
        private int lowerBoundMinValue;
        private int lowerBoundMaxValue;
        private int lowerBoundIncrement;
        private int upperBoundMinValue;
        private int upperBoundMaxValue;
        private int upperBoundIncrement;

        public IntegerIntervalMinMaxIncrementRollableEquipmentAffix(EquipmentAffix rerolledAffix)
            : base(rerolledAffix)
        {
        }

        public override void RerollAffix()
        {
            RerolledAffix.RerollValue(this);
        }

        public DamageRange RerollValue()
        {
            IRandomNumberGenerator randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();

            int newLowerBound = lowerBoundMinValue;
            int newUpperBound = upperBoundMinValue;

            if (lowerBoundMinValue < lowerBoundMaxValue)
            {
                newLowerBound = randomNumberGenerator.GenerateIntegerBetweenAndWithStep(lowerBoundMinValue, lowerBoundMaxValue, lowerBoundIncrement);
            }

            if (upperBoundMinValue < upperBoundMaxValue)
            {
                newUpperBound = randomNumberGenerator.GenerateIntegerBetweenAndWithStep(upperBoundMinValue, upperBoundMaxValue, upperBoundIncrement);
            }

            return new DamageRange(newLowerBound, newUpperBound);
        }

        public override bool Equals(RollableEquipmentAffix other)
        {
            if (other == null)
            {
                return false;
            }

            if (other is IntegerIntervalMinMaxIncrementRollableEquipmentAffix otherAffix)
            {
                bool affixesAreSameType = RerolledAffix?.GetType() == otherAffix.RerolledAffix?.GetType();

                return affixesAreSameType &&
                       lowerBoundMinValue == otherAffix.lowerBoundMinValue &&
                       lowerBoundMaxValue == otherAffix.lowerBoundMaxValue &&
                       lowerBoundIncrement == otherAffix.lowerBoundIncrement &&
                       upperBoundMinValue == otherAffix.upperBoundMinValue &&
                       upperBoundMaxValue == otherAffix.upperBoundMaxValue &&
                       upperBoundIncrement == otherAffix.upperBoundIncrement;
            }

            return false;
        }

        public override RollableEquipmentAffix Clone()
        {
            IntegerIntervalMinMaxIncrementRollableEquipmentAffix copy = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix(RerolledAffix.Clone());
            copy.lowerBoundMinValue = lowerBoundMinValue;
            copy.lowerBoundMaxValue = lowerBoundMaxValue;
            copy.lowerBoundIncrement = lowerBoundIncrement;
            copy.upperBoundMinValue = upperBoundMinValue;
            copy.upperBoundMaxValue = upperBoundMaxValue;
            copy.upperBoundIncrement = upperBoundIncrement;

            return copy;
        }

        public class Builder
        {
            private EquipmentAffix rerolledAffix;
            private int lowerBoundMinValue;
            private int lowerBoundMaxValue;
            private int lowerBoundIncrement;
            private int upperBoundMinValue;
            private int upperBoundMaxValue;
            private int upperBoundIncrement;

            public Builder SetRerolledAffix(EquipmentAffix affix)
            {
                rerolledAffix = affix;
                return this;
            }

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

            public IntegerIntervalMinMaxIncrementRollableEquipmentAffix Build()
            {
                IntegerIntervalMinMaxIncrementRollableEquipmentAffix result = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix(rerolledAffix);
                result.lowerBoundMinValue = lowerBoundMinValue;
                result.lowerBoundMaxValue = lowerBoundMaxValue;
                result.lowerBoundIncrement = lowerBoundIncrement;
                result.upperBoundMinValue = upperBoundMinValue;
                result.upperBoundMaxValue = upperBoundMaxValue;
                result.upperBoundIncrement = upperBoundIncrement;

                return result;
            }
        }
    }
}