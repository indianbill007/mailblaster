using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocioBoardInvitationMailSender.Domain;
using SocioBoardInvitationMailSender;

namespace SocioBoardInvitationMailSender.Model
{
    class InvitationRepository
    {
        public void Add(Invitation invitation)
        {
            try
            {
                //Creates a database connection and opens up a session
                using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
                {
                    //After Session creation, start Transaction. 
                    using (NHibernate.ITransaction transaction = session.BeginTransaction())
                    {
                        //Proceed action to save data.
                        session.Save(invitation);
                        transaction.Commit();

                    }//End Using trasaction
                }//End Using session
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

            }
        }


        public bool IsEmailExist(string Emailid)
        {
            try
            {
                //Creates a database connection and opens up a session
                using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
                {
                    //After Session creation, start Transaction. 
                    using (NHibernate.ITransaction transaction = session.BeginTransaction())
                    {
                        NHibernate.IQuery query = session.CreateQuery("from  Invitation u where u.FriendEmail = : email");
                        query.SetParameter("email", Emailid);
                        var result = query.UniqueResult();
                        if (result == null)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }//End Using trasaction
                }//End Using session
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public int GetTodayMailCount()
        {
            try
            {
                //Creates a database connection and opens up a session
                using (NHibernate.ISession session = SocioBoardInvitationMailSenderSessionFactory.GetNewSession())
                {
                    //After Session creation, start Transaction. 
                    using (NHibernate.ITransaction transaction = session.BeginTransaction())
                    {

                        List<Invitation> maildata = session.CreateQuery("from Invitation")
                            .List<Invitation>().ToList<Invitation>().Where(d => d.MandrillSendDate.Date==DateTime.Now.Date).ToList<Invitation>();
                        return maildata.Count;
                    }//End Using trasaction
                }//End Using session
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return 0;
            }
        }

    }
}
