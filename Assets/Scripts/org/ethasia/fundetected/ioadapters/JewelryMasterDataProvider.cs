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
            return new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusStrengthWeaponsBelt())
                .Build();
        }

        public JewelryMasterData GetWarBeltMasterData()
        {
            return new JewelryMasterData.Builder()
                .SetName("War Belt")
                .SetItemClass(ItemClass.BELT)
                .SetMinimumItemLevel(2)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncPhysicalDamagePercentWarBelt())
                .Build();
        }

        public JewelryMasterData GetDiamondBandMasterData()
        {
            return new JewelryMasterData.Builder()
                .SetName("Diamond Band")
                .SetItemClass(ItemClass.RING)
                .SetMinimumItemLevel(5)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncPhysicalDamageWithAttacksPercentDiamondBand())
                .Build();
        }

        public JewelryMasterData GetIronAmuletMasterData()
        {
            return new JewelryMasterData.Builder()
                .SetName("Iron Amulet")
                .SetItemClass(ItemClass.AMULET)
                .SetMinimumItemLevel(10)
                .SetFirstImplicit(implicitsMasterDataProvider.CreateIncArmorPercentIronAmulet())
                .Build();
        }        
    }
}