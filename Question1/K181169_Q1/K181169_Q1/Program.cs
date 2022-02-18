using System;
using System.IO;
using System.Configuration;

namespace K181169_Q1
{
    class Person_data
    {

        public static string strencode(string password)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public static string concatenate(string username, string encodepassword, string station_id)
        {
            string output = username + "," + encodepassword + "," + station_id;
            return output;
        }

        public static void check_sid(string sid, string res, string path, bool duplication_exist)
        {
            if (sid == "210001" || sid == "210002")
            {
                if (!duplication_exist)
                {
                    using (StreamWriter write = new StreamWriter(path, true))
                    {
                        write.WriteLine(res);
                        write.Close();
                    }
                }
                else
                {
                    Console.Write("user exist");
                }

            }
            else
            {
                Console.Write("station_id not valid");
            }
        }


        public static void hello(string username, string sid, string user_data)
        {
            string path = ConfigurationManager.AppSettings["Path"];
            bool duplication_exist = false;

            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);

                string[] a = readText.Split("\r\n");
                int i = 0;

                while (i < a.Length && !duplication_exist)
                {
                    string[] b = a[i].Split(",");
                    if (b[0] == username && b[0].Length == username.Length)
                    {
                        duplication_exist = true;
                    }
                    i++;
                }

                check_sid(sid, user_data, path, duplication_exist);
            }
            else
            {
                check_sid(sid, user_data, path, duplication_exist);
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 3)
                {
                    Console.Write("The arguments not complete.");
                }
                else
                {

                    string encodepassword = Person_data.strencode(args[1]);

                    string user_info = Person_data.concatenate(args[0], encodepassword, args[2]);

                    Person_data.hello(args[0], args[2], user_info);
                }
            }
            catch (Exception e)
            {
                Console.Write("Something went wrong, Please try again");
            }
            
        }
    }

}
