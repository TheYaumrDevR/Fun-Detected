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
        private Dictionary<string, AudioSource> permanentAudioSourcesById;
        private Dictionary<string, Action<string>> soundMethodsById;

        public AudioSource globalAudioSource;
        public AudioClip enemyHitSound;
        public AudioClip swingSoundOne;
        public AudioClip swingSoundTwo;
        public AudioClip portalTransitionSound;
        public AudioClip healingWellUseSound;

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

        public void AddPermanentAudioSource(string audioSourceId, AudioSource audioSource)
        {
            if (null == permanentAudioSourcesById)
            {
                permanentAudioSourcesById = new Dictionary<string, AudioSource>();
            }

            permanentAudioSourcesById.Add(audioSourceId, audioSource);
        }

        public void ClearAudioSources()
        {
            audioSourcesById.Clear();
        }

        public void PlayEnemyHitSound(string audioSourceId)
        {
            AudioSource audioSource = GetAudioSourceById(audioSourceId);

            if (null != audioSource)
            {
                audioSource.PlayOneShot(enemyHitSound);
            }
        }

        public void PlayPortalTransitionSound()
        {
            globalAudioSource.PlayOneShot(portalTransitionSound);
        }

        public void PlayHealingWellUseSound(string audioSourceId)
        {
            AudioSource audioSource = GetAudioSourceById(audioSourceId);

            if (null != audioSource)
            {
                audioSource.PlayOneShot(healingWellUseSound);
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

            AudioSource audioSource = GetAudioSourceById(audioSourceId);

            if (null != audioSource)
            {
                if (0 == randomNumber)
                {
                    audioSource.PlayOneShot(swingSoundOne);
                }
                else
                {
                    audioSource.PlayOneShot(swingSoundTwo);
                }
            }
        }

        private AudioSource GetAudioSourceById(string audioSourceId)
        {
            if (null != audioSourcesById && audioSourcesById.ContainsKey(audioSourceId))
            {
                return audioSourcesById[audioSourceId];
            }         
            else if (null != permanentAudioSourcesById && permanentAudioSourcesById.ContainsKey(audioSourceId))
            {
                return permanentAudioSourcesById[audioSourceId];                
            }

            return null;
        }
    }
}