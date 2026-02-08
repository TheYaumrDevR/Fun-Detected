using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class ItemInventoryExtractionVisitor : ItemVisitor
    {
        private ItemInventory inventoryToExtract;

        private ItemInInventoryShape currentlyExtractingShape;

        public List<ItemWithShape<Weapon>> ExtractedWeapons = new List<ItemWithShape<Weapon>>();
        public List<ItemWithShape<Armor>> ExtractedArmors = new List<ItemWithShape<Armor>>();
        public List<ItemWithShape<Jewelry>> ExtractedJewelry = new List<ItemWithShape<Jewelry>>();
        public List<ItemWithShape<RecoveryPotion>> ExtractedRecoveryPotions = new List<ItemWithShape<RecoveryPotion>>();

        public ItemInventoryExtractionVisitor(ItemInventory inventoryToExtract)
        {
            this.inventoryToExtract = inventoryToExtract;
        }

        public void ExtractItems()
        {
            Reset();

            List<ItemInInventoryShape> itemsInInventory = inventoryToExtract.GetItems();
            foreach (ItemInInventoryShape itemInInventoryShape in itemsInInventory)
            {
                currentlyExtractingShape = itemInInventoryShape;

                itemInInventoryShape.Item.Accept(this);
            }
        }

        public override void Visit(Weapon equipment)
        {
            ExtractedWeapons.Add(new ItemWithShape<Weapon>(equipment, currentlyExtractingShape));
        }

        public override void Visit(Armor equipment)
        {
            ExtractedArmors.Add(new ItemWithShape<Armor>(equipment, currentlyExtractingShape));
        }

        public override void Visit(Jewelry equipment)
        {
            ExtractedJewelry.Add(new ItemWithShape<Jewelry>(equipment, currentlyExtractingShape));
        }

        public override void Visit(RecoveryPotion recoveryPotion)
        {
            ExtractedRecoveryPotions.Add(new ItemWithShape<RecoveryPotion>(recoveryPotion, currentlyExtractingShape));
        }

        private void Reset()
        {
            currentlyExtractingShape = null;

            ExtractedWeapons.Clear();
            ExtractedArmors.Clear();
            ExtractedJewelry.Clear();
            ExtractedRecoveryPotions.Clear();
        }

        public struct ItemWithShape<TItem> where TItem : Item
        {
            public TItem Item
            {
                get;
                private set;
            }

            public ItemInInventoryShape ItemInInventoryShape
            {
                get;
                private set;
            }

            public ItemWithShape(TItem item, ItemInInventoryShape itemInInventoryShape)
            {
                Item = item;
                ItemInInventoryShape = itemInInventoryShape;
            }
        }
    }
}