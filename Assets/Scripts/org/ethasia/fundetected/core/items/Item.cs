namespace Org.Ethasia.Fundetected.Core.Items
{
    public abstract class Item
    {
        public string Name
        {
            get;
            private set;
        }

        public ItemClass ItemClass
        {
            get;
            private set;
        }
        
        public int MinimumItemLevel
        {
            get;
            private set;
        }

        public int ItemLevel
        {
            get;
            private set;
        }
        
        public ItemInInventoryShape CreateInventoryShape()
        {
            return ItemClass.CreateInventoryShape(this);
        }
        
        public abstract void Accept(ItemVisitor visitor);

        public class Builder
        {
            private string name;
            private ItemClass itemClass;
            private int minimumItemLevel;
            private int itemLevel;

            public Builder SetName(string value)
            {
                this.name = value;
                return this;
            }

            public Builder SetItemClass(ItemClass value)
            {
                this.itemClass = value;
                return this;
            }

            public Builder SetMinimumItemLevel(int value)
            {
                this.minimumItemLevel = value;
                return this;
            }

            public Builder SetItemLevel(int value)
            {
                this.itemLevel = value;
                return this;
            }

            protected void FillItemFields(Item statlessItem)
            {
                statlessItem.Name = name;
                statlessItem.ItemClass = itemClass;
                statlessItem.MinimumItemLevel = minimumItemLevel;
                statlessItem.ItemLevel = itemLevel;
            }
        }        
    }
}