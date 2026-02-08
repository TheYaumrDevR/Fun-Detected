using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
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
            return new InventoryPresentationContext(CreateEquipmentSlotsPresentationContext(extractor), CreateInventoryGridPresentationContext(inventoryExtractor));
        }

        private InventoryGridPresentationContext CreateInventoryGridPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor)
        {
            InventoryGridPresentationContext result = new InventoryGridPresentationContext();

            ConvertWeaponsToPresentationContext(inventoryExtractor, result);
            ConvertArmorsToPresentationContext(inventoryExtractor, result);
            ConvertJewelryToPresentationContext(inventoryExtractor, result);
            ConvertRecoveryPotionsToPresentationContext(inventoryExtractor, result);

            return result;
        }

        private void ConvertWeaponsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var weapon in inventoryExtractor.ExtractedWeapons)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(weapon.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(weapon.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddItemPresentationContext(itemPresentationContextBuilder.Build());
            }
        }

        private void ConvertArmorsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var armor in inventoryExtractor.ExtractedArmors)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(armor.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(armor.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddItemPresentationContext(itemPresentationContextBuilder.Build());
            }
        }

        private void ConvertJewelryToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var jewelry in inventoryExtractor.ExtractedJewelry)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(jewelry.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(jewelry.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddItemPresentationContext(itemPresentationContextBuilder.Build());
            }
        }

        private void ConvertRecoveryPotionsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var recoveryPotion in inventoryExtractor.ExtractedRecoveryPotions)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(recoveryPotion.Item.Name)
                    .WithCanBeEquipped(false);
                ConvertShapeAndPositionToPresentationContext(recoveryPotion.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddItemPresentationContext(itemPresentationContextBuilder.Build());
            }
        }

        private void ConvertShapeAndPositionToPresentationContext(ItemInInventoryShape itemInInventoryShape, InventoryItemPresentationContext.Builder contextBuilder)
        {
            contextBuilder
                .WithTopLeftCornerX(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.X)
                .WithTopLeftCornerY(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.Y)
                .WithDimensionX(itemInInventoryShape.Width)
                .WithDimensionY(itemInInventoryShape.Height);
        }

        private EquipmentSlotsPresentationContext CreateEquipmentSlotsPresentationContext(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            return new EquipmentSlotsPresentationContext.Builder()
                .SetMainHand(ExtractMainHandEquipment(extractor))
                .SetOffHand(ExtractOffHandEquipment(extractor))
                .SetLeftRing(ExtractLeftRingEquipment(extractor))
                .SetRightRing(ExtractRightRingEquipment(extractor))
                .SetBelt(ExtractBeltEquipment(extractor))
                .Build();
        }

        private EquipmentSlotPresentationContext ExtractMainHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractMainHandEquipment();

            return ExtractWeapon(extractor);
        }

        private EquipmentSlotPresentationContext ExtractOffHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractOffHandEquipment();

            return ExtractWeapon(extractor);
        }

        private EquipmentSlotPresentationContext ExtractWeapon(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            Weapon extractedWeapon = extractor.ExtractedWeapon;

            if (null != extractedWeapon)
            {
                return new EquipmentSlotPresentationContext.Builder()
                    .SetItemId(extractedWeapon.Name)
                    .SetIsLegallyEquipped(true)
                    .Build();
            }

            return EquipmentSlotPresentationContext.CreateEmpty();            
        }

        private EquipmentSlotPresentationContext ExtractLeftRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractLeftRingEquipment();

            return ExtractJewelry(extractor);
        }

        private EquipmentSlotPresentationContext ExtractRightRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractRightRingEquipment();

            return ExtractJewelry(extractor);
        }

        private EquipmentSlotPresentationContext ExtractBeltEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractBeltEquipment();

            return ExtractJewelry(extractor);
        }

        private EquipmentSlotPresentationContext ExtractJewelry(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            Jewelry extractedJewelry = extractor.ExtractedJewelry;

            if (null != extractedJewelry)
            {
                return new EquipmentSlotPresentationContext.Builder()
                    .SetItemId(extractedJewelry.Name)
                    .SetIsLegallyEquipped(true)
                    .Build();
            }

            return EquipmentSlotPresentationContext.CreateEmpty();
        }
    }
}