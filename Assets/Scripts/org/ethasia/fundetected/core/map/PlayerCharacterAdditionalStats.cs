namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerCharacterAdditionalStats
    {
        public int StrengthAddend
        {
            get;
            private set;
        }

        public float StrengthIncrease
        {
            get;
            private set;
        }

        public float StrengthMultiplier
        {
            get;
            private set;
        }

        public int AgilityAddend
        {
            get;
            private set;
        }

        public float AgilityIncrease
        {
            get;
            private set;
        }

        public float AgilityMultiplier
        {
            get;
            private set;
        }

        public int IntelligenceAddend
        {
            get;
            private set;
        }

        public float IntelligenceIncrease
        {
            get;
            private set;
        }

        public float IntelligenceMultiplier
        {
            get;
            private set;
        }

        public int MaximumLifeAddend
        {
            get;
            private set;
        }

        public float MaximumLifeIncrease
        {
            get;
            private set;
        }

        public float MaximumLifeMultiplier
        {
            get;
            private set;
        }

        public int MaximumManaAddend
        {
            get;
            private set;
        }

        public float MaximumManaIncrease
        {
            get;
            private set;
        }

        public float MaximumManaMultiplier
        {
            get;
            private set;
        }

        public DamageRange AddedPhysicalDamage
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageIncrease
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageMultiplier
        {
            get;
            private set;
        }

        public DamageRange AddedPhysicalDamageWithMeleeAttacks
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithMeleeAttacksIncrease
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithMeleeAttacksMultiplier
        {
            get;
            private set;
        }

        public DamageRange AddedPhysicalDamageWithRangedAttacks
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithRangedAttacksIncrease
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithRangedAttacksMultiplier
        {
            get;
            private set;
        }

        public DamageRange AddedPhysicalDamageWithSpells
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithSpellsIncrease
        {
            get;
            private set;
        }

        public float AddedPhysicalDamageWithSpellsMultiplier
        {
            get;
            private set;
        }

        public int AccuracyRatingAddend
        {
            get;
            private set;
        }

        public float AccuracyRatingIncrease
        {
            get;
            private set;
        }

        public float AccuracyRatingMultiplier
        {
            get;
            private set;
        }

        public int EvasionRatingAddend
        {
            get;
            private set;
        }

        public float EvasionRatingIncrease
        {
            get;
            private set;
        }

        public float EvasionRatingMultiplier
        {
            get;
            private set;
        }

        public float AttacksPerSecondIncrease
        {
            get;
            private set;
        }

        public float AttacksPerSecondMultiplier
        {
            get;
            private set;
        }

        public int MovementSpeedAddend
        {
            get;
            private set;
        }

        public float MovementSpeedIncrease
        {
            get;
            private set;
        }

        public float MovementSpeedMultiplier
        {
            get;
            private set;
        }

        public PlayerCharacterAdditionalStats()
        {
            AddedPhysicalDamage = new DamageRange(0, 0);
            AddedPhysicalDamageWithMeleeAttacks = new DamageRange(0, 0);
            AddedPhysicalDamageWithRangedAttacks = new DamageRange(0, 0);
            AddedPhysicalDamageWithSpells = new DamageRange(0, 0);

            StrengthMultiplier = 1.0f;
            AgilityMultiplier = 1.0f;
            IntelligenceMultiplier = 1.0f;
            MaximumLifeMultiplier = 1.0f;
            MaximumManaMultiplier = 1.0f;
            AddedPhysicalDamageMultiplier = 1.0f;
            AddedPhysicalDamageWithMeleeAttacksMultiplier = 1.0f;
            AddedPhysicalDamageWithRangedAttacksMultiplier = 1.0f;
            AddedPhysicalDamageWithSpellsMultiplier = 1.0f;
            AccuracyRatingMultiplier = 1.0f;
            EvasionRatingMultiplier = 1.0f;
            AttacksPerSecondMultiplier = 1.0f;
            MovementSpeedMultiplier = 1.0f;
        }

        public void AddStrengthAddend(int value)
        {
            StrengthAddend += value;
        }

        public void AddStrengthIncrease(float value)
        {
            StrengthIncrease += value;
        }

        public void AddStrengthMultiplier(float value)
        {
            StrengthMultiplier *= value;
        }

        public void AddAgilityAddend(int value)
        {
            AgilityAddend += value;
        }

        public void AddAgilityIncrease(float value)
        {
            AgilityIncrease += value;
        }

        public void AddAgilityMultiplier(float value)
        {
            AgilityMultiplier *= value;
        }

        public void AddIntelligenceAddend(int value)
        {
            IntelligenceAddend += value;
        }

        public void AddIntelligenceIncrease(float value)
        {
            IntelligenceIncrease += value;
        }

        public void AddIntelligenceMultiplier(float value)
        {
            IntelligenceMultiplier *= value;
        }

        public void AddMaximumLifeAddend(int value)
        {
            MaximumLifeAddend += value;
        }

        public void AddMaximumLifeIncrease(float value)
        {
            MaximumLifeIncrease += value;
        }

        public void AddMaximumLifeMultiplier(float value)
        {
            MaximumLifeMultiplier *= value;
        }

        public void AddMaximumManaAddend(int value)
        {
            MaximumManaAddend += value;
        }

        public void AddMaximumManaIncrease(float value)
        {
            MaximumManaIncrease += value;
        }

        public void AddMaximumManaMultiplier(float value)
        {
            MaximumManaMultiplier *= value;
        }

        public void AddAddedPhysicalDamage(DamageRange value)
        {
            AddedPhysicalDamage.Add(value);
        }

        public void AddAddedPhysicalDamageIncrease(float value)
        {
            AddedPhysicalDamageIncrease += value;
        }

        public void AddAddedPhysicalDamageMultiplier(float value)
        {
            AddedPhysicalDamageMultiplier *= value;
        }

        public void AddAddedPhysicalDamageWithMeleeAttacks(DamageRange value)
        {
            AddedPhysicalDamageWithMeleeAttacks.Add(value);
        }

        public void AddAddedPhysicalDamageWithMeleeAttacksIncrease(float value)
        {
            AddedPhysicalDamageWithMeleeAttacksIncrease += value;
        }

        public void AddAddedPhysicalDamageWithMeleeAttacksMultiplier(float value)
        {
            AddedPhysicalDamageWithMeleeAttacksMultiplier *= value;
        }

        public void AddAddedPhysicalDamageWithRangedAttacks(DamageRange value)
        {
            AddedPhysicalDamageWithRangedAttacks.Add(value);
        }

        public void AddAddedPhysicalDamageWithRangedAttacksIncrease(float value)
        {
            AddedPhysicalDamageWithRangedAttacksIncrease += value;
        }

        public void AddAddedPhysicalDamageWithRangedAttacksMultiplier(float value)
        {
            AddedPhysicalDamageWithRangedAttacksMultiplier *= value;
        }

        public void AddAddedPhysicalDamageWithSpells(DamageRange value)
        {
            AddedPhysicalDamageWithSpells.Add(value);
        }

        public void AddAddedPhysicalDamageWithSpellsIncrease(float value)
        {
            AddedPhysicalDamageWithSpellsIncrease += value;
        }

        public void AddAddedPhysicalDamageWithSpellsMultiplier(float value)
        {
            AddedPhysicalDamageWithSpellsMultiplier *= value;
        }

        public void AddAccuracyRatingAddend(int value)
        {
            AccuracyRatingAddend += value;
        }

        public void AddAccuracyRatingIncrease(float value)
        {
            AccuracyRatingIncrease += value;
        }

        public void AddAccuracyRatingMultiplier(float value)
        {
            AccuracyRatingMultiplier *= value;
        }

        public void AddEvasionRatingAddend(int value)
        {
            EvasionRatingAddend += value;
        }

        public void AddEvasionRatingIncrease(float value)
        {
            EvasionRatingIncrease += value;
        }

        public void AddEvasionRatingMultiplier(float value)
        {
            EvasionRatingMultiplier *= value;
        }

        public void AddAttacksPerSecondIncrease(float value)
        {
            AttacksPerSecondIncrease += value;
        }

        public void AddAttacksPerSecondMultiplier(float value)
        {
            AttacksPerSecondMultiplier *= value;
        }

        public void AddMovementSpeedAddend(int value)
        {
            MovementSpeedAddend += value;
        }

        public void AddMovementSpeedIncrease(float value)
        {
            MovementSpeedIncrease += value;
        }

        public void AddMovementSpeedMultiplier(float value)
        {
            MovementSpeedMultiplier *= value;
        }
    }
}