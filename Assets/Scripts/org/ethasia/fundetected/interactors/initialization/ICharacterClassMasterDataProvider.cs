namespace Org.Ethasia.Fundetected.Interactors.Initialization
{
    public interface ICharacterClassMasterDataProvider
    {
        CharacterClassMasterData CreateJockMasterData();
        CharacterClassMasterData CreateDuelistMasterData(); 
        CharacterClassMasterData CreateBattleMageMasterData(); 
        CharacterClassMasterData CreateZoomerMasterData(); 
        CharacterClassMasterData CreateMagicianMasterData();    
        CharacterClassMasterData CreateCuckMasterData();        
    }
}