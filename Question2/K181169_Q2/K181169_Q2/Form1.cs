using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace K181169_Q2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string strdecode(string a)
        {
            var bytes = System.Convert.FromBase64String(a);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["Path1"];
            try
            {
                if (File.Exists(path))
                {
                    string readText = File.ReadAllText(path);
                    string username = name.Text;
                    string password = pass.Text;
                    string station_id;

                    string[] a = readText.Split("\r\n");
                    int i = 0;
                    bool userfound = false;

                    while (i < a.Length - 1 && !userfound)
                    {
                        string[] b = a[i].Split(",");
                        string decode_password = strdecode(b[1]);

                        if (b[0] == username && decode_password == password)
                        {
                            userfound = true;
                            station_id = b[2];
                            MessageBox.Show("Welcome to login");
                            var Form2 = new Form2(station_id);
                            Form2.Show();
                            this.Hide();
                        }
                        i++;
                    }
                    if (!userfound)
                    {
                        MessageBox.Show("Incorrect Username or Password");
                    }

                }
            }
            catch(Exception){ 
                MessageBox.Show("The File not exist");
                return;
            }
        }
    }
}
