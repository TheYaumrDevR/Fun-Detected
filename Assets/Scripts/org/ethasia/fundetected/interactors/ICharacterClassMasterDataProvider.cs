namespace Org.Ethasia.Fundetected.Interactors
{
    public interface ICharacterClassMasterDataProvider
    {
        CharacterClassMasterData CreateStrongManMasterData();
        CharacterClassMasterData CreateDuelistMasterData(); 
        CharacterClassMasterData CreateBattleMageMasterData(); 
        CharacterClassMasterData CreateZoomerMasterData(); 
        CharacterClassMasterData CreateMagicianMasterData();    
        CharacterClassMasterData CreateCuckMasterData();        
    }
}