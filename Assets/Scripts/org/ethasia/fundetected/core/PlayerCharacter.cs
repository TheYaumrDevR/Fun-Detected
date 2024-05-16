using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Maths;

using UnityEngine;

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

        private void CreateMeleeAttack()
        {
            BresenhamBasedHitArcGenerationAlgorithm hitArcGenerator = new BresenhamBasedHitArcGenerationAlgorithm();
            hitArcGenerator.CreateFilledCircleArc(-0.3829252379, 0.9971066017, 22);

            List<HitboxTilePosition> meleeHitArc = hitArcGenerator.HitboxTilePositions;

            meleeAttack = new MeleeAttack(meleeHitArc, (1.0 / baseStats.AttacksPerSecond) / 2.0);
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
                enemiesHit.OnResponseReceived((enemies) => {
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
                                    .SetTargetName(target.Name)
                                    .SetTargetDamageTaken(damageTaken)
                                    .SetTargetRemainingHealth(target.CurrentLife)
                                    .Build());

                                Debug.Log("X: " + target.Position.X + " Y: " + target.Position.Y);
                            }
                            else 
                            {
                                battleActionResults.Add(new AttackMissedBattleLogEntry());
                            }
                        }
                    }

                    result.SetResponseObject(battleActionResults);
                });
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

        private bool EnoughTimePassedForTheNextAttackToBeExecuted()
        {
            return meleeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(baseStats.AttacksPerSecond);
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

                result.CreateMeleeAttack();

                return result;
            }  
        }
    }
}