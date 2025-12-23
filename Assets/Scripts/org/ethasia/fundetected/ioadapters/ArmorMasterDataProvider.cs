using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ArmorMasterDataProvider
    {
        private ImplicitsMasterDataProvider implicitsMasterDataProvider;

        public ArmorMasterDataProvider()
        {
            implicitsMasterDataProvider = new ImplicitsMasterDataProvider();
        }

        public ArmorMasterData GetCorrodedCapMasterData()
        {
            ArmorMasterData.Builder builder = new ArmorMasterData.Builder()
                .SetName("Corroded Cap")
                .SetItemClass(ItemClass.HEAD_GEAR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(9)
                .SetArmorValue(11);

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

            builder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToRightEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToTopEdgeFromCenter(0);
            builder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);
                
            return builder.Build();
        }                                       
    }
}