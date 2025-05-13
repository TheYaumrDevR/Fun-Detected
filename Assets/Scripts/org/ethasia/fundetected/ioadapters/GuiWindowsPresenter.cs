using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class GuiWindowsPresenter : IGuiWindowsPresenter
    {
        public void ShowMapSelectionWindowForSingletonMap(string mapName, string destinationPortalId, string mapInstanceId)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();

            MapSelectionWindowContext mapSelectionWindowContent = new MapSelectionWindowContext.Builder()
                .SetMapName(mapName)
                .SetMapIds(new List<string> { mapInstanceId })
                .SetDestinationPortalId(destinationPortalId)
                .SetShowNewInstanceButton(false)
                .Build();
            
            guiWindowsController.OpenMapSelectionWindow(mapSelectionWindowContent);
        }

        public void ShowMapSelectionWindow(string mapName, string destinationPortalId, List<string> mapInstanceIds)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();

            MapSelectionWindowContext mapSelectionWindowContent = new MapSelectionWindowContext.Builder()
                .SetMapName(mapName)
                .SetMapIds(mapInstanceIds)
                .SetDestinationPortalId(destinationPortalId)
                .SetShowNewInstanceButton(true)
                .Build();
            
            guiWindowsController.OpenMapSelectionWindow(mapSelectionWindowContent);
        }
    }
}