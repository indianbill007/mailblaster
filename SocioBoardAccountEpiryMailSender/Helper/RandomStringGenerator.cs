using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace SocioBoardAccountEpiryMailSender.Helper
{
    public class RandomStringGenerator
    {
        private const string _chars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";

        private const string _Numbers = "0123456789";

        private const string _Both = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int size)
        {
            Random _rng = new Random();

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

        public static string RandomNumber(int size)
        {
            Random _rng = new Random();

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _Numbers[_rng.Next(_Numbers.Length)];
            }
            return new string(buffer);
        }


        public static string RandomStringAndNumber(int size)
        {
            Random _rng = new Random();

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _Both[_rng.Next(_Both.Length)];
            }
            return new string(buffer);
        }

        string[] range_str = { "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789.", "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789_." };

        public string RandomPasswordAndAnswer()
        {
            Random random = new Random();
            int rand_len = random.Next(20, 23);
            int i, j;
            StringBuilder builder = new StringBuilder();
            for (i = 0; i < rand_len; i++)
            {
                j = random.Next(range_str[0].Length - 1);
                builder.Append(range_str[0][j]);
            }
            return builder.ToString();
        }

        public string AimRandomPasswordAndAnswer()
        {
            Random random = new Random();
            int rand_len = random.Next(10, 15);
            int i, j;
            StringBuilder builder = new StringBuilder();
            for (i = 0; i < rand_len; i++)
            {
                j = random.Next(range_str[0].Length - 1);
                builder.Append(range_str[0][j]);
            }
            return builder.ToString();
        }

        public string RandomYahooID()
        {
            Random random = new Random();
            int rand_len = random.Next(1, 3);
            int i, j;
            StringBuilder builder = new StringBuilder();
            j = random.Next(52);
            builder.Append(range_str[1][j]);
            for (i = 1; i < rand_len; i++)
            {
                j = random.Next(range_str[1].Length - 2);
                if (builder[i - 1] != '_' && builder[i - 1] != '.')
                    j = random.Next(range_str[1].Length - 1);
                if (builder[i - 1] != '_' && builder.ToString().Contains(".") == false)
                    j = random.Next(range_str[1].Length - 1);
                builder.Append(range_str[1][j]);
            }
            return builder.ToString();
        }

        public string txtreader(string FileName)
        {
            string[] res;
            if (File.Exists(FileName))
            {
                res = File.ReadAllLines(FileName);
                if (res.Length == 1)
                    return res[0];
                else
                {
                    Random r = new Random();
                    return res[r.Next(res.Length)];
                }
            }
            return null;
        }

        public int trial(string path)
        {
            int i;
            string a;
            if (File.Exists(path))
            {
                a = File.ReadAllText(path);
                i = int.Parse(a);
                if (i == 0) return i;
                i -= 1;
                File.WriteAllText(path, i.ToString());
            }
            else
            {
                i = 5;
                File.WriteAllText(path, "5");
            }
            return i;
        }

        //public List<string> DecaptchaDetail(string Path)
        //{
        //    List<string> tempAccounts = new List<string>();
        //    List<string> DecaptchaAccounts = new List<string>();

        //    tempAccounts = GlobusFileHelper.ReadFiletoStringList(Path);

        //    foreach (string AcctData in tempAccounts)
        //    {
        //        string[] tempArray = AcctData.Split(':');
        //        foreach (string accounts in tempAccounts)
        //        {
        //            DecaptchaAccounts.Add(accounts);
        //        }
        //        //DecaptchaHost = tempArray[0];
        //        //DecaptchaLogin = tempArray[1];
        //        //DecaptchaPassword = tempArray[2];
        //    }
        //    return DecaptchaAccounts;
        //}

        public static int GenerateRandom(int minValue, int maxValue)
        {
            if (minValue <= maxValue)
            {
                Random random = new Random();
                return random.Next(minValue, maxValue);
            }
            else
            {
                return 0;
            }
        }

        public static ArrayList RandomNumbers(int max)
        {
            // Create an ArrayList object that will hold the numbers
            ArrayList lstNumbers = new ArrayList();
            // The Random class will be used to generate numbers
            Random rndNumber = new Random();

            // Generate a random number between 1 and the Max
            int number = rndNumber.Next(1, max + 1);
            // Add this first random number to the list
            lstNumbers.Add(number);
            // Set a count of numbers to 0 to start
            int count = 0;

            do // Repeatedly...
            {
                // ... generate a random number between 1 and the Max
                number = rndNumber.Next(1, max + 1);

                // If the newly generated number in not yet in the list...
                if (!lstNumbers.Contains(number))
                {
                    // ... add it
                    lstNumbers.Add(number);
                }

                // Increase the count
                count++;
            } while (count <= 10 * max); // Do that again

            /////Casting from ArrayList to List<string>
            //List<int> randomNoList = new List<int>();
            //int[] tempArr = (int[])lstNumbers.ToArray();
            //randomNoList = tempArr.ToList();

            // Once the list is built, return it
            return lstNumbers;
        }

    }
}
