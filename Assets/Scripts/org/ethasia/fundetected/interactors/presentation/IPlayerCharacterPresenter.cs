using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IPlayerCharacterPresenter
    {
        void PresentPlayer(string playerName, Position playerPosition, AnimationPresentationContext animationContext);
        string GetPlayerCharacterIdPrefix();
    }
}