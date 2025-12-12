using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Interactors
{
    public static class AffixClassesExtension
    {
        public static EquipmentAffix ToRollableEquipmentAffix(this AffixClasses affixClass)
        {
            switch (affixClass)
            {
                case AffixClasses.PlusGlobalPhysicalDamageIncrease:
                    return new IncreasedGlobalPhysicalDamageAffix(0);
                case AffixClasses.PlusGlobalArmorIncrease:
                    return new IncreasedGlobalArmourAffix(0);
                case AffixClasses.PlusPhysicalDamageWithAttacksIncrease:
                    return new IncreasedPhysicalDamageWithAttacksAffix(0);
                case AffixClasses.PlusAllElementalResistances:
                    return new PlusAllElementalResistancesAffix(0);
                case AffixClasses.PlusStrength:
                    return new PlusStrengthAffix(0);
                case AffixClasses.PlusGlobalMinMaxDamageToAttacks:
                    return new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0);
                default:
                    throw null;
            }
        }
    }
}
