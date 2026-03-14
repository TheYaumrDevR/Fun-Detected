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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(weapon.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(weapon.ItemInInventoryShape, itemPresentationContextBuilder);

                WeaponPresentationContext weaponPresentationContext = new WeaponPresentationContext.Builder()
                    .WithMinToMaxPhysicalDamage(weapon.Item.MinToMaxPhysicalDamage)
                    .WithMinToMaxSpellDamage(weapon.Item.MinToMaxSpellDamage)
                    .WithSkillsPerSecond(weapon.Item.SkillsPerSecond)
                    .WithCriticalStrikeChance(weapon.Item.CriticalStrikeChance)
                    .Build();

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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(armor.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(armor.ItemInInventoryShape, itemPresentationContextBuilder);

                ArmorPresentationContext armorPresentationContext = new ArmorPresentationContext.Builder()
                    .WithArmorValue(armor.Item.ArmorValue)
                    .WithMovementSpeedAddend(armor.Item.MovementSpeedAddend)
                    .Build();

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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(jewelry.Item.Name)
                    .WithCanBeEquipped(true);
                ConvertShapeAndPositionToPresentationContext(jewelry.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddJewelryPresentationContext(itemPresentationContextBuilder.Build());
            }

            return presentationContext;
        }

        private InventoryGridPresentationContext ConvertRecoveryPotionsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var recoveryPotion in inventoryExtractor.ExtractedRecoveryPotions)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = new InventoryItemPresentationContext.Builder()
                    .WithItemId(recoveryPotion.Item.Name)
                    .WithCanBeEquipped(false);
                ConvertShapeAndPositionToPresentationContext(recoveryPotion.ItemInInventoryShape, itemPresentationContextBuilder);

                RecoveryPotionPresentationContext recoveryPotionPresentationContext = new RecoveryPotionPresentationContext.Builder()
                    .WithUses(recoveryPotion.Item.Uses)
                    .WithRecoveryAmount(recoveryPotion.Item.RecoveryAmount)
                    .Build();

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

            slotsBuilder.AddEquippedWeapon(ExtractWeapon(extractor, EquipmentSlotPositions.MAIN_HAND));
        }

        private void ExtractOffHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractOffHandEquipment();

            slotsBuilder.AddEquippedWeapon(ExtractWeapon(extractor, EquipmentSlotPositions.OFF_HAND));
        }

        private void ExtractLeftRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractLeftRingEquipment();

            slotsBuilder.AddEquippedJewelry(ExtractJewelry(extractor, EquipmentSlotPositions.LEFT_RING));
        }

        private void ExtractRightRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractRightRingEquipment();

            slotsBuilder.AddEquippedJewelry(ExtractJewelry(extractor, EquipmentSlotPositions.RIGHT_RING));
        }

        private void ExtractBeltEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractBeltEquipment();

            slotsBuilder.AddEquippedJewelry(ExtractJewelry(extractor, EquipmentSlotPositions.BELT));
        }

        private EquippedWeaponPresentationContext ExtractWeapon(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotPositions slotPosition)
        {
            Weapon extractedWeapon = extractor.ExtractedWeapon;

            if (null != extractedWeapon)
            {
                InventoryItemPresentationContext itemContext = new InventoryItemPresentationContext.Builder()
                    .WithItemId(extractedWeapon.Name)
                    .WithCanBeEquipped(true)
                    .Build();

                WeaponPresentationContext weaponContext = new WeaponPresentationContext.Builder()
                    .WithMinToMaxPhysicalDamage(extractedWeapon.MinToMaxPhysicalDamage)
                    .WithMinToMaxSpellDamage(extractedWeapon.MinToMaxSpellDamage)
                    .WithSkillsPerSecond(extractedWeapon.SkillsPerSecond)
                    .WithCriticalStrikeChance(extractedWeapon.CriticalStrikeChance)
                    .Build();

                return new EquippedWeaponPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .WithWeaponPresentationContext(weaponContext)
                    .Build();
            }

            return EquippedWeaponPresentationContext.CreateEmpty();            
        }

        private EquippedJewelryPresentationContext ExtractJewelry(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotPositions slotPosition)
        {
            Jewelry extractedJewelry = extractor.ExtractedJewelry;

            if (null != extractedJewelry)
            {
                InventoryItemPresentationContext itemContext = new InventoryItemPresentationContext.Builder()
                    .WithItemId(extractedJewelry.Name)
                    .WithCanBeEquipped(true)
                    .Build();

                return new EquippedJewelryPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .Build();
            }

            return EquippedJewelryPresentationContext.CreateEmpty();
        }
    }
}