using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public interface AbilityMasterData
    {
        string GetAbilityName();
        EnemyAbility CreateAbilityForEnemy(Enemy enemy);
    }
}