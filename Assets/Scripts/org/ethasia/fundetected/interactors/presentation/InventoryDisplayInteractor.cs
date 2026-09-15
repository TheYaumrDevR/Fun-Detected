using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public class InventoryDisplayInteractor
    {
        public virtual void ExtractAndShowInventory()
        {
            Area currentMap = Area.ActiveArea;

            if (null != currentMap)
            {
                PlayerCharacter player = currentMap.Player;

                if (null != player)
                {
                    PlayerEquipmentItemsExtractionVisitor equipmentItemsExtractionVisitor = player.CreateItemExtractionVisitor();
                    ItemInventoryExtractionVisitor inventoryExtractionVisitor = player.CreateInventoryItemExtractionVisitor();

                    InventoryPresentationContext inventoryPresentationContext = CreateInventoryPresentationContext(equipmentItemsExtractionVisitor, inventoryExtractionVisitor);

                    IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
                    guiWindowsPresenter.OpenInventoryWindow(inventoryPresentationContext);
                }
            }
        }

        protected InventoryPresentationContext CreateInventoryPresentationContext(PlayerEquipmentItemsExtractionVisitor extractor, ItemInventoryExtractionVisitor inventoryExtractor)
        {
            return new InventoryPresentationContext(CreateEquipmentSlotsPresentationContext(extractor), InventoryToPresentationContextConverter.Convert(inventoryExtractor));
        }

        private EquipmentSlotsPresentationContext CreateEquipmentSlotsPresentationContext(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            EquipmentSlotsPresentationContext.Builder builder = new EquipmentSlotsPresentationContext.Builder();

            ExtractMainHandEquipment(extractor, builder);
            ExtractOffHandEquipment(extractor, builder);
            ExtractLeftRingEquipment(extractor, builder);
            ExtractRightRingEquipment(extractor, builder);
            ExtractBeltEquipment(extractor, builder);

            return builder.Build();
        }

        private void ExtractMainHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractMainHandEquipment();

            EquippedWeaponPresentationContext? weaponContext = ItemToPresentationContextConverter.ConvertWeaponToEquipmentContext(extractor.ExtractedWeapon, EquipmentSlotPositions.MAIN_HAND);
            if (weaponContext != null)
            {
                slotsBuilder.AddEquippedWeapon(weaponContext.Value);
            }
        }

        private void ExtractOffHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractOffHandEquipment();

            EquippedWeaponPresentationContext? offHandWeaponContext = ItemToPresentationContextConverter.ConvertWeaponToEquipmentContext(extractor.ExtractedWeapon, EquipmentSlotPositions.OFF_HAND);
            if (offHandWeaponContext != null)
            {
                slotsBuilder.AddEquippedWeapon(offHandWeaponContext.Value);
            }
        }

        private void ExtractLeftRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractLeftRingEquipment();

            EquippedJewelryPresentationContext? leftRingContext = ItemToPresentationContextConverter.ConvertJewelryToEquipmentContext(extractor.ExtractedJewelry, EquipmentSlotPositions.LEFT_RING);
            if (leftRingContext != null)
            {
                slotsBuilder.AddEquippedJewelry(leftRingContext.Value);
            }
        }

        private void ExtractRightRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractRightRingEquipment();

            EquippedJewelryPresentationContext? rightRingContext = ItemToPresentationContextConverter.ConvertJewelryToEquipmentContext(extractor.ExtractedJewelry, EquipmentSlotPositions.RIGHT_RING);
            if (rightRingContext != null)
            {
                slotsBuilder.AddEquippedJewelry(rightRingContext.Value);
            }
        }

        private void ExtractBeltEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractBeltEquipment();

            EquippedJewelryPresentationContext? beltContext = ItemToPresentationContextConverter.ConvertJewelryToEquipmentContext(extractor.ExtractedJewelry, EquipmentSlotPositions.BELT);
            if (beltContext != null)
            {
                slotsBuilder.AddEquippedJewelry(beltContext.Value);
            }
        }
    }
}