using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IEnvironmentInteractionInteractor
    {
        void PlayHealingWellUseSound(string playerCharacterName);
        void ActivateMapSelection(string mapName, string destinationPortalId, List<Area> mapInstances);
        void ActivateMapSelectionForSingletonMap(string mapName, string destinationPortalId);
    }
}