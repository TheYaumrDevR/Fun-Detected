using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerCharacter
    {
        private IRandomNumberGenerator randomNumberGenerator;

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

        private PlayerEquipmentSlots allEquipment;
        private ItemInventory inventory;

        public int EvasionRating
        {
            get
            {
                return TotalStats.EvasionRating;    
            }
        }

        private MeleeAttack meleeAttack;

        private PlayerCharacter()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            StatModifiers = new PlayerCharacterAdditionalStats();
            TotalStats = new PlayerCharacterTotalStats();
            allEquipment = new PlayerEquipmentSlots();
            inventory = new ItemInventory();
        }

        private void CreateMeleeAttack(MeleeHitArcProperties meleeHitArcProperties)
        {
            meleeAttack = new MeleeAttack.MeleeAttackBuilder()
                .SetTimeToHitFromStartOfAttack((1.0 / TotalStats.AttacksPerSecond) / 2.0)
                .SetPositionOffsetRightSwingToPlayerCharacterCenter(new Position(meleeHitArcProperties.HitArcCenterXOffset, meleeHitArcProperties.HitArcCenterYOffset))
                .SetOriginalAttackRange(meleeHitArcProperties.HitArcRadius)
                .SetHitArcStartAngle(meleeHitArcProperties.HitArcStartAngle)
                .SetHitArcEndAngle(meleeHitArcProperties.HitArcEndAngle)
                .Build();
        }

        public void Tick(double actionTime)
        {
            meleeAttack.Tick(actionTime);
        }

        public bool CanAutoAttack()
        {
            return TotalStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted();
        }

        public AsyncResponse<List<IBattleActionResult>> AutoAttack()
        {
            AsyncResponse<List<IBattleActionResult>> result = new AsyncResponse<List<IBattleActionResult>>();
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            if (TotalStats.CurrentLife > 0 && EnoughTimePassedForTheNextAttackToBeExecuted())
            {
                AsyncResponse<HashSet<Enemy>> enemiesHit = meleeAttack.Start(TotalStats.AttacksPerSecond);

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
            while (timeSinceLastMovement >= TotalStats.SecondsToMoveOneUnit) 
            {
                timeSinceLastMovement -= TotalStats.SecondsToMoveOneUnit;
                result++;
            }

            return result;            
        }    

        public void FullyHealHp()
        {
            TotalStats.Heal();
        }

        public void FullyHealHpAndMp()
        {
            TotalStats.FullHeal();
        }

        public void TakePhysicalDamage(int incomingDamage)
        {
            if (TotalStats.CurrentLife <= 0)
            {
                return;
            }

            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, 0);
            TotalStats.ReduceCurrentLifeBy(finalDamage);

            PresentDamage(finalDamage);
        }    

        public Org.Ethasia.Fundetected.Core.Equipment.Equipment PickupEquipment(Org.Ethasia.Fundetected.Core.Equipment.Equipment equipment)
        {
            Org.Ethasia.Fundetected.Core.Equipment.Equipment result = allEquipment.EquipIntoFreeSlotBasedOnItemClass(equipment);

            if (result != equipment)
            {
                TotalStats.Calculate(BaseStats, StatModifiers, allEquipment.EquipmentStats);
                meleeAttack.SetAdditionalAttackRange(TotalStats.RightHandAbilityRange);

                return result;
            }
            else
            {
                if (!inventory.AddItemAtNextFreePosition(equipment.CreateInventoryShape()))
                {
                    return result;
                }

                return null;
            }
        }

        public Potion PickupPotion(Potion potion)
        {
            if (!inventory.AddItemAtNextFreePosition(potion.CreateInventoryShape()))
            {
                return potion;
            }

            return null;
        }

        public PlayerEquipmentItemsExtractionVisitor CreateItemExtractionVisitor()
        {
            return new PlayerEquipmentItemsExtractionVisitor(allEquipment);
        }

        public ItemInventoryExtractionVisitor CreateInventoryItemExtractionVisitor()
        {
            return new ItemInventoryExtractionVisitor(inventory);
        }

        private void PresentDamage(int damageTaken)
        {
            IPlayerDamageTakenInteractor playerDamageTakenInteractor = InteractorsFactoryForCore.GetInstance().GetPlayerDamageTakenInteractorInstance();
            
            IPlayerDamageTakenInteractor.PlayerDamageContext playerDamageContext = new IPlayerDamageTakenInteractor.PlayerDamageContext();
            playerDamageContext.DamageTaken = damageTaken;
            playerDamageContext.MaximumHealth = TotalStats.MaximumLife;
            playerDamageContext.CurrentHealth = TotalStats.CurrentLife;

            playerDamageTakenInteractor.NotifyPlayerOfDamageTaken(playerDamageContext);
        }

        private void DealDamageToHitEnemies(HashSet<Enemy> enemies, AsyncResponse<List<IBattleActionResult>> battleActionResponse)
        {
            List<IBattleActionResult> battleActionResults = new List<IBattleActionResult>();

            foreach (Enemy target in enemies)
            {
                if (!target.IsDead())
                {
                    float chanceToHit = Formulas.CalculateChanceToHit(TotalStats.AccuracyRating, target.EvasionRating);
                            
                    if (randomNumberGenerator.CheckProbabilityIsHit(chanceToHit))
                    {
                        DamageRange damageRange = TotalStats.PhysicalDamageWithRightHandMeleeAttacks;

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
            return meleeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(TotalStats.AttacksPerSecond);
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
                result.TotalStats.Calculate(playerCharacterBaseStats, result.StatModifiers, result.allEquipment.EquipmentStats);

                result.CreateMeleeAttack(meleeHitArcProperties);

                return result;
            }  
        }
    }
}