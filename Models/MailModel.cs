using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ricco.Email.Models
{
    public class MailModel
    {
        public string SMTP_HOST { get; set; }
        public int SMTP_PORT { get; set; } //Default is 25
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }

        public string MessageBody { get; set; }
        public string MessageSubject { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
    }


}
