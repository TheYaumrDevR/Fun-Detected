using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimationFrame
    {
        public Sprite Sprite
        {
            get;
            private set;
        }

        public bool HasSprite
        {
            get;
            private set;
        }

        public string SoundMethodId
        {
            get;
            private set;
        }

        public Sprite2dAnimationFrame() 
        {
            HasSprite = false;
            SoundMethodId = "";
        } 

        public Sprite2dAnimationFrame(Sprite sprite)
        {
            Sprite = sprite;
            HasSprite = true;
            SoundMethodId = "";
        }

        public Sprite2dAnimationFrame(Sprite sprite, string soundMethodId)
        {
            Sprite = sprite;
            HasSprite = true;
            SoundMethodId = soundMethodId;
        }

        public void PlayFrameTransitionSoundEffect(string audioSourceId)
        {
            if ("" != SoundMethodId)
            {
                SoundPlayer.GetInstance().CallSoundMethodById(SoundMethodId, audioSourceId);
            }
        }
    }
}