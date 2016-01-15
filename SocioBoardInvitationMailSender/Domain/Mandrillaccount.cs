using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocioBoardInvitationMailSender.Domain
{
    class Mandrillaccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
        public string Sent { get; set; }
        public string Opens { get; set; }
        public string Clicks { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
