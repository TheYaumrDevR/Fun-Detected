using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PhysicsBody
    {
        private StopWatch stopWatch = new StopWatch();

        private IPhysicsBodyEventObserver stopFallingEventObserver;

        public int InitialVerticalVelocityUnitsPerSecond;

        public int OriginalPosY
        {
            get;
            private set;
        }

        public bool IsFalling
        {
            get;
            private set;
        } = false;

        public double TimePassedSinceVerticalMovementStart
        {
            get
            {
                return stopWatch.TimePassedSinceStart;
            }
        }

        public void RegisterStopFallingEventObserver(IPhysicsBodyEventObserver observer)
        {
            stopFallingEventObserver = observer;
        }

        public void StartFalling(int originalPosY)
        {
            IsFalling = true;
            OriginalPosY = originalPosY;
        }

        public void StopFalling()
        {
            stopWatch.Reset();
            IsFalling = false;

            if (null != stopFallingEventObserver)
            {
                stopFallingEventObserver.OnEventTriggered();
            }
        }

        public void Fall(double deltaTime)
        {
            if (IsFalling)
            {
                stopWatch.Tick(deltaTime);
            }
        }
    }
}