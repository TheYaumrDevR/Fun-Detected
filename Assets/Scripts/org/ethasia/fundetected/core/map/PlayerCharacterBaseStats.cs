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

        public DamageRange RightHandPhysicalDamageWithMeleeAttacks
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

        public PlayerCharacterBaseStats()
        {
            RightHandPhysicalDamageWithMeleeAttacks = new DamageRange(1, 1);
        }

        public void LevelUp()
        {
            if (Level < MAXIMUM_LEVEL)
            {
                Level = Level + 1;

                MaximumLife += 12;
                MaximumMana += 6;
                AccuracyRating += 2;
            }
        }  

        public class PlayerCharacterBaseStatsBuilder
        {
            private int level;
            private int intelligence;
            private int agility;
            private int strength;

            private int maximumLife;
            private int maximumMana;       

            private DamageRange rightHandPhysicalDamageWithMeleeAttacks;     

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

            public PlayerCharacterBaseStatsBuilder SetRightHandPhysicalDamageWithMeleeAttacks(DamageRange value)
            {
                rightHandPhysicalDamageWithMeleeAttacks = value;
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
                result.AccuracyRating = accuracyRating;
                result.EvasionRating = evasionRating;
                result.RightHandPhysicalDamageWithMeleeAttacks = rightHandPhysicalDamageWithMeleeAttacks;
                result.AttacksPerSecond = attacksPerSecond;
                result.MovementSpeed = movementSpeed;

                if (null == rightHandPhysicalDamageWithMeleeAttacks)
                {
                    result.RightHandPhysicalDamageWithMeleeAttacks = new DamageRange(1, 1);
                }

                return result;
            }  
        }                
    }
}