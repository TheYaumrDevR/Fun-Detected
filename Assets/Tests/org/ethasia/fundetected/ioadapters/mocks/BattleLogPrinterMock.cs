using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{

    public class BattleLogPrinterMock : IBattleLogPrinter
    {
        public void PrintBattleLogEntry(IBattleActionResult logEntry) {}
    }
}