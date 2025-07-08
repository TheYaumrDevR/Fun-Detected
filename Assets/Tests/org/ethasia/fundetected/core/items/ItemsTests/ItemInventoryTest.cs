using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Items.Tests
{
    public class ItemInventoryTest
    {
        [Test]
        public void TestReplaceItemAtCanPutItemAtEmptySlot()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(10, 1));

            Assert.That(oldItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(10, 1)), Is.True);
        }

        [Test]
        public void TestReplaceItemAtReplacesAndRemovesExistingItem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            Weapon.Builder foilBuilder = new Weapon.Builder();
            foilBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            Weapon foil = foilBuilder.Build();

            ItemInInventoryShape foilShape = foil.CreateInventoryShape();

            testCandidate.ReplaceItemAt(foilShape, new PositionImmutable(10, 1));
            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(10, 1));

            Assert.That(oldItem, Is.EqualTo(foilShape));
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(10, 1)), Is.True);
            Assert.That(foilShape.IsAtPosition(new PositionImmutable(10, 1)), Is.False);
        }

        [Test]
        public void TestReplaceItemAtDoesNotReplaceItemWhenNewItemIsPlacedOverTwoItems()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            Jewelry.Builder belt1Builder = new Jewelry.Builder();
            belt1Builder.SetItemClass(ItemClass.BELT);

            Jewelry belt1 = belt1Builder.Build();

            ItemInInventoryShape belt1Shape = belt1.CreateInventoryShape();

            Jewelry.Builder belt2Builder = new Jewelry.Builder();
            belt2Builder.SetItemClass(ItemClass.BELT);

            Jewelry belt2 = belt2Builder.Build();

            ItemInInventoryShape belt2Shape = belt2.CreateInventoryShape();

            testCandidate.ReplaceItemAt(belt1Shape, new PositionImmutable(7, 0));
            testCandidate.ReplaceItemAt(belt2Shape, new PositionImmutable(6, 3));

            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(6, 0));

            Assert.That(oldItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(6, 0)), Is.False);
            Assert.That(belt1Shape.IsAtPosition(new PositionImmutable(7, 0)), Is.True);
            Assert.That(belt2Shape.IsAtPosition(new PositionImmutable(6, 3)), Is.True);
        }

        private ItemInInventoryShape CreateBowShape()
        {
            Weapon.Builder bowBuilder = new Weapon.Builder();
            bowBuilder.SetItemClass(ItemClass.BOW);

            Weapon bow = bowBuilder.Build();

            return bow.CreateInventoryShape();
        }
    }
}