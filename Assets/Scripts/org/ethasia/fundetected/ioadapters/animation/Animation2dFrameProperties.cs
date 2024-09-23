namespace Org.Ethasia.Fundetected.Ioadapters.Animation
{
    public struct Animation2dFrameProperties
    {
        public int FrameIndex
        {
            get;
            private set;
        }

        public bool HasImage
        {
            get;
            private set;
        }

        public string SoundMethodId
        {
            get;
            set;
        }

        public Animation2dFrameProperties(int frameIndex, bool hasImage)
        {
            FrameIndex = frameIndex;
            HasImage = hasImage;
            SoundMethodId = "";
        }
    }
}