namespace Org.Ethasia.Fundetected.Core
{
    public class NothingToAttackBattleLogEntry : IBattleActionResult
    {
        public override string ToString()
        {
            return "No enemy in range";
        }
    }
}