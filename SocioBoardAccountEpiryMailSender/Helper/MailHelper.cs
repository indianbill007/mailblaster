using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SendGridMail;
using System.Net.Mail;
using System.Net;
using SendGridMail.Transport;

namespace SocioBoardAccountEpiryMailSender.Helper
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
                message.from_email = "sumit@socioboard.com";
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

        public static string SendMailBySendGrid(string Html, string Subject, string UserId, string Password,string FromName, string FromEmail, string ToEmail)
        {
            string sendMailBySendGrid = string.Empty;
            try
            {
                //var smtp = new SmtpClient();
                //smtp.Port = 25;
                //smtp.Host = "smtp.sendgrid.net";
                SendGrid myMessage = SendGridMail.SendGrid.GetInstance();
                myMessage.AddTo(ToEmail);
                myMessage.From = new MailAddress(FromEmail);
                myMessage.Subject = Subject;

                //Add the HTML and Text bodies
                myMessage.Html = Html;

                //myMessage.InitializeFilters();
                var credentials = new NetworkCredential(UserId, Password);

                var transportWeb = SMTP.GetInstance(credentials);

                // Send the email.
                transportWeb.Deliver(myMessage);

                sendMailBySendGrid = "success";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                sendMailBySendGrid = "failed";
            }
            return sendMailBySendGrid;
           
        }

        public static string SendMailBySmtp(string html, string subject, string UserId, string Password, string tomail)
        {
            string response = "";
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(tomail);
                    mail.From = new MailAddress(UserId);
                    mail.Subject = subject;
                    mail.Body = html;
                    mail.IsBodyHtml = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.zoho.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(UserId, Password);
                    smtp.Send(mail);
                    response = "Success";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

            return response;
        }

    }
}
