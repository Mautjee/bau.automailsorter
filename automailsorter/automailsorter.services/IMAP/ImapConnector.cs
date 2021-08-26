using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using automailsorter.models;
using MimeKit;

namespace automailsorter.services.IMAP
{
    public class ImapConnector : IConnector
    {
        private ImapClient _client;
        private ConnectionConfiguration _config;

        public ImapConnector(Action<ConnectionConfiguration> configuration)
        {
            var config = new ConnectionConfiguration();
            configuration?.Invoke(config);

            this._config = config;
        }

        public void connectMailBox()
        {
            var client = new ImapClient();
            client.Connect(_config.server, _config.port, true);
            client.Authenticate(_config.user, _config.password);

            this._client = client;
        }

        public List<Mail> getUnreadInboxMessages()
        {
            List<Mail> mailList = new List<Mail>();

            var inbox = _client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            var query = SearchQuery.NotSeen.And(SearchQuery.DeliveredAfter(DateTime.Parse("2021-08-01")));

            foreach (var uid in inbox.Search(query))
            {
                var message = inbox.GetMessage(uid);
                MailAddress mailAddress = new MailAddress(message.From.OfType<MailboxAddress>().Single().Address.ToString());
                Mail mail = new Mail(mailAddress, message.From[0].Name, message.Subject);
                mailList.Add(mail);
            }

            return mailList;
        }

        public void disconnectMailBox()
        {
            _client.Disconnect(true);
        }
    }
}
