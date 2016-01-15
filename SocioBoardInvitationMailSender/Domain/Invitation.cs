using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocioBoardInvitationMailSender.Domain
{
    class Invitation
    {
        public int Id { get; set; }
        public string InvitationBody { get; set; }
        public string Subject { get; set; }
        public string SenderName { get; set; }
        public string FriendName { get; set; }
        public string SenderEmail { get; set; }
        public string FriendEmail { get; set; }
        public DateTime SaveDate { get; set; }
        public string Status { get; set; }
        public int MandrillId { get; set; }
        public DateTime MandrillSendDate { get; set; }
    }
}
