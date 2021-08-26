using automailsorter.services.Scheduler;
using automailsorter.services.IMAP;
using System;
using System.Threading.Tasks;
using automailsorter.logic.Jobs;
using automailsorter.logic.Listeners;

namespace automailsorter
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Setup access to mailbox of user
            IConnector conn = new ImapConnector(config =>
            {
                config.server = "imap.ethereal.email";
                config.port = 993;
                config.user = "casimer.dietrich85@ethereal.email";
                config.password = "cN83M1Uqx1bgPUnyVa";
            });

            // Schedule jobs, these trigger listeners which will sort the mailbox
            Scheduler scheduler = await Scheduler.InitialiseScheduler();

            var job = scheduler.createJob<GenericJob>("job-sortunreadmail");
            var trigger = scheduler.createTrigger("0 0/1 * * * ?", "trigger-sortunreadmail");
            await scheduler.scheduleJob(job, trigger);

            var listener = new UnreadMailToMapListener("listener-sortunreadmail", conn);
            scheduler.setJobListener(listener, "job-sortunreadmail");

            Console.ReadLine();
		}
    }
}
