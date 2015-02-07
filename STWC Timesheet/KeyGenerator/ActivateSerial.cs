using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeyGenerator
{
    public partial class ActivateSerial : Form
    {
        public ActivateSerial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                try
                {
                    int x = Convert.ToInt32(textBox1.Text);
                    x = x * x + 53 / x + 113 * (x / 4);
                    textBox2.Text = x.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Serial Key");
                }
            }
            else
            {
                MessageBox.Show("Please enter Serial Key");
            }
        }
    }
}
