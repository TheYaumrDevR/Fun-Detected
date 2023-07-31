namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private CharacterClasses characterClass;
        private string name;

        private int intelligence;
        private int dexterity;
        private int strength;

        private int life;
        private int mana;

        public class PlayerCharacterBuilder
        {
            private string name;
            private CharacterClasses characterClass;

            private int intelligence;
            private int dexterity;
            private int strength;

            private int life;
            private int mana;            

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

            public PlayerCharacterBuilder SetDexterity(int value)
            {
                dexterity = value;
                return this;
            }  

            public PlayerCharacterBuilder SetStrength(int value)
            {
                strength = value;
                return this;
            }    

            public PlayerCharacterBuilder SetLife(int value)
            {
                life = value;
                return this;
            }  

            public PlayerCharacterBuilder SetMana(int value)
            {
                mana = value;
                return this;
            }                                                     

            public PlayerCharacter Build()
            {
                PlayerCharacter result = new PlayerCharacter();
                result.name = name;
                result.characterClass = characterClass;

                result.intelligence = intelligence;
                result.dexterity = dexterity;
                result.strength = strength;
                result.life = life;
                result.mana = mana;

                return result;
            }  
        }
    }
}