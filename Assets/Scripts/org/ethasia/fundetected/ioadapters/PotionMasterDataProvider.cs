using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PotionMasterDataProvider
    {
        public RecoveryPotionMasterData GetTinyLifePotionMasterData()
        {
            return new RecoveryPotionMasterData.Builder()
                .SetItemClass(ItemClass.LIFE_POTION)
                .SetMinimumItemLevel(1)
                .SetName("Tiny Life Potion")
                .SetRecoveryAmount(70)
                .SetUses(3)
                .Build();
        }
    }
}