using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IBattleLogPrinter
    {
        void PrintBattleLogEntry(IBattleActionResult logEntry);
    }
}