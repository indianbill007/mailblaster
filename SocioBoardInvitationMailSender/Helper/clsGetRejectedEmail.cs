using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace SocioBoardInvitationMailSender.Helper
{
    class clsGetRejectedEmail
    {
        public static string WebRequestForMandrill(string url)
        {
            string _Content = "";
            try
            {
                //string url = "https://mandrillapp.com/api/1.0/rejects/list.json?key=" + ApiKey.Trim() + "&include_expired=true";
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.Method = "GET";
                httpRequest.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse httResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httResponse.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream, Encoding.Default);
                _Content = responseStreamReader.ReadToEnd();
                responseStreamReader.Close();
                responseStream.Close();
                httResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return _Content;
        }

        public static string GetUrlToGetBounces(string ApiKey)
        {
            string url = "https://mandrillapp.com/api/1.0/rejects/list.json?key=" + ApiKey.Trim() + "&include_expired=true";
            return url;
        }

        public static string GetUrlToGetClicks(string ApiKey)
        {
            string url = "https://mandrillapp.com/api/1.0/users/senders.json?key=" + ApiKey.Trim();
            return url;
        }
    }
}
