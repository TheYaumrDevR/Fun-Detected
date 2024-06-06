using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class MeleeHitArcMasterDataProvider : IMeleeHitArcMasterDataProvider
    {
        public MeleeHitArcMasterData CreateFemaleCharacterOneMeleeHitArcMasterData()
        {
            MeleeHitArcMasterData result = new MeleeHitArcMasterData();

            result.HitArcStartAngle = -0.3829252379;
            result.HitArcEndAngle = 0.9971066017;
            result.HitArcRadius = 10;
            result.HitArcCenterXOffset = -3;
            result.HitArcCenterYOffset = 4;

            return result;
        }
    }
}