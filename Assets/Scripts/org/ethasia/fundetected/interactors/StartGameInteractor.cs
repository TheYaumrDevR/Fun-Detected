using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class StartGameInteractor
    {
        private ICharacterClassMasterDataProvider characterClassMasterDataProvider;
        private IMeleeHitArcMasterDataProvider meleeHitArcMasterDataProvider;

        public StartGameInteractor()
        {
            characterClassMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetCharacterClassMasterDataProviderInstance();
            meleeHitArcMasterDataProvider = IoAdaptersFactoryForInteractors.GetInstance().GetMeleeHitArcMasterDataProviderInstance();
        }

        public void CreateCharacterAndStartGame(CharacterClasses characterClass)
        {
            CharacterCreationMasterData playerCharacterBaseStats = CreateCharacterCreationMasterDataFromSelectedCharacterTraits(characterClass); 
            PlayerCharacter playerCharacter = CreatePlayerCharacterFromStartingStats(characterClass, playerCharacterBaseStats);

            AreaSwitchingInteractor areaSwitchingInteractor = new AreaSwitchingInteractor();
            areaSwitchingInteractor.SwitchActiveMap("Hill", playerCharacter);

            IoAdaptersFactoryForInteractors.GetInstance().GetPlayerCharacterPresenterInstance().PresentPlayer("FunEnjoyer");
        }

        private CharacterCreationMasterData CreateCharacterCreationMasterDataFromSelectedCharacterTraits(CharacterClasses characterClass)
        {
            CharacterClassMasterData characterClassMasterData = CreateCharacterMasterDataBasedOnCharacterClass(characterClass);
            MeleeHitArcMasterData meleeHitArcMasterData = CreateMeleeHitArcMasterDataBasedOnCharacterBodyType();

            return new CharacterCreationMasterData
            {
                CharacterClassMasterData = characterClassMasterData,
                MeleeHitArcMasterData = meleeHitArcMasterData
            };
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

        private MeleeHitArcMasterData CreateMeleeHitArcMasterDataBasedOnCharacterBodyType()
        {
            return meleeHitArcMasterDataProvider.CreateFemaleCharacterOneMeleeHitArcMasterData();
        }

        private PlayerCharacter CreatePlayerCharacterFromStartingStats(CharacterClasses characterClass, CharacterCreationMasterData playerCharacterBaseStats)
        {
            CharacterClassMasterData playerCharacterStartingStats = playerCharacterBaseStats.CharacterClassMasterData;
            MeleeHitArcMasterData meleeHitArcMasterData = playerCharacterBaseStats.MeleeHitArcMasterData;

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

            MeleeHitArcProperties meleeHitArcProperties = new MeleeHitArcProperties();

            meleeHitArcProperties.HitArcStartAngle = meleeHitArcMasterData.HitArcStartAngle;
            meleeHitArcProperties.HitArcEndAngle = meleeHitArcMasterData.HitArcEndAngle;
            meleeHitArcProperties.HitArcRadius = meleeHitArcMasterData.HitArcRadius;
            meleeHitArcProperties.HitArcCenterXOffset = meleeHitArcMasterData.HitArcCenterXOffset;
            meleeHitArcProperties.HitArcCenterYOffset = meleeHitArcMasterData.HitArcCenterYOffset;
            
            startingStats.DeriveStats();
            startingStats.FullHeal();

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetFacingDirection(FacingDirection.RIGHT)
                .SetCharacterClass(characterClass)
                .SetPlayerCharacterBaseStats(startingStats)
                .SetMeleeHitArcProperties(meleeHitArcProperties)
                .Build();            
        }
    }
}