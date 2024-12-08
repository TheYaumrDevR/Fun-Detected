namespace Org.Ethasia.Fundetected.Core.Items.Consumables
{
    public abstract class Consumable : Item
    {
        public int MaximumStackSize
        {
            get;
            private set;
        }

        public int StackSize
        {
            get;
            private set;
        }

        public void Consume()
        {
            if (StackSize > 0)
            {
                StackSize--;
            }
        }

        public Consumable AddToStack(Consumable otherConsumable)
        {
            if (StackSize + otherConsumable.StackSize <= MaximumStackSize)
            {
                StackSize += otherConsumable.StackSize;
                return null;
            } 
            else 
            {
                StackSize = MaximumStackSize;
                otherConsumable.StackSize = StackSize + otherConsumable.StackSize - MaximumStackSize;

                return otherConsumable;
            }
        }

        public Consumable SplitStack(int amount)
        {
            if (StackSize - amount > 0)
            {
                StackSize -= amount;

                Consumable newStack = (Consumable)this.MemberwiseClone();
                newStack.StackSize = amount;

                return newStack;
            } 
            else 
            {
                return null;
            }
        }

        new public class Builder : Item.Builder
        {
            private int maximumStackSize;
            private int stackSize;

            public Builder SetMaximumStackSize(int value)
            {
                maximumStackSize = value;
                return this;
            }

            public Builder SetStackSize(int value)
            {
                stackSize = value;
                return this;
            }

            protected void FillConsumableFields(Consumable consumable)
            {
                consumable.MaximumStackSize = maximumStackSize;
                consumable.StackSize = stackSize;

                FillItemFields(consumable);
            }
        }
    }
}