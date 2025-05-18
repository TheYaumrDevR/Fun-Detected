using System.Collections.Generic;

using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class GuiContentFactory
    {
        public static List<GuiWindowsController.MapSelectionRow> CreateMapSelectionRows(MapSelectionWindowContext windowContent)
        {
            List<string> mapIds = windowContent.MapIds;
            List<GuiWindowsController.MapSelectionRow> result = new List<GuiWindowsController.MapSelectionRow>(mapIds.Count + 1);

            for (int i = 0; i < mapIds.Count; i++)
            {
                result.Add(new GuiWindowsController.MapSelectionRow(GuiWindowsController.MapSelectionRowType.STANDARD, mapIds[i]));
            }

            if (windowContent.ShowNewInstanceButton)
            {
                result.Add(new GuiWindowsController.MapSelectionRow(GuiWindowsController.MapSelectionRowType.NEW_INSTANCE, "Create new instance"));
            }

            result.Reverse();

            return result;
        }
    }
}