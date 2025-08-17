using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class EnemyMasterDataToEnemyConverterTest
    {

        [Test]
        public void TestCreateEnemyFromMasterDataCopiesPropertiesFromMasterData()
        {
            EnemySpawnLocation spawnLocationData = new EnemySpawnLocation(new Position(7, 23), 1.0f, 2);

            Enemy result = EnemyMasterDataToEnemyConverter.CreateEnemyFromMasterData(CreateMasterDataForTest(), spawnLocationData, 1);

            Assert.That(result.IndividualId, Is.EqualTo("BloatedHorseflySwarm1"));
            Assert.That(result.TypeId, Is.EqualTo("BloatedHorseflySwarm"));
            Assert.That(result.Position.X, Is.EqualTo(7));
            Assert.That(result.Position.Y, Is.EqualTo(23));
            Assert.That(result.Name, Is.EqualTo("Bloated Horsefly Swarm"));
            Assert.That(result.CurrentLife, Is.EqualTo(30));
            Assert.That(result.EvasionRating, Is.EqualTo(150));
            Assert.That(result.UnarmedStrikeRange, Is.EqualTo(12));
            Assert.That(result.AttacksPerSecond, Is.EqualTo(1.4f));
            Assert.That(result.BoundingBox.DistanceToRightEdge, Is.EqualTo(7));
            Assert.That(result.BoundingBox.DistanceToLeftEdge, Is.EqualTo(7));
            Assert.That(result.BoundingBox.DistanceToTopEdge, Is.EqualTo(7));
            Assert.That(result.BoundingBox.DistanceToBottomEdge, Is.EqualTo(7));
        }

        [Test]
        public void TestCreateEnemyFromMasterDataConvertsDropTable()
        {
            EnemySpawnLocation spawnLocationData = new EnemySpawnLocation(new Position(7, 23), 1.0f, 2);

            Enemy result = EnemyMasterDataToEnemyConverter.CreateEnemyFromMasterData(CreateMasterDataForTest(), spawnLocationData, 1);
            EnemyWithExposedDropTable testableResult = new EnemyWithExposedDropTable(result);

            Assert.That(testableResult.DropTables.Count, Is.EqualTo(1));

            DropTable convertedDropTable = testableResult.DropTables[0];

            Assert.That(convertedDropTable.DropTableRows.Count, Is.EqualTo(3));
            Assert.That(convertedDropTable.DropTableRows[0].DropTableEntries.Count, Is.EqualTo(1));
            Assert.That(convertedDropTable.DropTableRows[1].DropTableEntries.Count, Is.EqualTo(1));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries.Count, Is.EqualTo(4));

            Assert.That(convertedDropTable.DropTableRows[0].DropTableEntries[0].Item.Name, Is.EqualTo("Hyperinjector"));
            Assert.That(convertedDropTable.DropTableRows[1].DropTableEntries[0].Item.Name, Is.EqualTo("Steel Artisan's Knife"));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[0].Item.Name, Is.EqualTo("Tattered Leather Armor"));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[1].Item.Name, Is.EqualTo("Corroded Cutlass"));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[2].Item.Name, Is.EqualTo("Minor Mana Potion"));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[3].Item.Name, Is.EqualTo("Minor Healing Potion"));
        }

        [Test]
        public void TestCreateEnemyFromMasterDataConvertsProbabilityOfEqualChanceGroups()
        {
            EnemySpawnLocation spawnLocationData = new EnemySpawnLocation(new Position(7, 23), 1.0f, 2);

            Enemy result = EnemyMasterDataToEnemyConverter.CreateEnemyFromMasterData(CreateMasterDataForTest(), spawnLocationData, 1);
            EnemyWithExposedDropTable testableResult = new EnemyWithExposedDropTable(result);

            DropTable convertedDropTable = testableResult.DropTables[0];

            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[2].DropChance, Is.EqualTo(0.375f));
            Assert.That(convertedDropTable.DropTableRows[2].DropTableEntries[3].DropChance, Is.EqualTo(0.375f));
        }

        [Test]
        public void TestCreateEnemyFromMasterDataConvertsDropChance()
        {
            EnemySpawnLocation spawnLocationData = new EnemySpawnLocation(new Position(45, 12), 1.0f, 4);

            Enemy result = EnemyMasterDataToEnemyConverter.CreateEnemyFromMasterData(CreateMasterDataForTest(), spawnLocationData, 1);    
            EnemyWithExposedDropTable testableResult = new EnemyWithExposedDropTable(result);

            Assert.That(testableResult.DropChance, Is.EqualTo(0.3f));
        }

        private EnemyMasterData CreateMasterDataForTest()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "BloatedHorseflySwarm";
            result.Name = "Bloated Horsefly Swarm";
            result.IsAggressiveOnSight = true;
            result.MinimumSpawnLevel = 2;
            result.DropChance = 0.3f;
            result.ScalableMasterData.MaxLife = 30;
            result.ScalableMasterData.Armor = 3;
            result.ScalableMasterData.EvasionRating = 150;
            result.ScalableMasterData.AccuracyRating = 11;
            result.AttacksPerSecond = 1.4f;
            result.UnarmedStrikeRange = 12;
            result.CorpseMass = 2;
            result.ScalableMasterData.MinPhysicalDamage = 1;
            result.ScalableMasterData.MaxPhysicalDamage = 3;
            result.DistanceToLeftEdge = 7;
            result.DistanceToRightEdge = 7;
            result.DistanceToBottomEdge = 7;
            result.DistanceToTopEdge = 7;

            DropTableMasterData globalDropTable = CreateDropTableDataForTest();

            UnarmedAsymmetricSwingAbilityMasterData unarmedAsymmetricSwingAbilityMasterData = new UnarmedAsymmetricSwingAbilityMasterData
            {
                AbilityName = "Branch Swing",
                LeftSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -2.671575486, // -97,91
                    HitArcEndAngle = -1.7088518706, // -153,07
                    HitArcRadius = 12,
                    HitArcCenterXOffset = -1,
                    HitArcCenterYOffset = -6,
                    DefaultTimeToHit = 0.25f
                },
                RightSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -1.4030701857, // -80,39
                    HitArcEndAngle = -0.637045177, // -36,5
                    HitArcRadius = 12,
                    HitArcCenterXOffset = 1,
                    HitArcCenterYOffset = -7,
                    DefaultTimeToHit = 0.25f
                }
            };

            IMasterDataScalingStrategy scalingStrategy = new FixedStatsPerLevelEnemyScalingMasterData
            {
                AdditionsPerLevel = new ScalableEnemyMasterData
                {
                    MaxLife = 2,
                    Armor = 1,
                    FireResistance = 0,
                    IceResistance = 0,
                    LightningResistance = 0,
                    MagicResistance = 0,
                    MinPhysicalDamage = 2,
                    MaxPhysicalDamage = 3,
                    AccuracyRating = 2,
                    EvasionRating = 13
                }
            };

            result.AbilityMasterData = unarmedAsymmetricSwingAbilityMasterData;
            result.ScalingStrategy = scalingStrategy;

            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(globalDropTable);

            return result;
        }

        private DropTableMasterData CreateDropTableDataForTest()
        {
            DropTableMasterData result = new DropTableMasterData(100);
            DropTableRowMasterData dropTableRow1 = new DropTableRowMasterData(0.001f);
            DropTableRowMasterData dropTableRow2 = new DropTableRowMasterData(1.0f);
            DropTableRowMasterData dropTableRow3 = new DropTableRowMasterData(0.5f);

            JewelryMasterData rareBelt = new JewelryMasterData.Builder()
                .SetItemClass(ItemClass.BELT)
                .SetFirstImplicit(CreateImplicitMasterDataForTest())
                .SetMinimumItemLevel(45)
                .SetName("Hyperinjector")
                .SetStrengthRequirement(15)
                .SetAgilityRequirement(0)
                .SetIntelligenceRequirement(0)
                .Build();

            RecoveryPotionMasterData lifePotion = new RecoveryPotionMasterData.Builder()
                .SetItemClass(ItemClass.LIFE_POTION)
                .SetMinimumItemLevel(1)
                .SetName("Minor Healing Potion")
                .SetRecoveryAmount(10)
                .SetUses(3)
                .Build();

            RecoveryPotionMasterData manaPotion = new RecoveryPotionMasterData.Builder()
                .SetItemClass(ItemClass.MANA_POTION)
                .SetMinimumItemLevel(1)
                .SetName("Minor Mana Potion")
                .SetRecoveryAmount(10)
                .SetUses(3)
                .Build();

            WeaponMasterData sword = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(4, 9))
                .SetSkillsPerSecond(1.55)
                .SetCriticalStrikeChance(500)
                .SetWeaponRange(12)
                .SetName("Corroded Cutlass")
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetAgilityRequirement(8)
                .SetItemClass(ItemClass.ONE_HANDED_SWORD)
                .Build();

            ArmorMasterData tatteredLeatherArmor = new ArmorMasterData.Builder()
                .SetName("Tattered Leather Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(1)
                .SetStrengthRequirement(8)
                .SetArmorValue(15)
                .SetMovementSpeedAddend(6)
                .SetFirstImplicit(CreateImplicitMasterDataForTest())
                .Build();

            WeaponMasterData steelArtisansKnife = new WeaponMasterData.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(19, 76))
                .SetSkillsPerSecond(1.4)
                .SetCriticalStrikeChance(650)
                .SetWeaponRange(10)
                .SetName("Steel Artisan's Knife")
                .SetMinimumItemLevel(56)
                .SetAgilityRequirement(113)
                .SetIntelligenceRequirement(78)
                .SetItemClass(ItemClass.DAGGER)
                .Build();

            DropTableEntryMasterData swordEntry = new DropTableEntryMasterData(0.25f, sword);
            DropTableEntryMasterData manaPotionEntry = new DropTableEntryMasterData(0f, manaPotion);
            DropTableEntryMasterData lifePotionEntry = new DropTableEntryMasterData(0f, lifePotion);
            DropTableEntryMasterData rareBeltEntry = new DropTableEntryMasterData(0.001f, rareBelt);
            DropTableEntryMasterData tatteredLeatherArmorEntry = new DropTableEntryMasterData(0.2, tatteredLeatherArmor);
            DropTableEntryMasterData steelArtisansKnifeEntry = new DropTableEntryMasterData(1.0, steelArtisansKnife);

            DropTableEntryEqualChanceGroupMasterData potionGroup = new DropTableEntryEqualChanceGroupMasterData(0.375f);
            potionGroup.DropTableEntries.Add(manaPotionEntry);
            potionGroup.DropTableEntries.Add(lifePotionEntry);

            dropTableRow2.DropTableEntryEqualChanceGroups.Add(potionGroup);
            dropTableRow2.DropTableEntries.Add(tatteredLeatherArmorEntry);
            dropTableRow2.DropTableEntries.Add(swordEntry);

            dropTableRow1.DropTableEntries.Add(rareBeltEntry);

            dropTableRow3.DropTableEntries.Add(steelArtisansKnifeEntry);

            result.DropTableRows.Add(dropTableRow2);
            result.DropTableRows.Add(dropTableRow1);
            result.DropTableRows.Add(dropTableRow3);

            return result;
        }

        public AffixMasterDataBaseForIntegerMinMaxAndIncrement CreateImplicitMasterDataForTest()
        {
            return new AffixMasterDataBaseForIntegerMinMaxAndIncrement.Builder()
                .SetMinValue(12)
                .SetMaxValue(24)
                .SetIncrement(1)
                .SetAffixClasses(AffixClasses.PlusGlobalPhysicalDamageIncrease)
                .Build();            
        }

        public class EnemyWithExposedDropTable : Enemy
        {
            public List<DropTable> DropTables
            {
                get { return dropTables; }
            }

            public float DropChance
            {
                get { return dropChance; }
            }

            public EnemyWithExposedDropTable(Enemy enemy) : base(enemy) { }
        }
    }
}