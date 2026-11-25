namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IGuiWindowsController
    {
        void OpenMapSelectionWindow(MapSelectionWindowContext windowContent);
        void OpenInventoryWindow(InventoryRenderContext context);
        void CloseCurrentlyOpenWindow();      
        bool IsAnyWindowOpen();
        void OpenMainMenuWindow();
        void ToggleInventoryWindow();
        void ShowDeathOverlay(int lostExperiencePoints);
        void HideDeathOverlay();
        bool IsDeathOverlayVisible();
    }
}