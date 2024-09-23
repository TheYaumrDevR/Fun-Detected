using System;
using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class SoundPlayer : MonoBehaviour, ISoundPlayer
    {
        private static SoundPlayer instance;
        private Dictionary<string, AudioSource> audioSourcesById;
        private Dictionary<string, Action<string>> soundMethodsById;

        public AudioClip enemyHitSound;
        public AudioClip swingSoundOne;
        public AudioClip swingSoundTwo;

        public static SoundPlayer GetInstance()
        {
            return instance;
        }

        public SoundPlayer()
        {
            soundMethodsById = new Dictionary<string, Action<string>>();
            soundMethodsById.Add("PlayRandomSwingSound", PlayRandomSwingSound);
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

        public void PlayEnemyHitSound(string audioSourceId)
        {
            if (audioSourcesById.ContainsKey(audioSourceId))
            {
                audioSourcesById[audioSourceId].PlayOneShot(enemyHitSound);
            }
        }

        public void CallSoundMethodById(string soundMethodId, string audioSourceId)
        {
            if (soundMethodsById.ContainsKey(soundMethodId))
            {
                soundMethodsById[soundMethodId](audioSourceId);
            }
        }

        private void PlayRandomSwingSound(string audioSourceId)
        {
            IRandomNumberGenerator rng = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
            int randomNumber = rng.GenerateRandomPositiveInteger(1);

            if (audioSourcesById.ContainsKey(audioSourceId))
            {
                if (0 == randomNumber)
                {
                    audioSourcesById[audioSourceId].PlayOneShot(swingSoundOne);
                }
                else
                {
                    audioSourcesById[audioSourceId].PlayOneShot(swingSoundTwo);
                }
            }
        }
    }
}