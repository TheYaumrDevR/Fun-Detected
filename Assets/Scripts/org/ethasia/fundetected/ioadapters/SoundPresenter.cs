using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class SoundPresenter : ISoundPresenter
    {
        public void PlayEnemyHitSound(string audioSourceId)
        {
            ISoundPlayer soundPlayer = TechnicalFactory.GetInstance().GetSoundPlayerInstance();

            if (null != soundPlayer)
            {
                soundPlayer.PlayEnemyHitSound(audioSourceId);
            }
        }
    }
}