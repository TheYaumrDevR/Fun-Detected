namespace Org.Ethasia.Fundetected.Interactors
{
    public struct SpawnableMonster
    {
        public string Name
        {
            get;
        }

        public int SpawnChanceMillis
        {
            get;
        }

        public SpawnableMonster(string name, int spawnChanceMillis)
        {
            Name = name;
            SpawnChanceMillis = spawnChanceMillis;
        }
    }
}