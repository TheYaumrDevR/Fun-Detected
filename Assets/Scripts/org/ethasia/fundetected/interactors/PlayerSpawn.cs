namespace Org.Ethasia.Fundetected.Interactors
{
    public struct PlayerSpawn
    {
        public bool IsSet
        {
            get;
            private set;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public PlayerSpawn(int x, int y)
        {
            X = x;
            Y = y;
            IsSet = true;
        }

        public static PlayerSpawn CreateUnset()
        {
            PlayerSpawn result = new PlayerSpawn(0, 0);
            result.IsSet = false;

            return result;
        }
    }
}