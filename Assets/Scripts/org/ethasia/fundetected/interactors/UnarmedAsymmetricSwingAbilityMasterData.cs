using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct UnarmedAsymmetricSwingAbilityMasterData : AbilityMasterData
    {
        public string AbilityName;
        public UnarmedSwingAbilityMasterData LeftSwingData;
        public UnarmedSwingAbilityMasterData RightSwingData;

        public EnemyAbility CreateAbilityForEnemy(Enemy enemy)
        {
            return EnemyAbilityFactory.FromMasterData(this, enemy);
        }     

        public string GetAbilityName()
        {
            return AbilityName;
        }   
    }
}