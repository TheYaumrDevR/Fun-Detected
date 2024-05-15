namespace Org.Ethasia.Fundetected.Core
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        public override string ToString()
        {
            return "The player's attack missed";
        }
    }
}