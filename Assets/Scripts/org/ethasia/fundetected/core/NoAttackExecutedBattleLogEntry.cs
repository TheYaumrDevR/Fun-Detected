namespace Org.Ethasia.Fundetected.Core
{
    public class NoAttackExecutedBattleLogEntry : IBattleActionResult
    {
        public bool AttackWasExecuted()
        {
            return false;
        }

        public override string ToString()
        {
            return "";
        }
    }
}