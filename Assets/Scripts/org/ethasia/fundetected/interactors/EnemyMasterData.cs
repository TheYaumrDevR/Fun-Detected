namespace Org.Ethasia.Fundetected.Interactors
{
    public struct EnemyMasterData
    {
        public string Id;
        public string Name;
        public bool IsAggressiveOnSight;
        public int MaxLife;
        public int Armor;
        public int FireResistance;
        public int IceResistance;
        public int LightningResistance;
        public int MagicResistance;
        public float AttacksPerSecond;
        public int UnarmedStrikeRange;
        public int CorpseMass;
        public int MinPhysicalDamage;
        public int MaxPhysicalDamage;
        public int AccuracyRating;
        public int EvasionRating;
        public int DistanceToLeftEdge;
        public int DistanceToRightEdge;
        public int DistanceToBottomEdge;
        public int DistanceToTopEdge;
        public AbilityMasterData AbilityMasterData;
    }
}