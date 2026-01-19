using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IGuiWindowsPresenter
    {
        void ShowMapSelectionWindow(string mapName, string destinationPortalId, List<string> mapInstanceIds);
        void ShowMapSelectionWindowForSingletonMap(string mapName, string destinationPortalId, string mapInstanceId);
        void OpenInventoryWindow(InventoryPresentationContext context);
    }
}