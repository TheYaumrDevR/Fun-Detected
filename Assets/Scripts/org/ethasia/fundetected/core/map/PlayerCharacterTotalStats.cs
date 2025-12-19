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

        public int CurrentLife
        {
            get;
            private set;
        }

        public int CurrentMana
        {
            get;
            private set;
        }  

        public DamageRange PhysicalDamageWithRightHandMeleeAttacks
        {
            get;
            private set;
        }

        public DamageRange PhysicalDamageWithLeftHandMeleeAttacks
        {
            get;
            private set;
        }

        public DamageRange PhysicalDamageWithRangedAttacks
        {
            get;
            private set;
        }

        public DamageRange PhysicalDamageWithSpells
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

        public double SecondsToMoveOneUnit
        {
            get;
            private set;
        }

        public int RightHandAbilityRange
        {
            get;
            private set;
        }

        public int LeftHandAbilityRange
        {
            get;
            private set;
        }

        public PlayerCharacterTotalStats()
        {
            PhysicalDamageWithRightHandMeleeAttacks = new DamageRange(0, 0);
            PhysicalDamageWithLeftHandMeleeAttacks = new DamageRange(0, 0);
            PhysicalDamageWithRangedAttacks = new DamageRange(0, 0);
            PhysicalDamageWithSpells = new DamageRange(0, 0);
        }

        public void Heal()
        {
            CurrentLife = MaximumLife;
        }

        public void FullHeal()
        {
            CurrentLife = MaximumLife;
            CurrentMana = MaximumMana;
        }

        public void ReduceCurrentLifeBy(int damage)
        {
            CurrentLife -= damage;

            if (CurrentLife < 0)
            {
                CurrentLife = 0;
            }
        }

        public void Calculate(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            CalculateTotalIntelligence(baseStats, modifiers, equipmentStats);
            CalculateTotalAgility(baseStats, modifiers, equipmentStats);
            CalculateTotalStrength(baseStats, modifiers, equipmentStats);
            CalculateMaximumLife(baseStats, modifiers, equipmentStats);
            CalculateMaximumMana(baseStats, modifiers, equipmentStats);
            CalculatePhysicalDamageWithMeleeAttacks(baseStats, modifiers, equipmentStats);
            CalculatePhysicalDamageWithRangedAttacks(modifiers, equipmentStats);
            CalculatePhysicalDamageWithSpells(modifiers, equipmentStats);
            CalculateAccuracyRating(baseStats, modifiers, equipmentStats);
            CalculateEvasionRating(baseStats, modifiers, equipmentStats);
            CalculateAttacksPerSecond(baseStats, modifiers, equipmentStats);
            CalculateMovementSpeed(baseStats, modifiers, equipmentStats);
            CalculateRightHandAbilityRange(modifiers, equipmentStats);
            CalculateLeftHandAbilityRange(modifiers, equipmentStats);
        }

        private void CalculateTotalIntelligence(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Intelligence)
                .SetAddend(modifiers.IntelligenceAddend + equipmentStats.PlusIntelligence)
                .SetIncrease(1.0f + modifiers.IntelligenceIncrease)
                .SetMultiplier(modifiers.IntelligenceMultiplier)
                .Build();

            Intelligence = CalculateTotal(context);
        }

        private void CalculateTotalAgility(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Agility)
                .SetAddend(modifiers.AgilityAddend + equipmentStats.PlusAgility)
                .SetIncrease(1.0f + modifiers.AgilityIncrease)
                .SetMultiplier(modifiers.AgilityMultiplier)
                .Build();

            Agility = CalculateTotal(context);
        }

        private void CalculateTotalStrength(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.Strength)
                .SetAddend(modifiers.StrengthAddend + equipmentStats.PlusStrength)
                .SetIncrease(1.0f + modifiers.StrengthIncrease)
                .SetMultiplier(modifiers.StrengthMultiplier)
                .Build();

            Strength = CalculateTotal(context);
        }

        private void CalculateMaximumLife(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            int additionalLifeFromStrength = Strength / 2;

            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MaximumLife)
                .SetAddend(modifiers.MaximumLifeAddend + additionalLifeFromStrength + equipmentStats.PlusMaximumLife)
                .SetIncrease(1.0f + modifiers.MaximumLifeIncrease + equipmentStats.IncreasedMaximumLifeInPercent / 100.0f)
                .SetMultiplier(modifiers.MaximumLifeMultiplier)
                .Build();

            MaximumLife = CalculateTotal(context);

            if (CurrentLife > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
        }

        private void CalculateMaximumMana(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            int additionalManaFromIntelligence = Intelligence / 2;

            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MaximumMana)
                .SetAddend(modifiers.MaximumManaAddend + additionalManaFromIntelligence + equipmentStats.PlusMaximumMana)
                .SetIncrease(1.0f + modifiers.MaximumManaIncrease)
                .SetMultiplier(modifiers.MaximumManaMultiplier)
                .Build();

            MaximumMana = CalculateTotal(context);

            if (CurrentMana > MaximumMana)
            {
                CurrentMana = MaximumMana;
            }
        }

        private void CalculatePhysicalDamageWithMeleeAttacks(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            PhysicalDamageWithRightHandMeleeAttacks.SetToZero();
            PhysicalDamageWithLeftHandMeleeAttacks.SetToZero();

            float strengthBasedPhysicalDamageIncrease = Strength / 5 * 0.01f;

            float increasedDamageFromEquipmentStats = (equipmentStats.IncreasedPhysicalDamageInPercent + equipmentStats.IncreasedPhysicalDamageWithAttacksInPercent) / 100.0f;

            float totalMultiplier = (1.0f + modifiers.AddedPhysicalDamageWithMeleeAttacksIncrease + modifiers.AddedPhysicalDamageIncrease + increasedDamageFromEquipmentStats + strengthBasedPhysicalDamageIncrease)
                * modifiers.AddedPhysicalDamageWithMeleeAttacksMultiplier
                * modifiers.AddedPhysicalDamageMultiplier;

            PhysicalDamageWithRightHandMeleeAttacks.Add(baseStats.RightHandPhysicalDamageWithMeleeAttacks);
            PhysicalDamageWithRightHandMeleeAttacks.Add(modifiers.AddedPhysicalDamageWithMeleeAttacks);
            PhysicalDamageWithRightHandMeleeAttacks.Add(modifiers.AddedPhysicalDamage);
            PhysicalDamageWithRightHandMeleeAttacks.Add(equipmentStats.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks);
            PhysicalDamageWithRightHandMeleeAttacks.Multiply(totalMultiplier);

            PhysicalDamageWithLeftHandMeleeAttacks.Add(baseStats.LeftHandPhysicalDamageWithMeleeAttacks);
            PhysicalDamageWithLeftHandMeleeAttacks.Add(modifiers.AddedPhysicalDamageWithMeleeAttacks);
            PhysicalDamageWithLeftHandMeleeAttacks.Add(modifiers.AddedPhysicalDamage);
            PhysicalDamageWithLeftHandMeleeAttacks.Add(equipmentStats.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks);
            PhysicalDamageWithLeftHandMeleeAttacks.Multiply(totalMultiplier);
        }

        private void CalculatePhysicalDamageWithRangedAttacks(PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            PhysicalDamageWithRangedAttacks.SetToZero();

            float increasedDamageFromEquipmentStats = (equipmentStats.IncreasedPhysicalDamageInPercent + equipmentStats.IncreasedPhysicalDamageWithAttacksInPercent) / 100.0f;

            float totalMultiplier = (1.0f + modifiers.AddedPhysicalDamageWithRangedAttacksIncrease + modifiers.AddedPhysicalDamageIncrease + increasedDamageFromEquipmentStats)
                * modifiers.AddedPhysicalDamageWithRangedAttacksMultiplier
                * modifiers.AddedPhysicalDamageMultiplier;

            PhysicalDamageWithRangedAttacks.Add(modifiers.AddedPhysicalDamageWithRangedAttacks);
            PhysicalDamageWithRangedAttacks.Add(modifiers.AddedPhysicalDamage);
            PhysicalDamageWithRangedAttacks.Add(equipmentStats.PlusMinMaxPhysicalDamageWithRangedAttacks);
            PhysicalDamageWithRangedAttacks.Multiply(totalMultiplier);   
        }

        private void CalculatePhysicalDamageWithSpells(PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            PhysicalDamageWithSpells.SetToZero();

            float increasedDamageFromEquipmentStats = equipmentStats.IncreasedPhysicalDamageInPercent / 100.0f;

            float totalMultiplier = (1.0f + modifiers.AddedPhysicalDamageWithSpellsIncrease + increasedDamageFromEquipmentStats + modifiers.AddedPhysicalDamageIncrease)
                * modifiers.AddedPhysicalDamageWithSpellsMultiplier
                * modifiers.AddedPhysicalDamageMultiplier;

            PhysicalDamageWithSpells.Add(modifiers.AddedPhysicalDamageWithSpells);
            PhysicalDamageWithSpells.Add(modifiers.AddedPhysicalDamage);
            PhysicalDamageWithSpells.Add(equipmentStats.PlusMinMaxPhysicalDamageWithSpells);
            PhysicalDamageWithSpells.Multiply(totalMultiplier);
        }

        private void CalculateAccuracyRating(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            int additionalAccuracyFromAgility = Agility * 2;

            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.AccuracyRating)
                .SetAddend(modifiers.AccuracyRatingAddend + additionalAccuracyFromAgility + equipmentStats.PlusAccuracy)
                .SetIncrease(1.0f + modifiers.AccuracyRatingIncrease)
                .SetMultiplier(modifiers.AccuracyRatingMultiplier)
                .Build();

            AccuracyRating = CalculateTotal(context);
        }

        private void CalculateEvasionRating(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            float agilityBasedEvasionRatingIncrease = Agility / 5 * 0.01f;

            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.EvasionRating)
                .SetAddend(modifiers.EvasionRatingAddend)
                .SetIncrease(1.0f + modifiers.EvasionRatingIncrease + agilityBasedEvasionRatingIncrease)
                .SetMultiplier(modifiers.EvasionRatingMultiplier)
                .Build();

            EvasionRating = CalculateTotal(context);
        }

        private void CalculateAttacksPerSecond(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            double result = baseStats.AttacksPerSecond;
            result *= 1.0f + modifiers.AttacksPerSecondIncrease;
            result *= modifiers.AttacksPerSecondMultiplier;

            AttacksPerSecond = result;
        }

        private void CalculateMovementSpeed(PlayerCharacterBaseStats baseStats, PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(baseStats.MovementSpeed)
                .SetAddend(modifiers.MovementSpeedAddend)
                .SetIncrease(1.0f + modifiers.MovementSpeedIncrease)
                .SetMultiplier(modifiers.MovementSpeedMultiplier)
                .Build();

            MovementSpeed = CalculateTotal(context);

            SecondsToMoveOneUnit = 1.0 / (MovementSpeed / 10); 
        }

        private void CalculateRightHandAbilityRange(PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(0)
                .SetAddend(equipmentStats.PlusRightHandWeaponRange)
                .SetIncrease(1.0f)
                .SetMultiplier(1.0f)
                .Build();

            RightHandAbilityRange = CalculateTotal(context);
        }

        private void CalculateLeftHandAbilityRange(PlayerCharacterAdditionalStats modifiers, StatsFromEquipment equipmentStats)
        {
            TotalStatValueCalculationContext context = new TotalStatValueCalculationContext.Builder()
                .SetBaseStat(0)
                .SetAddend(equipmentStats.PlusLeftHandWeaponRange)
                .SetIncrease(1.0f)
                .SetMultiplier(1.0f)
                .Build();

            LeftHandAbilityRange = CalculateTotal(context);
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