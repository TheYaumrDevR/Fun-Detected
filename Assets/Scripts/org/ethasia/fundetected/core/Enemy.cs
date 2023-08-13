namespace Org.Ethasia.Fundetected.Core
{
    public class Enemy
    {
        private string name;
        private int maxLife;
        private int currentLife;
        private int armor;

        public void TakePhysicalHit(int incomingDamage)
        {
            int finalDamage = Formulas.CalculatePhysicalDamageAfterReduction(incomingDamage, armor);
            currentLife -= finalDamage;

            if (0 > currentLife)
            {
                currentLife = 0;
            }
        }

        public bool IsDead()
        {
            return 0 == currentLife;
        }

        public class Builder
        {
            private string name;
            private int maxLife;
            private int currentLife;
            private int armor;

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

            public Builder SetLife(int value)
            {
                maxLife = value;
                currentLife = value;
                return this;
            }                       

            public Enemy Build()
            {
                Enemy result = new Enemy();
                result.name = name;
                result.armor = armor;
                result.maxLife = maxLife;
                result.currentLife = currentLife;

                return result;
            }
        }
    }
}