namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PhysicsBodyDropSoundPlayingEventObserver : IPhysicsBodyEventObserver
    {
        public void OnEventTriggered()
        {
            ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
            soundPresenter.PlayNormalItemDroppedSound();
        }
    }
}