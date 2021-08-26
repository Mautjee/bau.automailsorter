using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.models
{
    public static class WordGroupingDatabase
    {
        public static Dictionary<string, List<string>> wordGroups = new Dictionary<string, List<string>>()
        {
            { "food", new List<string>()
                {
                    "uber",
                    "deliveroo",
                    "thuisbezorgd"
                } 
            },
            { "shopping", new List<string>()
                {
                    "aliexpress",
                    "zalando",
                    "ticketswap",
                    "adidas"
                }
            }
        };
    }
}
