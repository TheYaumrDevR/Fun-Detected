namespace Org.Ethasia.Fundetected.Core
{
    public class Enemy
    {
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

        public int TakePhysicalHit(int incomingDamage)
        {
            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, armor);
            CurrentLife -= finalDamage;

            if (0 > CurrentLife)
            {
                CurrentLife = 0;
            }

            return finalDamage;
        }

        public bool IsDead()
        {
            return 0 == CurrentLife;
        }

        public class Builder
        {
            private string name;
            private int maxLife;
            private int currentLife;
            private int armor;
            private int evasionRating;

            public Builder SetName(string value)
            {
                name = value;
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

            public Enemy Build()
            {
                Enemy result = new Enemy();
                result.Name = name;
                result.armor = armor;
                result.maxLife = maxLife;
                result.CurrentLife = currentLife;
                result.EvasionRating = evasionRating;

                return result;
            }
        }
    }
}