using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class RecoveryPotionMasterData : ItemMasterData
    {
        public int RecoveryAmount
        {
            get;
            private set;
        }

        public int Uses
        {
            get;
            private set;
        }

        public override Item ToItem()
        {
            return ItemMasterDataToItemConverter.ConvertRecoveryPotionMasterDataToPotion(this);
        }        

        public class Builder
        {
            private ItemClass itemClass;
            private int minimumItemLevel;
            private string name;
            private int recoveryAmount;
            private int uses;

            public Builder SetItemClass(ItemClass value)
            {
                itemClass = value;
                return this;
            }

            public Builder SetMinimumItemLevel(int value)
            {
                minimumItemLevel = value;
                return this;
            }

            public Builder SetName(string value)
            {
                name = value;
                return this;
            }

            public Builder SetRecoveryAmount(int value)
            {
                this.recoveryAmount = value;
                return this;
            }

            public Builder SetUses(int value)
            {
                this.uses = value;
                return this;
            }

            public RecoveryPotionMasterData Build()
            {
                RecoveryPotionMasterData result = new RecoveryPotionMasterData();

                result.ItemClass = itemClass;
                result.MinimumItemLevel = minimumItemLevel;
                result.Name = name;
                result.RecoveryAmount = recoveryAmount;
                result.Uses = uses;

                return result;
            }
        }
    }
}