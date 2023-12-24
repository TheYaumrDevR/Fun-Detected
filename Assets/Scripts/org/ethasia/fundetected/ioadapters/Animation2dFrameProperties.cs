namespace Org.Ethasia.Fundetected.Ioadapters
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

        public Animation2dFrameProperties(int frameIndex, bool hasImage)
        {
            FrameIndex = frameIndex;
            HasImage = hasImage;
        }
    }
}