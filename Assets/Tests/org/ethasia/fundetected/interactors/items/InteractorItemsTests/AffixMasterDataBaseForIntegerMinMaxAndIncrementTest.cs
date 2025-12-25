using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class AffixMasterDataBaseForIntegerMinMaxAndIncrementTest
    {
        [Test]
        public void TestToRollableEquipmentAffix_CreatesCorrectAffixInstance()
        {
            AffixMasterDataBaseForIntegerMinMaxAndIncrement masterData = 
                new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                    .SetMinValue(10)
                    .SetMaxValue(50)
                    .SetIncrement(5)
                    .SetAffixClass(AffixClasses.PlusGlobalArmorIncrease)
                    .Build();

            var result = masterData.ToRollableEquipmentAffix();
            var expected = new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetMinValue(10)
                .SetMaxValue(50)
                .SetIncrement(5)
                .SetRerolledAffix(new IncreasedGlobalArmourAffix(0))
                .Build();

            Assert.That(result.Equals(expected), Is.True);
        }
    }
}