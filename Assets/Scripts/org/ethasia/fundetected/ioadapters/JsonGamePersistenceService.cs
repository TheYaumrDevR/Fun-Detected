using System;

using Org.Ethasia.Fundetected.Interactors.Persistence;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JsonGamePersistenceService : IGamePersistenceService
    {
        private const string FILE_EXTENSION = ".json";

        public void Save(GamePersistenceContext context)
        {
            if (string.IsNullOrEmpty(context.Player.Id))
            {
                throw new ArgumentException("Player persistence context needs a player with a unique id.");
            }

            TechnicalFactory technicalFactory = TechnicalFactory.GetInstance();

            IJsonSerializer jsonSerializer = technicalFactory.GetJsonSerializerInstance();
            string json = jsonSerializer.Serialize(context.Player, true);

            technicalFactory.GetFileStoreInstance().Save(context.Player.Id + FILE_EXTENSION, json);
        }
    }
}