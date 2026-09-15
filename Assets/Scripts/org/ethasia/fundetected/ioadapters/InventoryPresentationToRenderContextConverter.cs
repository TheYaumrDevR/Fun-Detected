using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public static class InventoryPresentationToRenderContextConverter
    {
        public static InventoryGridRenderContext Convert(InventoryGridPresentationContext toConvert)
        {
            InventoryGridRenderContext result = new InventoryGridRenderContext();

            result = ConvertWeaponPresentationContexts(toConvert, result);
            result = ConvertArmorPresentationContexts(toConvert, result);
            result = ConvertJewelryPresentationContexts(toConvert, result);
            result = ConvertRecoveryPotionPresentationContexts(toConvert, result);

            return result;
        }

        private static InventoryGridRenderContext ConvertWeaponPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.WeaponsPresentationContexts != null)
            {
                foreach (var weaponContext in toConvert.WeaponsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryWeaponRenderContext(weaponContext, parentContext);
                }
            }

            return parentContext;
        }

        private static InventoryGridRenderContext ConvertArmorPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.ArmorsPresentationContexts != null)
            {
                foreach (var armorContext in toConvert.ArmorsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryArmorRenderContext(armorContext, parentContext);
                }
            }

            return parentContext;
        }

        private static InventoryGridRenderContext ConvertJewelryPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.JewelriesPresentationContexts != null)
            {
                foreach (var jewelryContext in toConvert.JewelriesPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryPlainItemRenderContext(jewelryContext, parentContext);
                }
            }

            return parentContext;
        }

        private static InventoryGridRenderContext ConvertRecoveryPotionPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.RecoveryPotionsPresentationContexts != null)
            {
                foreach (var recoveryPotionContext in toConvert.RecoveryPotionsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryRecoveryPotionRenderContext(recoveryPotionContext, parentContext);
                }
            }

            return parentContext;
        }

        private static InventoryGridRenderContext ConvertAndAddInventoryWeaponRenderContext(InventoryWeaponPresentationContext inventoryWeaponContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryWeaponContext.ItemContext;
            var weaponContext = inventoryWeaponContext.WeaponContext;
            var tooltip = ItemPresentationToRenderContextConverter.ConvertWeaponPresentationContext(weaponContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private static InventoryGridRenderContext ConvertAndAddInventoryArmorRenderContext(InventoryArmorPresentationContext inventoryArmorContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryArmorContext.ItemContext;
            var armorContext = inventoryArmorContext.ArmorContext;
            var tooltip = ItemPresentationToRenderContextConverter.ConvertArmorPresentationContext(armorContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private static InventoryGridRenderContext ConvertAndAddInventoryPlainItemRenderContext(
            InventoryItemPresentationContext itemContext,
            InventoryGridRenderContext inventoryGridRenderContext)
        {
            var tooltip = ItemPresentationToRenderContextConverter.ConvertPlainItemPresentationContextToTooltipContext(itemContext);
            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private static InventoryGridRenderContext ConvertAndAddInventoryRecoveryPotionRenderContext(InventoryRecoveryPotionPresentationContext inventoryRecoveryPotionContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryRecoveryPotionContext.ItemContext;
            var recoveryPotionContext = inventoryRecoveryPotionContext.RecoveryPotionContext;
            var tooltip = ItemPresentationToRenderContextConverter.ConvertRecoveryPotionPresentationContext(recoveryPotionContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private static InventoryGridRenderContext ConvertAndAddInventoryItemRenderContext(
            InventoryItemPresentationContext itemContext,
            InventoryGridRenderContext inventoryGridRenderContext,
            ItemTooltipRenderContext? tooltipRenderContext = null)
        {
            for (int x = 0; x < itemContext.DimensionX; x++)
            {
                for (int y = 0; y < itemContext.DimensionY; y++)
                {
                    InventorySlotRenderContext.Builder builder = new InventorySlotRenderContext.Builder()
                        .WithItemBaseTypeName(itemContext.ItemId)
                        .ShouldRenderSomething(true)
                        .WithCanBeEquipped(itemContext.CanBeEquipped);

                    if (x == 0 && y == 0)
                    {
                        builder.WithItemImageName(itemContext.ItemId);
                    }

                    if (tooltipRenderContext != null)
                    {
                        builder.WithToolTipRenderContext(tooltipRenderContext.Value);
                    }

                    InventorySlotRenderContext slotRenderContext = builder.Build();
                    inventoryGridRenderContext.AddSlotRenderContext(
                        itemContext.TopLeftCornerX + x,
                        itemContext.TopLeftCornerY + y,
                        slotRenderContext);
                }
            }

            return inventoryGridRenderContext;
        }
    }
}