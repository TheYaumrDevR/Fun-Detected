using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class SoundPlayer : MonoBehaviour, ISoundPlayer
    {
        private static SoundPlayer instance;

        public AudioClip enemyHitSound;
        private Dictionary<string, AudioSource> audioSourcesById;

        public static SoundPlayer GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void AddAudioSource(string audioSourceId, AudioSource audioSource)
        {
            if (null == audioSourcesById)
            {
                audioSourcesById = new Dictionary<string, AudioSource>();
            }

            audioSourcesById.Add(audioSourceId, audioSource);
        }

        public void PlayEnemyHitSound(string individualEnemyId)
        {
            if (audioSourcesById.ContainsKey(individualEnemyId))
            {
                audioSourcesById[individualEnemyId].PlayOneShot(enemyHitSound);;
            }
        }
    }
}