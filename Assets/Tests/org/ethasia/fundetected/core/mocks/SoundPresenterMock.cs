using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Items;

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

        public void PlayItemDropSound()
        {
            playItemDropSoundCallCount++;
        }

        public int GetPlayItemDropSoundCallCount()
        {
            return playItemDropSoundCallCount;
        }

        public void PlayNormalItemDroppedSound()
        {
        }

        public void PlayDroppedItemPickedUpSound()
        {
        }

        public void PlayInventoryGrabItemSound()
        {
        }

        public void PlayItemMaterialSound(ItemMaterials itemMaterial)
        {
        }

        public void ResetMock()
        {
            playItemDropSoundCallCount = 0;
        }
    }
}