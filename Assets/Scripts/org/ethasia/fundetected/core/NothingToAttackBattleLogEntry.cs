namespace Org.Ethasia.Fundetected.Core
{
    public class NothingToAttackBattleLogEntry : IBattleLogEntry
    {
        public override string ToString()
        {
            return "No enemy in range";
        }
    }
}