using automailsorter.services.Scheduler;
using automailsorter.services.IMAP;
using System;
using System.Threading.Tasks;

namespace automailsorter
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            ImapConnector conn = new ImapConnector(config =>
            {
                config.server = "imap.ethereal.email";
                config.port = 993;
                config.user = "casimer.dietrich85@ethereal.email";
                config.password = "cN83M1Uqx1bgPUnyVa";
            });

            conn.connectMailBox();
            Console.WriteLine(conn.getUnreadInboxMessages());
            conn.disconnectMailBox();
		}
    }
}
