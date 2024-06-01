namespace Org.Ethasia.Fundetected.Core
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        public void PresentToPlayer()
        {
            // TODO: Show "miss" text later
        }

        public override string ToString()
        {
            return "The player's attack missed";
        }
    }
}