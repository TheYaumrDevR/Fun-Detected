using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class CreateNewCharacterInteractor
    {
        private ICharacterClassMasterDataProvider characterClassMasterDataProvider;

        public CreateNewCharacterInteractor()
        {
            characterClassMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetCharacterClassMasterDataProviderInstance();
        }

        public void CreateCharacterAndStartGame(CharacterClasses characterClass)
        {
            CharacterClassMasterData playerCharacterStartingStats = CreateCharacterMasterDataBasedOnCharacterClass(characterClass); 
            PlayerCharacter playerCharacter = CreatePlayerCharacterFromStartingStats(characterClass, playerCharacterStartingStats);
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
                .SetAccuracyRating(playerCharacterStartingStats.Mana)
                .SetBasePhysicalDamage(basePhysicalDamage)
                .Build();   

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetCharacterClass(characterClass)
                .SetPlayerCharacterBaseStats(startingStats)
                .Build();            
        }
    }
}