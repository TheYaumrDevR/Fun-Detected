namespace Org.Ethasia.Fundetected.Core.Items.Consumables
{
    public abstract class Consumable : Item
    {
        public int MaximumStackSize
        {
            get;
            protected set;
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
            if (otherConsumable.StackSize < 1)
            {
                return null;
            }

            if (StackSize + otherConsumable.StackSize <= MaximumStackSize)
            {
                StackSize += otherConsumable.StackSize;
                return null;
            } 
            else 
            {
                otherConsumable.StackSize = StackSize + otherConsumable.StackSize - MaximumStackSize;
                StackSize = MaximumStackSize;

                return otherConsumable;
            }
        }

        public Consumable SplitStack(int amount)
        {
            if (amount > 0 && StackSize - amount > 0)
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

        protected void Clone(Consumable clone)
        {
            clone.MaximumStackSize = MaximumStackSize;
            clone.StackSize = StackSize;

            Clone(clone);
        }

        new public class Builder : Item.Builder
        {
            private int stackSize;

            public Builder SetStackSize(int value)
            {
                stackSize = value;
                return this;
            }

            protected void FillConsumableFields(Consumable consumable)
            {
                if (stackSize > consumable.MaximumStackSize)
                {
                    consumable.StackSize = consumable.MaximumStackSize;
                }
                else
                {
                    consumable.StackSize = stackSize;
                }

                FillItemFields(consumable);
            }
        }
    }
}