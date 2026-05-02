using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public class DropItemInteractor : IDropItemInteractor
    {
        public void DropItemFromMonster(Item item, string monsterId)
        {
            Area.ActiveArea.AddItem(item);
            ShowDroppedItem(item);
            PlayItemDropSound();
        }

        public void DropItemFromPlayer(Item item)
        {
            Area.ActiveArea.AddItem(item);
            ShowDroppedItem(item);
            PlayItemDropSound();
        }

        private void ShowDroppedItem(Item item)
        {
            IDroppedItemPresenter droppedItemPresenter = IoAdaptersFactoryForCore.GetInstance().GetDroppedItemPresenterInstance();

            ItemDropPresentationInformation itemDropInfo = new ItemDropPresentationInformation();
            itemDropInfo.UniqueId = item.UniqueId;
            itemDropInfo.BaseTypeOrUniqueName = item.Name;
            itemDropInfo.PositionX = item.CollisionShape.Position.X;
            itemDropInfo.PositionY = item.CollisionShape.Position.Y;

            droppedItemPresenter.PresentItemDrop(itemDropInfo);
        }

        private void PlayItemDropSound(string individualId)
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            soundPresenter.PlayItemDropSound(individualId);
        }

        private void PlayItemDropSound()
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            soundPresenter.PlayItemDropSound();
        }
    }
}