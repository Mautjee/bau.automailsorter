using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.models
{
    public class ConnectionConfiguration
    {
        public string server { get; set; }
        public int port { get; set; }
        public string user { get; set; }
        public string password { get; set; }
    }
}
