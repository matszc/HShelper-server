using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using HShelper_server.Models;
using MongoDB.Driver;

namespace HShelper_server.Services
{
    public class CardService
    {
        private readonly IMongoCollection<Card> _cards;

        public CardService(IMongoConnection settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _cards = database.GetCollection<Card>("cards.collectible");
        }

        public List<Card> Get()
        {
            try
            {
                return _cards.Find(card => card.collectible == true).ToList();
            }
            catch
            {
                throw new Exception("Can't load resource");
            }
        }
    }
}
