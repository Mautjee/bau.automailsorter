using automailsorter.models;
using System.Collections.Generic;

namespace automailsorter.services.IMAP
{
    public interface IConnector
    {
        void connectMailBox();
        void disconnectMailBox();
        List<Mail> getUnreadInboxMessages();
    }
}