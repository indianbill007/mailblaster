using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocioBoardInvitationMailSender.Domain;

namespace SocioBoardInvitationMailSender.Model
{
    class MandrillaccountRepository
    {
        public List<Mandrillaccount> getAllMandrillData()
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
                        List<Mandrillaccount> alsdata = session.CreateQuery("from Mandrillaccount")
                            .List<Mandrillaccount>()
                            .ToList<Mandrillaccount>();
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

        public void UpdateMandrillAccount(int id,int total)
        {
            //Creates a database connection and opens up a session
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //Begin session trasaction and opens up.
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.CreateQuery("Update Mandrillaccount set Total =:total where Id =:id")
                            .SetParameter("total", total)
                            .SetParameter("id", id)
                            .ExecuteUpdate();
                        transaction.Commit();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        // return 0;
                    }
                }//End Trasaction
            }//End session
        }

        public List<Mandrillaccount> GetAllMandrillData(int count)
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
                        List<Mandrillaccount> alsdata = session.CreateQuery("from Mandrillaccount")
                            .SetFirstResult(count)
                            .SetMaxResults(11)
                            .List<Mandrillaccount>()
                            .ToList<Mandrillaccount>();
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

        public void UpdateOpenandClicks(string Sent, string Opens, string Clicks, string email)
        {
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //Begin session trasaction and opens up.
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        int i = session.CreateQuery("Update Mandrillaccount set Sent =:sent, Opens =: opens, Clicks =: clicks where UserName =:email")
                            .SetParameter("email", email)
                            .SetParameter("opens", Opens)
                            .SetParameter("clicks",Clicks)
                            .SetParameter("sent",Sent)
                            .ExecuteUpdate();
                        transaction.Commit();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        // return 0;
                    }
                }//End Trasaction
            }//End session
        }


    }
}
