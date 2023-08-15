using UnityEngine;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class BattleLogPrinter : IBattleLogPrinter
    {
        public void PrintBattleLogEntry(IBattleLogEntry logEntry)
        {
            Debug.Log(logEntry.ToString());
        }
    }
}