using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class InventoryPresenter : IInventoryPresenter
    {
        public void ShowSwappedEquippedWeapon(string itemId, EquippedWeaponPresentationContext context)
        {
            EquipmentSlotRenderContext equipmentRenderContext = ItemPresentationToRenderContextConverter.ConvertWeaponEquipmentSlotPresentationContext(context.ItemPresentationContext, context.WeaponPresentationContext);

            PresentEquippedItem(context.SlotPosition, equipmentRenderContext);
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedArmor(string itemId, EquippedArmorPresentationContext context)
        {
            EquipmentSlotRenderContext equipmentRenderContext = ItemPresentationToRenderContextConverter.ConvertArmorEquipmentSlotPresentationContext(context.ItemPresentationContext, context.ArmorPresentationContext);

            PresentEquippedItem(context.SlotPosition, equipmentRenderContext);
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedJewelry(string itemId, EquippedJewelryPresentationContext context)
        {
            EquipmentSlotRenderContext equipmentRenderContext = ItemPresentationToRenderContextConverter.ConvertEquipmentSlotPresentationContext(context.ItemPresentationContext);

            PresentEquippedItem(context.SlotPosition, equipmentRenderContext);
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedRecoveryPotion(string itemId, EquippedRecoveryPotionPresentationContext context)
        {
            EquipmentSlotRenderContext equipmentRenderContext = ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(context.ItemPresentationContext, context.RecoveryPotionPresentationContext);

            PresentEquippedItem(context.SlotPosition, equipmentRenderContext);
            ShowItemOnCursor(itemId);
        }

        private void PresentEquippedItem(EquipmentSlotPositions slotPosition, EquipmentSlotRenderContext equipmentRenderContext)
        {
            IUiRenderer uiRenderer = TechnicalFactory.GetInstance().GetUiRendererInstance();
            uiRenderer.RenderEquippedItemInInventoryWindow(slotPosition, equipmentRenderContext);
        }

        private void ShowItemOnCursor(string itemId)
        {
            IIconOnCursorRenderer iconOnCursorRenderer = TechnicalFactory.GetInstance().GetIconOnCursorRendererInstance();

            if (string.IsNullOrEmpty(itemId))
            {
                iconOnCursorRenderer.HideIcon();
            }
            else
            {
                iconOnCursorRenderer.ShowIcon(itemId);
            }
        }
    }
}