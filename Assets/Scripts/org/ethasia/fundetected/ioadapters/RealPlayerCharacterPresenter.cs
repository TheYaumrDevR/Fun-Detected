using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealPlayerCharacterPresenter : AbstractAnimationPresenter, IPlayerCharacterPresenter
    {
        public void PresentPlayer()
        {
            Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph("FemaleCharacterOne");

            GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                .SetPosX(5.5f)
                .SetPosY(1.63f)
                .SetScaleX(2.936439f)
                .SetScaleY(3.046849f)
                .SetAnimationProperties(animation2dData)
                .Build();
        }       
    }
}