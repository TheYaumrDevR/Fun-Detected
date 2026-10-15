using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class DropTableEntryTest
    {
        [Test]
        public void TestDropItemRerollsImplicits()
        {
            CreateMockIoAdaptersFactoryWithRngMock();

            Armor testItem = CreateTestArmor();
            DropTableEntry testCandidate = new DropTableEntry(1.0f, testItem);

            Armor droppedItem = (Armor)testCandidate.DropItem(1);
            Armor droppedItem2 = (Armor)testCandidate.DropItem(1);
            Armor droppedItem3 = (Armor)testCandidate.DropItem(1);

            TestablePlusAllElementalResistancesAffix result = (TestablePlusAllElementalResistancesAffix)droppedItem.FirstImplicit.RerolledAffix;
            TestablePlusAllElementalResistancesAffix result2 = (TestablePlusAllElementalResistancesAffix)droppedItem2.FirstImplicit.RerolledAffix;
            TestablePlusAllElementalResistancesAffix result3 = (TestablePlusAllElementalResistancesAffix)droppedItem3.FirstImplicit.RerolledAffix;

            Assert.That(result.GetValueForTesting(), Is.EqualTo(11));
            Assert.That(result2.GetValueForTesting(), Is.EqualTo(6));
            Assert.That(result3.GetValueForTesting(), Is.EqualTo(7));
        }

        [Test]
        public void TestDropItemSetsPassedItemLevel()
        {
            CreateMockIoAdaptersFactoryWithRngMock();

            Armor templateItem = CreateTestArmor();
            DropTableEntry testCandidate = new DropTableEntry(1.0f, templateItem);

            Item droppedItem = testCandidate.DropItem(42);

            Assert.That(droppedItem.ItemLevel, Is.EqualTo(42));
            Assert.That(templateItem.ItemLevel, Is.EqualTo(73));
        }        

        private Armor CreateTestArmor()
        {
            Armor.Builder builder = new Armor.Builder();
            builder.SetMovementSpeedAddend(5)
                .SetArmorValue(250);

            IntegerMinMaxIncrementRollableEquipmentAffix firstImplicit = new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new TestablePlusAllElementalResistancesAffix(9))
                .SetMinValue(5)
                .SetMaxValue(15)
                .SetIncrement(1)
                .Build();

            PlusAgilityAffix suffixOne = new PlusAgilityAffix(23);
            IncreasedLocalArmourAffix prefixOne = new IncreasedLocalArmourAffix(10);
            IncreasedMaximumLifeAffix prefixTwo = new IncreasedMaximumLifeAffix(80);

            builder.SetStrengthRequirement(32)
                .SetAgilityRequirement(0)
                .SetIntelligenceRequirement(0)
                .AddAffix(prefixOne)
                .AddAffix(suffixOne)
                .AddAffix(prefixTwo)
                .SetFirstImplicit(firstImplicit);

            builder.SetName("Test Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(62)
                .SetItemLevel(73)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(3)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(3)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(4)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(4);

            return builder.Build();
        }

        private static void CreateMockIoAdaptersFactoryWithRngMock()
        {
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(new int[] { 11, 6, 7 }, new float[] { }, new double[] { });
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);
            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);            
        }

        private class TestablePlusAllElementalResistancesAffix : PlusAllElementalResistancesAffix
        {
            public TestablePlusAllElementalResistancesAffix(int value) : base(value)
            {
            }

            public int GetValueForTesting()
            {
                return Value;
            }

            public override EquipmentAffix Clone()
            {
                TestablePlusAllElementalResistancesAffix copy = new TestablePlusAllElementalResistancesAffix(Value);
                Clone(copy);

                return copy;
            }
        }
    }
}