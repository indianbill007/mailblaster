using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocioBoardInvitationMailSender.Domain;

namespace SocioBoardInvitationMailSender.Model
{
    class MantaemailRepository
    {
        public List<Mantaemail> getAllCompanyData(int count)
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
                        List<Mantaemail> alsdata = session.CreateQuery("from Mantaemail where Status!=1 and Status!=2")
                            .SetFirstResult(count)
                            .SetMaxResults(10000)
                            .List<Mantaemail>()
                            .ToList<Mantaemail>().Where(e => e.Email != "").Where(a => a.Email != "NA").ToList<Mantaemail>();
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

        public void UpdateStatus(int id)
        {
            //Creates a database connection and opens up a session
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //Begin session trasaction and opens up.
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.CreateQuery("Update Mantaemail set Status =1 where Id =:id")
                            .SetParameter("id",id)
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

        public void UpdateStatusBulk(List<int> ids)
        {
            //Creates a database connection and opens up a session
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //Begin session trasaction and opens up.
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        string str = "Update Mantaemail set Status =1 where Id IN(";
                        foreach (int id in ids)
                        {
                            str += id + ",";
                        }
                        str = str.Substring(0, str.Length - 1);
                        str += ")";
                        int i = session.CreateQuery(str)
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

        public List<Mantaemail> getAllCompanyDataNew(int count)
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
                        List<Mantaemail> alsdata = session.CreateQuery("from Mantaemail where Status = 1 and Bounce = 0 and Spam = 0 and IsInvalid=0") 
                            .SetFirstResult(count)
                            .SetMaxResults(10000)
                            .List<Mantaemail>()
                            .ToList<Mantaemail>();
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

        public void UpdateStatus2(int id)
         {
             //Creates a database connection and opens up a session
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         session.CreateQuery("Update Mantaemail set Status =2 where Id =:id")
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

        public void UpdateStatus2Bulk(List<int> ids)
         {
             //Creates a database connection and opens up a session
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         string str = "Update Mantaemail set Status =2 where Id IN(";
                         foreach (int id in ids)
                         {
                             str += id + ",";
                         }
                         str = str.Substring(0,str.Length-1);
                         str += ")";
                        int i = session.CreateQuery(str)
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

        public void UpdateBounce(string email)
         {
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         session.CreateQuery("Update Mantaemail set Bounce =1 where Email =:Email")
                             .SetParameter("Email", email)
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

        public void UpdateSpam(string email)
         {
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         session.CreateQuery("Update Mantaemail set Spam =1 where Email =:Email")
                             .SetParameter("Email", email)
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

        public void UpdateBounceBulk(List<string> emails)
         {
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         string str="Update Mantaemail set Bounce =1 where Email IN(";
                         foreach(string email in emails)
                         {
                             str+="'" + email + "',";
                         }
                         str = str.Substring(0,str.Length-1);
                         str += ")";
                         int i= session.CreateQuery(str)
                                .ExecuteUpdate();
                         transaction.Commit();
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.StackTrace);
                     }
                 }//End Trasaction
             }//End session
         }

        public void UpdateSpamBulk(List<string> emails)
         {
             using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
             {
                 //Begin session trasaction and opens up.
                 using (NHibernate.ITransaction transaction = session.BeginTransaction())
                 {
                     try
                     {
                         string str="Update Mantaemail set Spam =1 where Email IN(";
                         foreach(string email in emails)
                         {
                             str+="'"+email + "',";
                         }
                         str = str.Substring(0,str.Length-1);
                         str += ")";
                         int i = session.CreateQuery(str)
                                .ExecuteUpdate();
                         transaction.Commit();
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.StackTrace);
                     }
                 }//End Trasaction
             }//End session
         }

        public void UpdateStatusIsValid(List<int> ids)
        {
            //Creates a database connection and opens up a session
            using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
            {
                //Begin session trasaction and opens up.
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        string str = "Update Mantaemail set IsInvalid =1 where Id IN(";
                        foreach (int id in ids)
                        {
                            str += id + ",";
                        }
                        str = str.Substring(0, str.Length - 1);
                        str += ")";
                        int i = session.CreateQuery(str)
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
