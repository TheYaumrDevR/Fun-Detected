using Org.Ethasia.Fundetected.Interactors.Combat;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MeleeHitArcMasterDataProviderMock : IMeleeHitArcMasterDataProvider
    {
        public MeleeHitArcMasterData CreateFemaleCharacterOneMeleeHitArcMasterData()
        {
            MeleeHitArcMasterData result = new MeleeHitArcMasterData();

            result.HitArcStartAngle = -0.3829252379;
            result.HitArcEndAngle = 0.9971066017;
            result.HitArcRadius = 22;
            result.HitArcCenterXOffset = -3;
            result.HitArcCenterYOffset = 4;

            return result;
        }
    }
}