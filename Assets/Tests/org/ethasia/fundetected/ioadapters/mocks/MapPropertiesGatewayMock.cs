using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MapPropertiesGatewayMock : IMapPropertiesGateway
    {
        public MapProperties LoadMapProperties(string mapName)
        {
            MapProperties result = new MapProperties.Builder()
                .SetWidth(300)
                .SetHeight(100)
                .SetLowestScreenX(0)
                .SetLowestScreenY(0)
                .SetMaximumMonsters(11)
                .Build();

            SpawnableMonster fireMage = new SpawnableMonster("Fire Mage", 200);
            SpawnableMonster wolf = new SpawnableMonster("Wolf", 800);

            result.SpawnableMonsters.Add(fireMage);
            result.SpawnableMonsters.Add(wolf);

            Spawner spawner1 = new Spawner(10, 20);
            Spawner spawner2 = new Spawner(20, 25);
            Spawner spawner3 = new Spawner(30, 25);
            Spawner spawner4 = new Spawner(40, 25);
            Spawner spawner5 = new Spawner(50, 25);
            Spawner spawner6 = new Spawner(60, 25);
            Spawner spawner7 = new Spawner(70, 25);
            Spawner spawner8 = new Spawner(80, 25);
            Spawner spawner9 = new Spawner(90, 25);
            Spawner spawner10 = new Spawner(100, 25);
            Spawner spawner11 = new Spawner(110, 25);
            Spawner spawner12 = new Spawner(120, 35);
            Spawner spawner13 = new Spawner(130, 35);
            Spawner spawner14 = new Spawner(140, 35);
            Spawner spawner15 = new Spawner(150, 35);
            Spawner spawner16 = new Spawner(160, 35);
            Spawner spawner17 = new Spawner(170, 35);
            Spawner spawner18 = new Spawner(180, 35);
            Spawner spawner19 = new Spawner(190, 35);
            Spawner spawner20 = new Spawner(200, 35);
            Spawner spawner21 = new Spawner(210, 35);

            result.Spawners.Add(spawner1);
            result.Spawners.Add(spawner2);
            result.Spawners.Add(spawner3);
            result.Spawners.Add(spawner4);
            result.Spawners.Add(spawner5);
            result.Spawners.Add(spawner6);
            result.Spawners.Add(spawner7);
            result.Spawners.Add(spawner8);
            result.Spawners.Add(spawner9);
            result.Spawners.Add(spawner10);
            result.Spawners.Add(spawner11);
            result.Spawners.Add(spawner12);
            result.Spawners.Add(spawner13);
            result.Spawners.Add(spawner14);
            result.Spawners.Add(spawner15);
            result.Spawners.Add(spawner16);
            result.Spawners.Add(spawner17);
            result.Spawners.Add(spawner18);
            result.Spawners.Add(spawner19);
            result.Spawners.Add(spawner20);
            result.Spawners.Add(spawner21);

            return result;
        }
    }
}