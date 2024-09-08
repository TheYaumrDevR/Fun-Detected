using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerRepeatedUpdateInteractor
    {
        public void Update(double deltaTime)
        {
            Area activeArea = Area.ActiveArea;
            activeArea.Player.Tick(deltaTime);
        }
    }
}