namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IInventoryPresenter
    {
        void ShowSwappedEquippedWeapon(string itemIdOnCursor, EquippedWeaponPresentationContext newEquippedWeapon);
        void ShowSwappedEquippedArmor(string itemIdOnCursor, EquippedArmorPresentationContext newEquippedArmor);
        void ShowSwappedEquippedJewelry(string itemIdOnCursor, EquippedJewelryPresentationContext newEquippedJewelry);
        void ShowSwappedEquippedRecoveryPotion(string itemIdOnCursor, EquippedRecoveryPotionPresentationContext newEquippedRecoveryPotion);
    }
}