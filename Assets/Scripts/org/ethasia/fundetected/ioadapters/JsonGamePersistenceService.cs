using System;
using System.IO;

using Org.Ethasia.Fundetected.Interactors.Persistence;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class JsonGamePersistenceService : IGamePersistenceService
    {
        private const string FILE_EXTENSION = ".json";
        private const string SAVE_DIRECTORY_NAME = "SaveGames";

        public void Save(GamePersistenceContext context)
        {
            if (string.IsNullOrEmpty(context.Player.Id))
            {
                throw new ArgumentException("Player persistence context needs a player with a unique id.");
            }

            TechnicalFactory technicalFactory = TechnicalFactory.GetInstance();

            IJsonSerializer jsonSerializer = technicalFactory.GetJsonSerializerInstance();
            string json = jsonSerializer.Serialize(context.Player, true);

            string directory = Path.Combine(technicalFactory.GetSaveLocationProviderInstance().GetBaseSaveDirectory(), SAVE_DIRECTORY_NAME);

            technicalFactory.GetFileStoreInstance().Save(directory, context.Player.Id + FILE_EXTENSION, json);
        }
    }
}