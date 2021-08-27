using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.models
{
    public static class UnreadMailToMapResult
    {
        public static Dictionary<Mail, List<string>> labeledMailList = new Dictionary<Mail, List<string>>();
    }
}
