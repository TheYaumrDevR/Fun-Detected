using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

        private CharacterClasses characterClass;

        private FacingDirection facingDirection;

        private string name;

        private PlayerCharacterBaseStats baseStats;     

        private double lastAttackTime;

        private double timeSinceLastMovement;

        private PlayerEquipmentSlots allEquipment;

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            allEquipment = new PlayerEquipmentSlots();
        }

        public IBattleLogEntry AutoAttack(double actionTime, Enemy target)
        {
            if (baseStats.CurrentLife > 0 && EnoughTimePassedSinceLastAttack(actionTime))
            {
                if (target.IsDead())
                {
                    return new NothingToAttackBattleLogEntry();
                }

                lastAttackTime = actionTime;

                float chanceToHit = Formulas.CalculateChanceToHit(baseStats.AccuracyRating, target.EvasionRating);
                
                if (randomNumberGenerator.CheckProbabilityIsHit(chanceToHit))
                {
                    DamageRange damageRange = baseStats.BasePhysicalDamage;

                    int damage = randomNumberGenerator.GenerateIntegerBetweenAnd(damageRange.minDamage, damageRange.maxDamage);

                    int damageTaken = target.TakePhysicalHit(damage);

                    return new PlayerAbilityActionResult.Builder()
                        .SetTargetName(target.Name)
                        .SetTargetDamageTaken(damageTaken)
                        .SetTargetRemainingHealth(target.CurrentLife)
                        .Build();
                }

                return new AttackMissedBattleLogEntry();
            }

            return new EmptyBattleLogEntry();
        }

        public int MoveLeft(double actionTime)
        {
            facingDirection = FacingDirection.LEFT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
        }

        public int MoveRight(double actionTime)
        {
            facingDirection = FacingDirection.RIGHT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
        }

        private bool EnoughTimePassedSinceLastAttack(double actionTime)
        {
            double secondsPerAttack = 1.0 / baseStats.AttacksPerSecond;
            return 0.0 == lastAttackTime || actionTime - lastAttackTime >= secondsPerAttack;
        }

        public int CalculateMovementDistance()
        {
            int result = 0;
            while (timeSinceLastMovement >= baseStats.SecondsToMoveOneUnit) 
            {
                timeSinceLastMovement -= baseStats.SecondsToMoveOneUnit;
                result++;
            }

            return result;            
        }

        public class PlayerCharacterBuilder
        {
            private FacingDirection facingDirection;
            private string name;
            private CharacterClasses characterClass;

            private PlayerCharacterBaseStats playerCharacterBaseStats;

            public PlayerCharacterBuilder SetFacingDirection(FacingDirection value)
            {
                facingDirection = value;
                return this;
            }   

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

                result.facingDirection = facingDirection;

                result.name = name;
                result.characterClass = characterClass;

                result.baseStats = playerCharacterBaseStats;

                return result;
            }  
        }
    }
}