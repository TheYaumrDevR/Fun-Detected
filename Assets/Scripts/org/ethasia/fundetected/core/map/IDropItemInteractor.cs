using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IDropItemInteractor
    {
        void DropItemFromMonster(Item item, string monsterId);
        void DropItemFromPlayer(Item item);
    }
}