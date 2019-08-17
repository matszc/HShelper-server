using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HShelper_server.Models
{
    public class Card
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public int dbfId { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public string rarity { get; set; }
        public int attack { get; set; }
        public string cardClass { get; set; }
        public string faction { get; set; }
        public int health { get; set; }
        public string set { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public bool collectible { get; set; }
        public string text { get; set; }
        public string[] mechanics { get; set; }
        public string artist { get; set; }
        public string flavor { get; set; }
        public Object playRequirements { get; set; }
        public string[] referencedTags { get; set; }
        public string race { get; set; }
        public bool elite { get; set; }
        public string targetingArrowText { get; set; }
        public int durability { get; set; }
        public int overload { get; set; }
        public int spellDamage { get; set; }
        public string collectionText { get; set; }
        public int armor { get; set; }
        public string[] entourage { get; set; }
        public int puzzleType { get; set; }
        public bool hideStats { get; set; }
        public string howToEarn { get; set; }
        public string howToEarnGolden { get; set; }
        public string[] classes { get; set; }
        public string multiClassGroup { get; set; }
        public string questReward { get; set; }
    }
}
