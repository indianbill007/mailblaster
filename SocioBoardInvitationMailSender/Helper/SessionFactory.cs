using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SocioBoardInvitationMailSender
{
    class SocioBoardInvitationMailSenderSessionFactory
    {
        public static NHibernate.ISessionFactory sFactory;
        public static string configfilepath { get; set; }
        public static void Init()
        {
            try
            {
                NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration();
                string path = string.Empty;
                if (string.IsNullOrEmpty(configfilepath))
                {
                    path = HttpContext.Current.Server.MapPath("~/hibernate.cfg.xml");
                }
                else
                {
                    path = configfilepath;
                }
                config.Configure(path);
                config.AddAssembly("SocioBoardInvitationMailSender");//adds all the embedded resources .hbm.xml
                sFactory = config.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.StackTrace);
            }
        }

        public static NHibernate.ISessionFactory GetSessionFactory()
        {
            if (sFactory == null)
            {
                Init();
            }
            return sFactory;

        }

        public static NHibernate.ISession GetNewSession()
        {

            return GetSessionFactory().OpenSession();
        }

    }
}
