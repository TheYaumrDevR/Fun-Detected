namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface ISoundPlayer
    {
        void PlayEnemyHitSound(string individualEnemyId);
        void PlayPortalTransitionSound();
        void CallSoundMethodById(string soundMethodId, string audioSourceId);
        void PlayHealingWellUseSound(string audioSourceId);
    }
}