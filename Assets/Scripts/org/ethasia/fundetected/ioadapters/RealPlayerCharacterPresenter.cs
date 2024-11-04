using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealPlayerCharacterPresenter : AbstractAnimationPresenter, IPlayerCharacterPresenter
    {
        private IAnimatedCharactersInitializer playerCharacterInitializer;

        public void PresentPlayer(string playerName)
        {
            playerCharacterInitializer = TechnicalFactory.GetInstance().GetPlayerCharacterInitializerInstance();

            Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph("FemaleCharacterOne");

            GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                .SetIndividualId("PlayerCharacter " + playerName)
                .SetName("PlayerCharacter " + playerName)
                .SetPosX(-14.5f)
                .SetPosY(-3.43f)
                .SetScaleX(2.936439f)
                .SetScaleY(3.046849f)
                .SetAnimationProperties(animation2dData)
                .Build();

            playerCharacterInitializer.InitializeAnimatedCharacter(gameObjectProxy);
        }       
    }
}