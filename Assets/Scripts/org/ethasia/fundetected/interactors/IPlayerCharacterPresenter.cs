using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IPlayerCharacterPresenter
    {
        void PresentPlayer(string playerName, Position playerPosition);
        string GetPlayerCharacterIdPrefix();
    }
}