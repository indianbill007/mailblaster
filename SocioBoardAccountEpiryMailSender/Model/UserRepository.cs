using SocioBoardAccountEpiryMailSender.Domain;
using SocioBoardAccountEpiryMailSender.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocioBoardAccountEpiryMailSender.Model
{
    public class UserRepository 
    {
        public List<User> GetAllExpiredUser()
        {
            //Creates a database connection and opens up a session
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //After Session creation, start Transaction. 
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    //Proceed action to get Archive messages
                    // And return list of archive messages.
                    try
                    {
                        List<User> alsdata = session.CreateQuery("from User")
                                        .List<User>()
                                        .ToList<User>()
                                        .Where(e => e.ExpiryDate.Date == DateTime.Now.Date)
                                        .ToList<User>();
                        return alsdata;

                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.StackTrace);
                        return null;
                    }
                }//End using transaction  
            }//Using using session
        }
    }
}