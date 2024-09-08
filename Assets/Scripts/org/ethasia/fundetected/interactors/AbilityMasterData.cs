using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface AbilityMasterData
    {
        string GetAbilityName();
        EnemyAbility CreateAbilityForEnemy(Enemy enemy);
    }
}