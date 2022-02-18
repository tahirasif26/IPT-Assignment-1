using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Configuration;

namespace K181169_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                string[] dirs = Directory.GetFiles(@"C:\IPT_Assignment1\Question2", "AA*");

                string file_210001 = ConfigurationManager.AppSettings["Path1"] + "210001" + "_" + DateTime.Now.ToString("ddMMMyy") + ".xml";
                string file_210002 = ConfigurationManager.AppSettings["Path2"] + "210002" + "_" + DateTime.Now.ToString("ddMMMyy") + ".xml";
                string merged_files = ConfigurationManager.AppSettings["Path3"];

                foreach (string dir in dirs)
                {
                    bool filenot_found = false;

                    if (File.Exists(merged_files))
                    {
                        string readText = File.ReadAllText(merged_files);
                        string[] a = readText.Split("\r\n");
                        int i = 0;

                        while (i < a.Length && !filenot_found)
                        {
                            if (dir == a[i])
                            {
                                filenot_found = true;
                            }
                            i++;
                        }
                    }
                    if(!filenot_found)
                    {
                        
                        if (dir.Contains("210001" + "_" + DateTime.Now.ToString("ddMMMyy")))
                        {
                            if (!File.Exists(file_210001))
                            {
                                XDocument doc = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                new XElement("Votes"));
                                doc.Save(file_210001);
                            }

                            XDocument q2_xml= XDocument.Load(dir);

                            foreach (XElement e in q2_xml.Descendants("Vote"))
                            {
                                XDocument q3_xml = XDocument.Load(file_210001);
                                XElement xele = new XElement(e);
                                q3_xml.Root.Add(xele);
                                q3_xml.Save(file_210001);
                            }

                            using (StreamWriter write = new StreamWriter(merged_files, true))
                            {
                                write.WriteLine(dir);
                                write.Close();
                            }
                        }
                        if (dir.Contains("210002" + "_" + DateTime.Now.ToString("ddMMMyy")))
                        {
                            if (!File.Exists(file_210002))
                            {
                                XDocument doc = new XDocument(
                                new XDeclaration("1.0", "utf-8", "yes"),
                                new XElement("Votes"));
                                doc.Save(file_210002);
                            }

                            XDocument q2_xml = XDocument.Load(dir);

                            foreach (XElement e in q2_xml.Descendants("Vote"))
                            {
                                XDocument q3_xml = XDocument.Load(file_210002);
                                XElement xele = new XElement(e);
                                q3_xml.Root.Add(xele);
                                q3_xml.Save(file_210002);
                            }

                            using (StreamWriter write = new StreamWriter(merged_files, true))
                            {
                                write.WriteLine(dir);
                                write.Close();
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, Please try again");
                return;
            }
        }
    }
}
