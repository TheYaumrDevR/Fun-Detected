using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class ItemInventoryExtractionVisitorTest
    {
        [Test]
        public void TestExtractItems_ExtractsAllItemTypesAndStoresThemInLists()
        {
            ItemInventory inventory = new ItemInventory();

            Weapon testWeapon1 = CreateTestWeapon("WeaponOne");
            Weapon testWeapon2 = CreateTestWeapon("WeaponTwo");
            Armor testArmor1 = CreateTestArmor("ArmorOne");
            Armor testArmor2 = CreateTestArmor("ArmorTwo");
            Armor testArmor3 = CreateTestArmor("ArmorThree");
            Jewelry testJewelry1 = CreateTestJewelry("JewelryOne");
            Jewelry testJewelry2 = CreateTestJewelry("JewelryTwo");
            RecoveryPotion testPotion1 = CreateTestRecoveryPotion("PotionOne");
            RecoveryPotion testPotion2 = CreateTestRecoveryPotion("PotionTwo");

            ItemInInventoryShape weaponShape1 = ItemInInventoryShape.CreateTwoByThree(testWeapon1);
            ItemInInventoryShape weaponShape2 = ItemInInventoryShape.CreateTwoByThree(testWeapon2);
            ItemInInventoryShape armorShape1 = ItemInInventoryShape.CreateTwoByTwo(testArmor1);
            ItemInInventoryShape armorShape2 = ItemInInventoryShape.CreateTwoByTwo(testArmor2);
            ItemInInventoryShape armorShape3 = ItemInInventoryShape.CreateTwoByTwo(testArmor3);
            ItemInInventoryShape jewelryShape1 = ItemInInventoryShape.CreateTwoByOne(testJewelry1);
            ItemInInventoryShape jewelryShape2 = ItemInInventoryShape.CreateTwoByOne(testJewelry2);
            ItemInInventoryShape potionShape1 = ItemInInventoryShape.CreateOneByTwo(testPotion1);
            ItemInInventoryShape potionShape2 = ItemInInventoryShape.CreateOneByTwo(testPotion2);

            inventory.AddItemAtNextFreePosition(weaponShape1);
            inventory.AddItemAtNextFreePosition(weaponShape2);
            inventory.AddItemAtNextFreePosition(armorShape1);
            inventory.AddItemAtNextFreePosition(armorShape2);
            inventory.AddItemAtNextFreePosition(armorShape3);
            inventory.AddItemAtNextFreePosition(jewelryShape1);
            inventory.AddItemAtNextFreePosition(jewelryShape2);
            inventory.AddItemAtNextFreePosition(potionShape1);
            inventory.AddItemAtNextFreePosition(potionShape2);

            ItemInventoryExtractionVisitor testCandidate = new ItemInventoryExtractionVisitor(inventory);
            testCandidate.ExtractItems();

            Assert.That(testCandidate.ExtractedWeapons[0].Item, Is.EqualTo(testWeapon1));
            Assert.That(testCandidate.ExtractedWeapons[1].Item, Is.EqualTo(testWeapon2));

            Assert.That(testCandidate.ExtractedArmors[0].Item, Is.EqualTo(testArmor1));
            Assert.That(testCandidate.ExtractedArmors[1].Item, Is.EqualTo(testArmor2));
            Assert.That(testCandidate.ExtractedArmors[2].Item, Is.EqualTo(testArmor3));

            Assert.That(testCandidate.ExtractedJewelry[0].Item, Is.EqualTo(testJewelry1));
            Assert.That(testCandidate.ExtractedJewelry[1].Item, Is.EqualTo(testJewelry2));
            
            Assert.That(testCandidate.ExtractedRecoveryPotions[0].Item, Is.EqualTo(testPotion1));
            Assert.That(testCandidate.ExtractedRecoveryPotions[1].Item, Is.EqualTo(testPotion2));
        }

        private Weapon CreateTestWeapon(string name)
        {
            var builder = new Weapon.Builder();

            builder.SetName(name)
                .SetItemClass(ItemClass.FIST_WEAPON);

            return builder.Build();
        }

        private Armor CreateTestArmor(string name)
        {
            var builder = new Armor.Builder();

            builder.SetName(name)
                .SetItemClass(ItemClass.GLOVES);

            return builder.Build();
        }
        
        private Jewelry CreateTestJewelry(string name)
        {
            var builder = new Jewelry.Builder();

            builder.SetName(name)
                .SetItemClass(ItemClass.BELT);

            return builder.Build();
        }
        
        private RecoveryPotion CreateTestRecoveryPotion(string name)
        {
            var builder = new RecoveryPotion.Builder();

            builder.SetName(name)
                .SetItemClass(ItemClass.LIFE_POTION);

            return builder.Build();
        }
    }
}