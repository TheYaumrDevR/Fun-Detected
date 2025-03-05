namespace Org.Ethasia.Fundetected.Core
{
    public interface ISoundPresenter
    {
        void PlayEnemyHitSound(string audioSourceId);
        void PlayPortalTransitionSound();
        void PlayHealingWellUseSound(string audioSourceId);
    }
}