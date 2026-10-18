using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PhysicsBodyDropSoundPlayingEventObserver : IPhysicsBodyEventObserver
    {
        private Item item;

        public PhysicsBodyDropSoundPlayingEventObserver(Item item)
        {
            this.item = item;
        }

        public void OnEventTriggered()
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();

            switch (item.Potential)
            {
                case ItemPotential.LATENT:
                    soundPresenter.PlayLatentItemDroppedSound();
                    break;
                default:
                    soundPresenter.PlayNormalItemDroppedSound();
                    break;
            }
        }
    }
}