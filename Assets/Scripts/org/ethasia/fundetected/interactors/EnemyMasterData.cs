using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct EnemyMasterData
    {
        public string Id;
        public string Name;
        public ScalableEnemyMasterData ScalableMasterData;
        public bool IsAggressiveOnSight;
        public int MinimumSpawnLevel;
        public float AttacksPerSecond;
        public int UnarmedStrikeRange;
        public int CorpseMass;
        public int DistanceToLeftEdge;
        public int DistanceToRightEdge;
        public int DistanceToBottomEdge;
        public int DistanceToTopEdge;
        public float DropChance;
        public AbilityMasterData AbilityMasterData;
        public IMasterDataScalingStrategy ScalingStrategy;
        public List<DropTableMasterData> DropTables;
    }
}