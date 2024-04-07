using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

        private CharacterClasses characterClass;

        public FacingDirection FacingDirection
        {
            get;
            private set;
        }

        private string name;

        private PlayerCharacterBaseStats baseStats;     

        private double timeSinceLastMovement;

        private PlayerEquipmentSlots allEquipment;

        private StopWatch lastStartOfAttackStopWatch;

        public bool AttackWasCancelled
        {
            get;
            private set;
        }

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            allEquipment = new PlayerEquipmentSlots();
            lastStartOfAttackStopWatch = new StopWatch();
        }

        public void Tick(double actionTime)
        {
            lastStartOfAttackStopWatch.Tick(actionTime);
        }

        public IBattleActionResult AutoAttack(Enemy target)
        {
            if (baseStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted())
            {
                lastStartOfAttackStopWatch.Reset();
                AttackWasCancelled = false;

                if (target.IsDead())
                {
                    return new NothingToAttackBattleLogEntry();
                }

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

            return new NoAttackExecutedBattleLogEntry();
        }

        public bool IsAttacking()
        {
            return !EnoughTimePassedForTheNextAttackToBeExecuted();
        }

        public int MoveLeft(double actionTime)
        {
            AttackWasCancelled = true;
            FacingDirection = FacingDirection.LEFT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
        }

        public int MoveRight(double actionTime)
        {
            AttackWasCancelled = true;
            FacingDirection = FacingDirection.RIGHT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
        }

        private bool EnoughTimePassedForTheNextAttackToBeExecuted()
        {
            double secondsPerAttack = 1.0 / baseStats.AttacksPerSecond;
            return lastStartOfAttackStopWatch.TimePassedSinceStart >= secondsPerAttack || AttackWasCancelled;            
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

                result.FacingDirection = facingDirection;

                result.name = name;
                result.characterClass = characterClass;

                result.baseStats = playerCharacterBaseStats;

                return result;
            }  
        }
    }
}