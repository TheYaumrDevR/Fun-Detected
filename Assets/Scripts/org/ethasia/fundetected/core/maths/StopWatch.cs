namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StopWatch
    {
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
        }
    }
}