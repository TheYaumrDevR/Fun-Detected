using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class ItemMasterDataTest
    {
        [Test]
        public void TestItemMasterDataConvertsToItem()
        {
            // Arrange
            ArmorMasterData testCandidate = new ArmorMasterData.Builder()
                .SetName("Tattered Wizard Robe")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(4)
                .SetArmorValue(8)
                .SetFirstImplicit(CreatePlusAllElementalResistancesTatteredWizardRobe())
                .Build();

            // Act
            Item item = testCandidate.ToItem();

            // Assert

        }

        private AffixMasterDataBaseForIntegerMinMaxAndIncrement CreatePlusAllElementalResistancesTatteredWizardRobe()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(2)
                .SetMaxValue(3)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusAllElementalResistances)
                .Build();
        }
    }
}