using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ArmorMasterDataProvider
    {
        private ImplicitsMasterDataProvider implicitsMasterDataProvider;
        private Dictionary<string, Func<ArmorMasterData>> factoriesByUniqueId;

        public ArmorMasterDataProvider()
        {
            implicitsMasterDataProvider = new ImplicitsMasterDataProvider();

            factoriesByUniqueId = new Dictionary<string, Func<ArmorMasterData>>
            {
                { "Masterdata/Item/Equipment/Armor/HeadGear/CorrodedCap", GetCorrodedCapMasterData },
                { "Masterdata/Item/Equipment/Armor/HeadGear/TatteredLeatherCap", GetTatteredLeatherCapMasterData },
                { "Masterdata/Item/Equipment/Armor/HeadGear/TatteredClothHood", GetTatteredClothHoodMasterData },
                { "Masterdata/Item/Equipment/Armor/HeadGear/CorrodedLombardHelmet", GetCorrodedLombardHelmet },
                { "Masterdata/Item/Equipment/Armor/BodyArmor/CorrodedPlateArmor", GetCorrodedPlateArmorMasterData },
                { "Masterdata/Item/Equipment/Armor/BodyArmor/TatteredLeatherArmor", GetTatteredLeatherArmorMasterData },
                { "Masterdata/Item/Equipment/Armor/BodyArmor/TatteredWizardRobe", GetTatteredWizardRobeMasterData },
                { "Masterdata/Item/Equipment/Armor/BodyArmor/CorrodedLamellarArmor", GetCorrodedLamellarArmorMasterData }
            };
        }

        public ArmorMasterData GetMasterDataByUniqueId(string uniqueId)
        {
            return factoriesByUniqueId.TryGetValue(uniqueId, out Func<ArmorMasterData> factory) ? factory() : null;
        }

        public ArmorMasterData GetCorrodedCapMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Corroded Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(9)
                .SetArmorValue(11);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/HeadGear/CorrodedCap");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public ArmorMasterData GetTatteredLeatherCapMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Tattered Leather Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(6)
                .SetArmorValue(8)
                .SetMovementSpeedAddend(3);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/HeadGear/TatteredLeatherCap");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            return builder.Build();
        }

        public ArmorMasterData GetTatteredClothHoodMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Tattered Cloth Hood")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(3)
                .SetArmorValue(4)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusAllElementalResistancesTatteredClothHood());

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/HeadGear/TatteredClothHood");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
            
            return builder.Build();
        }

        public ArmorMasterData GetCorrodedLombardHelmet()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Corroded Lombard Helmet")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(7)
                .SetArmorValue(9)
                .SetMovementSpeedAddend(1);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/HeadGear/CorrodedLombardHelmet");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
            
            return builder.Build();
        }

        public ArmorMasterData GetCorrodedPlateArmorMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Corroded Plate Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(12)
                .SetArmorValue(23);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/BodyArmor/CorrodedPlateArmor");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
                
            return builder.Build();
        }

        public ArmorMasterData GetTatteredLeatherArmorMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Tattered Leather Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetArmorValue(15)
                .SetMovementSpeedAddend(6);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/BodyArmor/TatteredLeatherArmor");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
                
            return builder.Build();
        }

        public ArmorMasterData GetTatteredWizardRobeMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Tattered Wizard Robe")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(4)
                .SetArmorValue(8)
                .SetFirstImplicit(implicitsMasterDataProvider.CreatePlusAllElementalResistancesTatteredWizardRobe());

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/BodyArmor/TatteredWizardRobe");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
                
            return builder.Build();
        }

        public ArmorMasterData GetCorrodedLamellarArmorMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Corroded Lamellar Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(10)
                .SetArmorValue(19)
                .SetMovementSpeedAddend(3);

            builder.SetUniqueId("Masterdata/Item/Equipment/Armor/BodyArmor/CorrodedLamellarArmor");
            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
                
            return builder.Build();
        }                                       
    }
}