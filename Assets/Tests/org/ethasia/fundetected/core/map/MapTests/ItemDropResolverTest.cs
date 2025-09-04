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
            IRandomNumberGenerator randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();

            if (null != randomNumberGenerator && randomNumberGenerator is RandomNumberGeneratorMock)
            {
                rngMock = (RandomNumberGeneratorMock)randomNumberGenerator;
            }
            else
            {
                rngMock = new RandomNumberGeneratorMock(new int[] {}, new float[] {}, new double[] {});
                MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
                ioAdaptersFactoryForCore.SetRngInstance(rngMock);
                IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
            }
        }

        [Test]
        public void TestResolveItemDropPicksSecondTableSecondRowThirdItem()
        {
            int[] randomNumbersToGenerate = { 223 };
            float[] randomFloatsToGenerate = {};    
            double[] randomDoublesToGenerate = {0.07, 0.5};

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);

            List<DropTable> testInput = TestDropTableFactory.CreateDropTableWithFourJewelryItems();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput, 100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("Third Item"));
        }

        [Test]
        public void TestResolveItemDropPicksLastRowIfNoOtherHit()
        {
            int[] randomNumbersToGenerate = { 223 };
            float[] randomFloatsToGenerate = { };
            double[] randomDoublesToGenerate = { 0.21, 0.5 };

            rngMock.Reset(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            
            List<DropTable> testInput = TestDropTableFactory.CreateDropTableWithFourJewelryItems();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput, 100);

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
            
            List<DropTable> testInput = TestDropTableFactory.CreateDropTableWithFourJewelryItems();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput, 100);

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
            
            List<DropTable> testInput = TestDropTableFactory.CreateDropTableWithFourJewelryItems();
            DropTableEntry? result = ItemDropResolver.ResolveItemDrop(testInput, 100);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value.Item.Name, Is.EqualTo("Second Item"));               
        }        
    }
}   