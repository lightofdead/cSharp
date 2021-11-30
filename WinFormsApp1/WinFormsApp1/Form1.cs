using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if(label1.Text == "Right")
                {
                    label1.Text = "Left";
                    label1.TextAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    label1.Text = "Right";
                    label1.TextAlign = ContentAlignment.MiddleRight;
                }
            }
            else
            {
                label1.Text = "Text changing is disabled";
                label1.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
