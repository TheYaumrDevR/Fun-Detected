using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public class Enemy
    {
        private EnemyAI ai;
        private Dictionary<string, EnemyAbility> abilitiesByName;

        private StopWatch lastStartOfAttackStopWatch;

        public string Id
        {
            get;
            private set;
        }

        public BoundingBox BoundingBox
        {
            get;
            private set;
        }

        public Position Position
        {
            get;
            private set;
        }

        public StateMachine ActionStateMachine
        {
            private get;
            set;
        }       

        public string Name
        {
            get;
            private set;
        }

        private int maxLife;

        public int CurrentLife
        {
            get;
            private set;
        }

        private int armor;
        public int EvasionRating
        {
            get;
            private set;
        }

        private float fireResistance;
        private float iceResistance;
        private float lightningResistance;
        private float magicResistance;

        public int UnarmedStrikeRange
        {
            get;
            private set;
        }

        private int corpseMass;

        public float AttacksPerSecond
        {
            get;
            private set;
        }

        private Enemy()
        {
            lastStartOfAttackStopWatch = new StopWatch();
        }

        public void Update(double actionTime, Area map)
        {
            lastStartOfAttackStopWatch.Tick(actionTime);
            ai.Update(map);
        }

        public int TakePhysicalHit(int incomingDamage)
        {
            ai.OnHitTaken();
            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, armor);
            CurrentLife -= finalDamage;

            ExecuteAfterDamageTakenActions();

            return finalDamage;
        }

        public int TakeNonPhysicalHit(int incomingDamage, ResistanceDamageTypes damageType)
        {
            ai.OnHitTaken();
            int finalDamage = 0;

            switch (damageType)
            {
                case ResistanceDamageTypes.FIRE:
                    finalDamage = Formulas.CalculateNonPhysicalDamageAfterReduction(incomingDamage, fireResistance);
                    break;
                case ResistanceDamageTypes.ICE:
                    finalDamage = Formulas.CalculateNonPhysicalDamageAfterReduction(incomingDamage, iceResistance);
                    break;
                case ResistanceDamageTypes.LIGHTNING:
                    finalDamage = Formulas.CalculateNonPhysicalDamageAfterReduction(incomingDamage, lightningResistance);
                    break;
                case ResistanceDamageTypes.MAGIC:
                    finalDamage = Formulas.CalculateNonPhysicalDamageAfterReduction(incomingDamage, magicResistance);
                    break;
            }

            CurrentLife -= finalDamage;
            ExecuteAfterDamageTakenActions();

            return finalDamage;
        }

        public void StartIdling()
        {
            if (EnoughTimePassedForTheNextAttackToBeExecuted(AttacksPerSecond))
            {
                IEnemyAnimationPresenter animationPresenter = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
                animationPresenter.PlayIdleAnimation(ActionStateMachine);
            }
        }

        public void StrikeLeft(PlayerCharacter player)
        {
            if (EnoughTimePassedForTheNextAttackToBeExecuted(AttacksPerSecond))
            {
                lastStartOfAttackStopWatch.Reset();
                PlayStrikeLeftAnimation();
            }
        }

        public void StrikeRight(PlayerCharacter player)
        {
            if (EnoughTimePassedForTheNextAttackToBeExecuted(AttacksPerSecond))
            {
                lastStartOfAttackStopWatch.Reset();
                PlayStrikeRightAnimation();
            }
        }

        private bool EnoughTimePassedForTheNextAttackToBeExecuted(double attacksPerSecond)
        {
            double secondsPerAttack = 1.0 / attacksPerSecond;
            return !lastStartOfAttackStopWatch.WasReset || lastStartOfAttackStopWatch.TimePassedSinceStart >= secondsPerAttack;            
        } 

        private void PlayStrikeLeftAnimation()
        {
            IEnemyAnimationPresenter animationPresenter = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            animationPresenter.PlayLeftStrikeAnimation(ActionStateMachine);
        }

        private void PlayStrikeRightAnimation()
        {
            IEnemyAnimationPresenter animationPresenter = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            animationPresenter.PlayRightStrikeAnimation(ActionStateMachine);
        }

        public bool IsDead()
        {
            return 0 == CurrentLife;
        }

        private void ExecuteAfterDamageTakenActions()
        {
            if (0 > CurrentLife)
            {
                CurrentLife = 0;
            }

            if (IsDead())
            {
                PlayDeathAnimation();
            }
        }

        public void AddAbilityByName(string name, EnemyAbility ability)
        {
            abilitiesByName[name] = ability;
        }

        public EnemyAbility GetAbilityByName(string name)
        {
            return abilitiesByName[name];
        }

        private void PlayDeathAnimation()
        {
            IEnemyAnimationPresenter animationPresenter = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            animationPresenter.PlayDeathAnimation(ActionStateMachine);
        }

        public class Builder
        {
            private string id;
            private bool isAggressiveOnSight;
            private string name;
            private int maxLife;
            private int currentLife;
            private int armor;
            private float fireResistance;
            private float iceResistance;
            private float lightningResistance;
            private float magicResistance;
            private int evasionRating;
            private float attacksPerSecond;
            private int unarmedStrikeRange;
            private int corpseMass;
            private BoundingBox boundingBox;
            private Position position;

            public Builder SetName(string value)
            {
                name = value;
                return this;
            }            

            public Builder SetIsAggressiveOnSight(bool value)
            {
                isAggressiveOnSight = value;
                return this;
            }

            public Builder SetArmor(int value)
            {
                armor = value;
                return this;
            }

            public Builder SetFireResistance(float value)
            {
                fireResistance = value;
                return this;
            }

            public Builder SetIceResistance(float value)
            {
                iceResistance = value;
                return this;
            }

            public Builder SetLightningResistance(float value)
            {
                lightningResistance = value;
                return this;
            }

            public Builder SetMagicResistance(float value)
            {
                magicResistance = value;
                return this;
            }

            public Builder SetEvasionRating(int value)    
            {
                evasionRating = value;
                return this;
            }        

            public Builder SetLife(int value)
            {
                maxLife = value;
                currentLife = value;
                return this;
            }  

            public Builder SetAttacksPerSecond(float value)
            {
                attacksPerSecond = value;
                return this;
            }    

            public Builder SetBoundingBox(BoundingBox value)
            {
                boundingBox = value;
                return this;
            }    

            public Builder SetPosition(Position value)
            {
                position = value;
                return this;
            }   

            public Builder SetId(string value)
            {
                id = value;
                return this;
            }         

            public Builder SetUnarmedStrikeRange(int value)
            {
                unarmedStrikeRange = value;
                return this;
            }              

            public Builder SetCorpseMass(int value)
            {
                corpseMass = value;
                return this;
            }

            public Enemy Build()
            {
                Enemy result = new Enemy();

                EnemyAI enemyAI = new EnemyAI.Builder()
                    .IsAggressiveOnSight(isAggressiveOnSight)
                    .ManagedEnemy(result)
                    .Build();

                result.Id = id;
                result.Name = name;
                result.armor = armor;
                result.fireResistance = fireResistance;
                result.iceResistance = iceResistance;
                result.lightningResistance = lightningResistance;
                result.magicResistance = magicResistance;
                result.maxLife = maxLife;
                result.CurrentLife = currentLife;
                result.EvasionRating = evasionRating;
                result.AttacksPerSecond = attacksPerSecond;
                result.UnarmedStrikeRange = unarmedStrikeRange;
                result.corpseMass = corpseMass;
                result.BoundingBox = boundingBox;
                result.Position = position;
                result.ai = enemyAI;
                result.abilitiesByName = new Dictionary<string, EnemyAbility>();

                return result;
            }
        }
    }
}