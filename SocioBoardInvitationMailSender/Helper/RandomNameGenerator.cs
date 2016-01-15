using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocioBoardInvitationMailSender.Helper
{
    class RandomNameGenerator
    {
        public static string CreateName()
        {
            string firstname = "";
            string secondname = "";
            string Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string Path = "C:\\Users\\SUMIT\\Desktop\\vikash\\SocioBoardInvitationMailSender";
            RandomStringGenerator objRandomGenrator = new RandomStringGenerator();
            firstname = objRandomGenrator.txtreader(Path + "\\" + "US_Male_FirstName.txt");
            secondname = objRandomGenrator.txtreader(Path + "\\" + "US_SecondName.txt");
            return firstname + " " + secondname;
        }
    }
}
