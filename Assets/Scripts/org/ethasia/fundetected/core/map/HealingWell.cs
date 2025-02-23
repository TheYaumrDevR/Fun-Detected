using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class HealingWell : InteractableEnvironmentObject
    {
        private bool hasInfiniteCharges;     

        public int Charges
        {
            get;
            private set;
        }

        public override void OnInteract()
        {
            if (Charges > 0)
            {
                PlayerCharacter player = Area.ActiveArea.Player;
                player.FullyHealHpAndMp();
            }

            if (!hasInfiniteCharges)
            {
                Charges--;
            }
        }

        public class Builder
        {
            private Position position;
            private int width;
            private int height;
            private int charges;
            private bool hasInfiniteCharges;

            public Builder SetPosition(Position value)
            {
                position = value;
                return this;
            }

            public Builder SetWidth(int value)
            {
                width = value;
                return this;
            }

            public Builder SetHeight(int value)
            {
                height = value;
                return this;
            }

            public Builder SetCharges(int value)
            {
                if (!hasInfiniteCharges)
                {
                    charges = value;
                }

                return this;
            }

            public Builder MakeInfinite()
            {
                hasInfiniteCharges = true;
                charges = 1;
                return this;
            }

            public HealingWell Build()
            {
                HealingWell result = new HealingWell();

                result.Position = position;
                result.Width = width;
                result.Height = height;
                result.Charges = charges;
                result.hasInfiniteCharges = hasInfiniteCharges;

                return result;
            }
        }
    }
}