using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Ioadapters;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class CreateNewCharacterInteractor
    {
        private CharacterClassMasterdataProvider characterClassMasterDataProvider;

        public CreateNewCharacterInteractor()
        {
            characterClassMasterDataProvider = new CharacterClassMasterdataProvider();
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

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetCharacterClass(characterClass)
                .SetIntelligence(playerCharacterStartingStats.Intelligence)
                .SetAgility(playerCharacterStartingStats.Agility)
                .SetStrength(playerCharacterStartingStats.Strength)
                .SetMaxLife(playerCharacterStartingStats.Life)
                .SetMaxMana(playerCharacterStartingStats.Mana)
                .SetAccuracyRating(playerCharacterStartingStats.Mana)
                .SetBasePhysicalDamage(basePhysicalDamage)
                .Build();            
        }
    }
}