using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public static class InventoryToPresentationContextConverter
    {
        public static InventoryGridPresentationContext Convert(ItemInventoryExtractionVisitor inventoryExtractor)
        {
            InventoryGridPresentationContext result = new InventoryGridPresentationContext();
            inventoryExtractor.ExtractItems();

            result = ConvertWeapons(inventoryExtractor, result);
            result = ConvertArmors(inventoryExtractor, result);
            result = ConvertJewelry(inventoryExtractor, result);
            result = ConvertRecoveryPotions(inventoryExtractor, result);

            return result;
        }

        private static InventoryGridPresentationContext ConvertWeapons(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var weapon in inventoryExtractor.ExtractedWeapons)
            {
                InventoryWeaponPresentationContext inventoryWeaponPresentationContext = ItemToPresentationContextConverter.ConvertWeaponToInventoryContext(weapon);
                presentationContext.AddWeaponPresentationContext(inventoryWeaponPresentationContext);
            }

            return presentationContext;
        }

        private static InventoryGridPresentationContext ConvertArmors(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var armor in inventoryExtractor.ExtractedArmors)
            {
                InventoryArmorPresentationContext inventoryArmorPresentationContext = ItemToPresentationContextConverter.ConvertArmorToInventoryContext(armor);
                presentationContext.AddArmorPresentationContext(inventoryArmorPresentationContext);
            }

            return presentationContext;
        }

        private static InventoryGridPresentationContext ConvertJewelry(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var jewelry in inventoryExtractor.ExtractedJewelry)
            {
                InventoryItemPresentationContext inventoryItemPresentationContext = ItemToPresentationContextConverter.ConvertItemAndShapeToPresentationContext(jewelry.Item, jewelry.ItemInInventoryShape);
                presentationContext.AddJewelryPresentationContext(inventoryItemPresentationContext);
            }

            return presentationContext;
        }

        private static InventoryGridPresentationContext ConvertRecoveryPotions(ItemInventoryExtractionVisitor inventoryExtractor, InventoryGridPresentationContext presentationContext)
        {
            foreach (var recoveryPotion in inventoryExtractor.ExtractedRecoveryPotions)
            {
                InventoryRecoveryPotionPresentationContext inventoryRecoveryPotionPresentationContext = ItemToPresentationContextConverter.ConvertRecoveryPotionToInventoryContext(recoveryPotion);
                presentationContext.AddRecoveryPotionPresentationContext(inventoryRecoveryPotionPresentationContext);
            }

            return presentationContext;
        }
    }
}