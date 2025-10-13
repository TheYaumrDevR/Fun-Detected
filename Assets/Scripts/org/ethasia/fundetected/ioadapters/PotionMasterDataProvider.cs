using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PotionMasterDataProvider
    {
        public RecoveryPotionMasterData GetTinyLifePotionMasterData()
        {
            RecoveryPotionMasterData.Builder builder = new RecoveryPotionMasterData.Builder()
                .SetItemClass(ItemClass.LIFE_POTION)
                .SetMinimumItemLevel(1)
                .SetName("Tiny Life Potion")
                .SetRecoveryAmount(70)
                .SetUses(3);

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(1);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(2);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(4);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(4);

            return builder.Build();
        }
    }
}