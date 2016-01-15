using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using SocioBoardAccountEpiryMailSender.Helper;
using SocioBoardAccountEpiryMailSender.Domain;
//using SocioBoardAccountEpiryMailSender.Model;
using Domain.Socioboard.Domain;
using SocioBoardAccountEpiryMailSender.Domain;
using Newtonsoft.Json.Linq;
namespace SocioBoardAccountEpiryMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountEpryMailSender objAccountEpryMailSender = new AccountEpryMailSender();
            objAccountEpryMailSender.MailSending();
        }
    }
    public class AccountEpryMailSender
    {
        public void MailSending()
        {
            Console.WriteLine("1. Account-Epiry-Mailer");
            Console.WriteLine("2. Connect-to-blog-and-twitter-Mailer");
            Console.WriteLine("3. Login-Reminder");
            Console.WriteLine("4. Daily-Social-Media-Stat");
            Console.WriteLine("5. Social-Media-Stat-7");
            Console.WriteLine("6. Social-Media-Stat-15");
            Console.WriteLine("7. Social-Media-Stat-30");
            Console.WriteLine("8. Social-Media-Stat-60");
            Console.WriteLine("9. Social-Media-Stat-90");
            string str = Console.ReadLine();
            string ActionType = string.Empty;
            switch (str)
            {
                case "1":
                    ActionType = "AccountEpiryMailer";
                    break;
                case "2":
                    ActionType = "ConnectToBlogMailer";
                    break;
                case "3":
                    ActionType = "LoginReminder";
                    break;
                case "4":
                    ActionType = "DailySocialMediaStat";
                    break;
                case "5":
                    ActionType = "SocialMediaStat_7";
                    break;
                case "6":
                    ActionType = "SocialMediaStat_15";
                    break;
                case "7":
                    ActionType = "SocialMediaStat_30";
                    break;
                case "8":
                    ActionType = "SocialMediaStat_60";
                    break;
                case "9":
                    ActionType = "SocialMediaStat_90";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(ActionType) && ActionType.Equals("AccountEpiryMailer"))
            {
                StartMailSender(ActionType);
            }
            else if (ActionType.Equals("ConnectToBlogMailer"))
            {
                StartBlogmailSending();
            }
            else if (ActionType.Equals("LoginReminder"))
            {
                DateTime _today = DateTime.Now.Date;
                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.Date.AddDays(7);
                            LoginReminder();
                        }
                        else
                        {
                            Thread.Sleep(600 * 5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Case Debug : " + ex.StackTrace);
                    }
                }
            }
            else if (ActionType.Equals("DailySocialMediaStat"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            DailySocialMediaStat();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Daily-Social-Media-Stat = >" + ex.Message);
                    }
                }
            }
            else if (ActionType.Equals("SocialMediaStat_7"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            SocialMediaStat_7();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Social-Media-Stat-7 = >" + ex.Message);
                    }
                }
            }
            else if (ActionType.Equals("SocialMediaStat_15"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            SocialMediaStat_15();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Social-Media-Stat-15 = >" + ex.Message);
                    }
                }
            }
            else if (ActionType.Equals("SocialMediaStat_30"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            SocialMediaStat_30();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Social-Media-Stat-30 = >" + ex.Message);
                    }
                }
            }
            else if (ActionType.Equals("SocialMediaStat_60"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            SocialMediaStat_60();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Social-Media-Stat-60 = >" + ex.Message);
                    }
                }
            }
            else if (ActionType.Equals("SocialMediaStat_90"))
            {
                DateTime _today = DateTime.Now.Date;

                while (true)
                {
                    try
                    {

                        if (_today == DateTime.Now.Date)
                        {
                            _today = DateTime.Now.AddDays(1).Date;
                            SocialMediaStat_90();
                        }
                        else
                        {
                            Thread.Sleep(600 * 1000);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Social-Media-Stat-90 = >" + ex.Message);
                    }
                }
            }
        }

        public void StartMailSender(string actiontype)
        {
            try
            {
                DateTime today = DateTime.Now.Date;
                while (true)
                {
                    if (actiontype == "AccountEpiryMailer")
                    {
                        if (today == DateTime.Now.Date)
                        {
                            today = DateTime.Now.Date.AddDays(1);
                            StartMailSending();
                        }
                        else
                        {
                            Thread.Sleep(60 * 5000);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Case Debug : " + ex.StackTrace);
            }
        }

        public void StartMailSending()
        {
            Console.WriteLine("<------------------------------------------------->");
            Console.WriteLine("<--------Start Account Expiry Mail Sending-------->");
            Console.WriteLine("<--------------" + DateTime.Now.Date + "-------------->");
            Console.WriteLine("<------------------------------------------------->");
            try
            {
                //UserRepository _UserRepo = new UserRepository();
                Api.User.User ApiUser = new Api.User.User();
                List<User> lstEmail = (List<User>)new JavaScriptSerializer().Deserialize(ApiUser.GetAllExpiredUser(""), typeof(List<User>));
                foreach (User _user in lstEmail)
                {
                    string rtn = MailSender.SendAccountExpiryMail(_user.UserName, _user.EmailId, "support@socioboard.com", "L4gSIIb6JH-aF8tAfrEGzw", "");
                    if (rtn != null)
                    {
                        try
                        {
                            Console.WriteLine("<----------------------------------------------------------------->");
                            Console.WriteLine("<---------------Mail Send to:" + _user.EmailId + "---------------->");
                            Console.WriteLine("<----------------------------------------------------------------->");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("<------------------------------------------------->");
                            Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                            Console.WriteLine("<------------------------------------------------->");
                        }
                    }
                    else
                    {
                        Console.WriteLine("<------------------------------------------------->");
                        Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                        Console.WriteLine("<------------------------------------------------->");
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void StartBlogmailSending()
        {
            Api.User.User ApiUser = new Api.User.User();
            try
            {
                List<User> _lstUser = (List<User>)new JavaScriptSerializer().Deserialize(ApiUser.GetAllUsers(""), typeof(List<User>));
                foreach (User _user in _lstUser)
                {
                    string rtn = MailSender.SendBlogmail(_user.UserName, _user.EmailId, "support@socioboard.com", "L4gSIIb6JH-aF8tAfrEGzw", "");
                    if (rtn != null)
                    {
                        try
                        {
                            Console.WriteLine("<----------------------------------------------------------------->");
                            Console.WriteLine("<---------------Mail Send to:" + _user.EmailId + "---------------->");
                            Console.WriteLine("<----------------------------------------------------------------->");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("<------------------------------------------------->");
                            Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                            Console.WriteLine("<------------------------------------------------->");
                        }
                    }
                    else
                    {
                        Console.WriteLine("<------------------------------------------------->");
                        Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                        Console.WriteLine("<------------------------------------------------->");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void LoginReminder()
        {
            Api.User.User ApiUser = new Api.User.User();
            List<User> _lstUser = (List<User>)new JavaScriptSerializer().Deserialize(ApiUser.InactiveUser(), typeof(List<User>));
            foreach (User _user in _lstUser)
            {
                string str = MailSender.SendInActiveUsermail(_user.UserName, _user.EmailId, "support@socioboard.com", "L4gSIIb6JH-aF8tAfrEGzw", "");
                if (str != null)
                {
                    try
                    {
                        Console.WriteLine("<----------------------------------------------------------------->");
                        Console.WriteLine("<---------------Mail Send to:" + _user.EmailId + "---------------->");
                        Console.WriteLine("<----------------------------------------------------------------->");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("<------------------------------------------------->");
                        Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                        Console.WriteLine("<------------------------------------------------->");
                    }
                }
                else
                {
                    Console.WriteLine("<------------------------------------------------->");
                    Console.WriteLine("<----Mail Failled to:" + _user.EmailId + "------->");
                    Console.WriteLine("<------------------------------------------------->");
                }
            }

        }

        public void DailySocialMediaStat()
        {
            Api.User.User ApiUser = new Api.User.User();
            Api.AdminUserDetails.AdminUserDetails ApiAdminUserDetails = new Api.AdminUserDetails.AdminUserDetails();
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            string email = string.Empty;

            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                string TwitterProfileId = string.Empty;
                string FacebookProfileId = string.Empty;
                string FacebookPageProfileId = string.Empty;
                string InstagramProfileId = string.Empty;
                int TotalLikes = 0;
                int TalkingAbout = 0;
                int PageLike = 0;
                int PageUnlike = 0;
                int PageImpression = 0;
                int objFacebookAccount = 0;
                SocialStat _SocialStat = new Domain.SocialStat();
                //List<TwitterAccount> lstTwitterAccount =(List<TwitterAccount>)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.getAllTwitterAccountsOfUser(item_user.Id.ToString()), typeof(List<TwitterAccount>));
                List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));
                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                //Dictionary<FacebookAccount, FbPageStat> lstFacebookStats = new Dictionary<FacebookAccount, Domain.FbPageStat>();
                //List<FbPageStat> lstFacebookStats = new List<Domain.FbPageStat>();
                FacebookStat _FacebookStat = new Domain.FacebookStat();
                List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                List<FacebookAccount> lastFacebookPage = new List<FacebookAccount>();
                List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                FbPageStat _FbPageStat = new Domain.FbPageStat();
                string FollowerIds = string.Empty;

                foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                {
                    if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                    {
                        TwitterProfileId += item_TeamMemberProfile.ProfileId + ",";
                        TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                        List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                        foreach (InboxMessages item in lstfollowers)
                        {
                            FollowerIds += item.FromId + ",";
                        }
                        lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                    }

                    if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                    {
                        FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                        lstFacebookProfiles.Add(_FacebookAccount);
                    }

                    if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                    {
                        FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                        if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                        {

                            JObject fbaccountdetails = _FacebookStat.GetFacebookPageDetails(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken);
                            string totalLikes = fbaccountdetails["likes"].ToString();
                            string talkingAbout = fbaccountdetails["talking_about_count"].ToString();
                            int fblikers = _FacebookStat.GetFacebookNewLiker(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 1);
                            int fbunliker = _FacebookStat.GetFacebookUnliker(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 1);
                            int fbimpression = _FacebookStat.GetFacebookImpression(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 1);

                            lastFacebookPage.Add(_FacebookAccount);
                            TotalLikes += Int32.Parse(totalLikes);
                            TalkingAbout += Int32.Parse(talkingAbout);
                            PageLike += fblikers;
                            PageUnlike += fbunliker;
                            PageImpression += fbimpression;

                        }
                    }


                    if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                    {
                        InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                        InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                        lstInstagramAccount.Add(_InstagramAccount);
                    }

                }
                try
                {
                    TwitterProfileId = TwitterProfileId.Substring(0, TwitterProfileId.Length - 1);
                }
                catch (Exception e)
                {
                    TwitterProfileId = string.Empty;
                    Console.WriteLine(e.Message);
                }

                try
                {
                    InstagramProfileId = InstagramProfileId.Substring(0, InstagramProfileId.Length - 1);
                }
                catch (Exception e)
                {
                    InstagramProfileId = string.Empty;
                    Console.WriteLine(e.Message);
                }

                try
                {
                    FollowerIds = FollowerIds.Substring(0, FollowerIds.Length - 1);
                }
                catch (Exception ex)
                {
                    FollowerIds = string.Empty;
                }
                string sexratio = ApiGroupReports.GetSexRatio(FollowerIds);
                string male = "0";
                string female = "0";
                string _male = "0";
                string _female = "0";
                try
                {
                    male = sexratio.Split(',')[0];
                    female = sexratio.Split(',')[1];
                }
                catch (Exception ex)
                {
                    male = "0";
                    female = "0";
                }
                try
                {
                    _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                }
                catch (Exception ex)
                {
                    _male = "0";
                }
                try
                {
                    _female = (Int32.Parse(female) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                }
                catch (Exception ex)
                {
                    _female = "0";
                }
                _FbPageStat.TotalLikes = TotalLikes.ToString();
                _FbPageStat.TalkingAbout = TalkingAbout.ToString();
                _FbPageStat.PageLike = PageLike.ToString();
                _FbPageStat.PageUnlike = PageUnlike.ToString();
                _FbPageStat.PageImpression = PageImpression.ToString();
                _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                _FbPageStat.lstFacebookpage = lastFacebookPage;

                _SocialStat.male = _male;
                _SocialStat.female = _female;

                _SocialStat.Mentions = ApiInboxMessages.GetTwitterMentionCount(_Groups.UserId.ToString(), TwitterProfileId, "1");
                _SocialStat.Retweets = ApiInboxMessages.GetTwitterRetweetCount(_Groups.UserId.ToString(), TwitterProfileId, "1");
                _SocialStat.New_Followers = ApiInboxMessages.GetTwitterFollowersCount(_Groups.UserId.ToString(), TwitterProfileId, "1");
                _SocialStat.Messages_Sent = (Int32.Parse(ApiScheduledMessage.GetSentMessageCount(_Groups.UserId.ToString(), TwitterProfileId, "1")) + Int32.Parse(ApiTwitterDirectMessages.GetTwitterDirectMessageSentCount(_Groups.UserId.ToString(), TwitterProfileId, "1"))).ToString();
                _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "1");
                _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "1");
                _SocialStat.lsttwitterfollower = lsttwitterfollower;

                InstagramStat _InstagramStat = new Domain.InstagramStat();
                _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "1");
                _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "1");
                _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "1");
                _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "1");
                _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "1");
                _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "1");
                _InstagramStat.lstInstagramAccount = lstInstagramAccount;


                string ret = MailSender.SendGroupRepors(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat);


            }


        }

        public void SocialMediaStat_7()
        {
            Api.User.User ApiUser = new Api.User.User();
            Api.AdminUserDetails.AdminUserDetails ApiAdminUserDetails = new Api.AdminUserDetails.AdminUserDetails();
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            string email = string.Empty;

            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                string TwitterProfileId = string.Empty;
                string FacebookProfileId = string.Empty;
                string FacebookPageProfileId = string.Empty;
                string InstagramProfileId = string.Empty;
                int TotalLikes = 0;
                int TalkingAbout = 0;
                int PageLike = 0;
                int PageUnlike = 0;
                int PageImpression = 0;
                int objFacebookAccount = 0;
                SocialStat _SocialStat = new Domain.SocialStat();
                //List<TwitterAccount> lstTwitterAccount =(List<TwitterAccount>)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.getAllTwitterAccountsOfUser(item_user.Id.ToString()), typeof(List<TwitterAccount>));
                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                double days = DateTime.Now.Subtract(_Groups.EntryDate).TotalDays;
                int mod = Convert.ToInt32(days) % 7;
                if (mod == 0)
                {
                    List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));

                    Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                    //Dictionary<FacebookAccount, FbPageStat> lstFacebookStats = new Dictionary<FacebookAccount, Domain.FbPageStat>();
                    //List<FbPageStat> lstFacebookStats = new List<Domain.FbPageStat>();
                    FacebookStat _FacebookStat = new Domain.FacebookStat();
                    List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                    List<FacebookAccount> lastFacebookPage = new List<FacebookAccount>();
                    List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                    FbPageStat _FbPageStat = new Domain.FbPageStat();
                    string FollowerIds = string.Empty;

                    foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                    {
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                        {
                            TwitterProfileId += item_TeamMemberProfile.ProfileId + ",";
                            TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                            List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                            foreach (InboxMessages item in lstfollowers)
                            {
                                FollowerIds += item.FromId + ",";
                            }
                            lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            lstFacebookProfiles.Add(_FacebookAccount);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                            {

                                JObject fbaccountdetails = _FacebookStat.GetFacebookPageDetails(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken);
                                string totalLikes = fbaccountdetails["likes"].ToString();
                                string talkingAbout = fbaccountdetails["talking_about_count"].ToString();
                                int fblikers = _FacebookStat.GetFacebookNewLiker(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 7);
                                int fbunliker = _FacebookStat.GetFacebookUnliker(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 7);
                                int fbimpression = _FacebookStat.GetFacebookImpression(_FacebookAccount.FbUserId, _FacebookAccount.AccessToken, 7);

                                lastFacebookPage.Add(_FacebookAccount);
                                TotalLikes += Int32.Parse(totalLikes);
                                TalkingAbout += Int32.Parse(talkingAbout);
                                PageLike += fblikers;
                                PageUnlike += fbunliker;
                                PageImpression += fbimpression;

                            }
                        }


                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                        {
                            InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                            InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                            lstInstagramAccount.Add(_InstagramAccount);
                        }

                    }
                    try
                    {
                        TwitterProfileId = TwitterProfileId.Substring(0, TwitterProfileId.Length - 1);
                    }
                    catch (Exception e)
                    {
                        TwitterProfileId = string.Empty;
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        InstagramProfileId = InstagramProfileId.Substring(0, InstagramProfileId.Length - 1);
                    }
                    catch (Exception e)
                    {
                        InstagramProfileId = string.Empty;
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        FollowerIds = FollowerIds.Substring(0, FollowerIds.Length - 1);
                    }
                    catch (Exception ex)
                    {
                        FollowerIds = string.Empty;
                    }
                    string sexratio = ApiGroupReports.GetSexRatio(FollowerIds);
                    string male = "0";
                    string female = "0";
                    string _male = "0";
                    string _female = "0";
                    try
                    {
                        male = sexratio.Split(',')[0];
                        female = sexratio.Split(',')[1];
                    }
                    catch (Exception ex)
                    {
                        male = "0";
                        female = "0";
                    }
                    try
                    {
                        _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _male = "0";
                    }
                    try
                    {
                        _female = (Int32.Parse(female) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _female = "0";
                    }
                    _FbPageStat.TotalLikes = TotalLikes.ToString();
                    _FbPageStat.TalkingAbout = TalkingAbout.ToString();
                    _FbPageStat.PageLike = PageLike.ToString();
                    _FbPageStat.PageUnlike = PageUnlike.ToString();
                    _FbPageStat.PageImpression = PageImpression.ToString();
                    _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                    _FbPageStat.lstFacebookpage = lastFacebookPage;

                    _SocialStat.male = _male;
                    _SocialStat.female = _female;

                    _SocialStat.Mentions = ApiInboxMessages.GetTwitterMentionCount(_Groups.UserId.ToString(), TwitterProfileId, "7");
                    _SocialStat.Retweets = ApiInboxMessages.GetTwitterRetweetCount(_Groups.UserId.ToString(), TwitterProfileId, "7");
                    _SocialStat.New_Followers = ApiInboxMessages.GetTwitterFollowersCount(_Groups.UserId.ToString(), TwitterProfileId, "7");
                    _SocialStat.Messages_Sent = (Int32.Parse(ApiScheduledMessage.GetSentMessageCount(_Groups.UserId.ToString(), TwitterProfileId, "7")) + Int32.Parse(ApiTwitterDirectMessages.GetTwitterDirectMessageSentCount(_Groups.UserId.ToString(), TwitterProfileId, "7"))).ToString();
                    _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "7");
                    _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "7");
                    _SocialStat.lsttwitterfollower = lsttwitterfollower;

                    InstagramStat _InstagramStat = new Domain.InstagramStat();
                    _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "7");
                    _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "7");
                    _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "7");
                    _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "7");
                    _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "7");
                    _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "7");
                    _InstagramStat.lstInstagramAccount = lstInstagramAccount;


                    string ret = MailSender.SendGroupReporsByDay(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat, 7);
                }

            }


        }

        public void SocialMediaStat_15()
        {
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.User.User ApiUser = new Api.User.User();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            Api.FacebookGroupReport.FacebookGroupReport ApiFacebookGroupReport = new Api.FacebookGroupReport.FacebookGroupReport();
            Api.InstagramReports.InstagramReports ApiInstagramReports = new Api.InstagramReports.InstagramReports();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                SocialStat _SocialStat = new Domain.SocialStat();
                Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                FacebookStat _FacebookStat = new Domain.FacebookStat();
                List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                List<FacebookAccount> lstFacebookPage = new List<FacebookAccount>();
                List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                FbPageStat _FbPageStat = new Domain.FbPageStat();

                string TwitterProfileId = string.Empty;
                string InstagramProfileId = string.Empty;

                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                double days = DateTime.Now.Subtract(_Groups.EntryDate).TotalDays;
                int mod = Convert.ToInt32(days) % 15;
                if (mod == 0)
                {
                    List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));
                    foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                    {
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                        {
                            TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                            List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                            lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            lstFacebookProfiles.Add(_FacebookAccount);
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                            {
                                lstFacebookPage.Add(_FacebookAccount);
                            }
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                        {
                            InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                            InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                            lstInstagramAccount.Add(_InstagramAccount);
                        }
                        try
                        {
                            InstagramProfileId = InstagramProfileId.TrimEnd(',');
                        }
                        catch (Exception ex)
                        {
                            InstagramProfileId = string.Empty;
                        }
                    }


                    GroupReports _GroupReports = (GroupReports)new JavaScriptSerializer().Deserialize(ApiGroupReports.retrievedata(_Groups.Id.ToString()), typeof(GroupReports));
                    string sexratio = _GroupReports.sexratio;
                    string male = "0";
                    string female = "0";
                    string _male = "0";
                    string _female = "0";
                    try
                    {
                        male = sexratio.Split(',')[0];
                        female = sexratio.Split(',')[1];
                    }
                    catch (Exception ex)
                    {
                        male = "0";
                        female = "0";
                    }
                    try
                    {
                        _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _male = "0";
                    }
                    try
                    {
                        if (female != "0")
                        {
                            _female = (100 - Int32.Parse(_male)).ToString();
                        }
                        else
                        {
                            _female = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        _female = "0";
                    }

                    _SocialStat.male = _male;
                    _SocialStat.female = _female;

                    _SocialStat.Mentions = _GroupReports.twtmentions_15.ToString();
                    _SocialStat.Retweets = _GroupReports.twtretweets_15.ToString();
                    _SocialStat.New_Followers = _GroupReports.twitterfollower_15.ToString();
                    _SocialStat.Messages_Sent = _GroupReports.sent_15.ToString();
                    _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "15");
                    _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "15");
                    _SocialStat.lsttwitterfollower = lsttwitterfollower;

                    FacebookGroupReport_15 _FacebookGroupReport_15 = (FacebookGroupReport_15)new JavaScriptSerializer().Deserialize(ApiFacebookGroupReport.retrieve_15(_Groups.Id.ToString()), typeof(FacebookGroupReport_15));
                    _FbPageStat.TotalLikes = _FacebookGroupReport_15.TotalLikes;
                    _FbPageStat.TalkingAbout = _FacebookGroupReport_15.TalkingAbout;
                    _FbPageStat.PageLike = _FacebookGroupReport_15.Likes.ToString();
                    _FbPageStat.PageUnlike = _FacebookGroupReport_15.Unlikes.ToString();
                    _FbPageStat.PageImpression = _FacebookGroupReport_15.Impression.ToString();
                    _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                    _FbPageStat.lstFacebookpage = lstFacebookPage;
                    InstagramStat _InstagramStat = new Domain.InstagramStat();
                    _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "15");
                    _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "15");
                    _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "15");
                    _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "15");
                    _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "15");
                    _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "15");
                    _InstagramStat.lstInstagramAccount = lstInstagramAccount;

                    string ret = MailSender.SendGroupReporsByDay(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat, 15);
                }
            }

        }

        public void SocialMediaStat_30()
        {
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.User.User ApiUser = new Api.User.User();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            Api.FacebookGroupReport.FacebookGroupReport ApiFacebookGroupReport = new Api.FacebookGroupReport.FacebookGroupReport();
            Api.InstagramReports.InstagramReports ApiInstagramReports = new Api.InstagramReports.InstagramReports();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                SocialStat _SocialStat = new Domain.SocialStat();
                Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                FacebookStat _FacebookStat = new Domain.FacebookStat();
                List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                List<FacebookAccount> lstFacebookPage = new List<FacebookAccount>();
                List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                FbPageStat _FbPageStat = new Domain.FbPageStat();
                string InboxMessages = string.Empty;
                string InstagramProfileId = string.Empty;
                string TwitterProfileId = string.Empty;
                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                double days = DateTime.Now.Subtract(_Groups.EntryDate).TotalDays;
                int mod = Convert.ToInt32(days) % 30;
                if (mod == 0)
                {
                    List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));
                    foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                    {
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                        {
                            TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                            List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                            lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            lstFacebookProfiles.Add(_FacebookAccount);
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                            {
                                lstFacebookPage.Add(_FacebookAccount);
                            }
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                        {
                            InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                            InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                            lstInstagramAccount.Add(_InstagramAccount);
                        }
                        try
                        {
                            InstagramProfileId = InstagramProfileId.TrimEnd(',');
                        }
                        catch (Exception ex)
                        {
                            InstagramProfileId = string.Empty;
                        }
                    }
                    GroupReports _GroupReports = (GroupReports)new JavaScriptSerializer().Deserialize(ApiGroupReports.retrievedata(_Groups.Id.ToString()), typeof(GroupReports));
                    string sexratio = _GroupReports.sexratio;
                    string male = "0";
                    string female = "0";
                    string _male = "0";
                    string _female = "0";
                    try
                    {
                        male = sexratio.Split(',')[0];
                        female = sexratio.Split(',')[1];
                    }
                    catch (Exception ex)
                    {
                        male = "0";
                        female = "0";
                    }
                    try
                    {
                        _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _male = "0";
                    }
                    try
                    {
                        if (female != "0")
                        {
                            _female = (100 - Int32.Parse(_male)).ToString();
                        }
                        else
                        {
                            _female = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        _female = "0";
                    }

                    _SocialStat.male = _male;
                    _SocialStat.female = _female;

                    _SocialStat.Mentions = _GroupReports.twtmentions_30.ToString();
                    _SocialStat.Retweets = _GroupReports.twtretweets_30.ToString();
                    _SocialStat.New_Followers = _GroupReports.twitterfollower_30.ToString(); 
                    _SocialStat.Messages_Sent = _GroupReports.sent_30.ToString();
                    _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "30");
                    _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "30");
                    _SocialStat.lsttwitterfollower = lsttwitterfollower;

                    FacebookGroupReport_30 _FacebookGroupReport_30 = (FacebookGroupReport_30)new JavaScriptSerializer().Deserialize(ApiFacebookGroupReport.retrieve_30(_Groups.Id.ToString()), typeof(FacebookGroupReport_30));
                    _FbPageStat.TotalLikes = _FacebookGroupReport_30.TotalLikes;
                    _FbPageStat.TalkingAbout = _FacebookGroupReport_30.TalkingAbout;
                    _FbPageStat.PageLike = _FacebookGroupReport_30.Likes.ToString();
                    _FbPageStat.PageUnlike = _FacebookGroupReport_30.Unlikes.ToString();
                    _FbPageStat.PageImpression = _FacebookGroupReport_30.Impression.ToString();
                    _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                    _FbPageStat.lstFacebookpage = lstFacebookPage;
                    InstagramStat _InstagramStat = new Domain.InstagramStat();
                    _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "30");
                    _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "30");
                    _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "30");
                    _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "30");
                    _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "30");
                    _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "30");
                    _InstagramStat.lstInstagramAccount = lstInstagramAccount;

                    string ret = MailSender.SendGroupReporsByDay(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat, 30);
                }
            }

        }

        public void SocialMediaStat_60()
        {
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.User.User ApiUser = new Api.User.User();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.FacebookGroupReport.FacebookGroupReport ApiFacebookGroupReport = new Api.FacebookGroupReport.FacebookGroupReport();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            Api.InstagramReports.InstagramReports ApiInstagramReports = new Api.InstagramReports.InstagramReports();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                SocialStat _SocialStat = new Domain.SocialStat();
                Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                FacebookStat _FacebookStat = new Domain.FacebookStat();
                List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                List<FacebookAccount> lstFacebookPage = new List<FacebookAccount>();
                List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                FbPageStat _FbPageStat = new Domain.FbPageStat();
                string TwitterProfileId = string.Empty;
                string InstagramProfileId = string.Empty;
                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                double days = DateTime.Now.Subtract(_Groups.EntryDate).TotalDays;
                int mod = Convert.ToInt32(days) % 60;
                if (mod == 0)
                {
                    List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));
                    foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                    {
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                        {
                            TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                            List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                            lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            lstFacebookProfiles.Add(_FacebookAccount);
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                            {
                                lstFacebookPage.Add(_FacebookAccount);
                            }
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                        {
                            InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                            InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                            lstInstagramAccount.Add(_InstagramAccount);
                        }
                        try
                        {
                            InstagramProfileId = InstagramProfileId.TrimEnd(',');
                        }
                        catch (Exception ex)
                        {
                            InstagramProfileId = string.Empty;
                        }
                    }
                    GroupReports _GroupReports = (GroupReports)new JavaScriptSerializer().Deserialize(ApiGroupReports.retrievedata(_Groups.Id.ToString()), typeof(GroupReports));
                    string sexratio = _GroupReports.sexratio;
                    string male = "0";
                    string female = "0";
                    string _male = "0";
                    string _female = "0";
                    try
                    {
                        male = sexratio.Split(',')[0];
                        female = sexratio.Split(',')[1];
                    }
                    catch (Exception ex)
                    {
                        male = "0";
                        female = "0";
                    }
                    try
                    {
                        _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _male = "0";
                    }
                    try
                    {
                        if (female != "0")
                        {
                            _female = (100 - Int32.Parse(_male)).ToString();
                        }
                        else
                        {
                            _female = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        _female = "0";
                    }

                    _SocialStat.male = _male;
                    _SocialStat.female = _female;

                    _SocialStat.Mentions = _GroupReports.twtmentions_60.ToString();
                    _SocialStat.Retweets = _GroupReports.twtretweets_60.ToString();
                    _SocialStat.New_Followers = _GroupReports.twitterfollower_60.ToString();
                    _SocialStat.Messages_Sent = _GroupReports.sent_60.ToString();
                    _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "60");
                    _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "60");
                    _SocialStat.lsttwitterfollower = lsttwitterfollower;

                    FacebookGroupReport_60 _FacebookGroupReport_60 = (FacebookGroupReport_60)new JavaScriptSerializer().Deserialize(ApiFacebookGroupReport.retrieve_60(_Groups.Id.ToString()), typeof(FacebookGroupReport_60));
                    _FbPageStat.TotalLikes = _FacebookGroupReport_60.TotalLikes;
                    _FbPageStat.TalkingAbout = _FacebookGroupReport_60.TalkingAbout;
                    _FbPageStat.PageLike = _FacebookGroupReport_60.Likes.ToString();
                    _FbPageStat.PageUnlike = _FacebookGroupReport_60.Unlikes.ToString();
                    _FbPageStat.PageImpression = _FacebookGroupReport_60.Impression.ToString();
                    _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                    _FbPageStat.lstFacebookpage = lstFacebookPage;
                    InstagramStat _InstagramStat = new Domain.InstagramStat();
                    _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "60");
                    _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "60");
                    _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "60");
                    _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "60");
                    _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "60");
                    _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "60");
                    _InstagramStat.lstInstagramAccount = lstInstagramAccount;
                    string ret = MailSender.SendGroupReporsByDay(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat, 60);
                }
            }

        }

        public void SocialMediaStat_90()
        {
            Api.TwitterAccount.TwitterAccount ApiTwitterAccount = new Api.TwitterAccount.TwitterAccount();
            Api.FacebookAccount.FacebookAccount ApiFacebookAccount = new Api.FacebookAccount.FacebookAccount();
            Api.InstagramAccount.InstagramAccount ApiInstagramAccount = new Api.InstagramAccount.InstagramAccount();
            Api.InboxMessages.InboxMessages ApiInboxMessages = new Api.InboxMessages.InboxMessages();
            Api.ScheduledMessage.ScheduledMessage ApiScheduledMessage = new Api.ScheduledMessage.ScheduledMessage();
            Api.TwitterDirectMessages.TwitterDirectMessages ApiTwitterDirectMessages = new Api.TwitterDirectMessages.TwitterDirectMessages();
            Api.User.User ApiUser = new Api.User.User();
            Api.Team.Team ApiTeam = new Api.Team.Team();
            Api.Groups.Groups ApiGroups = new Api.Groups.Groups();
            Api.FacebookGroupReport.FacebookGroupReport ApiFacebookGroupReport = new Api.FacebookGroupReport.FacebookGroupReport();
            Api.GroupReports.GroupReports ApiGroupReports = new Api.GroupReports.GroupReports();
            Api.InstagramReports.InstagramReports ApiInstagramReports = new Api.InstagramReports.InstagramReports();
            Api.TeamMemberProfile.TeamMemberProfile ApiTeamMemberProfile = new Api.TeamMemberProfile.TeamMemberProfile();
            List<Team> lstTeam = (List<Team>)new JavaScriptSerializer().Deserialize(ApiTeam.GetAllActiveTeam(), typeof(List<Team>));
            foreach (Team item_team in lstTeam)
            {
                SocialStat _SocialStat = new Domain.SocialStat();
                Dictionary<TwitterAccount, List<InboxMessages>> lsttwitterfollower = new Dictionary<TwitterAccount, List<InboxMessages>>();
                FacebookStat _FacebookStat = new Domain.FacebookStat();
                List<FacebookAccount> lstFacebookProfiles = new List<FacebookAccount>();
                List<FacebookAccount> lstFacebookPage = new List<FacebookAccount>();
                List<InstagramAccount> lstInstagramAccount = new List<InstagramAccount>();
                FbPageStat _FbPageStat = new Domain.FbPageStat();
                string TwitterProfileId = string.Empty;
                string InstagramProfileId = string.Empty;
                Groups _Groups = (Groups)new JavaScriptSerializer().Deserialize(ApiGroups.GetGroupDetailsByGroupId(item_team.GroupId.ToString()), typeof(Groups));
                double days = DateTime.Now.Subtract(_Groups.EntryDate).TotalDays;
                int mod = Convert.ToInt32(days) % 90;
                if (mod == 0)
                {
                    List<TeamMemberProfile> lstTeamMemberProfile = (List<TeamMemberProfile>)new JavaScriptSerializer().Deserialize(ApiTeamMemberProfile.getAllTeamMemberProfilesOfTeam(item_team.Id.ToString()), typeof(List<TeamMemberProfile>));
                    foreach (TeamMemberProfile item_TeamMemberProfile in lstTeamMemberProfile)
                    {
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "twitter")
                        {
                            TwitterAccount _TwitterAccount = (TwitterAccount)new JavaScriptSerializer().Deserialize(ApiTwitterAccount.GetTwitterAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(TwitterAccount));
                            List<InboxMessages> lstfollowers = (List<InboxMessages>)(new JavaScriptSerializer().Deserialize(ApiInboxMessages.GetTwitterFollowers(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId, "1"), typeof(List<InboxMessages>)));
                            lsttwitterfollower.Add(_TwitterAccount, lstfollowers);
                        }

                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            lstFacebookProfiles.Add(_FacebookAccount);
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "facebook_page")
                        {
                            FacebookAccount _FacebookAccount = (FacebookAccount)new JavaScriptSerializer().Deserialize(ApiFacebookAccount.getFacebookAccountDetailsById(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(FacebookAccount));
                            if (!string.IsNullOrEmpty(_FacebookAccount.AccessToken))
                            {
                                lstFacebookPage.Add(_FacebookAccount);
                            }
                        }
                        if (!string.IsNullOrEmpty(item_TeamMemberProfile.ProfileId) && item_TeamMemberProfile.ProfileType == "instagram")
                        {
                            InstagramAccount _InstagramAccount = (InstagramAccount)new JavaScriptSerializer().Deserialize(ApiInstagramAccount.UserInformation(_Groups.UserId.ToString(), item_TeamMemberProfile.ProfileId), typeof(InstagramAccount));
                            InstagramProfileId += item_TeamMemberProfile.ProfileId + ",";
                            lstInstagramAccount.Add(_InstagramAccount);
                        }
                        try
                        {
                            InstagramProfileId = InstagramProfileId.TrimEnd(',');
                        }
                        catch (Exception ex)
                        {
                            InstagramProfileId = string.Empty;
                        }
                    }
                    GroupReports _GroupReports = (GroupReports)new JavaScriptSerializer().Deserialize(ApiGroupReports.retrievedata(_Groups.Id.ToString()), typeof(GroupReports));
                    string sexratio = _GroupReports.sexratio;
                    string male = "0";
                    string female = "0";
                    string _male = "0";
                    string _female = "0";
                    try
                    {
                        male = sexratio.Split(',')[0];
                        female = sexratio.Split(',')[1];
                    }
                    catch (Exception ex)
                    {
                        male = "0";
                        female = "0";
                    }
                    try
                    {
                        _male = (Int32.Parse(male) / (Int32.Parse(male) + Int32.Parse(female)) * 100).ToString();
                    }
                    catch (Exception ex)
                    {
                        _male = "0";
                    }
                    try
                    {
                        if (female != "0")
                        {
                            _female = (100 - Int32.Parse(_male)).ToString();
                        }
                        else
                        {
                            _female = "0";
                        }
                    }
                    catch (Exception ex)
                    {
                        _female = "0";
                    }

                    _SocialStat.male = _male;
                    _SocialStat.female = _female;

                    _SocialStat.Mentions = _GroupReports.twtmentions_90.ToString();
                    _SocialStat.Retweets = _GroupReports.twtretweets_90.ToString();
                    _SocialStat.New_Followers = _GroupReports.twitterfollower_90.ToString();
                    _SocialStat.Messages_Sent = _GroupReports.sent_90.ToString();
                    _SocialStat.Clicks = ApiScheduledMessage.GetClickCount(_Groups.UserId.ToString(), TwitterProfileId, "90");
                    _SocialStat.Direct_Message = ApiTwitterDirectMessages.GetTwitterDirectMessageRecievedCount(_Groups.UserId.ToString().ToString(), TwitterProfileId, "90");
                    _SocialStat.lsttwitterfollower = lsttwitterfollower;

                    FacebookGroupReport_90 _FacebookGroupReport_90 = (FacebookGroupReport_90)new JavaScriptSerializer().Deserialize(ApiFacebookGroupReport.retrieve_90(_Groups.Id.ToString()), typeof(FacebookGroupReport_90));
                    _FbPageStat.TotalLikes = _FacebookGroupReport_90.TotalLikes;
                    _FbPageStat.TalkingAbout = _FacebookGroupReport_90.TalkingAbout;
                    _FbPageStat.PageLike = _FacebookGroupReport_90.Likes.ToString();
                    _FbPageStat.PageUnlike = _FacebookGroupReport_90.Unlikes.ToString();
                    _FbPageStat.PageImpression = _FacebookGroupReport_90.Impression.ToString();
                    _FbPageStat.lstFacebookAccount = lstFacebookProfiles;
                    _FbPageStat.lstFacebookpage = lstFacebookPage;
                    InstagramStat _InstagramStat = new Domain.InstagramStat();
                    _InstagramStat.NewFollowers = ApiInboxMessages.GetInstagramFollower(_Groups.UserId.ToString(), InstagramProfileId, "90");
                    _InstagramStat.NewFollowings = ApiInboxMessages.GetInstagramFollowing(_Groups.UserId.ToString(), InstagramProfileId, "90");
                    _InstagramStat.ImageCount = ApiInstagramAccount.GetInstagramImageCount(InstagramProfileId, "90");
                    _InstagramStat.VideoCount = ApiInstagramAccount.GetInstagramVideosCount(InstagramProfileId, "90");
                    _InstagramStat.LikesCount = ApiInstagramAccount.GetInstagramLikesCount(InstagramProfileId, "90");
                    _InstagramStat.CommentCount = ApiInstagramAccount.GetInstagramCommentCount(InstagramProfileId, "90");
                    _InstagramStat.lstInstagramAccount = lstInstagramAccount;

                    string ret = MailSender.SendGroupReporsByDay(_Groups.GroupName, "cs101128@gmail.com", _SocialStat, _FbPageStat, _InstagramStat, 90);
                }
            }
        }
    }
}
