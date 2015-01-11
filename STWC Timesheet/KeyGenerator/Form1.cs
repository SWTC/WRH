using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Management;

namespace KeyGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = GetCpuId();
            textBox3.Text = GetMacAddress();
        }


        #region Get Hardware Information

        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                macAddresses = nic.GetPhysicalAddress().ToString();
                break;
            }
            return macAddresses;
        }

        public static string GetCpuId()
        {
            string cpuid = null;
            try
            {
                ManagementObjectSearcher mo = new ManagementObjectSearcher("select * from Win32_Processor");
                foreach (var item in mo.Get())
                {
                    cpuid = item["ProcessorId"].ToString();
                }
                return cpuid;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                textBox4.Text = GenerateKey(textBox3.Text);
            }
            else
            {
                MessageBox.Show("Please enter your Name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string GenerateKey(string mac)
        {
            int sum = 0;
            int index = 1;
            foreach (char c in mac)
            {
                if (char.IsDigit(c))
                    sum = sum + Convert.ToInt32(c) * (index * 2);
                else
                {
                    switch (c)
                    { 
                        case 'A':
                            sum += sum + 10 * (index * 2);
                            break;
                        case 'B':
                            sum += sum + 11 * (index * 2);
                            break;
                        case 'C':
                            sum += sum + 12 * (index * 2);
                            break;
                        case 'D':
                            sum += sum + 13 * (index * 2);
                            break;
                        case 'E':
                            sum += sum + 14 * (index * 2);
                            break;
                        case 'F':
                            sum += sum + 15 * (index * 2);
                            break;
                    }
                }
                index++;
            }
            return sum.ToString();
        }
    }
}
