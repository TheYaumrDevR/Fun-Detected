namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface ISoundPlayer
    {
        void PlayEnemyHitSound(string individualEnemyId);
        void CallSoundMethodById(string soundMethodId, string audioSourceId);
    }
}