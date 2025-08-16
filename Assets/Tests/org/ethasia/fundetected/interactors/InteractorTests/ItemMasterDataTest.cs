using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
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

            Armor.Builder expectedArmorBuilder = new Armor.Builder()
                .SetArmorValue(8);

            Equipment.Builder expectedEquipmentBuilder = expectedArmorBuilder
                .SetStrengthRequirement(4)
                .SetFirstImplicit(CreatePlusAllElementalResistancesRollableAffix());

            Item.Builder expectedItemBuilder = expectedEquipmentBuilder
                .SetName("Tattered Wizard Robe")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1);

            Armor expected = expectedArmorBuilder.Build();

            // Act
            Item item = testCandidate.ToItem();

            // Assert
            EqualItemComparisonVisitor visitor = new EqualItemComparisonVisitor();
            item.Accept(visitor);

            visitor.AssertExtractedArmorIsEqualTo(expected);
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

        private RollableEquipmentAffix CreatePlusAllElementalResistancesRollableAffix()
        {
            return new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusAllElementalResistancesAffix(0))
                .SetMinValue(2)
                .SetMaxValue(3)
                .SetIncrement(1)
                .Build();
        }
    }
}