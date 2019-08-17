using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HShelper_server.Models
{
    public class Lobby
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string id { get; set; }
        public ConfigLobby config { get; set; }
        public List<Player> players { get; set; }
        public string status { get; set; }
        public DateTime creationDate { get; set; }
    }
    //public class Lobby1
    //{
    //    public string _id { get; set; }
    //    public string id { get; set; }
    //    public ConfigLobby config { get; set; }
    //    public List<Player> players { get; set; }
    //    public string status { get; set; }
    //    public DateTime creationDate { get; set; }
    //}
    public class ConfigLobby
    {
        public string type { get; set; }
        public bool openDecklist { get; set; }
        public int picks { get; set; }
        public int bans { get; set; }
    }
    public class ConfigData
    {
        public string player { get; set; }
        public ConfigLobby config { get; set; }
    }
}
