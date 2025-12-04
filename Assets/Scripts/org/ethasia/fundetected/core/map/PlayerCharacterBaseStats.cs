namespace Org.Ethasia.Fundetected.Core.Map
{

    // Stats derived from level up values and class base stats
    public class PlayerCharacterBaseStats
    {
        private const int MAXIMUM_LEVEL = 5;

        public int Level
        {
            get;
            private set;
        }

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

        public DamageRange BasePhysicalDamageWithMeleeAttacks
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

        public PlayerCharacterBaseStats()
        {
            BasePhysicalDamageWithMeleeAttacks = new DamageRange(1, 1);
        }

        public void LevelUp()
        {
            if (Level < MAXIMUM_LEVEL)
            {
                Level = Level + 1;

                MaximumLife += 12;
                MaximumMana += 6;
                AccuracyRating += 2;

                FullHeal();
            }
        }

        public void DeriveStats()
        {
            MaximumLife += Strength / 2;
            MaximumMana += Intelligence / 2;
            AccuracyRating += Agility * 2;

            SecondsToMoveOneUnit = 1.0 / (MovementSpeed / 10); 
        }   

        public void ReduceCurrentLifeBy(int damage)
        {
            CurrentLife -= damage;

            if (CurrentLife < 0)
            {
                CurrentLife = 0;
            }
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

        public class PlayerCharacterBaseStatsBuilder
        {
            private int level;
            private int intelligence;
            private int agility;
            private int strength;

            private int maximumLife;
            private int maximumMana;   

            private int currentLife;
            private int currentMana;       

            private DamageRange basePhysicalDamageWithMeleeAttacks;     

            private int accuracyRating;   
            private int evasionRating;   

            private double attacksPerSecond; 

            private int movementSpeed;

            public PlayerCharacterBaseStatsBuilder SetLevel(int value)
            {
                level = value;
                return this;
            }

            public PlayerCharacterBaseStatsBuilder SetIntelligence(int value)
            {
                intelligence = value;
                return this;
            }  

            public PlayerCharacterBaseStatsBuilder SetAgility(int value)
            {
                agility = value;
                return this;
            }  

            public PlayerCharacterBaseStatsBuilder SetStrength(int value)
            {
                strength = value;
                return this;
            }    

            public PlayerCharacterBaseStatsBuilder SetMaxLife(int value)
            {
                maximumLife = value;
                return this;
            }  

            public PlayerCharacterBaseStatsBuilder SetMaxMana(int value)
            {
                maximumMana = value;
                return this;
            } 

            public PlayerCharacterBaseStatsBuilder SetAccuracyRating(int value)
            {
                accuracyRating = value;
                return this;
            }    

            public PlayerCharacterBaseStatsBuilder SetEvasionRating(int value)
            {
                evasionRating = value;
                return this;
            }              

            public PlayerCharacterBaseStatsBuilder SetBasePhysicalDamageWithMeleeAttacks(DamageRange value)
            {
                basePhysicalDamageWithMeleeAttacks = value;
                return this;
            }   

            public PlayerCharacterBaseStatsBuilder SetAttacksPerSecond(double value)
            {
                attacksPerSecond = value;
                return this;
            }      

            public PlayerCharacterBaseStatsBuilder SetMovementSpeed(int value)
            {
                movementSpeed = value;
                return this;
            }                                                                                                

            public PlayerCharacterBaseStats Build()
            {
                PlayerCharacterBaseStats result = new PlayerCharacterBaseStats();

                result.Level = level;
                result.Intelligence = intelligence;
                result.Agility = agility;
                result.Strength = strength;
                result.MaximumLife = maximumLife;
                result.MaximumMana = maximumMana;
                result.CurrentLife = currentLife;
                result.CurrentMana = currentMana;
                result.AccuracyRating = accuracyRating;
                result.EvasionRating = evasionRating;
                result.BasePhysicalDamageWithMeleeAttacks = basePhysicalDamageWithMeleeAttacks;
                result.AttacksPerSecond = attacksPerSecond;
                result.MovementSpeed = movementSpeed;

                if (null == basePhysicalDamageWithMeleeAttacks)
                {
                    result.BasePhysicalDamageWithMeleeAttacks = new DamageRange(1, 1);
                }

                return result;
            }  
        }                
    }
}