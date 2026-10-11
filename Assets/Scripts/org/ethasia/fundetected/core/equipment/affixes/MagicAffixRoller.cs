using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class MagicAffixRoller
    {
        private readonly IRandomNumberGenerator random;

        public MagicAffixRoller()
        {
            random = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
        }

        public void RollMagicAffixes(
            Equipment equipment,
            AffixRollCalculationTableMasterData prefixTable,
            AffixRollCalculationTableMasterData suffixTable)
        {
            if (RollOnlyOneAffix())
            {
                List<AffixRollCalculationTableEntryMasterData> combinedAffixPool = GetEligibleEntries(equipment, prefixTable);
                combinedAffixPool.AddRange(GetEligibleEntries(equipment, suffixTable));

                RollAndAdd(equipment, combinedAffixPool);

                return;
            }

            RollAndAdd(equipment, GetEligibleEntries(equipment, prefixTable));
            RollAndAdd(equipment, GetEligibleEntries(equipment, suffixTable));
        }

        private bool RollOnlyOneAffix()
        {
            return random.CheckProbabilityIsHit(0.5f);
        }

        private List<AffixRollCalculationTableEntryMasterData> GetEligibleEntries(
            Equipment equipment,
            AffixRollCalculationTableMasterData affixTable)
        {
            List<AffixRollCalculationTableEntryMasterData> result = new List<AffixRollCalculationTableEntryMasterData>();

            foreach (AffixRollCalculationTableEntryMasterData affix in affixTable.RollableAffixes)
            {
                if (affix.MinItemLevel <= equipment.ItemLevel)
                {
                    result.Add(affix);
                }
            }

            return result;
        }

        private void RollAndAdd(Equipment equipment, List<AffixRollCalculationTableEntryMasterData> affixPool)
        {
            int totalWeight = 0;

            foreach (AffixRollCalculationTableEntryMasterData affix in affixPool)
            {
                totalWeight += affix.Weighting;
            }

            if (totalWeight <= 0)
            {
                return;
            }

            int roll = random.GenerateRandomPositiveInteger(totalWeight - 1);

            foreach (AffixRollCalculationTableEntryMasterData affix in affixPool)
            {
                roll -= affix.Weighting;

                if (roll < 0)
                {
                    RollableEquipmentAffix rollableAffix = affix.RollableAffix.Clone();
                    rollableAffix.RerollAffix();
                    equipment.TryAddAffix(rollableAffix.RerolledAffix);

                    return;
                }
            }
        }
    }
}