using HShelper_server.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HShelper_server.Services
{
    public class LobbyService
    {
        private readonly IMongoCollection<Lobby> _lobby;
        public LobbyService(IMongoConnection settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _lobby = database.GetCollection<Lobby>("lobby");
        }
        public Lobby createLobby(ConfigData config)
        {
            var result = new Lobby {
                id = Guid.NewGuid().ToString().Substring(0,8),
                config = config.config,
                status = "pending",
                players = new List<string> { },
                creationDate = DateTime.Now.ToLocalTime()
            };
            result.players.Add(config.player);
            try
            {
                _lobby.InsertOne(result);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
