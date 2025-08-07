using Org.Ethasia.Fundetected.Interactors;

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
                .SetAffixClasses(AffixClasses.PlusPhysicalDamageIncrease)
                .Build();
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateIncArmorPercentIronAmulet()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(5)
                .SetMaxValue(6)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusArmorIncrease)
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
    }
}
