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
            return new InventoryPresentationContext(CreateEquipmentSlotsPresentationContext(extractor), CreateInventoryGridPresentationContext(inventoryExtractor));
        }

        private InventoryGridPresentationContext CreateInventoryGridPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor)
        {
            InventoryGridPresentationContext result = new InventoryGridPresentationContext();
            inventoryExtractor.ExtractItems();

            result = ConvertWeaponsToPresentationContext(inventoryExtractor, result);
            result = ConvertArmorsToPresentationContext(inventoryExtractor, result);
            result = ConvertJewelryToPresentationContext(inventoryExtractor, result);
            result = ConvertRecoveryPotionsToPresentationContext(inventoryExtractor, result);

            return result;
        }

        private InventoryGridPresentationContext ConvertWeaponsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var weapon in inventoryExtractor.ExtractedWeapons)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ItemToPresentationContextConverter.ConvertItemToPresentationContext(weapon.Item, true);
                itemPresentationContextBuilder.WithAffixes(ItemToPresentationContextConverter.ConvertItemAffixesToPresentationContext(weapon.Item));
                ConvertShapeAndPositionToPresentationContext(weapon.ItemInInventoryShape, itemPresentationContextBuilder);

                WeaponPresentationContext weaponPresentationContext = ItemToPresentationContextConverter.ConvertWeaponToPresentationContext(weapon.Item);

                InventoryWeaponPresentationContext inventoryWeaponPresentationContext = new InventoryWeaponPresentationContext.Builder()
                    .WithWeaponContext(weaponPresentationContext)
                    .WithItemContext(itemPresentationContextBuilder.Build())
                    .Build();

                presentationContext.AddWeaponPresentationContext(inventoryWeaponPresentationContext);
            }

            return presentationContext;
        }

        private InventoryGridPresentationContext ConvertArmorsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var armor in inventoryExtractor.ExtractedArmors)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ItemToPresentationContextConverter.ConvertItemToPresentationContext(armor.Item, true);
                itemPresentationContextBuilder.WithAffixes(ItemToPresentationContextConverter.ConvertItemAffixesToPresentationContext(armor.Item));
                ConvertShapeAndPositionToPresentationContext(armor.ItemInInventoryShape, itemPresentationContextBuilder);

                ArmorPresentationContext armorPresentationContext = ConvertArmorToPresentationContext(armor.Item);

                InventoryArmorPresentationContext inventoryArmorPresentationContext = new InventoryArmorPresentationContext.Builder()
                    .WithArmorContext(armorPresentationContext)
                    .WithItemContext(itemPresentationContextBuilder.Build())
                    .Build();

                presentationContext.AddArmorPresentationContext(inventoryArmorPresentationContext);
            }

            return presentationContext;
        }

        private InventoryGridPresentationContext ConvertJewelryToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var jewelry in inventoryExtractor.ExtractedJewelry)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ItemToPresentationContextConverter.ConvertItemToPresentationContext(jewelry.Item, true);
                itemPresentationContextBuilder.WithAffixes(ItemToPresentationContextConverter.ConvertItemAffixesToPresentationContext(jewelry.Item));
                ConvertShapeAndPositionToPresentationContext(jewelry.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddJewelryPresentationContext(itemPresentationContextBuilder.Build());
            }

            return presentationContext;
        }

        private InventoryGridPresentationContext ConvertRecoveryPotionsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var recoveryPotion in inventoryExtractor.ExtractedRecoveryPotions)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ItemToPresentationContextConverter.ConvertItemToPresentationContext(recoveryPotion.Item, false);
                itemPresentationContextBuilder.WithAffixes(new AffixesPresentationContext(new IAffixPresentationContext[] { }, new IAffixPresentationContext[] { }));
                ConvertShapeAndPositionToPresentationContext(recoveryPotion.ItemInInventoryShape, itemPresentationContextBuilder);

                RecoveryPotionPresentationContext recoveryPotionPresentationContext = ConvertRecoveryPotionToPresentationContext(recoveryPotion.Item);

                InventoryRecoveryPotionPresentationContext inventoryRecoveryPotionPresentationContext = new InventoryRecoveryPotionPresentationContext.Builder()
                    .WithRecoveryPotionContext(recoveryPotionPresentationContext)
                    .WithItemContext(itemPresentationContextBuilder.Build())
                    .Build();
                presentationContext.AddRecoveryPotionPresentationContext(inventoryRecoveryPotionPresentationContext);
            }

            return presentationContext;
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

        private ArmorPresentationContext ConvertArmorToPresentationContext(Armor armor)
        {
            return new ArmorPresentationContext.Builder()
                .WithArmorValue(armor.ArmorValue)
                .WithMovementSpeedAddend(armor.MovementSpeedAddend)
                .Build();
        }

        private RecoveryPotionPresentationContext ConvertRecoveryPotionToPresentationContext(RecoveryPotion recoveryPotion)
        {
            return new RecoveryPotionPresentationContext.Builder()
                .WithUses(recoveryPotion.Uses)
                .WithRecoveryAmount(recoveryPotion.RecoveryAmount)
                .Build();
        }
    }
}