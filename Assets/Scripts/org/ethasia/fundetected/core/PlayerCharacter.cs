namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

        private CharacterClasses characterClass;
        private string name;

        private PlayerCharacterBaseStats baseStats;     

        private double lastAttackTime;

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
        }

        public PlayerAbilityActionResult AutoAttack(double actionTime, Enemy target)
        {
            if (baseStats.CurrentLife > 0 && EnoughTimePassedSinceLastAttack(actionTime))
            {
                lastAttackTime = actionTime;

                DamageRange damageRange = baseStats.BasePhysicalDamage;

                int damage = randomNumberGenerator.GenerateIntegerBetweenAnd(damageRange.minDamage, damageRange.maxDamage);

                int damageTaken = target.TakePhysicalHit(damage);

                return new PlayerAbilityActionResult.Builder()
                    .SetTargetName(target.Name)
                    .SetTargetDamageTaken(damageTaken)
                    .SetTargetRemainingHealth(target.CurrentLife)
                    .Build();
            }

            return new PlayerAbilityActionResult.Builder().Build();
        }

        private bool EnoughTimePassedSinceLastAttack(double actionTime)
        {
            double secondsPerAttack = 1.0 / baseStats.AttacksPerSecond;
            return 0.0 == lastAttackTime || actionTime - lastAttackTime >= secondsPerAttack;
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