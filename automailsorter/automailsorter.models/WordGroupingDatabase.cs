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
                    "adidas",
                    "hard-wear.nl"
                }
            },
            { "developer", new List<string>()
                {
                    "devpost",
                    "acm",
                    "github",
                    "iohk"
                }
            },
            { "finance", new List<string>()
                {
                    "iuvo",
                    "bitbns",
                    "nexo",
                    "abn amro",
                    "mintos",
                    "lendermarket",
                    "trading 212",
                    "plus500",
                    "degiro"
                }
            },
            { "management", new List<string>()
                {
                    "pakket",
                    "factuur",
                    "bestelling",
                    "linkedin",
                    "tickets"
                }
            },
            { "advertisement", new List<string>()
                {
                    "free"
                }
            },
            { "entertainment", new List<string>()
                {
                    "straf_werk",
                    "into the woods",
                    "festival"
                }
            },
            { "gezondheid", new List<string>()
                {
                    "ggd",
                    "pearle",
                    "festival"
                }
            }
        };
    }
}
