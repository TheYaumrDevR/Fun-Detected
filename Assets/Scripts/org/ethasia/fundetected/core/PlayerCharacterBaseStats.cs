namespace Org.Ethasia.Fundetected.Core
{

    // Stats derived from level up values and passive skill points
    public class PlayerCharacterBaseStats
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

        public void DeriveStats()
        {
            MaximumLife += Strength / 2;
            MaximumMana += Intelligence / 2;
            AccuracyRating += Agility * 2;

            SecondsToMoveOneUnit = 1.0 / (MovementSpeed / 10); 
        }   

        public void FullHeal()
        {
            CurrentLife = MaximumLife;
            CurrentMana = MaximumMana;
        }

        public class PlayerCharacterBaseStatsBuilder
        {
            private int intelligence;
            private int agility;
            private int strength;

            private int maximumLife;
            private int maximumMana;   

            private int currentLife;
            private int currentMana;       

            private DamageRange basePhysicalDamage;     

            private int accuracyRating;   

            private double attacksPerSecond; 

            private int movementSpeed;

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

            public PlayerCharacterBaseStatsBuilder SetBasePhysicalDamage(DamageRange value)
            {
                basePhysicalDamage = value;
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

                result.Intelligence = intelligence;
                result.Agility = agility;
                result.Strength = strength;
                result.MaximumLife = maximumLife;
                result.MaximumMana = maximumMana;
                result.CurrentLife = currentLife;
                result.CurrentMana = currentMana;
                result.AccuracyRating = accuracyRating;
                result.BasePhysicalDamage = basePhysicalDamage;
                result.AttacksPerSecond = attacksPerSecond;
                result.MovementSpeed = movementSpeed;

                return result;
            }  
        }                
    }
}