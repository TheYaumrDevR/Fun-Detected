using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class ItemInInventoryShapeTest
    {
        [Test]
        public void TestCreateOneByOneSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateOneByOne(null);

            Assert.That(item.Width, Is.EqualTo(1));
            Assert.That(item.Height, Is.EqualTo(1));
        }

        [Test]
        public void TestCreateTwoByOneSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateTwoByOne(null);

            Assert.That(item.Width, Is.EqualTo(2));
            Assert.That(item.Height, Is.EqualTo(1));
        }

        [Test]
        public void TestCreateOneByTwoSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateOneByTwo(null);

            Assert.That(item.Width, Is.EqualTo(1));
            Assert.That(item.Height, Is.EqualTo(2));
        }

        [Test]
        public void TestCreateOneByThreeSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateOneByThree(null);

            Assert.That(item.Width, Is.EqualTo(1));
            Assert.That(item.Height, Is.EqualTo(3));
        }

        [Test]
        public void TestCreateTwoByTwoSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateTwoByTwo(null);

            Assert.That(item.Width, Is.EqualTo(2));
            Assert.That(item.Height, Is.EqualTo(2));
        }

        [Test]
        public void TestCreateOneByFourSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateOneByFour(null);

            Assert.That(item.Width, Is.EqualTo(1));
            Assert.That(item.Height, Is.EqualTo(4));
        }

        [Test]
        public void TestCreateTwoByThreeSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateTwoByThree(null);

            Assert.That(item.Width, Is.EqualTo(2));
            Assert.That(item.Height, Is.EqualTo(3));
        }

        [Test]
        public void TestCreateTwoByFourSetsCorrectDimensions()
        {
            ItemInInventoryShape item = ItemInInventoryShape.CreateTwoByFour(null);

            Assert.That(item.Width, Is.EqualTo(2));
            Assert.That(item.Height, Is.EqualTo(4));
        }

        [Test]
        public void TestIsShapeEqualToSameDimensionsAreEqual()
        {
            ItemInInventoryShape item1 = ItemInInventoryShape.CreateTwoByTwo(null);
            ItemInInventoryShape item2 = ItemInInventoryShape.CreateTwoByTwo(null);

            Assert.IsTrue(item1.IsShapeEqualTo(item2));
        }

        [Test]
        public void TestIsShapeEqualToDifferentHeightsAreNotEqual()
        {
            ItemInInventoryShape item1 = ItemInInventoryShape.CreateTwoByTwo(null);
            ItemInInventoryShape item2 = ItemInInventoryShape.CreateTwoByThree(null);

            Assert.IsFalse(item1.IsShapeEqualTo(item2));
        }

        [Test]
        public void TestIsShapeEqualToDifferentWidthsAreNotEqual()
        {
            ItemInInventoryShape item1 = ItemInInventoryShape.CreateTwoByTwo(null);
            ItemInInventoryShape item2 = ItemInInventoryShape.CreateOneByTwo(null);

            Assert.IsFalse(item1.IsShapeEqualTo(item2));
        }

        [Test]
        public void TestIsSameItemInstanceAsIsEqualForSameInstance()
        {
            Armor item = new Armor.Builder().Build();

            ItemInInventoryShape itemShape1 = ItemInInventoryShape.CreateTwoByTwo(item);
            ItemInInventoryShape itemShape2 = ItemInInventoryShape.CreateTwoByTwo(item);

            Assert.IsTrue(itemShape1.IsSameItemInstanceAs(itemShape2));
        }

        [Test]
        public void TestIsSameItemInstanceAsIsNotEqualForDifferentInstances()
        {
            Armor item1 = new Armor.Builder().Build();
            Armor item2 = new Armor.Builder().Build();

            ItemInInventoryShape itemShape1 = ItemInInventoryShape.CreateTwoByTwo(item1);
            ItemInInventoryShape itemShape2 = ItemInInventoryShape.CreateTwoByTwo(item2);

            Assert.IsFalse(itemShape1.IsSameItemInstanceAs(itemShape2));
        }

        [Test]
        public void TestIsSameItemInstanceAsIsNotEqualForNull()
        {
            Armor item = new Armor.Builder().Build();

            ItemInInventoryShape itemShape1 = ItemInInventoryShape.CreateTwoByTwo(item);
            ItemInInventoryShape itemShape2 = ItemInInventoryShape.CreateTwoByTwo(null);

            Assert.IsFalse(itemShape1.IsSameItemInstanceAs(itemShape2));
        }

        [Test]
        public void TestIsSameItemInstanceAsIsEqualForTwoNullItems()
        {
            Armor item = new Armor.Builder().Build();

            ItemInInventoryShape itemShape1 = ItemInInventoryShape.CreateTwoByTwo(null);
            ItemInInventoryShape itemShape2 = ItemInInventoryShape.CreateTwoByTwo(null);

            Assert.IsTrue(itemShape1.IsSameItemInstanceAs(itemShape2));
        }
    }
}