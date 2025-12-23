using UnityEngine;

using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class BattleLogPrinter : IBattleLogPrinter
    {
        public void PrintBattleLogEntry(IBattleActionResult logEntry)
        {
            // TODO print into log file
            Debug.Log("Battle log entry printed.");
        }
    }
}