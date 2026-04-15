using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors.Items.Tests
{
    public class TestJewelryProvider
    {
        public static Jewelry CreateBelt()
        {
            return ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(GetWeaponsBeltMasterData());
        }

        public static Jewelry CreateRing()
        {
            return ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(GetIronspikeBandMasterData());
        }

        public static Jewelry CreateAmulet()
        {
            return ItemMasterDataToItemConverter.ConvertJewelryMasterDataToJewelry(GetIronAmuletMasterData());
        }

        private static JewelryMasterData GetWeaponsBeltMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(TestImplicitsProvider.CreatePlusStrengthWeaponsBelt());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        private static JewelryMasterData GetIronspikeBandMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Ironspike Band")
                .SetItemClass(ItemClass.RING)
                .SetMinimumItemLevel(1)
                .SetFirstImplicit(TestImplicitsProvider.CreatePlusGlobalMinMaxDamageToAttacksIronspikeBand());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        }

        private static JewelryMasterData GetIronAmuletMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Iron Amulet")
                .SetItemClass(ItemClass.AMULET)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(TestImplicitsProvider.CreateIncArmorPercentIronAmulet());

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        } 
    }
}