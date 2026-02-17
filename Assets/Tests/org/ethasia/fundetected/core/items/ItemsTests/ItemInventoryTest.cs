using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items.Potions;
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

        [Test]
        public void TestReplaceItemAtDoesNotPlaceItemWhenPlacedOutsideInventoryGrid()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(11, 1));

            Assert.That(oldItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(11, 1)), Is.False);
        }

        [Test]
        public void TestReplaceItemAtDoesNotPlaceItemOrCrashWithNegativePosition()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(-1, -1));

            Assert.That(oldItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(-1, -1)), Is.False);
        }

        [Test]
        public void TestReplaceItemAtDoesNotPlaceItemOrCrashWithPositionOutsideGrid()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            ItemInInventoryShape oldItem = testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(12, 5));

            Assert.That(oldItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(12, 5)), Is.False);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TwoRingsArePresentAtTopLeft_AddsBowRightOfThem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ring1Shape);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ring2Shape);

            ItemInInventoryShape bowShape = CreateBowShape();

            bool addedBow = testCandidate.AddItemAtNextFreePosition(bowShape);

            Assert.That(addedRing1, Is.True);
            Assert.That(addedRing2, Is.True);
            Assert.That(addedBow, Is.True);

            Assert.That(bowShape.IsAtPosition(new PositionImmutable(1, 0)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TwoRingsArePresentAtTopLeft_AddsOneHandedMaceBelowThem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ring1Shape);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ring2Shape);

            ItemInInventoryShape oneHandedMaceShape = CreateOneHandedMaceShape();

            bool addedOneHandedMace = testCandidate.AddItemAtNextFreePosition(oneHandedMaceShape);

            Assert.That(addedOneHandedMace, Is.True);
            Assert.That(oneHandedMaceShape.IsAtPosition(new PositionImmutable(0, 2)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TwoRingsArePresentAtTopLeft_AddsDaggerBelowThem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ring1Shape);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ring2Shape);

            ItemInInventoryShape daggerShape = CreateDaggerShape();

            bool addedDagger = testCandidate.AddItemAtNextFreePosition(daggerShape);

            Assert.That(addedDagger, Is.True);
            Assert.That(daggerShape.IsAtPosition(new PositionImmutable(0, 2)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TwoRingsArePresentAtTopLeft_AddsBeltBelowThem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ring1Shape);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ring2Shape);

            ItemInInventoryShape beltShape = CreateBeltShape();

            bool addedBelt = testCandidate.AddItemAtNextFreePosition(beltShape);

            Assert.That(addedBelt, Is.True);
            Assert.That(beltShape.IsAtPosition(new PositionImmutable(0, 2)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TwoRingsArePresentAtTopLeft_AddsHelmetBelowThem()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ring1Shape);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ring2Shape);

            ItemInInventoryShape helmetShape = CreateHelmetShape();

            bool addedHelmet = testCandidate.AddItemAtNextFreePosition(helmetShape);

            Assert.That(addedHelmet, Is.True);
            Assert.That(helmetShape.IsAtPosition(new PositionImmutable(0, 2)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TestArrangeVariousItemsCreatesCorrectArrangement()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape daggerShape = CreateDaggerShape();
            ItemInInventoryShape ringShape1 = CreateRingShape();
            ItemInInventoryShape ringShape2 = CreateRingShape();
            ItemInInventoryShape stabbingSwordShape1 = CreateOneHandedStabbingSwordShape();
            ItemInInventoryShape stabbingSwordShape2 = CreateOneHandedStabbingSwordShape();
            ItemInInventoryShape oneHandedMaceShape1 = CreateOneHandedMaceShape();
            ItemInInventoryShape oneHandedMaceShape2 = CreateOneHandedMaceShape();
            ItemInInventoryShape oneHandedMaceShape3 = CreateOneHandedMaceShape();
            ItemInInventoryShape helmShape = CreateHelmetShape();

            testCandidate.ReplaceItemAt(daggerShape, new PositionImmutable(0, 1));
            bool addedStabbingSword1 = testCandidate.AddItemAtNextFreePosition(stabbingSwordShape1);
            bool addedOneHandedMaceOne = testCandidate.AddItemAtNextFreePosition(oneHandedMaceShape1);
            bool addedOneHandedMaceTwo = testCandidate.AddItemAtNextFreePosition(oneHandedMaceShape2);
            bool addedOneHandedMaceThree = testCandidate.AddItemAtNextFreePosition(oneHandedMaceShape3);
            bool addedStabbingSword2 = testCandidate.AddItemAtNextFreePosition(stabbingSwordShape2);
            testCandidate.ReplaceItemAt(ringShape1, new PositionImmutable(0, 4));
            testCandidate.ReplaceItemAt(ringShape2, new PositionImmutable(1, 4));
            bool addedHelm = testCandidate.AddItemAtNextFreePosition(helmShape);

            Assert.That(addedStabbingSword1, Is.True);
            Assert.That(addedOneHandedMaceOne, Is.True);
            Assert.That(addedOneHandedMaceTwo, Is.True);
            Assert.That(addedOneHandedMaceThree, Is.True);
            Assert.That(addedStabbingSword2, Is.True);
            Assert.That(addedHelm, Is.True);

            Assert.That(daggerShape.IsAtPosition(new PositionImmutable(0, 1)), Is.True);
            Assert.That(stabbingSwordShape1.IsAtPosition(new PositionImmutable(1, 0)), Is.True);
            Assert.That(oneHandedMaceShape1.IsAtPosition(new PositionImmutable(2, 0)), Is.True);
            Assert.That(oneHandedMaceShape2.IsAtPosition(new PositionImmutable(4, 0)), Is.True);
            Assert.That(oneHandedMaceShape3.IsAtPosition(new PositionImmutable(6, 0)), Is.True);
            Assert.That(stabbingSwordShape2.IsAtPosition(new PositionImmutable(8, 0)), Is.True);
            Assert.That(ringShape1.IsAtPosition(new PositionImmutable(0, 4)), Is.True);
            Assert.That(ringShape2.IsAtPosition(new PositionImmutable(1, 4)), Is.True);
            Assert.That(helmShape.IsAtPosition(new PositionImmutable(2, 3)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePosition_TestArrangeAlotVariousItemsCreatesCorrectArrangement()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ringShape1 = CreateRingShape();
            ItemInInventoryShape ringShape2 = CreateRingShape();
            ItemInInventoryShape ringShape3 = CreateRingShape();
            ItemInInventoryShape ringShape4 = CreateRingShape();
            ItemInInventoryShape ringShape5 = CreateRingShape();
            ItemInInventoryShape ringShape6 = CreateRingShape();
            ItemInInventoryShape ringShape7 = CreateRingShape();
            ItemInInventoryShape ringShape8 = CreateRingShape();
            ItemInInventoryShape ringShape9 = CreateRingShape();
            ItemInInventoryShape ringShape10 = CreateRingShape();
            ItemInInventoryShape ringShape11 = CreateRingShape();
            ItemInInventoryShape ringShape12 = CreateRingShape();

            ItemInInventoryShape beltShape = CreateBeltShape();
            ItemInInventoryShape daggerShape1 = CreateDaggerShape();
            ItemInInventoryShape daggerShape2 = CreateDaggerShape();
            ItemInInventoryShape oneHandedMaceShape = CreateOneHandedMaceShape();
            ItemInInventoryShape bowShape = CreateBowShape();

            ItemInInventoryShape potionShape = CreatePotionShape();
            ItemInInventoryShape beltShape2 = CreateBeltShape();

            bool addedRing1 = testCandidate.AddItemAtNextFreePosition(ringShape1);
            bool addedRing2 = testCandidate.AddItemAtNextFreePosition(ringShape2);
            bool addedRing3 = testCandidate.AddItemAtNextFreePosition(ringShape3);
            bool addedRing4 = testCandidate.AddItemAtNextFreePosition(ringShape4);
            bool addedDagger1 = testCandidate.AddItemAtNextFreePosition(daggerShape1);
            testCandidate.ReplaceItemAt(ringShape5, new PositionImmutable(2, 0));
            testCandidate.ReplaceItemAt(ringShape6, new PositionImmutable(2, 3));
            bool addedDagger2 = testCandidate.AddItemAtNextFreePosition(daggerShape2);
            testCandidate.ReplaceItemAt(ringShape7, new PositionImmutable(3, 4));
            testCandidate.ReplaceItemAt(beltShape, new PositionImmutable(4, 0));
            testCandidate.ReplaceItemAt(ringShape8, new PositionImmutable(4, 1));
            testCandidate.ReplaceItemAt(ringShape9, new PositionImmutable(5, 1));
            bool addedMace = testCandidate.AddItemAtNextFreePosition(oneHandedMaceShape);
            testCandidate.ReplaceItemAt(ringShape10, new PositionImmutable(6, 1));
            testCandidate.ReplaceItemAt(ringShape11, new PositionImmutable(6, 2));
            testCandidate.ReplaceItemAt(ringShape12, new PositionImmutable(6, 3));
            bool addedBow = testCandidate.AddItemAtNextFreePosition(bowShape);
            bool addedPotion = testCandidate.AddItemAtNextFreePosition(potionShape);
            bool addedBelt2 = testCandidate.AddItemAtNextFreePosition(beltShape2);

            Assert.That(addedRing1, Is.True);
            Assert.That(addedRing2, Is.True);
            Assert.That(addedRing3, Is.True);
            Assert.That(addedRing4, Is.True);
            Assert.That(addedDagger1, Is.True);
            Assert.That(addedDagger2, Is.True);
            Assert.That(addedMace, Is.True);
            Assert.That(addedBow, Is.True);
            Assert.That(addedPotion, Is.True);
            Assert.That(addedBelt2, Is.True);

            Assert.That(ringShape1.IsAtPosition(new PositionImmutable(0, 0)), Is.True);
            Assert.That(ringShape2.IsAtPosition(new PositionImmutable(0, 1)), Is.True);
            Assert.That(ringShape3.IsAtPosition(new PositionImmutable(0, 2)), Is.True);
            Assert.That(ringShape4.IsAtPosition(new PositionImmutable(0, 3)), Is.True);
            Assert.That(daggerShape1.IsAtPosition(new PositionImmutable(1, 0)), Is.True);
            Assert.That(ringShape5.IsAtPosition(new PositionImmutable(2, 0)), Is.True);
            Assert.That(ringShape6.IsAtPosition(new PositionImmutable(2, 3)), Is.True);
            Assert.That(daggerShape2.IsAtPosition(new PositionImmutable(3, 0)), Is.True);
            Assert.That(ringShape7.IsAtPosition(new PositionImmutable(3, 4)), Is.True);
            Assert.That(beltShape.IsAtPosition(new PositionImmutable(4, 0)), Is.True);
            Assert.That(ringShape8.IsAtPosition(new PositionImmutable(4, 1)), Is.True);
            Assert.That(ringShape9.IsAtPosition(new PositionImmutable(5, 1)), Is.True);
            Assert.That(oneHandedMaceShape.IsAtPosition(new PositionImmutable(4, 2)), Is.True);
            Assert.That(ringShape10.IsAtPosition(new PositionImmutable(6, 1)), Is.True);
            Assert.That(ringShape11.IsAtPosition(new PositionImmutable(6, 2)), Is.True);
            Assert.That(ringShape12.IsAtPosition(new PositionImmutable(6, 3)), Is.True);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(7, 0)), Is.True);
            Assert.That(potionShape.IsAtPosition(new PositionImmutable(1, 3)), Is.True);
            Assert.That(beltShape2.IsAtPosition(new PositionImmutable(6, 4)), Is.True);
        }

        [Test]
        public void TestRemoveItemAtRemovesItemFromInventory()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            testCandidate.ReplaceItemAt(bowShape, new PositionImmutable(10, 1));

            ItemInInventoryShape removedItem = testCandidate.RemoveItemAt(new PositionImmutable(11, 3));

            Assert.That(removedItem, Is.EqualTo(bowShape));
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(10, 1)), Is.False);
        }

        [Test]
        public void TestRemoveItemAtReturnsNullWhenNoItemAtPosition()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape bowShape = CreateBowShape();

            testCandidate.AddItemAtNextFreePosition(bowShape);

            ItemInInventoryShape removedItem = testCandidate.RemoveItemAt(new PositionImmutable(11, 3));

            Assert.That(removedItem, Is.Null);
            Assert.That(bowShape.IsAtPosition(new PositionImmutable(0, 0)), Is.True);
        }

        [Test]
        public void TestAddItemAtNextFreePositionAddsItemsToItemList()
        {
            ItemInventory testCandidate = new ItemInventory();

            ItemInInventoryShape ring1Shape = CreateRingShape();
            ItemInInventoryShape ring2Shape = CreateRingShape();
            ItemInInventoryShape potionShape = CreatePotionShape();
            ItemInInventoryShape helmShape = CreateHelmetShape();

            testCandidate.AddItemAtNextFreePosition(ring1Shape);
            testCandidate.AddItemAtNextFreePosition(ring2Shape);
            testCandidate.AddItemAtNextFreePosition(potionShape);
            testCandidate.AddItemAtNextFreePosition(helmShape);

            List<ItemInInventoryShape> result = testCandidate.GetItems();

            Assert.That(result, Has.Count.EqualTo(4));
            Assert.That(result, Has.Member(ring1Shape));
            Assert.That(result, Has.Member(ring2Shape));
            Assert.That(result, Has.Member(potionShape));
            Assert.That(result, Has.Member(helmShape));
        }

        private ItemInInventoryShape CreateBowShape()
        {
            Weapon.Builder bowBuilder = new Weapon.Builder();
            bowBuilder.SetItemClass(ItemClass.BOW);

            Weapon bow = bowBuilder.Build();

            return bow.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateRingShape()
        {
            Jewelry.Builder ringBuilder = new Jewelry.Builder();
            ringBuilder.SetItemClass(ItemClass.RING);

            Jewelry ring = ringBuilder.Build();

            return ring.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateBeltShape()
        {
            Jewelry.Builder beltBuilder = new Jewelry.Builder();
            beltBuilder.SetItemClass(ItemClass.BELT);

            Jewelry belt = beltBuilder.Build();

            return belt.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateHelmetShape()
        {
            Armor.Builder helmetBuilder = new Armor.Builder();
            helmetBuilder.SetItemClass(ItemClass.HEAD_GEAR);

            Armor helmet = helmetBuilder.Build();

            return helmet.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateDaggerShape()
        {
            Weapon.Builder daggerBuilder = new Weapon.Builder();
            daggerBuilder.SetItemClass(ItemClass.DAGGER);

            Weapon dagger = daggerBuilder.Build();

            return dagger.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateOneHandedMaceShape()
        {
            Weapon.Builder maceBuilder = new Weapon.Builder();
            maceBuilder.SetItemClass(ItemClass.ONE_HANDED_MACE);

            Weapon mace = maceBuilder.Build();

            return mace.CreateInventoryShape();
        }

        private ItemInInventoryShape CreateOneHandedStabbingSwordShape()
        {
            Weapon.Builder swordBuilder = new Weapon.Builder();
            swordBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            Weapon sword = swordBuilder.Build();

            return sword.CreateInventoryShape();
        }

        private ItemInInventoryShape CreatePotionShape()
        {
            RecoveryPotion.Builder potionBuilder = new RecoveryPotion.Builder();
            potionBuilder.SetItemClass(ItemClass.LIFE_POTION);

            RecoveryPotion potion = potionBuilder.Build();

            return potion.CreateInventoryShape();
        }
    }
}