using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class InventoryPresenter : IInventoryPresenter
    {
        public void ShowSwappedEquippedWeapon(string itemId, EquippedWeaponPresentationContext context)
        {
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedArmor(string itemId, EquippedArmorPresentationContext context)
        {
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedJewelry(string itemId, EquippedJewelryPresentationContext context)
        {
            ShowItemOnCursor(itemId);
        }

        public void ShowSwappedEquippedRecoveryPotion(string itemId, EquippedRecoveryPotionPresentationContext context)
        {
            ShowItemOnCursor(itemId);
        }

        private void ShowItemOnCursor(string itemId)
        {
            IIconOnCursorRenderer iconOnCursorRenderer = TechnicalFactory.GetInstance().GetIconOnCursorRendererInstance();

            if (string.IsNullOrEmpty(itemId))
            {
                iconOnCursorRenderer.HideIcon();
            }

            iconOnCursorRenderer.ShowIcon(itemId);
        }
    }
}