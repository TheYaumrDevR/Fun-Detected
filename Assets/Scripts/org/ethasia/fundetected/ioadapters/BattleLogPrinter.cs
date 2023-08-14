using UnityEngine;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class BattleLogPrinter : IBattleLogPrinter
    {
        public void PrintBattleLogEntry(PlayerAbilityActionResult logEntry)
        {
            Debug.Log("You hit " + logEntry.TargetName + " for " + logEntry.TargetDamageTaken + ". Remaining target HP: " + logEntry.TargetRemainingHealth);
        }
    }
}