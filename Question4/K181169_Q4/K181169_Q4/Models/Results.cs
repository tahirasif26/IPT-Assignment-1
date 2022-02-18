using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Xml;

namespace K181169_Q4.Models
{
    public class Results
    {
        public Dictionary<string, int> cand_list_of_pre = new Dictionary<string, int>();
        public Dictionary<string, int> cand_list_of_vpre = new Dictionary<string, int>();
        public Dictionary<string, int> cand_list_of_gensec = new Dictionary<string, int>();

        public Dictionary<string, int> pre = new Dictionary<string, int>();
        public Dictionary<string, int> vpre = new Dictionary<string, int>();
        public Dictionary<string, int> gensec = new Dictionary<string, int>();

        public string cand_list = WebConfigurationManager.AppSettings["Path1"];
        public void readfile() 
        {
            if (File.Exists(cand_list))
            {
                string[] a = File.ReadAllLines(cand_list);

                int i = 0;

                while (i < a.Length)
                {
                    string[] b = a[i].Split(',');

                    if (b[2] == " President")
                    {
                        cand_list_of_pre.Add(b[0], 0);
                    }
                    else if (b[2] == " Vice President")
                    {
                        cand_list_of_vpre.Add(b[0], 0);
                    }
                    else if (b[2] == " General Secretary")
                    {
                        cand_list_of_gensec.Add(b[0], 0);
                    }
                    i++;
                }

            }
            else
            {
                Console.Write("The Candidates List File not exist");
            }
        }
        
        public void count_votes()
        {
            string[] dirs = Directory.GetFiles(@"C:\IPT_Assignment1\Question3", "AA*");

            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
                XmlDocument q3xml = new XmlDocument();
                q3xml.Load(dir);

                foreach (XmlNode node in q3xml.SelectNodes("/Votes/Vote"))
                {
                    if (node["Position"].InnerText == "President")
                    {
                        ++cand_list_of_pre[node["Candidate_ID"].InnerText];
                    }
                    else if (node["Position"].InnerText == "Vice President")
                    {
                        ++cand_list_of_vpre[node["Candidate_ID"].InnerText];
                    }
                    else if (node["Position"].InnerText == "General Sercertary")
                    {
                        ++cand_list_of_gensec[node["Candidate_ID"].InnerText];
                    }

                }

            }


        }

        public void get_names()
        {

            if (File.Exists(cand_list))
            {
                string[] a = File.ReadAllLines(cand_list);
                
                int i = 0;

                while (i < a.Length)
                {
                    string[] b = a[i].Split(',');

                    if (b[2] == " President")
                    {
                        foreach (KeyValuePair<string, int> p in cand_list_of_pre)
                        {
                            if (b[0] == p.Key)
                            {
                                pre.Add(b[1], p.Value);
                            }
                        }
                    }
                    else if (b[2] == " Vice President")
                    {
                        foreach (KeyValuePair<string, int> vp in cand_list_of_vpre)
                        {
                            if (b[0] == vp.Key)
                            {
                                vpre.Add(b[1], vp.Value);
                            }
                        }
                    }
                    else if (b[2] == " General Secretary")
                    {
                        foreach (KeyValuePair<string, int> gs in cand_list_of_gensec)
                        {
                            if (b[0] == gs.Key)
                            {
                                gensec.Add(b[1], gs.Value);
                            }
                        }
                    }
                    i++;
                }

            }
            
        }


    }
}