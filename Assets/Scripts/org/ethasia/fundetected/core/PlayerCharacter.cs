namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

        private CharacterClasses characterClass;
        private string name;

        private PlayerCharacterBaseStats baseStats;     

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
        }

        public void AutoAttack(Enemy target)
        {
            if (baseStats.CurrentLife > 0)
            {
                DamageRange damageRange = baseStats.BasePhysicalDamage;

                int damage = randomNumberGenerator.GenerateIntegerBetweenAnd(damageRange.minDamage, damageRange.maxDamage);

                target.TakePhysicalHit(damage);
            }
        }

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

                result.baseStats = playerCharacterBaseStats;

                return result;
            }  
        }
    }
}