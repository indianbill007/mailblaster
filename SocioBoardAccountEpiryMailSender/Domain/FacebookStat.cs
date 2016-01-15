using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace SocioBoardAccountEpiryMailSender.Domain
{
    public class FacebookStat
    {
        public static string getFacebookResponse(string Url)
        {
            var facebooklistpagerequest = (HttpWebRequest)WebRequest.Create(Url);
            facebooklistpagerequest.Method = "GET";
            facebooklistpagerequest.Credentials = CredentialCache.DefaultCredentials;
            facebooklistpagerequest.AllowWriteStreamBuffering = true;
            facebooklistpagerequest.ServicePoint.Expect100Continue = false;
            facebooklistpagerequest.PreAuthenticate = false;
            string outputface = string.Empty;
            try
            {
                using (var response = facebooklistpagerequest.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                    {
                        outputface = stream.ReadToEnd();
                    }
                }
            }
            catch (Exception e) { }
            return outputface;
        }

        public JObject GetFacebookPageDetails(string ProfileId, string AccessToken)
        {
            string facebookpageUrl = "https://graph.facebook.com/v2.3/" + ProfileId + "?access_token=" + AccessToken;
            string outputfacepageUrl = getFacebookResponse(facebookpageUrl);
            JObject pageobj = JObject.Parse(outputfacepageUrl);
            return pageobj;
        }

        public int GetFacebookNewLiker(string ProfileId, string AccessToken, int days)
        {
            long since = DateTime.Now.AddDays(-days).ToUnixTimestamp();
            long until = DateTime.Now.ToUnixTimestamp();
            string facebooknewfanUrl = "https://graph.facebook.com/v2.3/" + ProfileId + "/insights/page_fan_adds?pretty=0&since=" + since.ToString() + "&suppress_http_code=1&until=" + until.ToString() + "&access_token=" + AccessToken;
            string outputface = getFacebookResponse(facebooknewfanUrl);
            JArray likesobj = JArray.Parse(JArray.Parse(JObject.Parse(outputface)["data"].ToString())[0]["values"].ToString());
            int likes = 0;
            foreach (JObject obj in likesobj)
            {
                likes += Int32.Parse(obj["value"].ToString());
            }
            return likes;
        }

        public int GetFacebookUnliker(string ProfileId, string AccessToken, int days)
        {
            long since = DateTime.Now.AddDays(-days).ToUnixTimestamp();
            long until = DateTime.Now.ToUnixTimestamp();
            string facebookunlikjeUrl = "https://graph.facebook.com/v2.3/" + ProfileId + "/insights/page_fan_removes?pretty=0&since=" + since.ToString() + "&suppress_http_code=1&until=" + until.ToString() + "&access_token=" + AccessToken;
            string outputfaceunlike = getFacebookResponse(facebookunlikjeUrl);
            JArray unlikesobj = JArray.Parse(JArray.Parse(JObject.Parse(outputfaceunlike)["data"].ToString())[0]["values"].ToString());
            int unlike = 0;
            foreach (JObject obj in unlikesobj)
            {
                unlike += Int32.Parse(obj["value"].ToString());
            }
            return unlike;
        }

        public int GetFacebookImpression(string ProfileId, string AccessToken, int days)
        {
            long since = DateTime.Now.AddDays(-days).ToUnixTimestamp();
            long until = DateTime.Now.ToUnixTimestamp();
            string facebookimpressionUrl = "https://graph.facebook.com/v2.3/" + ProfileId + "/insights/page_impressions?pretty=0&since=" + since.ToString() + "&suppress_http_code=1&until=" + until.ToString() + "&access_token=" + AccessToken;
            string outputfaceunimpression = getFacebookResponse(facebookimpressionUrl);
            JArray impressionobj = JArray.Parse(JArray.Parse(JObject.Parse(outputfaceunimpression)["data"].ToString())[0]["values"].ToString());
            int impression = 0;
            foreach (JObject obj in impressionobj)
            {
                impression +=Int32.Parse(obj["value"].ToString());
            }

            return impression;
        }
    }
}
