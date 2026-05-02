using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class InventoryPresenterMock : IInventoryPresenter
    {
        public void ShowSwappedEquippedWeapon(string itemId, EquippedWeaponPresentationContext context)
        {
        }

        public void ShowSwappedEquippedArmor(string itemId, EquippedArmorPresentationContext context)
        {
        }

        public void ShowSwappedEquippedJewelry(string itemId, EquippedJewelryPresentationContext context)
        {
        }

        public void ShowSwappedEquippedRecoveryPotion(string itemId, EquippedRecoveryPotionPresentationContext context)
        {
        }

        public void ShowEmptySlotAfterSwap(string itemId, EquipmentSlotPositions slotPosition)
        {
        }

        public void HideItemOnCursor()
        {
        }
    }
}