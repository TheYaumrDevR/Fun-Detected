namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private CharacterClasses characterClass;
        private string name;

        private int intelligence;
        private int agility;
        private int strength;

        private int maximumLife;
        private int maximumMana;

        private int currentLife;
        private int currentMana;

        private int accuracyRating;  

        public void DeriveStats()
        {
            maximumLife += strength / 2;
            maximumMana += intelligence / 2;
            accuracyRating += agility * 2;
        }       

        public class PlayerCharacterBuilder
        {
            private string name;
            private CharacterClasses characterClass;

            private int intelligence;
            private int agility;
            private int strength;

            private int maximumLife;
            private int maximumMana;   

            private int currentLife;
            private int currentMana;            

            private int accuracyRating;  

            public PlayerCharacterBuilder SetName(string value)
            {
                name = value;
                return this;
            }

            public PlayerCharacterBuilder SetCharacterClass(CharacterClasses value)
            {
                characterClass = value;
                return this;
            }     

            public PlayerCharacterBuilder SetIntelligence(int value)
            {
                intelligence = value;
                return this;
            }  

            public PlayerCharacterBuilder SetAgility(int value)
            {
                agility = value;
                return this;
            }  

            public PlayerCharacterBuilder SetStrength(int value)
            {
                strength = value;
                return this;
            }    

            public PlayerCharacterBuilder SetMaxLife(int value)
            {
                maximumLife = value;
                return this;
            }  

            public PlayerCharacterBuilder SetMaxMana(int value)
            {
                maximumMana = value;
                return this;
            } 

            public PlayerCharacterBuilder SetAccuracyRating(int value)
            {
                accuracyRating = value;
                return this;
            }                                                                   

            public PlayerCharacter Build()
            {
                PlayerCharacter result = new PlayerCharacter();
                result.name = name;
                result.characterClass = characterClass;

                result.intelligence = intelligence;
                result.agility = agility;
                result.strength = strength;
                result.maximumLife = maximumLife;
                result.maximumMana = maximumMana;
                result.currentLife = currentLife;
                result.currentMana = currentMana;
                result.accuracyRating = accuracyRating;

                return result;
            }  
        }
    }
}