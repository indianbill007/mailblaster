using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocioBoardInvitationMailSender.Domain
{
    class Mantaemail
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Email { set; get; }
        public int Status { set; get; }
        public int Bounce { set; get; }
        public int Spam { set; get; }
        public int IsInvalid { set; get; }
    }
}
