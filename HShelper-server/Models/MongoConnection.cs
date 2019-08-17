using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HShelper_server.Models
{
    public class MongoConnection: IMongoConnection
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
    public interface IMongoConnection
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}
