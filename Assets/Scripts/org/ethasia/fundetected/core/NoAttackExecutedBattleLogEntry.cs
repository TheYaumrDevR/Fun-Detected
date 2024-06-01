namespace Org.Ethasia.Fundetected.Core
{
    public class NoAttackExecutedBattleLogEntry : IBattleActionResult
    {
        public void PresentToPlayer()
        {
            // Nothing to present
        }

        public override string ToString()
        {
            return "";
        }
    }
}