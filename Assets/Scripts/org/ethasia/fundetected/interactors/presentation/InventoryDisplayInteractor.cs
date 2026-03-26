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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(weapon.Item, true);
                itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(weapon.Item));
                ConvertShapeAndPositionToPresentationContext(weapon.ItemInInventoryShape, itemPresentationContextBuilder);

                WeaponPresentationContext weaponPresentationContext = ConvertWeaponToPresentationContext(weapon.Item);

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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(armor.Item, true);
                itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(armor.Item));
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
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(jewelry.Item, true);
                itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(jewelry.Item));
                ConvertShapeAndPositionToPresentationContext(jewelry.ItemInInventoryShape, itemPresentationContextBuilder);

                presentationContext.AddJewelryPresentationContext(itemPresentationContextBuilder.Build());
            }

            return presentationContext;
        }

        private InventoryGridPresentationContext ConvertRecoveryPotionsToPresentationContext(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var recoveryPotion in inventoryExtractor.ExtractedRecoveryPotions)
            {
                InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(recoveryPotion.Item, false);
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

            EquippedWeaponPresentationContext? weaponContext = ExtractWeapon(extractor, EquipmentSlotPositions.MAIN_HAND);
            if (weaponContext != null)
            {
                slotsBuilder.AddEquippedWeapon(weaponContext.Value);
            }
        }

        private void ExtractOffHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractOffHandEquipment();

            EquippedWeaponPresentationContext? offHandWeaponContext = ExtractWeapon(extractor, EquipmentSlotPositions.OFF_HAND);
            if (offHandWeaponContext != null)
            {
                slotsBuilder.AddEquippedWeapon(offHandWeaponContext.Value);
            }
        }

        private void ExtractLeftRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractLeftRingEquipment();

            EquippedJewelryPresentationContext? leftRingContext = ExtractJewelry(extractor, EquipmentSlotPositions.LEFT_RING);
            if (leftRingContext != null)
            {
                slotsBuilder.AddEquippedJewelry(leftRingContext.Value);
            }
        }

        private void ExtractRightRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractRightRingEquipment();

            EquippedJewelryPresentationContext? rightRingContext = ExtractJewelry(extractor, EquipmentSlotPositions.RIGHT_RING);
            if (rightRingContext != null)
            {
                slotsBuilder.AddEquippedJewelry(rightRingContext.Value);
            }
        }

        private void ExtractBeltEquipment(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotsPresentationContext.Builder slotsBuilder)
        {
            extractor.Reset();
            extractor.ExtractBeltEquipment();

            EquippedJewelryPresentationContext? beltContext = ExtractJewelry(extractor, EquipmentSlotPositions.BELT);
            if (beltContext != null)
            {
                slotsBuilder.AddEquippedJewelry(beltContext.Value);
            }
        }

        private EquippedWeaponPresentationContext? ExtractWeapon(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotPositions slotPosition)
        {
            Weapon extractedWeapon = extractor.ExtractedWeapon;

            if (null != extractedWeapon)
            {
                InventoryItemPresentationContext itemContext = ConvertItemToPresentationContext(extractedWeapon, true)
                    .WithAffixes(ConvertItemAffixesToPresentationContext(extractedWeapon))
                    .Build();
                WeaponPresentationContext weaponContext = ConvertWeaponToPresentationContext(extractedWeapon);

                return new EquippedWeaponPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .WithWeaponPresentationContext(weaponContext)
                    .Build();
            }

            return null;
        }

        private EquippedJewelryPresentationContext? ExtractJewelry(PlayerEquipmentItemsExtractionVisitor extractor, EquipmentSlotPositions slotPosition)
        {
            Jewelry extractedJewelry = extractor.ExtractedJewelry;

            if (null != extractedJewelry)
            {
                InventoryItemPresentationContext itemContext = ConvertItemToPresentationContext(extractedJewelry, true)
                    .WithAffixes(ConvertItemAffixesToPresentationContext(extractedJewelry))
                    .Build();

                return new EquippedJewelryPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .Build();
            }

            return null;
        }

        private InventoryItemPresentationContext.Builder ConvertItemToPresentationContext(Item item, bool canBeEquipped)
        {
            return new InventoryItemPresentationContext.Builder()
                .WithItemId(item.Name)
                .WithItemClass(item.ItemClass)
                .WithCanBeEquipped(canBeEquipped);
        }

        private AffixesPresentationContext ConvertItemAffixesToPresentationContext(Equipment item)
        {
            AffixToPresentationContextConversionVisitor converter = new AffixToPresentationContextConversionVisitor();
            converter.ConvertAffixesToPresentationContexts(item.FirstImplicit, item.Prefixes, item.Suffixes);

            return new AffixesPresentationContext(converter.Implicits, converter.Explicits);
        }

        private WeaponPresentationContext ConvertWeaponToPresentationContext(Weapon weapon)
        {
            return new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(weapon.MinToMaxPhysicalDamage)
                .WithMinToMaxSpellDamage(weapon.MinToMaxSpellDamage)
                .WithSkillsPerSecond(weapon.SkillsPerSecond)
                .WithCriticalStrikeChance(weapon.CriticalStrikeChance)
                .Build();            
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