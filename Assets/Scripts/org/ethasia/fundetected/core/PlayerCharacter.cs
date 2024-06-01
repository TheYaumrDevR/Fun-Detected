using System.Collections.Generic;

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

        private MeleeAttack meleeAttack;

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            allEquipment = new PlayerEquipmentSlots();
        }

        private void CreateMeleeAttack(MeleeHitArcProperties meleeHitArcProperties)
        {
            BresenhamBasedHitArcGenerationAlgorithm hitArcGenerator = new BresenhamBasedHitArcGenerationAlgorithm();
            hitArcGenerator.CreateFilledCircleArc(meleeHitArcProperties.HitArcStartAngle, meleeHitArcProperties.HitArcEndAngle, meleeHitArcProperties.HitArcRadius);

            List<HitboxTilePosition> meleeHitArc = hitArcGenerator.HitboxTilePositionsRight;

            meleeAttack = new MeleeAttack.MeleeAttackBuilder()
                .SetHitArcRightSwing(meleeHitArc)
                .SetTimeToHitFromStartOfAttack((1.0 / baseStats.AttacksPerSecond) / 2.0)
                .SetPositionOffsetRightSwingToPlayerCharacterCenter(new Position(meleeHitArcProperties.HitArcCenterXOffset, meleeHitArcProperties.HitArcCenterYOffset))
                .Build();
        }

        public void Tick(double actionTime)
        {
            meleeAttack.Tick(actionTime);
        }

        public bool CanAutoAttack()
        {
            return baseStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted();
        }

        public AsyncResponse<List<IBattleActionResult>> AutoAttack()
        {
            AsyncResponse<List<IBattleActionResult>> result = new AsyncResponse<List<IBattleActionResult>>();
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            if (baseStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted())
            {
                AsyncResponse<HashSet<Enemy>> enemiesHit = meleeAttack.Start(baseStats.AttacksPerSecond);

                enemiesHit.OnResponseReceived((enemies) => DealDamageToHitEnemies(enemies, result));
            }
            else
            {
                battleActionResults.Add(new NoAttackExecutedBattleLogEntry());
                result.SetResponseObject(battleActionResults);
            }

            return result;
        }

        public bool IsAttacking()
        {
            return !EnoughTimePassedForTheNextAttackToBeExecuted();
        }

        public int MoveLeft(double actionTime)
        {
            meleeAttack.Cancel();
            FacingDirection = FacingDirection.LEFT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
        }

        public int MoveRight(double actionTime)
        {
            meleeAttack.Cancel();
            FacingDirection = FacingDirection.RIGHT;
            timeSinceLastMovement += actionTime;
            return CalculateMovementDistance();
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

        private void DealDamageToHitEnemies(HashSet<Enemy> enemies, AsyncResponse<List<IBattleActionResult>> battleActionResponse)
        {
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            foreach (Enemy target in enemies)
            {
                if (!target.IsDead())
                {
                    float chanceToHit = Formulas.CalculateChanceToHit(baseStats.AccuracyRating, target.EvasionRating);
                            
                    if (randomNumberGenerator.CheckProbabilityIsHit(chanceToHit))
                    {
                        DamageRange damageRange = baseStats.BasePhysicalDamage;

                        int damage = randomNumberGenerator.GenerateIntegerBetweenAnd(damageRange.minDamage, damageRange.maxDamage);

                        int damageTaken = target.TakePhysicalHit(damage);

                        battleActionResults.Add(new PlayerAbilityActionResult.Builder()
                            .SetTarget(target)
                            .SetTargetDamageTaken(damageTaken)
                            .Build());
                    }
                    else 
                    {
                        battleActionResults.Add(new AttackMissedBattleLogEntry());
                    }
                }
            }

            battleActionResponse.SetResponseObject(battleActionResults);
        }

        private bool EnoughTimePassedForTheNextAttackToBeExecuted()
        {
            return meleeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(baseStats.AttacksPerSecond);
        }

        public class PlayerCharacterBuilder
        {
            private FacingDirection facingDirection;
            private string name;
            private CharacterClasses characterClass;

            private PlayerCharacterBaseStats playerCharacterBaseStats;
            private MeleeHitArcProperties meleeHitArcProperties;

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

            public PlayerCharacterBuilder SetMeleeHitArcProperties(MeleeHitArcProperties value)
            {
                meleeHitArcProperties = value;
                return this;
            }                                                     

            public PlayerCharacter Build()
            {
                PlayerCharacter result = new PlayerCharacter();

                result.FacingDirection = facingDirection;

                result.name = name;
                result.characterClass = characterClass;

                result.baseStats = playerCharacterBaseStats;

                result.CreateMeleeAttack(meleeHitArcProperties);

                return result;
            }  
        }
    }
}