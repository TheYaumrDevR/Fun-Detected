using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JewelryMasterDataProvider
    {
        public JewelryMasterData GetWeaponsBeltMasterData()
        {
            return new JewelryMasterData.Builder()
                .SetName("Weapons Belt")
                .SetItemClass(ItemClass.BELT)
                .SetFirstImplicit(new PlusStrengthAffix(30))
                .Build();
        }
    }
}