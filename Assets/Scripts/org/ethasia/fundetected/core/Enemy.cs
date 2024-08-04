using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public class Enemy
    {
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

        private bool isAggressive; 

        public string Name
        {
            get;
            private set;
        }

        private bool isAggressiveOnSight;

        public bool IsAggressiveOnSight
        {
            get
            {
                return isAggressiveOnSight;
            }

            private set
            {
                isAggressiveOnSight = value;

                if (isAggressiveOnSight)
                {
                    isAggressive = true;
                }
            }
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

        public float AttacksPerSecond
        {
            get;
            private set;
        }

        public int TakePhysicalHit(int incomingDamage)
        {
            isAggressive = true;

            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, armor);
            CurrentLife -= finalDamage;

            if (0 > CurrentLife)
            {
                CurrentLife = 0;
            }

            if (IsDead())
            {
                PlayDeathAnimation();
            }

            return finalDamage;
        }

        public bool IsDead()
        {
            return 0 == CurrentLife;
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
            private int evasionRating;
            private float attacksPerSecond;
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

            public Enemy Build()
            {
                Enemy result = new Enemy();
                result.Id = id;
                result.Name = name;
                result.IsAggressiveOnSight = isAggressiveOnSight;
                result.armor = armor;
                result.maxLife = maxLife;
                result.CurrentLife = currentLife;
                result.EvasionRating = evasionRating;
                result.AttacksPerSecond = attacksPerSecond;
                result.BoundingBox = boundingBox;
                result.Position = position;

                return result;
            }
        }
    }
}