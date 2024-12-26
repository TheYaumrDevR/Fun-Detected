using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealPlayerCharacterPresenter : AbstractAnimationPresenter, IPlayerCharacterPresenter
    {
        private IAnimatedCharactersInitializer playerCharacterInitializer;

        public void PresentPlayer(string playerName, Position playerPosition)
        {
            playerCharacterInitializer = TechnicalFactory.GetInstance().GetPlayerCharacterInitializerInstance();

            Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph("FemaleCharacterOne");

            float playerPosX = playerPosition.X / 10.0f;
            float playerPosY = playerPosition.Y / 10.0f + 0.4f;

            GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                .SetIndividualId("PlayerCharacter " + playerName)
                .SetName("PlayerCharacter " + playerName)
                .SetPosX(playerPosX)
                .SetPosY(playerPosY)
                .SetScaleX(2.936439f)
                .SetScaleY(3.046849f)
                .SetAnimationProperties(animation2dData)
                .Build();

            playerCharacterInitializer.InitializeAnimatedCharacter(gameObjectProxy);
        }       
    }
}