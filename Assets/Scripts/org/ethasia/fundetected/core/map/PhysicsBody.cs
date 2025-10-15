using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PhysicsBody
    {
        private StopWatch stopWatch = new StopWatch();
        private bool isFalling = false;
        public int OriginalPosY;
        public int InitialVerticalVelocityUnitsPerSecond;

        public double TimePassedSinceVerticalMovemeentStart
        {
            get
            {
                return stopWatch.TimePassedSinceStart;
            }
        }

        public void StartFalling()
        {
            isFalling = true;
        }

        public void StopFalling()
        {
            stopWatch.Reset();
            isFalling = false;
        }

        public void Fall(double deltaTime)
        {
            if (isFalling)
            {
                stopWatch.Tick(deltaTime);
            }
        }
    }
}