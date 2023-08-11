namespace Org.Ethasia.Fundetected.Core
{

    // Stats derived from level up values and passive skill points
    public class PlayerCharacterBaseStats
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

        public void DeriveStats()
        {
            maximumLife += strength / 2;
            maximumMana += intelligence / 2;
            accuracyRating += agility * 2;
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

            public PlayerCharacterBaseStats Build()
            {
                PlayerCharacterBaseStats result = new PlayerCharacterBaseStats();

                result.intelligence = intelligence;
                result.agility = agility;
                result.strength = strength;
                result.maximumLife = maximumLife;
                result.maximumMana = maximumMana;
                result.currentLife = currentLife;
                result.currentMana = currentMana;
                result.accuracyRating = accuracyRating;
                result.basePhysicalDamage = basePhysicalDamage;

                result.DeriveStats();

                return result;
            }  
        }                
    }
}