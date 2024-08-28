using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface AbilityMasterData
    {
        string GetAbilityName();
        EnemyAbility CreateAbilityForEnemy(Enemy enemy);
    }
}