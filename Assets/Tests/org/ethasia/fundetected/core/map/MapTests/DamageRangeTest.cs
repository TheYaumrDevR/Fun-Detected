using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class DamageRangeTest
    {
        [Test]
        public void TestNegateNegatesPositiveRange()
        {
            DamageRange damageRange = new DamageRange(41698808, 33118420);

            damageRange.Negate();

            Assert.AreEqual(-41698808, damageRange.MinDamage);
            Assert.AreEqual(-33118420, damageRange.MaxDamage);
        }

        [Test]
        public void TestNegateNegatesNegativeRange()
        {
            DamageRange damageRange = new DamageRange(-41630356, -21180252);

            damageRange.Negate();

            Assert.AreEqual(41630356, damageRange.MinDamage);
            Assert.AreEqual(21180252, damageRange.MaxDamage);
        }


        [Test]
        public void TestAddAddsTwoRanges()
        {
            DamageRange damageRange = new DamageRange(46319103, 40618403);
            DamageRange otherDamageRange = new DamageRange(56619201, 94629991);

            damageRange.Add(otherDamageRange);

            Assert.AreEqual(102938304, damageRange.MinDamage);
            Assert.AreEqual(135248394, damageRange.MaxDamage);
        }

        [Test]
        public void TestAddAddsTwoRangesWithNegativeValues()
        {
            DamageRange damageRange = new DamageRange(-46319103, 40618403);
            DamageRange otherDamageRange = new DamageRange(56619201, -94629991);

            damageRange.Add(otherDamageRange);

            Assert.AreEqual(10300098, damageRange.MinDamage);
            Assert.AreEqual(-54011588, damageRange.MaxDamage);
        }

        [Test]
        public void TestAddAddsTwoIntegers()
        {
            DamageRange damageRange = new DamageRange(52863182, 98521777);

            damageRange.Add(26955229, 91584029);

            Assert.AreEqual(79818411, damageRange.MinDamage);
            Assert.AreEqual(190105806, damageRange.MaxDamage);
        }

        [Test]
        public void TestAddAddsNegativeIntegers()
        {
            DamageRange damageRange = new DamageRange(70523689, -94675859);

            damageRange.Add(-53295710, 27931179);

            Assert.AreEqual(17227979, damageRange.MinDamage);
            Assert.AreEqual(-66744680, damageRange.MaxDamage);
        }

        [Test]
        public void TestSubtractSubtractsTwoIntegers()
        {
            DamageRange damageRange = new DamageRange(5883598, 60797162);

            damageRange.Subtract(53171885, 45539980);

            Assert.AreEqual(-47288287, damageRange.MinDamage);
            Assert.AreEqual(15257182, damageRange.MaxDamage);
        }

        [Test]
        public void TestSubtractSubtractsNegativeIntegers()
        {
            DamageRange damageRange = new DamageRange(20705578, -63911743);

            damageRange.Subtract(96606225, 325017);

            Assert.AreEqual(-75900647, damageRange.MinDamage);
            Assert.AreEqual(-64236760, damageRange.MaxDamage);
        }

        [Test]
        public void TestMultiplyMultipliesRangeByFloat()
        {
            DamageRange damageRange = new DamageRange(49591954, 97637234);

            damageRange.Multiply(2.5f);

            Assert.AreEqual(123979880, damageRange.MinDamage);
            Assert.AreEqual(244093080, damageRange.MaxDamage);
        }
    }
}