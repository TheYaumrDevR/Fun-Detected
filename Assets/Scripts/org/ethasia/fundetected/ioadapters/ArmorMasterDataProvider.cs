using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ArmorMasterDataProvider
    {
        public ArmorMasterData GetCorrodedCapMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Corroded Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetStrengthRequirement(9)
                .SetArmorValue(11)
                .Build();
        }

        public ArmorMasterData GetTatteredLeatherCapMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Leather Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetStrengthRequirement(6)
                .SetArmorValue(8)
                .SetMovementSpeedAddend(3)
                .Build();
        }  

        public ArmorMasterData GetTatteredClothCapMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Cloth Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetStrengthRequirement(3)
                .SetArmorValue(4)
                .Build();
        }               
    }
}