using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ArmorMasterDataProvider
    {
        public ArmorMasterData GetCorrodedCapMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Corroded Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(9)
                .SetArmorValue(11)
                .Build();
        }

        public ArmorMasterData GetTatteredLeatherCapMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Leather Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(6)
                .SetArmorValue(8)
                .SetMovementSpeedAddend(3)
                .Build();
        }  

        public ArmorMasterData GetTatteredClothHoodMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Cloth Hood")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(3)
                .SetArmorValue(4)
                .SetFirstImplicit(new PlusAllElementalResistancesAffix(1))
                .Build();
        }   

        public ArmorMasterData GetCorrodedLombardHelmet()
        {
            return new ArmorMasterData.Builder()
                .SetName("Corroded Lombard Helmet")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(7)
                .SetArmorValue(9)
                .SetMovementSpeedAddend(1)
                .Build();
        } 

        public ArmorMasterData GetCorrodedPlateArmorMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Corroded Plate Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetArmorValue(23)
                .Build();
        } 

        public ArmorMasterData GetTatteredLeatherArmorMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Leather Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetArmorValue(15)
                .SetMovementSpeedAddend(6)
                .Build();
        }    

        public ArmorMasterData GetTatteredWizardRobeMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Tattered Wizard Robe")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(4)
                .SetArmorValue(8)
                .SetFirstImplicit(new PlusAllElementalResistancesAffix(2))
                .Build();
        }  

        public ArmorMasterData GetCorrodedLamellarArmorMasterData()
        {
            return new ArmorMasterData.Builder()
                .SetName("Corroded Lamellar Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(10)
                .SetArmorValue(19)
                .SetMovementSpeedAddend(3)
                .Build();
        }                                       
    }
}