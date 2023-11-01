using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class StartGameInteractor
    {
        private ICharacterClassMasterDataProvider characterClassMasterDataProvider;
        private IEnemyMasterDataProvider enemyMasterDataProvider;
        private IMapPropertiesGateway mapPropertiesGateway;

        public StartGameInteractor()
        {
            characterClassMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetCharacterClassMasterDataProviderInstance();
            enemyMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetEnemyMasterDataProviderInstance();
            mapPropertiesGateway = IoAdaptersFactoryForInteractors.GetInstance().GetMapPropertiesGatewayInstance();
        }

        public void CreateCharacterAndStartGame(CharacterClasses characterClass)
        {
            CharacterClassMasterData playerCharacterStartingStats = CreateCharacterMasterDataBasedOnCharacterClass(characterClass); 
            PlayerCharacter playerCharacter = CreatePlayerCharacterFromStartingStats(characterClass, playerCharacterStartingStats);
            Enemy enemy = CreateEnemy();

            MapProperties mapProperties = mapPropertiesGateway.LoadMapProperties("Hill");

            Area map = MapPropertiesConverter.ConvertMapPropertiesToArea(mapProperties);
            map.AddPlayerAt(playerCharacter, 145, 46);
            map.AddEnemy(enemy);

            Area.ActiveArea = map;
        }

        private CharacterClassMasterData CreateCharacterMasterDataBasedOnCharacterClass(CharacterClasses characterClass)
        {
            switch (characterClass)
            {
                case CharacterClasses.STRONGMAN:
                    return characterClassMasterDataProvider.CreateStrongManMasterData();
                case CharacterClasses.DUELIST:
                    return characterClassMasterDataProvider.CreateDuelistMasterData();
                case CharacterClasses.BATTLE_MAGE:
                    return characterClassMasterDataProvider.CreateBattleMageMasterData();
                case CharacterClasses.ZOOMER:
                    return characterClassMasterDataProvider.CreateZoomerMasterData();
                case CharacterClasses.MAGICIAN:
                    return characterClassMasterDataProvider.CreateMagicianMasterData();
                case CharacterClasses.CUCK:
                    return characterClassMasterDataProvider.CreateCuckMasterData(); 
            }

            return new CharacterClassMasterData();
        }

        private PlayerCharacter CreatePlayerCharacterFromStartingStats(CharacterClasses characterClass, CharacterClassMasterData playerCharacterStartingStats)
        {
            DamageRange basePhysicalDamage = new DamageRange(playerCharacterStartingStats.MinBasePhysicalDamage, playerCharacterStartingStats.MaxBasePhysicalDamage);

            PlayerCharacterBaseStats startingStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetIntelligence(playerCharacterStartingStats.Intelligence)
                .SetAgility(playerCharacterStartingStats.Agility)
                .SetStrength(playerCharacterStartingStats.Strength)
                .SetMaxLife(playerCharacterStartingStats.Life)
                .SetMaxMana(playerCharacterStartingStats.Mana)
                .SetBasePhysicalDamage(basePhysicalDamage)
                .SetAttacksPerSecond(playerCharacterStartingStats.AttacksPerSecond)
                .SetMovementSpeed(playerCharacterStartingStats.MovementSpeed)
                .Build();   
            
            startingStats.DeriveStats();
            startingStats.FullHeal();

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetCharacterClass(characterClass)
                .SetPlayerCharacterBaseStats(startingStats)
                .Build();            
        }

        private Enemy CreateEnemy()
        {
            EnemyMasterData enemyMasterData = enemyMasterDataProvider.CreateDrownedZombieMasterData();

            Enemy result = new Enemy.Builder()
                .SetName(enemyMasterData.Name)
                .SetLife(enemyMasterData.MaxLife)
                .SetArmor(enemyMasterData.Armor)
                .SetEvasionRating(enemyMasterData.EvasionRating)
                .Build();

            return result;
        }
    }
}