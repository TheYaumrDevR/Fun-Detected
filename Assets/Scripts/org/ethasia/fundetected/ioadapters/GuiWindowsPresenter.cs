using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class GuiWindowsPresenter : IGuiWindowsPresenter
    {
        public void ShowMapSelectionWindow(string mapName, List<string> mapInstanceIds)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();
            MapSelectionWindowContent mapSelectionWindowContent = new MapSelectionWindowContent(mapName, mapInstanceIds);
            
            guiWindowsController.OpenMapSelectionWindow(mapSelectionWindowContent);
        }
    }
}