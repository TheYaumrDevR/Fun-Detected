namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private CharacterClasses characterClass;
        private string name;

        private PlayerCharacterBaseStats playerCharacterBaseStats;     

        public class PlayerCharacterBuilder
        {
            private string name;
            private CharacterClasses characterClass;

            private PlayerCharacterBaseStats playerCharacterBaseStats;

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

            public PlayerCharacterBuilder SetPlayerCharacterBaseStats(PlayerCharacterBaseStats value)
            {
                playerCharacterBaseStats = value;
                return this;
            }                                                            

            public PlayerCharacter Build()
            {
                PlayerCharacter result = new PlayerCharacter();
                result.name = name;
                result.characterClass = characterClass;

                result.playerCharacterBaseStats = playerCharacterBaseStats;

                return result;
            }  
        }
    }
}