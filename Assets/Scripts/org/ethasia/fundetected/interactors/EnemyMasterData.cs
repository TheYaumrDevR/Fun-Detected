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
        public AbilityMasterData AbilityMasterData;
        public IMasterDataScalingStrategy ScalingStrategy;
    }
}