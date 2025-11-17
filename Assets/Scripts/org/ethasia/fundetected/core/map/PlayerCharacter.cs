using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

        private double timeSinceLastMovement;  

        public BoundingBox BoundingBox
        {
            get;
            private set;
        }              

        private CharacterClasses characterClass;

        public FacingDirection FacingDirection
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public PlayerCharacterBaseStats BaseStats
        {
            get;
            private set;
        }   

        public PlayerCharacterAdditionalStats StatModifiers
        {
            get;
            private set;
        }

        public PlayerCharacterTotalStats TotalStats
        {
            get;
            private set;
        }

        private PlayerEquipmentSlots allEquipment;

        public int EvasionRating
        {
            get
            {
                return BaseStats.EvasionRating;    
            }
        }

        private MeleeAttack meleeAttack;

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            StatModifiers = new PlayerCharacterAdditionalStats();
            TotalStats = new PlayerCharacterTotalStats();
            allEquipment = new PlayerEquipmentSlots();
        }

        private void CreateMeleeAttack(MeleeHitArcProperties meleeHitArcProperties)
        {
            BresenhamBasedHitArcGenerationAlgorithm hitArcGenerator = new BresenhamBasedHitArcGenerationAlgorithm();
            hitArcGenerator.CreateFilledCircleArc(meleeHitArcProperties.HitArcStartAngle, meleeHitArcProperties.HitArcEndAngle, meleeHitArcProperties.HitArcRadius);

            List<HitboxTilePosition> meleeHitArc = hitArcGenerator.HitboxTilePositionsRight;

            meleeAttack = new MeleeAttack.MeleeAttackBuilder()
                .SetHitArcRightSwing(meleeHitArc)
                .SetTimeToHitFromStartOfAttack((1.0 / BaseStats.AttacksPerSecond) / 2.0)
                .SetPositionOffsetRightSwingToPlayerCharacterCenter(new Position(meleeHitArcProperties.HitArcCenterXOffset, meleeHitArcProperties.HitArcCenterYOffset))
                .Build();
        }

        public void Tick(double actionTime)
        {
            meleeAttack.Tick(actionTime);
        }

        public bool CanAutoAttack()
        {
            return BaseStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted();
        }

        public AsyncResponse<List<IBattleActionResult>> AutoAttack()
        {
            AsyncResponse<List<IBattleActionResult>> result = new AsyncResponse<List<IBattleActionResult>>();
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            if (BaseStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted())
            {
                AsyncResponse<HashSet<Enemy>> enemiesHit = meleeAttack.Start(BaseStats.AttacksPerSecond);

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
            while (timeSinceLastMovement >= BaseStats.SecondsToMoveOneUnit) 
            {
                timeSinceLastMovement -= BaseStats.SecondsToMoveOneUnit;
                result++;
            }

            return result;            
        }    

        public void FullyHealHp()
        {
            BaseStats.Heal();
        }

        public void FullyHealHpAndMp()
        {
            BaseStats.FullHeal();
        }

        public void TakePhysicalDamage(int incomingDamage)
        {
            if (BaseStats.CurrentLife <= 0)
            {
                return;
            }

            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, 0);
            BaseStats.ReduceCurrentLifeBy(finalDamage);

            PresentDamage(finalDamage);
        }    

        public void PickupEquipment(Org.Ethasia.Fundetected.Core.Equipment.Equipment equipment)
        {
            allEquipment.EquipIntoFreeSlotBasedOnItemClass(equipment);
        }

        public PlayerEquipmentItemsExtractionVisitor CreateItemExtractionVisitor()
        {
            return new PlayerEquipmentItemsExtractionVisitor(allEquipment);
        }

        private void PresentDamage(int damageTaken)
        {
            IPlayerDamageTakenInteractor playerDamageTakenInteractor = InteractorsFactoryForCore.GetInstance().GetPlayerDamageTakenInteractorInstance();
            
            IPlayerDamageTakenInteractor.PlayerDamageContext playerDamageContext = new IPlayerDamageTakenInteractor.PlayerDamageContext();
            playerDamageContext.DamageTaken = damageTaken;
            playerDamageContext.MaximumHealth = BaseStats.MaximumLife;
            playerDamageContext.CurrentHealth = BaseStats.CurrentLife;
            
            playerDamageTakenInteractor.NotifyPlayerOfDamageTaken(playerDamageContext);
        }

        private void DealDamageToHitEnemies(HashSet<Enemy> enemies, AsyncResponse<List<IBattleActionResult>> battleActionResponse)
        {
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            foreach (Enemy target in enemies)
            {
                if (!target.IsDead())
                {
                    float chanceToHit = Formulas.CalculateChanceToHit(BaseStats.AccuracyRating, target.EvasionRating);
                            
                    if (randomNumberGenerator.CheckProbabilityIsHit(chanceToHit))
                    {
                        DamageRange damageRange = BaseStats.BasePhysicalDamage;

                        int damage = randomNumberGenerator.GenerateIntegerBetweenAnd(damageRange.MinDamage, damageRange.MaxDamage);

                        int damageTaken = target.TakePhysicalHit(damage);

                        battleActionResults.Add(new PlayerAbilityActionResult.Builder()
                            .SetTarget(target)
                            .SetTargetDamageTaken(damageTaken)
                            .Build());
                    }
                    else 
                    {
                        AttackMissedBattleLogEntry attackMissResult = new AttackMissedBattleLogEntry.Builder()
                            .SetEnemyPositionX(target.Position.X)
                            .SetEnemyPositionY(target.Position.Y)
                            .Build();

                        battleActionResults.Add(attackMissResult);
                    }
                }
            }

            battleActionResponse.SetResponseObject(battleActionResults);
        }

        private bool EnoughTimePassedForTheNextAttackToBeExecuted()
        {
            return meleeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(BaseStats.AttacksPerSecond);
        }

        public class PlayerCharacterBuilder
        {
            private BoundingBox boundingBox;
            private FacingDirection facingDirection;
            private string name;
            private CharacterClasses characterClass;

            private PlayerCharacterBaseStats playerCharacterBaseStats;
            private MeleeHitArcProperties meleeHitArcProperties;

            public PlayerCharacterBuilder SetBoundingBox(BoundingBox value)
            {
                boundingBox = value;
                return this;
            }  

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

                result.BoundingBox = boundingBox;

                result.FacingDirection = facingDirection;

                result.Name = name;
                result.characterClass = characterClass;

                result.BaseStats = playerCharacterBaseStats;
                result.TotalStats.Calculate(playerCharacterBaseStats, result.StatModifiers);

                result.CreateMeleeAttack(meleeHitArcProperties);

                return result;
            }  
        }
    }
}