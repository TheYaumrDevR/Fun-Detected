using Org.Ethasia.Fundetected.Interactors.Map;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerBoundingBoxMasterDataProvider : IPlayerBoundingBoxMasterDataProvider
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