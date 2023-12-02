namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public abstract class Item
    {
        public ItemClass ItemClass
        {
            get;
            private set;
        }

        public int ItemLevel
        {
            get;
            private set;            
        }

        public class Builder
        {
            private ItemClass itemClass;
            private int itemLevel;

            public Builder SetItemClass(ItemClass value)
            {
                this.itemClass = value;
                return this;
            }    

            public Builder SetItemLevel(int value)
            {
                this.itemLevel = value;
                return this;
            }                         

            protected void FillItemFields(Item statlessItem)
            {
                statlessItem.ItemClass = itemClass;
                statlessItem.ItemLevel = itemLevel;
            }
        }        
    }
}