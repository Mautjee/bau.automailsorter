using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automailsorter.models
{
    public class Mail
    {
        public MailAddress fromAddress { get; set; }
        public string title { get; set; }
    }

    public class MailAddress
    {
        public string department { get; }
        public string domain { get; }
        public string tld { get; }

        public MailAddress(string mailAddress)
        {
            string[] splittedAddress = mailAddress.Split(new[] { '@', ',' });
            this.department = splittedAddress[0];
            this.domain = splittedAddress[1];
            this.tld = splittedAddress[2];
        }

        public string getMailAddress()
        {
            return department + '@' + domain + '.' + tld;
        }
    }
}
