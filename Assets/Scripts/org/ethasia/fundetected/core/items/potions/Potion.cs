namespace Org.Ethasia.Fundetected.Core.Items.Potions
{
    public abstract class Potion : Item
    {
        public int Uses
        {
            get;
            private set;
        }

        protected void Clone(Potion clone)
        {
            clone.Uses = Uses;
            CloneItemFields(clone);
        }

        new public class Builder : Item.Builder
        {
            private int uses;

            public Builder SetUses(int value)
            {
                this.uses = value;
                return this;
            }

            protected void FillPotionFields(Potion uninitializedPotion)
            {
                uninitializedPotion.Uses = uses;
                FillItemFields(uninitializedPotion);
            }
        }
    }
}