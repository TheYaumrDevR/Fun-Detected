using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealPlayerCharacterPresenter : AbstractAnimationPresenter, IPlayerCharacterPresenter
    {
        private const string PLAYER_CHARACTER_ID_PREFIX = "PlayerCharacter ";
        private IAnimatedCharactersInitializer playerCharacterInitializer;

        public void PresentPlayer(string playerName, Position playerPosition)
        {
            playerCharacterInitializer = TechnicalFactory.GetInstance().GetPlayerCharacterInitializerInstance();

            Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph("FemaleCharacterOne");

            float playerPosX = ConvertMapPositionToScreenPosition(playerPosition.X);
            float playerPosY = ConvertMapPositionToScreenPosition(playerPosition.Y) + 0.4f;

            GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                .SetIndividualId(PLAYER_CHARACTER_ID_PREFIX + playerName)
                .SetName(PLAYER_CHARACTER_ID_PREFIX + playerName)
                .SetPosX(playerPosX)
                .SetPosY(playerPosY)
                .SetScaleX(2.936439f)
                .SetScaleY(3.046849f)
                .SetAnimationProperties(animation2dData)
                .Build();

            playerCharacterInitializer.InitializeAnimatedCharacter(gameObjectProxy);
        }       

        public string GetPlayerCharacterIdPrefix()
        {
            return PLAYER_CHARACTER_ID_PREFIX;
        }
    }
}