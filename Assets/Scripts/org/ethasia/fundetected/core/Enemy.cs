namespace Org.Ethasia.Fundetected.Core
{
    public class Enemy
    {
        private string id;

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
            private string id;
            private string name;
            private int maxLife;
            private int currentLife;
            private int armor;
            private int evasionRating;
            private BoundingBox boundingBox;
            private Position position;

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
                result.id = id;
                result.Name = name;
                result.armor = armor;
                result.maxLife = maxLife;
                result.CurrentLife = currentLife;
                result.EvasionRating = evasionRating;
                result.BoundingBox = boundingBox;
                result.Position = position;

                return result;
            }
        }
    }
}