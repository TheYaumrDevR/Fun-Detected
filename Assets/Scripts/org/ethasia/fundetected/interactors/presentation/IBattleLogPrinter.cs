using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IBattleLogPrinter
    {
        void PrintBattleLogEntry(IBattleActionResult logEntry);
    }
}