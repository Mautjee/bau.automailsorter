using automailsorter.services.IMAP;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automailsorter.logic.Listeners
{
    public class UnreadMailToMapListener : IJobListener
    {
        public string Name { get; }
        public IConnector _conn { get; }

        public UnreadMailToMapListener(string name, IConnector conn)
        {
            Name = name;
            _conn = conn;
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            _conn.connectMailBox();
            var list = _conn.getUnreadInboxMessages();
            foreach (var mail in list)
            {
                Console.WriteLine(mail.fromAddress.getMailAddress());
            }
            _conn.disconnectMailBox();

            return Task.CompletedTask;
        }
    }

}
