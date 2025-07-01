namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerCharacterTotalStats
    {
        public int Intelligence
        {
            get;
            private set;
        }

        public int Agility
        {
            get;
            private set;
        }

        public int Strength
        {
            get;
            private set;
        }

        public int MaximumLife
        {
            get;
            private set;
        }

        public int MaximumMana
        {
            get;
            private set;
        }

        public DamageRange BasePhysicalDamage
        {
            get;
            private set;
        }

        public int AccuracyRating
        {
            get;
            private set;
        }

        public int EvasionRating
        {
            get;
            private set;
        }

        public double AttacksPerSecond
        {
            get;
            private set;
        }

        public int MovementSpeed
        {
            get;
            private set;
        }

        public PlayerCharacterTotalStats()
        {
            BasePhysicalDamage = new DamageRange(0, 0);
        }

        public void Calculate(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            CalculateTotalIntelligence(baseStats, modifiers);
            CalculateTotalAgility(baseStats, modifiers);
            CalculateTotalStrength(baseStats, modifiers);
            CalculateMaximumLife(baseStats, modifiers);
            CalculateMaximumMana(baseStats, modifiers);
            CalculateBasePhysicalDamage(baseStats, modifiers);
            CalculateAccuracyRating(baseStats, modifiers);
            CalculateEvasionRating(baseStats, modifiers);
            CalculateAttacksPerSecond(baseStats, modifiers);
            CalculateMovementSpeed(baseStats, modifiers);
        }

        private void CalculateTotalIntelligence(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Intelligence)
                .SetAddend(modifiers.IntelligenceAddend)
                .SetIncrease(modifiers.IntelligenceIncrease)
                .SetMultiplier(modifiers.IntelligenceMultiplier)
                .Build();

            Intelligence = CalculateTotal(context);
        }

        private void CalculateTotalAgility(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Agility)
                .SetAddend(modifiers.AgilityAddend)
                .SetIncrease(modifiers.AgilityIncrease)
                .SetMultiplier(modifiers.AgilityMultiplier)
                .Build();

            Agility = CalculateTotal(context);
        }

        private void CalculateTotalStrength(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Strength)
                .SetAddend(modifiers.StrengthAddend)
                .SetIncrease(modifiers.StrengthIncrease)
                .SetMultiplier(modifiers.StrengthMultiplier)
                .Build();

            Strength = CalculateTotal(context);
        }

        private void CalculateMaximumLife(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MaximumLife)
                .SetAddend(modifiers.MaximumLifeAddend)
                .SetIncrease(modifiers.MaximumLifeIncrease)
                .SetMultiplier(modifiers.MaximumLifeMultiplier)
                .Build();

            MaximumLife = CalculateTotal(context);
        }

        private void CalculateMaximumMana(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MaximumMana)
                .SetAddend(modifiers.MaximumManaAddend)
                .SetIncrease(modifiers.MaximumManaIncrease)
                .SetMultiplier(modifiers.MaximumManaMultiplier)
                .Build();

            MaximumMana = CalculateTotal(context);
        }



        private void CalculateBasePhysicalDamage(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            BasePhysicalDamage.Add(baseStats.BasePhysicalDamage);
            BasePhysicalDamage.Add(modifiers.AddedPhysicalDamage);
            BasePhysicalDamage.Multiply(modifiers.AddedPhysicalDamageIncrease);
            BasePhysicalDamage.Multiply(modifiers.AddedPhysicalDamageMultiplier);
        }

        private void CalculateAccuracyRating(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.AccuracyRating)
                .SetAddend(modifiers.AccuracyRatingAddend)
                .SetIncrease(modifiers.AccuracyRatingIncrease)
                .SetMultiplier(modifiers.AccuracyRatingMultiplier)
                .Build();

            AccuracyRating = CalculateTotal(context);
        }

        private void CalculateEvasionRating(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.EvasionRating)
                .SetAddend(modifiers.EvasionRatingAddend)
                .SetIncrease(modifiers.EvasionRatingIncrease)
                .SetMultiplier(modifiers.EvasionRatingMultiplier)
                .Build();

            EvasionRating = CalculateTotal(context);
        }

        private void CalculateAttacksPerSecond(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            double result = baseStats.AttacksPerSecond;
            result *= modifiers.AttacksPerSecondIncrease;
            result *= modifiers.AttacksPerSecondMultiplier;

            AttacksPerSecond = result;
        }

        private void CalculateMovementSpeed(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MovementSpeed)
                .SetAddend(modifiers.MovementSpeedAddend)
                .SetIncrease(modifiers.MovementSpeedIncrease)
                .SetMultiplier(modifiers.MovementSpeedMultiplier)
                .Build();

            MovementSpeed = CalculateTotal(context);
        }

        private int CalculateTotal(TotalStatValueCalculationContext context)
        {
            float result = context.BaseStat + context.Addend;
            result *= context.Multiplier;
            result *= context.Increase;

            return (int)result;
        }

        private struct TotalStatValueCalculationContext
        {
            public int BaseStat
            {
                get;
                private set;
            }

            public int Addend
            {
                get;
                private set;
            }

            public float Increase
            {
                get;
                private set;
            }

            public float Multiplier
            {
                get;
                private set;
            }

            public class Builder
            {
                private int baseStat;
                private int addend;
                private float increase;
                private float multiplier;

                public Builder SetBaseStat(int value)
                {
                    baseStat = value;
                    return this;
                }

                public Builder SetAddend(int value)
                {
                    addend = value;
                    return this;
                }

                public Builder SetIncrease(float value)
                {
                    increase = value;
                    return this;
                }

                public Builder SetMultiplier(float value)
                {
                    multiplier = value;
                    return this;
                }

                public TotalStatValueCalculationContext Build()
                {
                    TotalStatValueCalculationContext result = new TotalStatValueCalculationContext();

                    result.BaseStat = baseStat;
                    result.Addend = addend;
                    result.Increase = increase;
                    result.Multiplier = multiplier;

                    return result;
                }
            }
        }
    }
}