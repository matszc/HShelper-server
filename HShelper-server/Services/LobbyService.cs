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
        public async Task<Lobby> CreateLobbyAsync(ConfigData config)
        {
            var result = new Lobby {
                id = Guid.NewGuid().ToString().Substring(0,8),
                config = config.config,
                status = "pending",
                players = new List<Player> { },
                creationDate = DateTime.Now.ToLocalTime()
            };
            result.players.Add(new Player {
                btag = config.player
            });
               await _lobby.InsertOneAsync(result);

            return result;
        }
        public async Task<Lobby> GetSingleLobbyAsync(string id)
        {
            return await _lobby.Find(lobby => lobby.id == id).SingleOrDefaultAsync();
        }
        public async Task<List<Lobby>> GetAllLobbyAsync()
        {
            return await _lobby.Find(lobby => lobby.status == "pending").ToListAsync();
        }
        public async Task<Lobby> UpdateLobbyAsync(Lobby lobby)
        {
            try
            {
                return await _lobby.FindOneAndReplaceAsync(l => l.id == lobby.id, lobby);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
