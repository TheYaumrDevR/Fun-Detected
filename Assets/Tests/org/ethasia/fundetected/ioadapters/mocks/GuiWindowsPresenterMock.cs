using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class GuiWindowsPresenterMock : IGuiWindowsPresenter
    {
        public void ShowMapSelectionWindowForSingletonMap(string mapName, string destinationPortalId, string mapInstanceId) {}
        public void ShowMapSelectionWindow(string mapName, string destinationPortalId, List<string> mapInstanceIds) {}
    }
}