using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace K181169_Q2
{
    public partial class Form2 : Form
    {
        private string sid;
        public Form2(string station_id)
        {
            InitializeComponent();
            sid = station_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path2 = ConfigurationManager.AppSettings["Path2"];
            string path4 = ConfigurationManager.AppSettings["Path4"];

            try
            {
                bool votes_done = false;

                if (File.Exists(path2))
                {
                    string readText = File.ReadAllText(path2);
                    string CNIC = cnic.Text;

                    if (File.Exists(path4))
                    {
                        string readText2 = File.ReadAllText(path4);
                        string[] arr = readText2.Split("\r\n");
                        int j = 0;

                        while (j < arr.Length && !votes_done)
                        {
                            if (arr[j] == CNIC)
                            {
                                votes_done = true;
                            }
                            j++;
                        }
                    }

                    if (!votes_done)
                    {
                        string[] a = readText.Split("\r\n");
                        int i = 0;
                        bool cnicfound = false;

                        while (i < a.Length && !cnicfound)
                        {
                            string[] b = a[i].Split(", ");

                            if (b[2] == CNIC)
                            {
                                cnicfound = true;
                                MessageBox.Show("Verified");
                                var Form3 = new Form3(CNIC, sid);
                                Form3.Show();
                                this.Hide();
                            }
                            i++;
                        }
                        if (!cnicfound)
                        {
                            MessageBox.Show("This CNIC invalid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your vote is done");
                    }

                }
            }
            catch(Exception)
            {
                MessageBox.Show("The Voter's List File not exist");
                return;
            }
            
        }
    }
}
