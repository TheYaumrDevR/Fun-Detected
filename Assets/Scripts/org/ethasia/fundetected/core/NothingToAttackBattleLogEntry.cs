namespace Org.Ethasia.Fundetected.Core
{
    public class NothingToAttackBattleLogEntry : IBattleActionResult
    {
        public bool AttackWasExecuted()
        {
            return true;
        }

        public override string ToString()
        {
            return "No enemy in range";
        }
    }
}