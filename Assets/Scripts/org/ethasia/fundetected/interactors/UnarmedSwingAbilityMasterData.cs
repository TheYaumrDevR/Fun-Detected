using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct UnarmedSwingAbilityMasterData : AbilityMasterData
    {
        public string AbilityName;
        public double HitArcStartAngle;
        public double HitArcEndAngle;
        public int HitArcRadius;
        public int HitArcCenterXOffset;
        public int HitArcCenterYOffset;
        public float DefaultTimeToHit;

        public EnemyAbility CreateAbilityForEnemy(Enemy enemy)
        {
            return null;
        }

        public string GetAbilityName()
        {
            return AbilityName;
        }
    }
}