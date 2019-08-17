using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HShelper_server.Models
{
    public class Player
    {
        public string btag { get; set; }
        public List<string> picks { get; set; }
        public List<string> bans { get; set; }
    }
}
