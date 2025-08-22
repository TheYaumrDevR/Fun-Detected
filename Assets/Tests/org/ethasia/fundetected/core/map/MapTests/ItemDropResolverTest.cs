using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class ItemDropResolverTest
    {
        private static RandomNumberGeneratorMock rngMock;

        static ItemDropResolverTest()
        {
            rngMock = new RandomNumberGeneratorMock(new int[] {}, new float[] {}, new double[] {});
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);
            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
        }

        [Test]
        public void TestResolveItemDropPicksSecondTableSecondRowThirdItem()
        {
            int[] randomNumbersToGenerate = { 223, 0 };
            float[] randomFloatsToGenerate = {};    
            double[] randomDoublesToGenerate = {0.07, 0.5};

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);

            List<DropTable> testInput = GetGlobalDropTables();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("Third Item"));
        }

        [Test]
        public void TestResolveItemDropPicksLastRowIfNoOtherHit()
        {
            int[] randomNumbersToGenerate = { 223, 0 };
            float[] randomFloatsToGenerate = { };
            double[] randomDoublesToGenerate = { 0.21, 0.5 };

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            
            List<DropTable> testInput = GetGlobalDropTables();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("First Item Third Row"));            
        }

        [Test]
        public void TestResolveItemDropTriesToFindItemUntilOneIsHit()
        {
            int[] randomNumbersToGenerate = { 223, 0 };
            float[] randomFloatsToGenerate = { };
            double[] randomDoublesToGenerate = { 0.07, 0.8, 0.8, 0.09 };

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            
            List<DropTable> testInput = GetGlobalDropTables();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("First Item"));               
        }

        [Test]
        public void TestResolveItemDropPicksRandomItemWhenMultipleAreHit()
        {
            int[] randomNumbersToGenerate = { 223, 1 };
            float[] randomFloatsToGenerate = { };
            double[] randomDoublesToGenerate = { 0.07, 0.09 };

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            
            List<DropTable> testInput = GetGlobalDropTables();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("Second Item"));               
        }        

        private List<DropTable> GetGlobalDropTables()
        {
            DropTableEntry tableEntry1 = new DropTableEntry(0.1, CreateJewelryWithName("First Item"));
            DropTableEntry tableEntry2 = new DropTableEntry(0.1, CreateJewelryWithName("Second Item"));
            DropTableEntry tableEntry3 = new DropTableEntry(0.7, CreateJewelryWithName("Third Item"));
            DropTableEntry tableEntry4 = new DropTableEntry(0.1, CreateJewelryWithName("Fourth Item"));

            DropTableEntry tableEntry5 = new DropTableEntry(0.6, CreateJewelryWithName("First Item Third Row"));

            DropTableRow row1 = new DropTableRow(0.00001);
            DropTableRow row2 = new DropTableRow(0.1);
            DropTableRow row3 = new DropTableRow(0.2);

            row2.DropTableEntries.Add(tableEntry1);
            row2.DropTableEntries.Add(tableEntry2);
            row2.DropTableEntries.Add(tableEntry3);
            row2.DropTableEntries.Add(tableEntry4);

            row3.DropTableEntries.Add(tableEntry5);

            DropTable dropTable1 = new DropTable(100);
            DropTable dropTable2 = new DropTable(200);

            dropTable2.DropTableRows.Add(row1);
            dropTable2.DropTableRows.Add(row2);
            dropTable2.DropTableRows.Add(row3);

            List<DropTable> result = new List<DropTable>();
            result.Add(dropTable1);
            result.Add(dropTable2);

            return result;
        }

        private Jewelry CreateJewelryWithName(string name)
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetName(name);

            return jewelryBuilder.Build();
        }
    }
}   