using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Mocks
{
    public class DropItemInteractorMock : IDropItemInteractor
    {
        public int DropItemFromMonsterCallCount
        {
            get;
            private set;
        }

        public int DropItemFromPlayerCallCount
        {
            get;
            private set;
        }

        public void DropItemFromMonster(Item item, string monsterId)
        {
            DropItemFromMonsterCallCount++;
        }

        public void DropItemFromPlayer(Item item)
        {
            DropItemFromPlayerCallCount++;
        }

        public void Reset()
        {
            DropItemFromMonsterCallCount = 0;
            DropItemFromPlayerCallCount = 0;
        }
    }
}