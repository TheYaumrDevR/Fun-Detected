using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JewelryMasterDataProvider
    {
        private ImplicitsMasterDataProvider implicitsMasterDataProvider;
        private Dictionary<string, Func<JewelryMasterData>> factoriesByUniqueId;

        public JewelryMasterDataProvider()
        {
            implicitsMasterDataProvider = new ImplicitsMasterDataProvider();

            factoriesByUniqueId = new Dictionary<string, Func<JewelryMasterData>>
            {
                { "Masterdata/Item/Equipment/Jewelry/Belt/WeaponsBelt", GetWeaponsBeltMasterData },
                { "Masterdata/Item/Equipment/Jewelry/Belt/WarBelt", GetWarBeltMasterData },
                { "Masterdata/Item/Equipment/Jewelry/Ring/DiamondBand", GetDiamondBandMasterData },
                { "Masterdata/Item/Equipment/Jewelry/Amulet/IronAmulet", GetIronAmuletMasterData },
                { "Masterdata/Item/Equipment/Jewelry/Ring/IronspikeBand", GetIronspikeBandMasterData }
            };
        }

        public JewelryMasterData GetMasterDataByUniqueId(string uniqueId)
        {
            return factoriesByUniqueId.TryGetValue(uniqueId, out Func<JewelryMasterData> factory) ? factory() : null;
        }

        public JewelryMasterData GetWeaponsBeltMasterData()
        {
            JewelryMasterData.Builder builder = new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(10)
                .SetMaterial(ItemMaterials.LEATHER_ARMOR)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusStrengthWeaponsBelt());

            builder.SetUniqueId("Masterdata/Item/Equipment/Jewelry/Belt/WeaponsBelt");
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
                .SetMaterial(ItemMaterials.LEATHER_ARMOR)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncPhysicalDamagePercentWarBelt());

            builder.SetUniqueId("Masterdata/Item/Equipment/Jewelry/Belt/WarBelt");
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

            builder.SetUniqueId("Masterdata/Item/Equipment/Jewelry/Ring/DiamondBand");
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

            builder.SetUniqueId("Masterdata/Item/Equipment/Jewelry/Amulet/IronAmulet");
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

            builder.SetUniqueId("Masterdata/Item/Equipment/Jewelry/Ring/IronspikeBand");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(3);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(3);

            return builder.Build();
        } 
    }
}