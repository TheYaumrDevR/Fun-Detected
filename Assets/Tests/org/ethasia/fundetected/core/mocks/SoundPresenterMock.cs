using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Core.Mocks
{
    public class SoundPresenterMock : ISoundPresenter
    {
        private int playItemDropSoundCallCount;

        public void PlayEnemyHitSound(string audioSourceId)
        {

        }

        public void PlayPortalTransitionSound()
        {
        }

        public void PlayHealingWellUseSound(string audioSourceId)
        {
        }

        public void PlayItemDropSound(string audioSourceId)
        {
            playItemDropSoundCallCount++;
        }

        public int GetPlayItemDropSoundCallCount()
        {
            return playItemDropSoundCallCount;
        }

        public void ResetMock()
        {
            playItemDropSoundCallCount = 0;
        }
    }
}