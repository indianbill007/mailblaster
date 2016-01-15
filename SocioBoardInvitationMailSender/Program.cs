using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using SocioBoardInvitationMailSender;
using SocioBoardInvitationMailSender.Model;
using SocioBoardInvitationMailSender.Domain;
using System.Text.RegularExpressions;
using System.Threading;
using SocioBoardInvitationMailSender.Helper;
using Newtonsoft.Json.Linq;
namespace SocioBoardInvitationMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            MailBlastingData objMBD = new MailBlastingData();

            objMBD.StartMailBlasting();
        }

    }
    public class MailBlastingData
    {
        public void StartMailBlasting()
        {
            Console.WriteLine("1. SendInvitationMail");
            Console.WriteLine("2. SendSocioQueuMail");
            Console.WriteLine("3. CheckBounce");
            Console.WriteLine("4. GetClickandOpens");
            string str = Console.ReadLine();
            string ActionType = string.Empty;
            switch (str)
            {
                case "1":
                    ActionType = "InvitationMailer";
                    break;
                case "2":
                    ActionType = "SocioQueuMailer";
                    break;
                case "3":
                    ActionType = "CheckBounce";
                    break;
                case "4":
                    ActionType = "GetClickandOpens";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(ActionType))
            {
                GetMailBlastingData(ActionType);
            }
        }

        public void GetMailBlastingData(string actiontype)
        {
            try
            {
                string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\SocioBoardInvitationMailSendrSetup";
                string path = dirPath + "\\hibernate.cfg.xml";
                string startUpFilePath = Application.StartupPath + "\\hibernate.cfg.xml";
                Console.Write(dirPath + " " + path + " " + startUpFilePath);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(path))
                {
                    File.Copy(startUpFilePath, path);
                }
                SocioBoardInvitationMailSenderSessionFactory.configfilepath = path;
                NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession();
                DateTime today = DateTime.Now.Date;
                while (true)
                {
                    if (actiontype == "InvitationMailer")
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
                    else if (actiontype == "SocioQueuMailer") 
                    {
                        if (today == DateTime.Now.Date)
                        {
                            today = DateTime.Now.Date.AddDays(1);
                            StartMailSendingForNew();
                        }
                        else 
                        {
                            Thread.Sleep(60 * 5000);
                        }
                    }
                    else if (actiontype == "CheckBounce") 
                    {
                        if (today == DateTime.Now.Date)
                        {
                            today = DateTime.Now.Date.AddDays(1);
                            GetMaindrillAccountInfo();
                        }
                        else
                        {
                             
                        }
                    }
                    else if (actiontype == "GetClickandOpens") 
                    {
                        if (today == DateTime.Now.Date)
                        {
                            today = DateTime.Now.Date.AddDays(1);
                            GetClicksForMandrillAccount();
                        }
                        else
                        {

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
            Console.WriteLine("<---------Start Invitation Mail Sending ---------->");
            Console.WriteLine("<------------------------------------------------->");

            MandrillaccountRepository mandrillRepo = new MandrillaccountRepository();
            MantaemailRepository mantaemailrepo = new MantaemailRepository();
            List<Mandrillaccount> allmandrillACC = mandrillRepo.getAllMandrillData();
            for (int i = 1; i < 110000; i += 10000)
            {
            List<Mantaemail> objemaillist = mantaemailrepo.getAllCompanyData(i);
            Thread SendInvitationMail_thread = new Thread(() => SendInvitationMail(objemaillist, allmandrillACC));
            SendInvitationMail_thread.Start();
            //SendInvitationMail(objemaillist, allmandrillACC);
            }
        }

        void SendInvitationMail(List<Mantaemail> objemaillist, List<Mandrillaccount> allmandrillACC)
        {
            MantaemailRepository mantaemailrepo = new MantaemailRepository();
            MandrillaccountRepository mandrillRepo = new MandrillaccountRepository();
            //InvitationRepository invitationRepo = new InvitationRepository();
            List<int> ValidIds = new List<int>();
            List<int> InvalidIds = new List<int>();
            int p = 0;
            try
            {
                foreach (Mantaemail email_item in objemaillist)
                {
                    try
                    {
                        Mandrillaccount mandrillACC = allmandrillACC[p];
                        string SenderEmail = mandrillACC.UserName;
                        string SenderPass = mandrillACC.Password;
                        string fromname = RandomNameGenerator.CreateName().ToLower();
                        string[] name = Regex.Split(fromname, " ");
                        string fname = name[0].Substring(0, 1).ToUpper() + name[0].Substring(1, name[0].Length - 1);
                        string lname = name[1].Substring(0, 1).ToUpper() + name[1].Substring(1, name[1].Length - 1);
                        fromname = fname + " " + lname;
                        string rtn = MailSender.SendIvitationMail(email_item.Name.Trim(), email_item.Email.Trim(), SenderEmail, SenderPass, fromname);
                        //string rtn4 = MailSender.SendIvitationMail(email_item.Name.Trim(), "indianbill007@gmail.com", SenderEmail, SenderPass,fromname);
                        //string rtn1 = MailSender.SendIvitationMail(email_item.Name.Trim(), "pgcoding@yahoo.co.in", SenderEmail, SenderPass, fromname);
                        //string rtn2 = MailSender.SendIvitationMail(email_item.Name.Trim(), "sumit@globussoft.com", SenderEmail, SenderPass,fromname);
                        //string rtn4 = MailSender.SendIvitationMail(email_item.Name.Trim(), "cs101128@gmail.com", SenderEmail, SenderPass, fromname);
                        //string rtn3 = MailSender.SendIvitationMail(email_item.Name.Trim(), "vikaskumar@globussoft.com", SenderEmail, SenderPass, fromname);

                        //string rtn = null;
                        if (rtn != null)
                        {
                            try
                            {
                                Console.WriteLine("<----------------------------------------------------------------->");
                                Console.WriteLine("<-------Mail Send to:" + email_item.Email + " By " + fromname + "--------->");
                                Console.WriteLine("<----------------------------------------------------------------->");
                                string[] mailinfo = Regex.Split(rtn, "####");

                                #region status set to 1 after success
                                ValidIds.Add(email_item.Id);
                                //mantaemailrepo.UpdateStatus(email_item.Id);
                                #endregion

                                #region Increase the total no of mail sent from a mandrill account
                                mandrillACC.Total = mandrillACC.Total + 1;
                                mandrillRepo.UpdateMandrillAccount(mandrillACC.Id, mandrillACC.Total);
                                #endregion

                                //#region Insert Record after success
                                //Invitation invite = new Invitation();
                                //invite.InvitationBody = mailinfo[0];
                                //invite.Subject = mailinfo[1];
                                //invite.SenderName = "";
                                //invite.FriendEmail = mailinfo[4];
                                //invite.SenderEmail = mailinfo[3];
                                //invite.FriendName = mailinfo[2];
                                //invite.Status = "1";
                                //invite.SaveDate = DateTime.Now;
                                //invite.MandrillSendDate = DateTime.Now;
                                //invite.MandrillId = mandrillACC.Id;
                                //invitationRepo.Add(invite);
                                //#endregion

                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.StackTrace);
                            }
                        }
                        else
                        {
                            Console.WriteLine("<------------------------------------------------->");
                            Console.WriteLine("<-------Mail Failled to:" + email_item.Email + "--------->");
                            Console.WriteLine("<------------------------------------------------->");
                            InvalidIds.Add(email_item.Id);
                        }
                        p++;
                        if (p >= allmandrillACC.Count())
                        {
                            p = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            mantaemailrepo.UpdateStatusIsValid(InvalidIds);
            mantaemailrepo.UpdateStatusBulk(ValidIds);
        }
       // ------------ For New Template--------------------// 
        public void StartMailSendingForNew()
        {
            Console.WriteLine("<------------------------------------------------->");
            Console.WriteLine("<---------Start SocioQueu Mail Sending ---------->");
            Console.WriteLine("<------------------------------------------------->");
            MandrillaccountRepository mandrillRepoNew = new MandrillaccountRepository();
            MantaemailRepository mantaemailrepoNew = new MantaemailRepository();
            List<Mandrillaccount> allmandrillACCNew = mandrillRepoNew.getAllMandrillData();
            for (int i = 1; i < 110000; i += 10000)
            {
                List<Mantaemail> objemaillistNew = mantaemailrepoNew.getAllCompanyDataNew(i);
                Thread SendInvitationMailForNew_thread = new Thread(() => SendInvitationMailForNew(objemaillistNew, allmandrillACCNew));
                SendInvitationMailForNew_thread.Start();
                //SendInvitationMailForNew(objemaillistNew, allmandrillACCNew);

            }
        }

        void SendInvitationMailForNew(List<Mantaemail> objemaillist, List<Mandrillaccount> allmandrillACC)
        {
            MantaemailRepository mantaemailrepo = new MantaemailRepository();
            MandrillaccountRepository mandrillRepo = new MandrillaccountRepository();
            //InvitationRepository invitationRepo = new InvitationRepository();
            List<int> ValidIds = new List<int>();
            List<int> InvalidIds = new List<int>();
            int p = 0;
            try
            {
                foreach (Mantaemail email_item in objemaillist)
                {
                    try
                    {
                        Mandrillaccount mandrillACC = allmandrillACC[p];
                        string SenderEmail = mandrillACC.UserName;
                        string SenderPass = mandrillACC.Password;
                        string fromname = RandomNameGenerator.CreateName().ToLower();
                        string[] name = Regex.Split(fromname, " ");
                        string fname = name[0].Substring(0, 1).ToUpper() + name[0].Substring(1, name[0].Length - 1);
                        string lname = name[1].Substring(0, 1).ToUpper() + name[1].Substring(1, name[1].Length - 1);
                        fromname = fname + " " + lname;
                        string rtn = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), email_item.Email.Trim(), SenderEmail, SenderPass, fromname);
                        //string rtn4 = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), "indianbill007@gmail.com", SenderEmail, SenderPass,fromname);
                        //string rtn1 = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), "pgcoding@yahoo.co.in", SenderEmail, SenderPass,fromname);
                        //string rtn2 = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), "sumit@globussoft.com", SenderEmail, SenderPass, fromname);
                        //string rtn4 = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), "cs101128@gmail.com", SenderEmail, SenderPass, fromname);
                        //string rtn3 = MailSender.SendIvitationMailForNew(email_item.Name.Trim(), "vikaskumar@globussoft.com", SenderEmail, SenderPass, fromname);

                        //string rtn = null;
                        if (rtn != null)
                        {
                            try
                            {
                                Console.WriteLine("<----------------------------------------------------------------->");
                                Console.WriteLine("<-------Mail Send to:" + email_item.Email + " By " + fromname + "--------->");
                                Console.WriteLine("<----------------------------------------------------------------->");
                                string[] mailinfo = Regex.Split(rtn, "####");

                                #region status set to 2 after success
                                ValidIds.Add(email_item.Id);
                                //mantaemailrepo.UpdateStatus2(email_item.Id);
                                #endregion

                                #region Increase the total no of mail sent from a mandrill account
                                mandrillACC.Total = mandrillACC.Total + 1;
                                mandrillRepo.UpdateMandrillAccount(mandrillACC.Id, mandrillACC.Total);
                                #endregion

                                //#region Insert Record after success
                                //Invitation invite = new Invitation();
                                //invite.InvitationBody = mailinfo[0];
                                //invite.Subject = mailinfo[1];
                                //invite.SenderName = "";
                                //invite.FriendEmail = mailinfo[4];
                                //invite.SenderEmail = mailinfo[3];
                                //invite.FriendName = mailinfo[2];
                                //invite.Status = "2";
                                //invite.SaveDate = DateTime.Now;
                                //invite.MandrillSendDate = DateTime.Now;
                                //invite.MandrillId = mandrillACC.Id;
                                //invitationRepo.Add(invite);
                                //#endregion

                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.StackTrace);
                            }
                        }
                        else
                        {
                            Console.WriteLine("<------------------------------------------------->");
                            Console.WriteLine("<-------Mail Failled to:" + email_item.Email + "--------->");
                            Console.WriteLine("<------------------------------------------------->");
                            InvalidIds.Add(email_item.Id);
                        }
                        p++;
                        if (p >= allmandrillACC.Count())
                        {
                            p = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            mantaemailrepo.UpdateStatusIsValid(InvalidIds);
            mantaemailrepo.UpdateStatus2Bulk(ValidIds);
        }

        public void GetMaindrillAccountInfo()
        {
            MandrillaccountRepository mandrillRepo = new MandrillaccountRepository();
            MantaemailRepository mantaemailrepo = new MantaemailRepository();
            //List<Mandrillaccount> allmandrillACC = mandrillRepo.getAllMandrillData();
            for (int i = 0; i < 44; i+=11 )
            {
                List<Mandrillaccount> allmandrillACC = mandrillRepo.GetAllMandrillData(i);
                Thread UpdateMandrillAccountInfo_Thread = new Thread(() => UpdateMandrillAccountInfo(allmandrillACC));
                UpdateMandrillAccountInfo_Thread.Start();
                //UpdateMandrillAccountInfo(allmandrillACC);
            }
                
        }

        void UpdateMandrillAccountInfo(List<Mandrillaccount> allmandrillACC)
        {
            MantaemailRepository mantaemailrepo = new MantaemailRepository();
            List<string> lstBounceEmails = new List<string>();
            List<string> lstSpamEmails = new List<string>();
            foreach(Mandrillaccount email_item in allmandrillACC)
            {
                try
                {
                    string url = clsGetRejectedEmail.GetUrlToGetBounces(email_item.Password);
                    string emailinfo = clsGetRejectedEmail.WebRequestForMandrill(url);
                    Console.WriteLine("Get Mandrill Account Info For " + email_item.UserName);
                    JArray JData = JArray.Parse(emailinfo);
                    foreach (var j_item in JData)
                    {
                        string reason = j_item["reason"].ToString();
                        string email = j_item["email"].ToString();
                        if (reason.Trim().Contains("bounce"))
                        {
                            lstBounceEmails.Add(email);
                            //mantaemailrepo.UpdateBounce(email.Trim());
                        }
                        else if (reason.Trim().Contains("spam"))
                        {
                            lstSpamEmails.Add(email);
                            //mantaemailrepo.UpdateSpam(email.Trim());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            mantaemailrepo.UpdateBounceBulk(lstBounceEmails);
            Console.WriteLine("UpdateBounceBulk");
            mantaemailrepo.UpdateSpamBulk(lstSpamEmails);
            Console.WriteLine("UpdateSpamBulk");
        }

        public void GetClicksForMandrillAccount()
        {
            try
            {
                MandrillaccountRepository mandrillRepo = new MandrillaccountRepository();
                List<Mandrillaccount> lstMandrillaccount = mandrillRepo.getAllMandrillData();
                foreach (Mandrillaccount item in lstMandrillaccount)
                {
                    try
                    {
                        string url = clsGetRejectedEmail.GetUrlToGetClicks(item.Password);
                        string mandrillaccinfo = clsGetRejectedEmail.WebRequestForMandrill(url);
                        JArray JData = JArray.Parse(mandrillaccinfo);
                        foreach (var mail_item in JData)
                        {
                            try
                            {
                                string email = mail_item["address"].ToString().Replace("\"", "");
                                if (email == item.UserName)
                                {
                                    string sent = mail_item["sent"].ToString();
                                    string opens = mail_item["opens"].ToString();
                                    string clicks = mail_item["clicks"].ToString();
                                    mandrillRepo.UpdateOpenandClicks(sent, opens, clicks, email);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.StackTrace);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
        }

    }
}
