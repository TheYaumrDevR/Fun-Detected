using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class SoundPlayer : MonoBehaviour, ISoundPlayer
    {
        private static SoundPlayer instance;

        public AudioSource sceneAudioSource;
        public AudioClip enemyHitSound;

        public static SoundPlayer GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void PlayEnemyHitSound()
        {
            sceneAudioSource.PlayOneShot(enemyHitSound);
        }
    }
}