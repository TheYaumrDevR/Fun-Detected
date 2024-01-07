using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class StartGameInteractor
    {
        private ICharacterClassMasterDataProvider characterClassMasterDataProvider;

        public StartGameInteractor()
        {
            characterClassMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetCharacterClassMasterDataProviderInstance();
        }

        public void CreateCharacterAndStartGame(CharacterClasses characterClass)
        {
            CharacterClassMasterData playerCharacterStartingStats = CreateCharacterMasterDataBasedOnCharacterClass(characterClass); 
            PlayerCharacter playerCharacter = CreatePlayerCharacterFromStartingStats(characterClass, playerCharacterStartingStats);

            AreaSwitchingInteractor areaSwitchingInteractor = new AreaSwitchingInteractor();
            areaSwitchingInteractor.SwitchActiveMap("Hill", playerCharacter);
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
                .SetLevel(1)
                .SetIntelligence(playerCharacterStartingStats.Intelligence)
                .SetAgility(playerCharacterStartingStats.Agility)
                .SetStrength(playerCharacterStartingStats.Strength)
                .SetMaxLife(playerCharacterStartingStats.Life)
                .SetMaxMana(playerCharacterStartingStats.Mana)
                .SetEvasionRating(playerCharacterStartingStats.EvasionRating)
                .SetBasePhysicalDamage(basePhysicalDamage)
                .SetAttacksPerSecond(playerCharacterStartingStats.AttacksPerSecond)
                .SetMovementSpeed(playerCharacterStartingStats.MovementSpeed)
                .Build();   
            
            startingStats.DeriveStats();
            startingStats.FullHeal();

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetFacingDirection(FacingDirection.RIGHT)
                .SetCharacterClass(characterClass)
                .SetPlayerCharacterBaseStats(startingStats)
                .Build();            
        }
    }
}