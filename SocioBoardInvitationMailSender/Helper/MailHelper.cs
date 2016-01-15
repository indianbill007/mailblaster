using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocioBoardInvitationMailSender.Helper
{
    class MailHelper
    {
        public static string SendMailByMandrill(string Host, int port, string from, string passsword, string to, string subject, string body, string SenderName)
        {
            
            
            string sendMailByMandrill = string.Empty;
            #region Mailsender
            try
            {
                Mandrill.EmailMessage message = new Mandrill.EmailMessage();
                message.from_email = from;
                message.from_name = SenderName;
                message.html = body;
                message.subject = subject;
                message.to = new List<Mandrill.EmailAddress>()
                {
                  new Mandrill.EmailAddress(to)
                };
                Mandrill.MandrillApi mandrillApi = new Mandrill.MandrillApi(passsword, false);
                var results = mandrillApi.SendMessage(message);

                foreach (var result in results)
                {
                    if (result.Status == Mandrill.EmailResultStatus.Invalid || result.Status == Mandrill.EmailResultStatus.Rejected)
                    {
                        sendMailByMandrill = "Invalid";
                    }
                    else
                    {
                        sendMailByMandrill = "Success";
                    }

                }
            #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //logger.Error(ex.Message);
            }

            return sendMailByMandrill;
        }
    }
}
