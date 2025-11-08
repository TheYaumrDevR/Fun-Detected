using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map
{

    public class ItemPresentationUpdateEventObserver : IPhysicsBodyEventObserver
    {
        private Item item;

        public ItemPresentationUpdateEventObserver(Item item)
        {
            this.item = item;
        }

        public void OnEventTriggered()
        {
            IDroppedItemPresenter droppedItemPresenter = IoAdaptersFactoryForCore.GetInstance().GetDroppedItemPresenterInstance();
            
            ItemDropPresentationInformation itemDropInfo = new ItemDropPresentationInformation();
            itemDropInfo.UniqueId = item.UniqueId;
            itemDropInfo.BaseTypeOrUniqueName = item.Name;
            itemDropInfo.PositionY = item.CollisionShape.Position.Y + item.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter;

            droppedItemPresenter.UpdateItemPresentationWhenRestingOnGround(itemDropInfo);
        }
    }
}