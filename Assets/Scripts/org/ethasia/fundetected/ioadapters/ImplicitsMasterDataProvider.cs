using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ImplicitsMasterDataProvider
    {
        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateIncPhysicalDamagePercentWarBelt()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(12)
                .SetMaxValue(24)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusGlobalPhysicalDamageIncrease)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateIncArmorPercentIronAmulet()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(5)
                .SetMaxValue(6)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusGlobalArmorIncrease)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateIncPhysicalDamageWithAttacksPercentDiamondBand()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(3)
                .SetMaxValue(4)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusPhysicalDamageWithAttacksIncrease)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreatePlusAllElementalResistancesTatteredClothHood()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(1)
                .SetMaxValue(2)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusAllElementalResistances)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreatePlusAllElementalResistancesTatteredWizardRobe()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(2)
                .SetMaxValue(3)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusAllElementalResistances)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreatePlusStrengthWeaponsBelt()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(25)
                .SetMaxValue(35)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusStrength)
                .Build();
        }

        public AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement CreatePlusGlobalMinMaxDamageToAttacksIronspikeBand()
        {
            return new AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement.Builder()
                .SetLowerBoundMinValue(1)
                .SetLowerBoundMaxValue(1)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(4)
                .SetUpperBoundMaxValue(4)
                .SetUpperBoundIncrement(1)
                .SetAffixClass(AffixClasses.PlusGlobalMinMaxDamageToAttacks)
                .Build();
        }
    }
}
