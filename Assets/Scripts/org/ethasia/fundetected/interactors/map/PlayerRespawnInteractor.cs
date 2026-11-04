using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public class PlayerRespawnInteractor
    {
        public bool IsPlayerDead()
        {
            Area activeArea = Area.ActiveArea;

            return activeArea != null && activeArea.Player != null && activeArea.Player.IsDead;
        }

        public void RespawnInNearestTown()
        {
            Area activeArea = Area.ActiveArea;
            PlayerCharacter player = activeArea.Player;

            string townMapId = activeArea.NearestTownMapId;
            string townPortalId = activeArea.NearestTownPortalId;

            player.FullyHealHpAndMp();

            if (string.IsNullOrEmpty(townMapId))
            {
                return;
            }

            IPortalTransitionInteractor portalTransitionInteractor = InteractorsFactoryForCore.GetInstance().GetPortalTransitionInteractor();
            portalTransitionInteractor.TransitionToOtherMap(townMapId, townPortalId);
        }
    }
}