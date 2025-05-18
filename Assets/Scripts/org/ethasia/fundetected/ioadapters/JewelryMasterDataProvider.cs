using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JewelryMasterDataProvider
    {
        public JewelryMasterData GetWeaponsBeltMasterData()
        {
            return new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SteItemClass(ItemClass.BELT)
                .SetFirstImplicit(new PlusStrengthAffix(30))
                .Build();
        }
    }
}