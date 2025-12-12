using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JewelryMasterDataProvider
    {
        private ImplicitsMasterDataProvider implicitsMasterDataProvider;

        public JewelryMasterDataProvider()
        {
            implicitsMasterDataProvider = new ImplicitsMasterDataProvider();
        }

        public JewelryMasterData GetWeaponsBeltMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusStrengthWeaponsBelt());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public JewelryMasterData GetWarBeltMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("War Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(2)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncPhysicalDamagePercentWarBelt());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(2);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        }

        public JewelryMasterData GetDiamondBandMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Diamond Band")
                .SetItemClass(ItemClass.RING)
                .SetMinimumItemLevel(5)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncPhysicalDamageWithAttacksPercentDiamondBand());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        }

        public JewelryMasterData GetIronAmuletMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Iron Amulet")
                .SetItemClass(ItemClass.AMULET)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncArmorPercentIronAmulet());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        }        

        public JewelryMasterData GetIronspikeBandMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Ironspike Band")
                .SetItemClass(ItemClass.RING)
                .SetMinimumItemLevel(1)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusGlobalMinMaxDamageToAttacksIronspikeBand());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        } 
    }
}