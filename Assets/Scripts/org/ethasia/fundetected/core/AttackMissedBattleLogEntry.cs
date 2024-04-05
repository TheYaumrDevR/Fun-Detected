namespace Org.Ethasia.Fundetected.Core
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        public bool AttackWasExecuted()
        {
            return true;
        }

        public override string ToString()
        {
            return "The player's attack missed";
        }
    }
}