namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public struct FixedStatsPerLevelEnemyScalingMasterData : IMasterDataScalingStrategy
    {
        public ScalableEnemyMasterData AdditionsPerLevel;

        public EnemyMasterData ScaleMasterData(EnemyMasterData masterData, int targetLevel)
        {
            if (targetLevel > 100)   
            {
                targetLevel = 100;
            }

            int levelDifference = targetLevel - masterData.MinimumSpawnLevel;

            if (levelDifference > 0)
            {
                masterData.ScalableMasterData.MaxLife += AdditionsPerLevel.MaxLife * levelDifference;
                masterData.ScalableMasterData.Armor += AdditionsPerLevel.Armor * levelDifference;
                masterData.ScalableMasterData.FireResistance += AdditionsPerLevel.FireResistance * levelDifference;
                masterData.ScalableMasterData.IceResistance += AdditionsPerLevel.IceResistance * levelDifference;
                masterData.ScalableMasterData.LightningResistance += AdditionsPerLevel.LightningResistance * levelDifference;
                masterData.ScalableMasterData.MagicResistance += AdditionsPerLevel.MagicResistance * levelDifference;
                masterData.ScalableMasterData.MinPhysicalDamage += AdditionsPerLevel.MinPhysicalDamage * levelDifference;
                masterData.ScalableMasterData.MaxPhysicalDamage += AdditionsPerLevel.MaxPhysicalDamage * levelDifference;
                masterData.ScalableMasterData.AccuracyRating += AdditionsPerLevel.AccuracyRating * levelDifference;
                masterData.ScalableMasterData.EvasionRating += AdditionsPerLevel.EvasionRating * levelDifference;
            }

            return masterData;
        }
    }
}