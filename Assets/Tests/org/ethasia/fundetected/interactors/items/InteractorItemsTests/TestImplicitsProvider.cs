namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class TestImplicitsProvider
    {
        public static AffixMasterDataBaseForIntegerMinMaxAndIncrement CreatePlusStrengthWeaponsBelt()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(25)
                .SetMaxValue(35)
                .SetIncrement(1)
                .SetAffixClass(AffixClasses.PlusStrength)
                .Build();
        }

        public static AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement CreatePlusGlobalMinMaxDamageToAttacksIronspikeBand()
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

        public static AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateIncArmorPercentIronAmulet()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(5)
                .SetMaxValue(6)
                .SetIncrement(1)
                .SetAffixClass(AffixClasses.PlusGlobalArmorIncrease)
                .Build();
        }
    }
}