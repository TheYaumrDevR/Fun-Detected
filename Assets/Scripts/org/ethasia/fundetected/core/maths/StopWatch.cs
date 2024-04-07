namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StopWatch
    {
        public bool WasReset
        {
            get;
            private set;
        }

        public double TimePassedSinceStart
        {
            get;
            private set;
        }

        public void Tick(double deltaTime)
        {
            TimePassedSinceStart += deltaTime;
        }

        public void Reset()
        {
            TimePassedSinceStart = 0.0;
            WasReset = true;
        }
    }
}