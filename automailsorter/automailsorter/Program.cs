using automailsorter.services.Scheduler;
using automailsorter.services.IMAP;
using System;
using System.Threading.Tasks;
using automailsorter.logic.Jobs;
using automailsorter.logic.Listeners;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace automailsorter
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Setup access to mailbox of user
            IConnector conn = new ImapConnector(config =>
            {
                config.port = Int32.Parse(ConfigurationManager.AppSettings.Get("port"));
                config.server = ConfigurationManager.AppSettings.Get("server");
                config.user = ConfigurationManager.AppSettings.Get("user");
                config.password = ConfigurationManager.AppSettings.Get("password");
            });

            // Schedule jobs, these trigger listeners which will sort the mailbox
            Scheduler scheduler = await Scheduler.InitialiseScheduler();

            var job = scheduler.createJob<GenericJob>("job-sortunreadmail");
            var trigger = scheduler.createTrigger("0 0/1 * * * ?", "trigger-sortunreadmail");
            await scheduler.scheduleJob(job, trigger);

            Console.WriteLine(conn.ToString());

            var listener = new UnreadMailToMapListener("listener-sortunreadmail", conn);
            scheduler.setJobListener(listener, "job-sortunreadmail");

            Console.ReadLine();
		}
    }
}
