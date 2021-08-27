using automailsorter.models;
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
            // Iterate over all unread messages in the inbox
            foreach (Mail mail in list)
            {
                List<string> labels = new List<string>();
                foreach (string key in WordGroupingDatabase.wordGroups.Keys)
                {
                    foreach (string word in WordGroupingDatabase.wordGroups[key])
                    {
                        if (mail.title.ToLower().Contains(word) || mail.fromName.ToLower().Contains(word) || mail.fromAddress.getMailAddress().ToLower().Contains(word))
                        {
                            labels.Add(key);
                        }
                    }
                }
                // Only add mail to database if they can be categorized/labeled
                if (labels.Count > 0)
                {
                    UnreadMailToMapResult.labeledMailList.Add(mail, labels);
                }
            }
            _conn.disconnectMailBox();

            //foreach (Mail mail in UnreadMailToMapResult.labeledMailList.Keys)
            //{
            //    Console.WriteLine("[Title] : " + mail.title);
            //    Console.Write("[Labels] : ");
            //    UnreadMailToMapResult.labeledMailList[mail].ForEach(Console.WriteLine);
            //}

            return Task.CompletedTask;
        }
    }

}
