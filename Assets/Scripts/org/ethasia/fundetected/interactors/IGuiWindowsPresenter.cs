using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IGuiWindowsPresenter
    {
        void ShowMapSelectionWindow(string mapName, List<string> mapInstanceIds);
        void ShowMapSelectionWindowForSingletonMap(string mapName, string mapInstanceId);
    }
}