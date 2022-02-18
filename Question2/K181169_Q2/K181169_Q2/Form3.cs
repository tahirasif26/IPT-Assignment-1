using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace K181169_Q2
{
    public class Candidate_List
    {
        public string cand_id,cand_name,position;

        public Candidate_List(string cid,string name,string pos)
        {
            cand_id = cid;
            cand_name = name;
            position = pos;
        }
    }

    public partial class Form3 : Form
    {
        private string cnic=null, stat_id=null;
        List<Candidate_List> cand_list_of_pre = new List<Candidate_List>();
        List<Candidate_List> cand_list_of_vpre = new List<Candidate_List>();
        List<Candidate_List> cand_list_of_gensec = new List<Candidate_List>();
        public Form3(string CNIC,string sid)
        {
            InitializeComponent();
            cnic = CNIC;
            stat_id = sid;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                string path3 = ConfigurationManager.AppSettings["Path3"];

                if (File.Exists(path3))
                {
                    string readText = File.ReadAllText(path3);

                    string[] a = readText.Split("\r\n");
                    int i = 0;

                    while (i < a.Length)
                    {
                        string[] b = a[i].Split(", ");

                        if (b[2] == "President")
                        {
                            Candidate_List listofcandidates = new Candidate_List(b[0], b[1], b[2]);
                            cand_list_of_pre.Add(listofcandidates);
                            pre.Items.Add(b[1]);
                        }
                        if (b[2] == "Vice President")
                        {
                            Candidate_List listofcandidates = new Candidate_List(b[0], b[1], b[2]);
                            cand_list_of_vpre.Add(listofcandidates);
                            vpre.Items.Add(b[1]);
                        }
                        if (b[2] == "General Secretary")
                        {
                            Candidate_List listofcandidates = new Candidate_List(b[0], b[1], b[2]);
                            cand_list_of_gensec.Add(listofcandidates);
                            gen_sec.Items.Add(b[1]);
                        }
                        i++;
                    }

                }
                else
                {
                    MessageBox.Show("The Candidates List File not exist");
                }
            }
            catch(Exception)
            {
                Console.Write("Something went wrong, Please try again.");
                return;
            }
             
            
        }

        public void xml_filing(string c, string p, string id)
        {
            try
            {
                string newfile = ConfigurationManager.AppSettings["Path5"] + stat_id + "_" + DateTime.Now.ToString("ddMMMyy") + "_" + DateTime.Now.ToString("hh00") + ".xml";
                if (!File.Exists(newfile))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;
                    xmlWriterSettings.NewLineOnAttributes = true;
                    using (XmlWriter writer = XmlWriter.Create(newfile, xmlWriterSettings))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Votes");
                        writer.WriteStartElement("Vote");
                        writer.WriteElementString("CNIC", c);
                        writer.WriteElementString("Position", p);
                        writer.WriteElementString("Candidate_ID", id);
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
                else
                {
                    XDocument xDocument = XDocument.Load(newfile);
                    XElement root = xDocument.Element("Votes");
                    IEnumerable<XElement> rows = root.Descendants("Vote");
                    XElement firstRow = rows.First();
                    firstRow.AddAfterSelf(
                       new XElement("Vote",
                       new XElement("CNIC", c),
                       new XElement("Position", p),
                       new XElement("Candidate_ID", id)));
                    xDocument.Save(newfile);
                }
            }
            catch (Exception)
            {
                Console.Write("Something went wrong, Please try again.");
                return;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pre.Text == "" && vpre.Text == "" && gen_sec.Text == "")
                {
                    MessageBox.Show("Please select any one of the above.");
                }
                else
                {
                    
                    if (pre.Text != "")
                    {
                        xml_filing(cnic, "President", cand_list_of_pre[pre.SelectedIndex].cand_id);
                    }
                    if (vpre.Text != "")
                    {
                        xml_filing(cnic, "Vice President", cand_list_of_vpre[vpre.SelectedIndex].cand_id);
                    }
                    if (gen_sec.Text != "")
                    {
                        xml_filing(cnic, "General Sercertary", cand_list_of_gensec[gen_sec.SelectedIndex].cand_id);
                    }
                   
                    string path4 = ConfigurationManager.AppSettings["Path4"];

                    using (StreamWriter write = new StreamWriter(path4, true))
                    {
                        write.WriteLine(cnic);
                        write.Close();
                    }
                    this.Hide();
                }
            }
            catch (Exception)
            {
                Console.Write("Something went wrong, Please try again.");
                return;
            }

            
        }


    }
}
