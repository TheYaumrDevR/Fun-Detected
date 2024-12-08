using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MapDefinitionGatewayMock : IMapDefinitionGateway
    {
        public MapDefinition LoadMapDefinition(string mapName)
        {
            // Setup test map definition
            MapDefinition result = new MapDefinition(11);

            result.Chunks.Add(CreateTestChunkOne());
            result.Chunks.Add(CreateTestChunkTwo());
            result.Chunks.Add(CreateTestChunkThree());

            SpawnableMonster fireMage = new SpawnableMonster("Fire Mage", 200);
            SpawnableMonster wolf = new SpawnableMonster("Wolf", 800);

            result.SpawnableMonsters.Add(fireMage);
            result.SpawnableMonsters.Add(wolf);   

            return result;         
        }

        private Chunk CreateTestChunkOne()
        {
            Spawner spawner1 = new Spawner(5, 36);
            Spawner spawner2 = new Spawner(15, 36);
            Spawner spawner3 = new Spawner(25, 36);
            Spawner spawner4 = new Spawner(35, 36);
            Spawner spawner5 = new Spawner(45, 26);
            Spawner spawner6 = new Spawner(55, 26);
            Spawner spawner7 = new Spawner(65, 26);
            Spawner spawner8 = new Spawner(75, 26);

            MapChunkProperties mapChunkProperties = new MapChunkProperties("testChunkOne", PlayerSpawn.CreateUnset());
            mapChunkProperties.Spawners.Add(spawner1);
            mapChunkProperties.Spawners.Add(spawner2);
            mapChunkProperties.Spawners.Add(spawner3);
            mapChunkProperties.Spawners.Add(spawner4);
            mapChunkProperties.Spawners.Add(spawner5);
            mapChunkProperties.Spawners.Add(spawner6);
            mapChunkProperties.Spawners.Add(spawner7);
            mapChunkProperties.Spawners.Add(spawner8);

            Collision collision1 = new Collision.Builder()
                .SetStartX(0)
                .SetStartY(26)
                .SetWidth(3)
                .SetHeight(2)
                .Build();

            Collision collision2 = new Collision.Builder()
                .SetStartX(40)
                .SetStartY(16)
                .SetWidth(2)
                .SetHeight(3)
                .Build();    

            mapChunkProperties.CollisionProperties.Add(collision1);
            mapChunkProperties.CollisionProperties.Add(collision2);

            Chunk result = new Chunk(-1, 0);
            result.PropertiesOfPossibleChunks.Add(mapChunkProperties);

            return result;
        }

        private Chunk CreateTestChunkTwo()
        {
            Spawner spawner1 = new Spawner(15, 56);
            Spawner spawner2 = new Spawner(25, 56);
            Spawner spawner3 = new Spawner(35, 56);
            Spawner spawner4 = new Spawner(45, 56);
            Spawner spawner5 = new Spawner(55, 56);
            Spawner spawner6 = new Spawner(65, 56);
            Spawner spawner7 = new Spawner(75, 56);

            MapChunkProperties mapChunkProperties = new MapChunkProperties("testChunkTwo", PlayerSpawn.CreateUnset());
            mapChunkProperties.Spawners.Add(spawner1);
            mapChunkProperties.Spawners.Add(spawner2);
            mapChunkProperties.Spawners.Add(spawner3);
            mapChunkProperties.Spawners.Add(spawner4);
            mapChunkProperties.Spawners.Add(spawner5);
            mapChunkProperties.Spawners.Add(spawner6);
            mapChunkProperties.Spawners.Add(spawner7);    

            Collision collision1 = new Collision.Builder()
                .SetStartX(0)
                .SetStartY(36)
                .SetWidth(1)
                .SetHeight(2)
                .Build();

            Collision collision2 = new Collision.Builder()
                .SetStartX(10)
                .SetStartY(46)
                .SetWidth(2)
                .SetHeight(1)
                .Build();    

            mapChunkProperties.CollisionProperties.Add(collision1);
            mapChunkProperties.CollisionProperties.Add(collision2);                 

            Chunk result = new Chunk(0, 0);
            result.PropertiesOfPossibleChunks.Add(mapChunkProperties);

            return result;
        }   

        private Chunk CreateTestChunkThree()
        {
            Spawner spawner1 = new Spawner(5, 56);
            Spawner spawner2 = new Spawner(15, 56);
            Spawner spawner3 = new Spawner(25, 56);
            Spawner spawner4 = new Spawner(35, 56);
            Spawner spawner5 = new Spawner(45, 56);
            Spawner spawner6 = new Spawner(55, 56);
            Spawner spawner7 = new Spawner(65, 56);
            Spawner spawner8 = new Spawner(75, 56);

            MapChunkProperties mapChunkProperties = new MapChunkProperties("testChunkThree", PlayerSpawn.CreateUnset());
            mapChunkProperties.Spawners.Add(spawner1);
            mapChunkProperties.Spawners.Add(spawner2);
            mapChunkProperties.Spawners.Add(spawner3);
            mapChunkProperties.Spawners.Add(spawner4);
            mapChunkProperties.Spawners.Add(spawner5);
            mapChunkProperties.Spawners.Add(spawner6);
            mapChunkProperties.Spawners.Add(spawner7);         
            mapChunkProperties.Spawners.Add(spawner8);    

            Chunk result = new Chunk(1, 0);
            result.PropertiesOfPossibleChunks.Add(mapChunkProperties);

            return result;
        }             
    }
}