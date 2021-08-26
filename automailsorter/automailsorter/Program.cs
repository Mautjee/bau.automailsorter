using System;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;

namespace automailsorter
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var client = new ImapClient())
			{
				client.Connect("imap.strato.com", 993, true);

				client.Authenticate("joey", "password");

				// The Inbox folder is always available on all IMAP servers...
				var inbox = client.Inbox;
				inbox.Open(FolderAccess.ReadOnly);

				Console.WriteLine("Total messages: {0}", inbox.Count);
				Console.WriteLine("Recent messages: {0}", inbox.Recent);

				for (int i = 0; i < inbox.Count; i++)
				{
					var message = inbox.GetMessage(i);
					Console.WriteLine("Subject: {0}", message.Subject);
				}

				client.Disconnect(true);
			}
		}
    }
}
