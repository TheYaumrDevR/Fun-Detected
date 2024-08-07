using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class PlayerBoundingBoxMasterDataProviderMock : IPlayerBoundingBoxMasterDataProvider
    {
        public BoundingBoxMasterData CreateFemaleCharacterOneBoundingBoxMasterData()
        {
            BoundingBoxMasterData result = new BoundingBoxMasterData();

            result.DistanceToLeftEdge = 4;
            result.DistanceToRightEdge = 5;
            result.DistanceToBottomEdge = 15;
            result.DistanceToTopEdge = 16;

            return result;
        }
    }
}